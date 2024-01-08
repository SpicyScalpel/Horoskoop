using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horoskoop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KuupaevadPage : ContentPage
    {
        DatePicker datePicker;
        Label resultLabel;
        Image zodiacImage;
        Button clearButton;

        public KuupaevadPage()
        {
            InitializeComponent();
            this.Title = "Определение знака зодиака по дате";

            datePicker = new DatePicker
            {
                Format = "D",
                MaximumDate = DateTime.Now,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(20)
            };

            resultLabel = new Label
            {
                Text = "Выберите дату",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center  
            };

            zodiacImage = new Image
            {
                Source = "Resources/drawable/zodiak.jpg",
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = 350,
                WidthRequest = 350
            };

            datePicker.DateSelected += OnDateSelected;

            clearButton = new Button
            {
                Text = "Очистить",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            clearButton.Clicked += ClearButton_Clicked;

            var stackLayout = new StackLayout
            {
                Children = { datePicker, resultLabel, zodiacImage, clearButton },
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20)
            };

            Content = stackLayout;
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            datePicker.Date = DateTime.Now;
            resultLabel.Text = "Выберите дату";
            SetDefaultImage();
        }

        private void SetDefaultImage()
        {
            zodiacImage.Source = "Resources/drawable/zodiak.jpg";
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime selectedDate = e.NewDate;
            string zodiacSign = GetZodiacSign(selectedDate);

            string zodiacDescription = GetZodiacDescription(zodiacSign);
            string imagePath = GetZodiacImagePath(zodiacSign);

            resultLabel.Text = $"Ваш знак зодиака: {zodiacSign}\nОписание: {zodiacDescription}";
            zodiacImage.Source = imagePath;
        }

        private string GetZodiacSign(DateTime date)
        {
            int day = date.Day;
            int month = date.Month;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
            {
                return "Овен";
            }
            else if ((month == 4 && day >= 21) || (month == 5 && day <= 21))
            {
                return "Телец";
            }
            else if ((month == 5 && day >= 22) || (month == 6 && day <= 21))
            {
                return "Близнецы";
            }
            else if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
            {
                return "Рак";
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                return "Лев";
            }
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 23))
            {
                return "Дева";
            }
            else if ((month == 9 && day >= 24) || (month == 10 && day <= 23))
            {
                return "Весы";
            }
            else if ((month == 10 && day >= 24) || (month == 11 && day <= 21))
            {
                return "Скорпион";
            }
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 20))
            {
                return "Стрелец";
            }
            else if ((month == 12 && day >= 21) || (month == 1 && day <= 19))
            {
                return "Козерог";
            }
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            {
                return "Водолей";
            }
            else
            {
                return "Рыбы";
            }
        }

        private Dictionary<string, string> zodiacImages = new Dictionary<string, string> {
            { "Овен", "Resources/drawable/Aries.png" },
            { "Телец", "Resources/drawable/Taurus.png" },
            { "Близнецы", "Resources/drawable/Gemini.png" },
            { "Рак", "Resources/drawable/Crayfish.png" },
            { "Лев", "Resources/drawable/Lion.png" },
            { "Дева", "Resources/drawable/Virgo.png" },
            { "Весы", "Resources/drawable/Libra.png" },
            { "Скорпион", "Resources/drawable/Scorpio.png" },
            { "Стрелец", "Resources/drawable/Sagittarius.png" },
            { "Козерог", "Resources/drawable/Capricornus.png" },
            { "Водолей", "Resources/drawable/Vodoley.png" },
            { "Рыбы", "Resources/drawable/Fishes.png" },
        };

        private string GetZodiacImagePath(string zodiacSign)
        {
            if (!zodiacImages.ContainsKey(zodiacSign))
            {
                return "Resources/drawable/zodiak.jpg";
            }

            return zodiacImages[zodiacSign];
        }

        private Dictionary<string, string> zodiacDescriptions = new Dictionary<string, string>{
            { "Овен", "С 21 марта по 20 апреля" },
            { "Телец", "С 21 апреля по 21 мая" },
            { "Близнецы", "С 22 мая по 21 июня" },
            { "Рак", "С 22 июня по 22 июля" },
            { "Лев", "С 23 июля по 22 августа" },
            { "Дева", "С 23 августа по 23 сентября" },
            { "Весы", "С 24 сентября по 23 октября" },
            { "Скорпион", "С 24 октября по 21 ноября" },
            { "Стрелец", "С 22 ноября по 20 декабря" },
            { "Козерог", "С 21 декабря по 19 января" },
            { "Водолей", "С 20 января до 18 февраля" },
            { "Рыбы", "С 19 февраля по 20 марта" }
        };

        private string GetZodiacDescription(string zodiacSign)
        {
            if (!zodiacDescriptions.ContainsKey(zodiacSign))
            {
                return "Не выбран знак зодиака!";
            }

            return zodiacDescriptions[zodiacSign];
        }

    }
}