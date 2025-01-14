
namespace Solution.PdfGenerator;

public interface IPdfgeneratorService
{
	Task GeneratePdf<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>
										(string fileName, Dictionary<string, object?> htmlData) where TComponent : IComponent;
}
