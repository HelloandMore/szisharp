namespace Solution.Common.Models;

public record ErrorObject(string Property, string ErrorMessage)
{
    public override string ToString() => $"{Property} -> {ErrorMessage}";
}
