namespace ChatGPT;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        if(webView.CanGoBack)
        {
            webView.GoBack();
            return true;
        }
        return base.OnBackButtonPressed();
    }

    private async void webView_Navigated(object sender, WebNavigatedEventArgs e)
    {
        if (e.Result == WebNavigationResult.Success)
        {
            webView.IsVisible = true;
            return;
        }
        else
        {
            webView.IsVisible = false;
            bool answer = await DisplayAlert("Something went wrong!!", "Please check your internet connection.", "Refresh", "Quit");

            if (answer == true)
            {
                webView.Reload();
            }
            else
            {
                Application.Current.Quit();
            }
        }
    }
}

