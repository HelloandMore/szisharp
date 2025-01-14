namespace Solution.DesktopApp;

public partial class App : Application
{
    public App()
    {
		ExceptionHandler.UnhandledException += OnException;

		InitializeComponent();
        MaximizeWindow();
	}

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }

	private async void OnException(object sender, UnhandledExceptionEventArgs e)
	{
		var exception = e.ExceptionObject as Exception;
        var message = exception?.Message ?? "Unexpected error!";

        var toast = Toast.Make(message, ToastDuration.Long, 16);

        await toast.Show(new CancellationTokenSource().Token);
    }

    private void MaximizeWindow()
    {
        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
    #if WINDOWS
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            ShowWindow(windowHandle, 3);
    #endif
        });
    }

    #if WINDOWS
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
    #endif
}