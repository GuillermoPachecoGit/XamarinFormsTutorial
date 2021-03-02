using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsTutorial.Models;

namespace XamarinFormsTutorial.ServicesApi
{
    public interface INoteService
    {
        [Get("/getTasks")]
        Task<List<NoteAPI>> GetNotes();

        [Post("/postTask")]
        Task PostNote([Body] NoteAPI note);
    }
}
