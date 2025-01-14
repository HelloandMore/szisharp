namespace MauiValidationLibrary.ValidationRules;

public class NullableLongRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; }

    public bool Check(T value)
    {
        if(value is not ulong data)
        { 
            return false;
        }
        
        return !string.IsNullOrEmpty(data.ToString());
    }
}
