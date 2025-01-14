namespace Solution.PdfGenerator;

public class PdfgeneratorService : IPdfgeneratorService
{
	private readonly IServiceProvider serviceProvider;
	private readonly ILoggerFactory loggerFactory;

	public PdfgeneratorService(IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
	{
		Microsoft.Playwright.Program.Main(["install"]);
		this.serviceProvider = serviceProvider;
		this.loggerFactory = loggerFactory;
	}
	public async Task GeneratePdf<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>
		                (string fileName, Dictionary<string, object?> htmlData) where TComponent : IComponent
	{
		await using var htmlRenderer = new HtmlRenderer(serviceProvider, loggerFactory);

		var html = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
		{
			var parameters = ParameterView.FromDictionary(htmlData);
			var output = await htmlRenderer.RenderComponentAsync(typeof(TComponent), parameters);
			return output.ToHtmlString();
		});

		using var playwright = await Playwright.CreateAsync();
		var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
		{
			Headless = true
		});

		var page = await browser.NewPageAsync();
		await page.SetContentAsync(html);

		await page.PdfAsync(new PagePdfOptions
		{
			Format = "A4",
			Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), $"{fileName.Replace(".pdf","")}.pdf")
		});

		await page.CloseAsync();
	}
}
