namespace GymTrackerApp
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            NavigateToMainPage();
        }

        private async void NavigateToMainPage()
        {
            await Task.Delay(2000);

            var window = Application.Current?.Windows.FirstOrDefault();
            if (window != null)
            {
                window.Page = new AppShell();
            }
        }
    }
}