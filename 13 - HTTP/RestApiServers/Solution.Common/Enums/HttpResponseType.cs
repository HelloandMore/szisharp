namespace Solution.Common.Enums;

/// <summary>
/// HTTP response status codes:
///1XX Codes: Informational codes.Rarely used in modern web apps.
///2XX Codes: Success codes. Tells the client that the request succeeded.
///3XX Codes: Redirect codes. Tells the client that they may need to redirect to another location.
///4XX Codes: Client Error codes.Tells the client that something was wrong with what it sent to the server.
///5XX Codes: Server Error codes.Tells the client that something went wrong on the server's side, so that the client may attempt the request again, possibly at a later time.
/// </summary>
public enum HttpResponseType
{
    /// <summary>
    /// Accepted indicates that the request has been accepted for further processing.
    /// </summary>
    Accepted = 200,

    /// <summary>
    /// Ambiguous indicates that the requested information has multiple representations. The default action is to treat this status as a redirect and follow the contents of the Location header associated with this response.
    /// </summary>
    Ambiguous = 300,

    /// <summary>
    /// BadGateway indicates that an intermediate proxy server received a bad response from another proxy or the origin server.
    /// </summary>
    BadGateway = 502,

    /// <summary>
    /// BadRequest indicates that the request could not be understood by the server. BadRequest is sent when no other error is applicable, or if the exact error is unknown or does not have its own error code.
    /// </summary>
    BadRequest = 400,

    /// <summary>
    /// Conflict indicates that the request could not be carried out because of a conflict on the server.
    /// </summary>
    Conflict = 409,

    /// <summary>
    /// Continue indicates that the client can continue with its request.
    /// </summary>
    Continue = 100,

    /// <summary>
    /// Created indicates that the request resulted in a new resource created before the response was sent.
    /// </summary>
    Created = 201,

    /// <summary>
    /// ExpectationFailed indicates that an expectation given in an Expect header could not be met by the server.
    /// </summary>
    ExpectationFailed = 417,

    /// <summary>
    /// Forbidden indicates that the server refuses to fulfill the request.
    /// </summary>
    Forbidden = 403,

    /// <summary>
    /// Found indicates that the requested information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will use the GET method.
    /// </summary>
    Found = 302,

    /// <summary>
    /// GatewayTimeout indicates that an intermediate proxy server timed out while waiting for a response from another proxy or the origin server.
    /// </summary>
    GatewayTimeout = 504,

    /// <summary>
    /// Gone indicates that the requested resource is no longer available.
    /// </summary>
    Gone = 410,

    /// <summary>
    /// HttpVersionNotSupported indicates that the requested HTTP version is not supported by the server.
    /// </summary>
    HttpVersionNotSupported = 505,

    /// <summary>
    /// InternalServerError indicates that a generic error has occurred on the server.
    /// </summary>
    InternalServerError = 500,

    /// <summary>
    /// LengthRequired indicates that the required Content-length header is missing.
    /// </summary>
    LengthRequired = 411,

    /// <summary>
    /// MethodNotAllowed indicates that the request method (POST or GET) is not allowed on the requested resource.
    /// </summary>
    MethodNotAllowed = 405,

    /// <summary>
    /// Moved indicates that the requested information has been moved to the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will use the GET method.
    /// </summary>
    Moved = 301,

    /// <summary>
    /// MovedPermanently indicates that the requested information has been moved to the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response.
    /// </summary>
    MovedPermanently = 301,

    /// <summary>
    /// MultipleChoices indicates that the requested information has multiple representations. The default action is to treat this status as a redirect and follow the contents of the Location header associated with this response.
    /// </summary>
    MultipleChoices = 300,

    /// <summary>
    /// NoContent indicates that the request has been successfully processed and that the response is intentionally blank.
    /// </summary>
    NoContent = 204,

    /// <summary>
    /// NonAuthoritativeInformation indicates that the returned metainformation is from a cached copy instead of the origin server and therefore may be incorrect.
    /// </summary>
    NonAuthoritativeInformation = 203,

    /// <summary>
    /// NotAcceptable indicates that the client has indicated with Accept headers that it will not accept any of the available representations of the resource.
    /// </summary>
    NotAcceptable = 406,

    /// <summary>
    /// NotFound indicates that the requested resource does not exist on the server.
    /// </summary>
    NotFound = 404,

