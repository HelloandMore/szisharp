namespace Solution.Validators.CustomValidators;

public static class StringValueValidators
{
    public static bool BeAValidPostalCode(string value) => Regex.IsMatch(value, @"^\d{4,}$");

    public static bool BeAValidPhoneNumber(string value) => Regex.IsMatch(value, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
}
