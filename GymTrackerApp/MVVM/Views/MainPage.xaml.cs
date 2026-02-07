namespace GymTrackerApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadData();
        }

        public async void LoadData()
        {
            var exerciseData = await MVVM.Services.JsonRead.Load();
            ProductsView.ItemsSource = exerciseData;
        }
    }
}
