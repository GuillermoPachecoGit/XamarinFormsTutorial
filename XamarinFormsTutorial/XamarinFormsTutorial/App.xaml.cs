using Prism;
using Prism.Ioc;
using SQLite;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using XamarinFormsTutorial.LocalDatabase;
using XamarinFormsTutorial.Models;
using XamarinFormsTutorial.ViewModels;
using XamarinFormsTutorial.Views;

namespace XamarinFormsTutorial
{
    public partial class App
    {

        private static SQLiteConnection database;
        public static SQLiteConnection Database
        {
            get
            {
                if (database != null)
                    return database;

                var platform = DependencyService.Get<ISQLitePlatform>();
                database = platform.GetSQLiteConnection();
                return database;
            }
        }

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");

            App.Database.CreateTable<NoteAPI>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<ListPage, ListPageViewModel>();
        }
    }
}
