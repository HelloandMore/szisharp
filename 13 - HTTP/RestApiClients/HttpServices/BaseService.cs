namespace HttpServices;

public abstract class BaseService
{
    protected HttpClient httpClient;
    private static JsonSerializerOptions options;
    private const string baseURL = "";

    protected BaseService()
    {
        this.httpClient = new HttpClient();
        SetHeaders();
    }

    static BaseService()
    {
        options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
    }

    /// <summary>
    /// Creates a simple get request
    /// </summary>
    /// <typeparam name="TResponse">The return type</typeparam>
    /// <param name="route">The route part without the base url</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    protected async Task<TResponse> SendGetRequestAsync<TResponse>(string route)
    {
        try
        {
            var uri = BuildUri(route);

            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var content = await SerializeResponseAsync<TResponse>(response.Content);
            return content;
        }
        catch (Exception ex)
        {
            return (TResponse)default;
        }
    }

    /// <summary>
    /// Creates a simple get request with a url parameter
    /// </summary>
    /// <typeparam name="TResponse">The return type</typeparam>
    /// <param name="route">The route part without the base url</param>
    /// <param name="routParam">Rout parameter</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    protected async Task<TResponse> SendGetRequestAsync<TResponse>(string route, object routParam)
    {
        try
        {
            var uri = BuildUri(route, routParam);

            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var content = await SerializeResponseAsync<TResponse>(response.Content);
            return content;
        }
        catch (Exception ex)
        {
            return (TResponse)default;
        }
    }

    /// <summary>
    /// Creates a simple delete request
    /// </summary>
    /// <param name="route">The route part without the base url</param>
    /// <param name="routParam">Rout parameter</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    protected async Task SendDeleteRequestAsync(string route, object routParam)
    {
        var uri = BuildUri(route, routParam);

        var response = await httpClient.DeleteAsync(uri);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Sends a POST request to the specified route, containing the body serialized as a JSON in the request body
    /// </summary>
    /// <param name="route">The route part without the base url</param>
    /// <param name="body">The request body object</param>
    /// <returns></returns>
    protected async Task<bool> SendPostRequestAsync(string route, object body)
    {
        try
        {
            var request = BuildRequestMessage(HttpMethod.Post, route, body);

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    /// <summary>
    /// Sends a POST request to the specified route, containing the body serialized as a JSON in the request body
    /// </summary>
    /// <param name="route">The route part without the base url</param>
    /// <param name="body">The request body object</param>
    /// <returns></returns>
    protected async Task<TResponse> SendPostRequestAsync<TResponse>(string route, object body)
    {
        try
        {
            var request = BuildRequestMessage(HttpMethod.Post, route, body);

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await SerializeResponseAsync<TResponse>(response.Content);
            return content;
        }
        catch (Exception ex)
        {
            return (TResponse)default;
        }
    }

    /// <summary>
    /// Sends a PATCH request to the specified route, containing the body serialized as a JSON in the request body
    /// </summary>
    /// <param name="route">The route part without the base url</param>
    /// <param name="body">The request body object</param>
    /// <returns></returns>
    protected async Task<bool> SendPatchRequestAsync(string route)
    {
        try
        {
            var request = BuildRequestMessage(HttpMethod.Patch, route, null);

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response.StatusCode <= System.Net.HttpStatusCode.NoContent;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    /// <summary>
    /// Sends a PUT request to the specified route, containing the body serialized as a JSON in the request body
    /// </summary>
    /// <param name="route">The route part without the base url</param>
    /// <param name="body">The request body object</param>
    /// <returns></returns>
    protected async Task SendPutRequestAsync(string route, object body)
    {
        var request = BuildRequestMessage(HttpMethod.Put, route, body);

        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Sends a PATCH request to the specified route, containing the body serialized as a JSON in the request body
    /// </summary>
    /// <param name="route">The route part without the base url</param>
    /// <param name="body">The request body object</param>
    /// <returns></returns>
    protected async Task<TResponse> SendPatchRequestAsync<TResponse>(string route, object body)
    {
        try
        {
            var request = BuildRequestMessage(HttpMethod.Patch, route, body);

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await SerializeResponseAsync<TResponse>(response.Content);
            return content;
        }
        catch (Exception ex)
        {
            return (TResponse)default;
        }
    }

    /// <summary>
    /// Sends a PATCH request to the specified route, containing the body serialized as a JSON in the request body
    /// </summary>
    /// <param name="route">The route part without the base url</param>
    /// <param name="body">The request body object</param>
    /// <returns></returns>
    protected async Task<bool> SendPatchRequestAsync(string route, object body)
    {
        var request = BuildRequestMessage(HttpMethod.Patch, route, body);

        var response = await httpClient.SendAsync(request);

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error: {error}");
        }

        return true;
    }

    /// <summary>
    /// Uploads a file to the provided url
    /// </summary>
    /// <param name="url">The URL of the server</param>
    /// <param name="streamContent">Stream content of the file to be uploaded</param>
    /// <returns></returns>
    protected async Task<bool> UploadFileAsync(string url, StreamContent streamContent)
    {
        this.httpClient.DefaultRequestHeaders.Clear();
        var response = await httpClient.PutAsync(url, streamContent);

        return response.IsSuccessStatusCode;
    }

    private void SetHeaders()
    {
        this.httpClient.BaseAddress ??= new Uri(baseURL);

        if (!httpClient.DefaultRequestHeaders.Any())
        {
            this.httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            this.httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");

            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("plain/text"));
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }

    private HttpRequestMessage BuildRequestMessage(HttpMethod httpMethod, string route, object body)
    {
        return new HttpRequestMessage
        {
            Method = httpMethod,
            RequestUri = BuildUri(route),
            Content = body is not null ?
                      new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, MediaTypeNames.Application.Json) :
                      null
        };
    }

    private Uri BuildUri(string route) => new Uri($"{baseURL}/{route}");

    private Uri BuildUri(string route, object routParam) => new Uri($"{baseURL}/{route}/{routParam}");

    protected virtual async Task<T> SerializeResponseAsync<T>(HttpContent content)
    {
        var encoding = content.Headers.ContentEncoding.FirstOrDefault();
        var responseStream = await content.ReadAsStreamAsync();
        var stream = encoding switch
        {
            "gzip" => new GZipStream(responseStream, CompressionMode.Decompress),
            "deflate" => new DeflateStream(responseStream, CompressionMode.Decompress),
            "br" => new BrotliStream(responseStream, CompressionMode.Decompress),
            _ => responseStream

        };

        var result = JsonSerializer.Deserialize<T>(stream, options);
        return result;
    }
}
