using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsTutorial.Models
{
    public class NoteAPI
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public DateTime date { get; set; }
        public string tarea { get; set; }
    }
}
