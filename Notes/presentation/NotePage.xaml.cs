using Notes.data;
using System;
using Xamarin.Forms;

namespace Notes.presentation
{
    public partial class NotePage : ContentPage
    {
        public NotePage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void SaveNote(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            if (!string.IsNullOrEmpty(note.Title) && !string.IsNullOrEmpty(note.Body))
            {
                note.Date = Format(DateTime.Now);
                App.Database.SaveItem(note);
            }
            Navigation.PopAsync();
        }
        private void DeleteNote(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            App.Database.DeleteItem(note.Id);
            Navigation.PopAsync();
        }

        private string Format(DateTime date)
        {
            return date.Day < 10 ? date.ToString("d MMMMMMMMM") : date.ToString("dd MMMMMMMMM");
        }
    }
}