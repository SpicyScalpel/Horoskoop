using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horoskoop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UhilduvusPage : ContentPage
    {
        Picker firstPicker;
        Picker secondPicker;
        Image zodiacImage;

        private readonly Dictionary<string, string> zodiacImages = new Dictionary<string, string> {
    { "Овен", "drawable/Aries.png" },
    { "Телец", "drawable/Taurus.png" },
    { "Близнецы", "drawable/Gemini.png" },
    { "Рак", "drawable/Crayfish.png" },
    { "Лев", "drawable/Lion.png" },
    { "Дева", "drawable/Virgo.png" },
    { "Весы", "drawable/Libra.png" },
    { "Скорпион", "drawable/Scorpio.png" },
    { "Стрелец", "drawable/Sagittarius.png" },
    { "Козерог", "drawable/Capricornus.png" },
    { "Водолей", "drawable/Vodoley.png" },
    { "Рыбы", "drawable/Fishes.png" }
};


        public UhilduvusPage()
        {
            InitializeComponent();

            // Создайте первый Picker
            firstPicker = new Picker
            {
                Title = "Выберите элемент",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Добавьте элементы в первый Picker
            firstPicker.Items.Add("Овен");
            firstPicker.Items.Add("Телец");
            firstPicker.Items.Add("Близнецы");
            firstPicker.Items.Add("Рак");
            firstPicker.Items.Add("Лев");
            firstPicker.Items.Add("Дева");
            firstPicker.Items.Add("Весы");
            firstPicker.Items.Add("Скорпион");
            firstPicker.Items.Add("Стрелец");
            firstPicker.Items.Add("Козерог");
            firstPicker.Items.Add("Водолей");
            firstPicker.Items.Add("Рыбы");

            // Создайте второй Picker
            secondPicker = new Picker
            {
                Title = "Выберите элемент",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Добавьте элементы во второй Picker
            secondPicker.Items.Add("Овен");
            secondPicker.Items.Add("Телец");
            secondPicker.Items.Add("Близнецы");
            secondPicker.Items.Add("Рак");
            secondPicker.Items.Add("Лев");
            secondPicker.Items.Add("Дева");
            secondPicker.Items.Add("Весы");
            secondPicker.Items.Add("Скорпион");
            secondPicker.Items.Add("Стрелец");
            secondPicker.Items.Add("Козерог");
            secondPicker.Items.Add("Водолей");
            secondPicker.Items.Add("Рыбы");

            zodiacImage = new Image
            {
                Aspect = Aspect.AspectFit, // Установите соответствующий Aspect (подгонка картинки)
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Добавьте обработчики событий для обработки выбора в первом и втором Pickers
            firstPicker.SelectedIndexChanged += FirstPicker_SelectedIndexChanged;
            secondPicker.SelectedIndexChanged += SecondPicker_SelectedIndexChanged;

            // Добавьте элементы на страницу
            Content = new StackLayout
            {
                Children = { firstPicker, secondPicker, zodiacImage },
                Padding = new Thickness(20)
            };
        }

        private void FirstPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = firstPicker.SelectedItem;
            // Обработка выбора в первом Picker
            DisplayAlert("Выбрано", $"Выбрано из первого Picker: {selectedValue}", "OK");
        }

        private void SecondPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = secondPicker.SelectedItem;
            // Обработка выбора во втором Picker
            DisplayAlert("Выбрано", $"Выбрано из второго Picker: {selectedValue}", "OK");
        }

        private void ShowZodiacImage(string zodiacSign)
        {
            if (zodiacSign != null && zodiacImages.ContainsKey(zodiacSign))
            {
                var imagePath = zodiacImages[zodiacSign];
                zodiacImage.Source = imagePath;
            }
        }
    }
}
