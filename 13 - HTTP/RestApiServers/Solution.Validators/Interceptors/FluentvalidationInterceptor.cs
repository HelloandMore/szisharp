namespace Solution.Validators.Interceptors;

public class FluentvalidationInterceptor : IValidatorInterceptor
{
    public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
    {
        if (!result.IsValid)
        {
            ICollection<ErrorObject> validationErrors = new List<ErrorObject>();

            foreach (ValidationFailure error in result.Errors)
            {
                validationErrors.Add(new ErrorObject(error.PropertyName, error.ErrorMessage));
            }

            string errorMessages = JsonSerializer.Serialize(validationErrors);
            throw new HttpStatusCodeException(HttpResponseType.BadRequest, errorMessages, ResponseErrorDictionary.VALIDATION_FAILD);
        }

        return result;
    }

    public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
    {
        return commonContext;
    }
}
