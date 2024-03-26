namespace Solution.Validators.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void RegisterFluentValidators(this WebApplicationBuilder builder)
    {
        var assembly = Assembly.GetExecutingAssembly();
        IEnumerable<TypeInfo> classTypes = assembly.ExportedTypes.Select(t => IntrospectionExtensions.GetTypeInfo(t)).Where(t => t.IsClass && !t.IsAbstract);

        foreach (TypeInfo type in classTypes)
        {
            var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

            foreach (var handlerType in interfaces.Where(i => i.IsGenericType))
            {
                builder.Services.AddTransient(handlerType.AsType(), type.AsType());
            }
        }
    }
}
