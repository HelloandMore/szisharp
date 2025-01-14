namespace MauiValidationLibrary;

public class ValidatableObject<T> : ObservableObject
{
    private IEnumerable<string> _errors;
    private bool _isValid;
    private T _value;
    
    public List<IValidationRule<T>> Validations { get; } = new();
    
    public IEnumerable<string> Errors
    {
        get => _errors;
        private set => SetProperty(ref _errors, value);
    }
    public bool IsValid
    {
        get => _isValid;
        private set => SetProperty(ref _isValid, value);
    }
    public T Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }
    public ValidatableObject()
    {
        _isValid = true;
        _errors = [];
        _value = default;
    }
    public bool Validate()
    {
        Errors = Validations?.Where(x => !x.Check(Value))
                            ?.Select(x => x.ValidationMessage)
                            ?.ToArray() ?? [];

        IsValid = !Errors.Any();
        
        return IsValid;
    }
}
