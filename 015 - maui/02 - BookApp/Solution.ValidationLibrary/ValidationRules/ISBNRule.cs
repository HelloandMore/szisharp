namespace Solution.ValidationLibrary.ValidationRules;

public class ISBNRule<T> : IValidationRule<T>
{
	public string ValidationMessage { get; set; }

	private static readonly Regex isbnRegex = new Regex(@"^(?=(?:[^0-9]*[0-9]){10}(?:(?:[^0-9]*[0-9]){3})?$)[\d-]+$");

	public bool Check(T value)
	{
		if (value is not string data)
		{
			return false;
		}
		return isbnRegex.IsMatch(data);
	}
}
