namespace blazspire;

using Auth0.OidcClient;

public partial class App : Application
{
	public App()
	{
		if (Auth0.OidcClient.Platforms.Windows.Activator.Default.CheckRedirectionActivation()) { return; }

		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{


		return new Window(new MainPage()) { Title = "blazspire" };
	}
}