    /// <summary>
    /// NotImplemented indicates that the server does not support the requested function.
    /// </summary>
    NotImplemented = 501,

    /// <summary>
    /// NotModified indicates that the client's cached copy is up to date. The contents of the resource are not transferred.
    /// </summary>
    NotModified = 304,

    /// <summary>
    /// OK indicates that the request succeeded and that the requested information is in the response. This is the most common status code to receive.
    /// </summary>
    OK = 200,

    /// <summary>
    /// PartialContent indicates that the response is a partial response as requested by a GET request that includes a byte range.
    /// </summary>
    PartialContent = 206,

    /// <summary>
    /// PaymentRequired is reserved for future use.
    /// </summary>
    PaymentRequired = 402,

    /// <summary>
    /// PreconditionFailed indicates that a condition set for this request failed, and the request cannot be carried out. Conditions are set with conditional request headers like If-Match, If-None-Match, or If-Unmodified-Since.
    /// </summary>
    PreconditionFailed = 412,

    /// <summary>
    /// ProxyAuthenticationRequired indicates that the requested proxy requires authentication. The Proxy-authenticate header contains the details of how to perform the authentication.
    /// </summary>
    ProxyAuthenticationRequired = 407,

    /// <summary>
    /// Redirect indicates that the requested information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will use the GET method.
    /// </summary>
    Redirect = 302,

    /// <summary>
    /// RedirectKeepVerb indicates that the request information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will also use the POST method.
    /// </summary>
    RedirectKeepVerb = 307,

    /// <summary>
    /// RedirectMethod automatically redirects the client to the URI specified in the Location header as the result of a POST. The request to the resource specified by the Location header will be made with a GET.
    /// </summary>
    RedirectMethod = 303,
    /// <summary>
    /// RequestedRangeNotSatisfiable indicates that the range of data requested from the resource cannot be returned, either because the beginning of the range is before the beginning of the resource, or the end of the range is after the end of the resource.
    /// </summary>
    RequestedRangeNotSatisfiable = 416,

    /// <summary>
    /// RequestEntityTooLarge indicates that the request is too large for the server to process.
    /// </summary>
    RequestEntityTooLarge = 413,

    /// <summary>
    /// RequestTimeout indicates that the client did not send a request within the time the server was expecting the request.
    /// </summary>
    RequestTimeout = 408,

    /// <summary>
    /// RequestUriTooLong indicates that the URI is too long.
    /// </summary>
    RequestUriTooLong = 414,

    /// <summary>
    /// ResetContent indicates that the client should reset (not reload) the current resource.
    /// </summary>
    ResetContent = 205,

    /// <summary>
    /// SeeOther automatically redirects the client to the URI specified in the Location header as the result of a POST. The request to the resource specified by the Location header will be made with a GET.
    /// </summary>
    SeeOther = 303,

    /// <summary>
    /// ServiceUnavailable indicates that the server is temporarily unavailable, usually due to high load or maintenance.
    /// </summary>
    ServiceUnavailable = 503,

    /// <summary>
    /// SwitchingProtocols indicates that the protocol version or protocol is being changed.
    /// </summary>
    SwitchingProtocols = 101,

    /// <summary>
    /// TemporaryRedirect indicates that the request information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will also use the POST method.
    /// </summary>
    TemporaryRedirect = 307,

    /// <summary>
    /// Unauthorized indicates that the requested resource requires authentication. The WWW-Authenticate header contains the details of how to perform the authentication.
    /// </summary>
    Unauthorized = 401,

    /// <summary>
    /// UnsupportedMediaType indicates that the request is an unsupported type.
    /// </summary>
    UnsupportedMediaType = 415,

    /// <summary>
    /// Unused is a proposed extension to the HTTP/1.1 specification that is not fully specified.
    /// </summary>
    Unused = 306,

    /// <summary>
    /// UpgradeRequired indicates that the client should switch to a different protocol such as TLS/1.0.
    /// </summary>
    UpgradeRequired = 426,

    /// <summary>
    /// UseProxy indicates that the request should use the proxy server at the URI specified in the Location header.
    /// </summary>
    UseProxy = 305,

    /// <summary>
    /// The attempt to fetch server-side information on a repository failed due to some unknown reason. This may be a temporary outage. The request should be tried again, once you’ve checked that the repository’s server is up and running.
    /// </summary>
    RepositoryInformationError = 210
}
