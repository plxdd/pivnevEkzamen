using NumbersApi.Data;
using System;
using System.IO;
using Xamarin.Forms;

namespace NumbersApi
{
    public partial class App : Application
    {
        static NotesDB _notesDB;

        public static NotesDB NotesDB 
        {
            get
            {
                if (_notesDB is null)
                {
                    _notesDB = new NotesDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "NotesDB.db3"));
                }
                return _notesDB;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
