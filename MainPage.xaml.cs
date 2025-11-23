//using Android.Graphics;
using System.Net.Http;
using System.Text.Json;

namespace Project
{

    public partial class MainPage : ContentPage
    {
        int count = 0;

        private HttpClient _httpClient;
        private movieViewModel viewModel;


        public MainPage()
        {
            InitializeComponent();

            viewModel= new movieViewModel();
            BindingContext = viewModel;
            _httpClient = new HttpClient();
           if (count == 0)
            {
                viewModel.downloadFile();
            }
           
        }
        /*  private async void downloadFile()
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
                      var texts = JsonSerializer.Deserialize<List<Root>>(text);

                  //each film in the texts list and call it film
                  foreach (var film in texts)
                      // Console.WriteLine(film.title);
                      movies.Text= text;
                  }
              }
          }
          public class Root
          {
              public string title { get; set; }
              public int year { get; set; }
              public List<string> genre { get; set; }
              public string director { get; set; }
              public double rating { get; set; }
              public string emoji { get; set; }
          }
        */

    }
}


