namespace MauiValidationLibrary.ValidationRules;

public class MinValueRule<T>(int minValue) : IValidationRule<T>
{
  public string ValidationMessage { get; set; } = $"Length can't bee less then {minValue}.";

  public bool Check(T value)
  {
      if(!int.TryParse(value?.ToString(), out int data))
      { 
          return false;
      }
        
      return data >= minValue;
  }
}
