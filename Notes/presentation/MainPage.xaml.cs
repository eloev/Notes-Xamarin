using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Notes
{
    public partial class MainPage : ContentPage
    {
        public List<Note> Notes { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Notes = new List<Note>
            {
                new Note {Title="Galaxy S8 asdasd adasda sdasda asdasdad asd", Body="Samsung", Date=Format(DateTime.Today) },
                new Note {Title="Huawei P10", Body="Huawei", Date=Format(DateTime.Now) },
                new Note {Title="HTC U Ultra", Body="HTC asdasd adasda sdasda asda sdad asdasdasd adasda sdasda asdasdad asd asdasd adasda sdasda asdasdad asd", Date=Format(DateTime.Now) },
                new Note {Title="iPhone 7", Body="Apple", Date=Format(DateTime.Now.AddDays(1D)) }
            };
            BindingContext = this;
        }

        private void AddButtonClicked(object sender, EventArgs e)
        {

        }

        public Command ItemTappedCommand
        {
            get
            {
                return new Command((note) =>
                {
                    var itemNote = note as Note;
                    this.DisplayAlert(itemNote.Title, itemNote.Body, itemNote.Date);
                });
            }
        }

        private string Format(DateTime date)
        {
            return date.Day < 10 ? date.ToString("d MMMMMMMMM") : date.ToString("dd MMMMMMMMM");
        }
    }
}