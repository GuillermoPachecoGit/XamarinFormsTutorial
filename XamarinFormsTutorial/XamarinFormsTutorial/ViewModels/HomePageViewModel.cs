using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinFormsTutorial.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private int _counter = 0;
        public HomePageViewModel(INavigationService navigationService)
            : base(navigationService) {
             AddClickCommand = new Command(AddClikCommandExecuteAsync);
             ClickCounterTitle = "Clicks 0";
        }

        private void AddClikCommandExecuteAsync(object obj)
        {
            ClickCounterTitle = $"Clicks {_counter+=1}";
        }

        private string _clickCounterTitle;
        public string ClickCounterTitle
        {
            get { return _clickCounterTitle; }

            set { _clickCounterTitle = value;
                RaisePropertyChanged();
            }
        }

        public ICommand AddClickCommand { get; set; }
    }
}
