namespace Solution.Configurations.WebApplicationBuilderExtensions;

public static class HttpContextConfiguration
{
    private static string KEY;

    public static void ConfigureHttpContext(this WebApplicationBuilder builder)
    {
        KEY = builder.Configuration.GetSection("JWT")["Key"]!;
    }

    public static string? GetUserEmail(this HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last() ?? "";

        if (string.IsNullOrEmpty(token))
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(KEY);
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
            ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        return jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Email).Value;
    }
}
