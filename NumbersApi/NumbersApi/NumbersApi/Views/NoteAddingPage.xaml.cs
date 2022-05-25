using NumbersApi.Models;
using System;

using Xamarin.Forms;

namespace NumbersApi.Views
{

    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteAddingPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        public NoteAddingPage()
        {
            InitializeComponent();

            BindingContext = new Note();
        }

        private async void LoadNote(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);
                var note = await App.NotesDB.GetNoteAsync(id);
                BindingContext = note;
            }
            catch { }
        }

        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (note.ID == 0) await App.NotesDB.AddNoteAsync(note);
            else await App.NotesDB.UpdateNoteAsync(note);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            await App.NotesDB.DeleteNoteAsync(note);

            await Shell.Current.GoToAsync("..");
        }
    }
}