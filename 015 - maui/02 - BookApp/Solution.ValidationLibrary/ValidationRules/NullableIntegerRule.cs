namespace MauiValidationLibrary.ValidationRules;

public class NullableIntegerRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; }

    public bool Check(T value)
    {
        if (value is not uint data)
        {
            return false;
        }

        return !string.IsNullOrEmpty(data.ToString());
    }
}
