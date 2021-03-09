using Acr.UserDialogs;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinFormsTutorial.Models;
using XamarinFormsTutorial.ServicesApi;

namespace XamarinFormsTutorial.ViewModels
{
    public class ListPageViewModel : ViewModelBase, IPageLifecycleAware 
    {
        private string text;

        public ListPageViewModel(INavigationService navigationService)
: base(navigationService)
        {
            Notes = new ObservableCollection<NoteAPI>();
            AddNoteCommand = new Command(async () => AddNoteCommandExecute());
        }

        private async Task AddNoteCommandExecute()
        {
            if (String.IsNullOrEmpty(this.Text))
            {
                ShowAlert("La nota esta vacia. Ingresa una nota valida.");
                return;
            }

            var cConfig = new ConfirmConfig();

            cConfig.Message = "¿Queres guardar la nota?";
            cConfig.OkText = "Si";
            cConfig.Title = "Confirm Dialog";
            cConfig.CancelText = "No";

            var result = await UserDialogs.Instance.ConfirmAsync(cConfig);

            if (result)
            {
                var random = new Random();
                var note = new NoteAPI() { tarea = this.Text, id = random.Next() };

                await App.RepositoryNote.AddItemAsync(note);

                var currentConnection = Connectivity.NetworkAccess;

                if (currentConnection == NetworkAccess.Internet)
                {
                    // send to BE
                    var apiResponse = RestService.For<INoteService>("https://c-3po-clases.herokuapp.com");

                    Task.Run(async () =>
                    {
                        UserDialogs.Instance.ShowLoading();
                        await apiResponse.PostNote(note);
                        UserDialogs.Instance.HideLoading();
                        RaisePropertyChanged(nameof(Notes));
                    });
                }
                Notes.Add(note);
                RaisePropertyChanged(nameof(Notes));
                Text = string.Empty;
            }
        }

        private void ShowAlert(string message)
        {
             var aConfi = new AlertConfig();
             aConfi.SetMessage(message);
             aConfi.SetTitle("Error");
             aConfi.SetOkText("Ok");
             UserDialogs.Instance.Alert(aConfi);

            // UserDialogs.Instance.Toast(message);
        }

        public void OnAppearing()
        {
            var currentConnection = Connectivity.NetworkAccess;

            if (currentConnection == NetworkAccess.Internet)
            {
                var apiResponse = RestService.For<INoteService>("https://c-3po-clases.herokuapp.com");

                Task.Run(async () =>
                {
                    UserDialogs.Instance.ShowLoading();
                    var notes = await apiResponse.GetNotes();
                    Notes = new ObservableCollection<NoteAPI>(notes);
                    UserDialogs.Instance.HideLoading();
                    RaisePropertyChanged(nameof(Notes));
                });
            }
            else
            {
                Task.Run(async () =>
                {
                    UserDialogs.Instance.ShowLoading();
                    var notes = await App.RepositoryNote.GetItemsAsync();
                    Notes = new ObservableCollection<NoteAPI>(notes);
                    UserDialogs.Instance.HideLoading();
                    RaisePropertyChanged(nameof(Notes));
                });
            }

        }

        public void OnDisappearing()
        {
            // TODO
        }

        public ObservableCollection<NoteAPI> Notes { get; set; }

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
