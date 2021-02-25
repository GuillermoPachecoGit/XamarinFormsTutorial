using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsTutorial.Models;

namespace XamarinFormsTutorial.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        private string text;

        public ListPageViewModel(INavigationService navigationService)
: base(navigationService)
        {
            Notes = new ObservableCollection<Note>();
            AddNoteCommand = new Command(AddNoteCommandExecute);
        }

        private void AddNoteCommandExecute(object obj)
        {
            Notes.Add(new Note() { Text = this.Text, Date = DateTime.Now });
            RaisePropertyChanged(nameof(Notes));
            Text = string.Empty;
        }

        public ObservableCollection<Note> Notes { get; set; }

        public ICommand AddNoteCommand { get; set; }

        public string Text 
        { 
            get => text; 
            set
            { 
                text = value;
                RaisePropertyChanged();
            } 
        }
    }
}
