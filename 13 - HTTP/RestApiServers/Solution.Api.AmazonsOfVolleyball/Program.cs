Log.Logger = new LoggerConfiguration()
   .WriteTo.Console()
   .MinimumLevel.Debug()
   .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
   .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
   .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        if (!context.ModelState.IsValid)
                        {
                            var errorInfos = context.ModelState.ToDictionary(k => k.Key, v => v.Value);

                            foreach (var errorInfo in errorInfos)
                                Log.Logger.Information($"validation error for: {errorInfo.Key} => {errorInfo.Value?.Errors.First().ErrorMessage}");

                            return new BadRequestObjectResult(context.ModelState);
                        }
                        return new OkResult();
                    };
                });

builder.Services.AddResponseCompression(options => options.EnableForHttps = true);
builder.ConfigureEnviorementVariables();
builder.ConfigureSettings();
builder.ConfigureSerilog();
builder.ConfigureFluentValidation();
builder.ConfigureDI();
builder.ConfigureSwagger();
builder.ConfigureCORS();
builder.ConfigureHttpContext();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();
builder.Services.AddOutputCache();
GlobalErrorResponse.Configure(builder.Configuration.GetValue<bool>("IsDevelopment"));


var app = builder.Build();
app.UseResponseCompression();
app.ConfigureSwagger();
app.UseMigrationsEndPoint();
app.UseHttpsRedirection();
app.ConfigureCORS();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseOutputCache();
app.UseMiddleware<ApiExceptionHandlerMiddleware>();
app.UseExceptionHandler("/error");


var cultureInfo = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


app.Run();
