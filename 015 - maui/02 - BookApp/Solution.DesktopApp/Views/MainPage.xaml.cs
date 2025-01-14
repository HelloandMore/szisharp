namespace Solution.DesktopApp;

public partial class MainPage : ContentPage
{
    public MainPageViewModel ViewModel => this.BindingContext as MainPageViewModel;

    public string Name => nameof(MainPage);

    public MainPage(MainPageViewModel viewModel)
    {
        this.BindingContext = viewModel;
        this.SizeChanged += OnSizeChanged;

		InitializeComponent();
    }

    private void OnSizeChanged(object? sender, EventArgs e)
    {
        ContentPage page = sender as ContentPage;
        ViewModel.TitleWidth = page.Width - 40;
	}
}
