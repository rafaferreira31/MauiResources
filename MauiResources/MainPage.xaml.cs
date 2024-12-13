using System.Text.Json;

namespace MauiResources
{
    public partial class MainPage : ContentPage
    {
        Pessoa pessoa;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing(); 

            await LoadMauiAsset();
        }

        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("demo.json");
            using var reader = new StreamReader(stream);

            var contents = reader.ReadToEnd();

            var pessoa = JsonSerializer.Deserialize<Pessoa>(contents);

            BindingContext = pessoa;
        }
    }

    public class Pessoa
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public int Idade { get; set; }

        public string Foto { get; set; }

    }

}


