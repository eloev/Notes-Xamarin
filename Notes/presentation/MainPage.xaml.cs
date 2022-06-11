using Notes.data;
using Notes.presentation;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace Notes
{
    public partial class MainPage : ContentPage
    {
        public List<Note> Notes { get; set; }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            Notes = App.Database.GetItems().ToList();
            notesList.FlowItemsSource = Notes;
            base.OnAppearing();
        }

        // Кнопка добавить
        private async void AddButtonClicked(object sender, EventArgs e)
        {
            Note note = new Note();
            NotePage notePage = new NotePage
            {
                BindingContext = note
            };
            await Navigation.PushAsync(notePage);
        }

        // Обработка тапа по элементу
        public Command ItemTappedCommand
        {
            get
            {
                return new Command(async(item) =>
                {
                    var itemNote = item as Note;
                    NotePage notePage = new NotePage
                    {
                        BindingContext = itemNote
                    };
                    await Navigation.PushAsync(notePage);
                });
            }
        }
    }
}