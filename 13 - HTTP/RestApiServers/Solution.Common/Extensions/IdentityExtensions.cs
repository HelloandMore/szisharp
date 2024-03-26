namespace Solution.Common.Extensions;

public static class IdentityExtensions
{
    public static string ToErrorObject(this IdentityResult identityResult) => JsonSerializer.Serialize(identityResult.Errors.Select(x => x.Description));
}
