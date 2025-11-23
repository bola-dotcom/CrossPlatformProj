//using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project
{
    public class movieViewModel : INotifyPropertyChanged
    {
        private HttpClient _httpClient = new HttpClient();
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();

        private Movie _selectedMovie;
        public Movie selectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged();
            }
        }
        private string _libraryName = "My Movie Library";
        public string LibraryName
        {
            get => _libraryName;
            set
            {
                _libraryName = value;
                OnPropertyChanged();
            }
        }


        public async void downloadFile()
        {
            //if this is the first time the application is opened

            //gets the link into the response variable
            var response = await _httpClient.GetAsync("https://raw.githubusercontent.com/DonH-ITS/jsonfiles/refs/heads/main/moviesemoji.json");


            if (response == null)
            {

            }
            //if the response is successful
            if (response.IsSuccessStatusCode)
            {
                //reads the content of the json into the text variable
                String text = await response.Content.ReadAsStringAsync();
                //deserializes the content into the texts variable
                var texts = JsonSerializer.Deserialize<List<Movie>>(text);
                Movies.Clear();
                //each film in the texts list and call it film
                foreach (var film in texts)
                    // Console.WriteLine(film.title);
                    Movies.Add(new Movie
                    {
                        title = film.title,
                        year = film.year,
                        genre =film.genre,
                        director = film.director,
                        rating = film.rating,
                        emoji = film.emoji
                    });
               
            }
        }


        public class Movie
        {
            public string title { get; set; }
            public int year { get; set; }
            public List<string> genre { get; set; }
            public string Genre => string.Join(",", genre);
            public string director { get; set; }
            public double rating { get; set; }
            public string emoji { get; set; }
        }
    }
}

    

