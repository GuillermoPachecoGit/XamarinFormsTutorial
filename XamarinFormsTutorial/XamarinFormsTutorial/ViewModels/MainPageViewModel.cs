using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinFormsTutorial.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            TapCommand = new Command(async () => await TapCommandExecuteAsync());
        }

        private async System.Threading.Tasks.Task TapCommandExecuteAsync()
        {
            await NavigationService.NavigateAsync("HomePage");
        }

        public ICommand TapCommand { get; set; }
    }
}
