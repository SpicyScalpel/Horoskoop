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
        Image firstZodiacImage;
        Image secondZodiacImage;
        Label compatibilityLabel;
        Button clearButton;
        Label linkLabel;

        private readonly Dictionary<string, string> zodiacImages = new Dictionary<string, string> {
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
            { "Рыбы", "Resources/drawable/Fishes.png" }
        };

        private readonly Dictionary<string, Dictionary<string, int>> compatibilityMatrix = new Dictionary<string, Dictionary<string, int>>{
            { "Овен", new Dictionary<string, int> { { "Овен", 70 }, { "Телец", 72 }, { "Близнецы", 85 }, { "Рак", 62 }, { "Лев", 92 }, { "Дева", 76 }, { "Весы", 72 }, { "Скорпион", 80 }, { "Стрелец", 85 }, { "Козерог", 52 }, { "Водолей", 72 }, { "Рыбы", 64 }} },
            { "Телец", new Dictionary<string, int> { { "Овен", 72 }, { "Телец", 92 }, { "Близнецы", 64 }, { "Рак", 80 }, { "Лев", 85 }, { "Дева", 95 }, { "Весы", 90 }, { "Скорпион", 88 }, { "Стрелец", 43 }, { "Козерог", 87 }, { "Водолей", 60 }, { "Рыбы", 70 }} },
            { "Близнецы", new Dictionary<string, int> { { "Овен", 85 }, { "Телец", 64 }, { "Близнецы", 80 }, { "Рак", 87 }, { "Лев", 75 }, { "Дева", 70 }, { "Весы", 90 }, { "Скорпион", 58 }, { "Стрелец", 96 }, { "Козерог", 64 }, { "Водолей", 93 }, { "Рыбы", 76 }} },
            { "Рак", new Dictionary<string, int> { { "Овен", 62 }, { "Телец", 80 }, { "Близнецы", 87 }, { "Рак", 83 }, { "Лев", 50 }, { "Дева", 80 }, { "Весы", 84 }, { "Скорпион", 92 }, { "Стрелец", 60 }, { "Козерог", 49 }, { "Водолей", 81 }, { "Рыбы", 95 }} },
            { "Лев", new Dictionary<string, int> { { "Овен", 92 }, { "Телец", 85 }, { "Близнецы", 75 }, { "Рак", 50 }, { "Лев", 87 }, { "Дева", 50 }, { "Весы", 79 }, { "Скорпион", 70 }, { "Стрелец", 94 }, { "Козерог", 73 }, { "Водолей", 29 }, { "Рыбы", 74 }} },
            { "Дева", new Dictionary<string, int> { { "Овен", 76 }, { "Телец", 95 }, { "Близнецы", 70 }, { "Рак", 80 }, { "Лев", 50 }, { "Дева", 78 }, { "Весы", 68 }, { "Скорпион", 90 }, { "Стрелец", 75 }, { "Козерог", 93 }, { "Водолей", 51 }, { "Рыбы", 76 }} },
            { "Весы", new Dictionary<string, int> { { "Овен", 72 }, { "Телец", 90 }, { "Близнецы", 90 }, { "Рак", 84 }, { "Лев", 79 }, { "Дева", 68 }, { "Весы", 92 }, { "Скорпион", 85 }, { "Стрелец", 95 }, { "Козерог", 65 }, { "Водолей", 91 }, { "Рыбы", 85 }} },
            { "Скорпион", new Dictionary<string, int> { { "Овен", 80 }, { "Телец", 88 }, { "Близнецы", 58 }, { "Рак", 92 }, { "Лев", 70 }, { "Дева", 90 }, { "Весы", 85 }, { "Скорпион", 95 }, { "Стрелец", 90 }, { "Козерог", 92 }, { "Водолей", 60 }, { "Рыбы", 95 }} },
            { "Стрелец", new Dictionary<string, int> { { "Овен", 85 }, { "Телец", 43 }, { "Близнецы", 96 }, { "Рак", 60 }, { "Лев", 94 }, { "Дева", 75 }, { "Весы", 95 }, { "Скорпион", 90 }, { "Стрелец", 97 }, { "Козерог", 65 }, { "Водолей", 100 }, { "Рыбы", 70 }} },
            { "Козерог", new Dictionary<string, int> { { "Овен", 52 }, { "Телец", 87 }, { "Близнецы", 64 }, { "Рак", 49 }, { "Лев", 73 }, { "Дева", 93 }, { "Весы", 65 }, { "Скорпион", 92 }, { "Стрелец", 65 }, { "Козерог", 84 }, { "Водолей", 90 }, { "Рыбы", 85 }} },
            { "Водолей", new Dictionary<string, int> { { "Овен", 72 }, { "Телец", 60 }, { "Близнецы", 93 }, { "Рак", 81 }, { "Лев", 29 }, { "Дева", 51 }, { "Весы", 91 }, { "Скорпион", 60 }, { "Стрелец", 100 }, { "Козерог", 90 }, { "Водолей", 85 }, { "Рыбы", 93 }} },
            { "Рыбы", new Dictionary<string, int> { { "Овен", 64 }, { "Телец", 70 }, { "Близнецы", 76 }, { "Рак", 95 }, { "Лев", 74 }, { "Дева", 76 }, { "Весы", 85 }, { "Скорпион", 95 }, { "Стрелец", 70 }, { "Козерог", 85 }, { "Водолей", 93 }, { "Рыбы", 99 }} },
        };

        public UhilduvusPage()
        {
            InitializeComponent();
            Title = "Совместимость знаков зодиаков";

            firstPicker = new Picker
            {
                Title = "Выберите элемент",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            AddZodiacSignsToPicker(firstPicker);

            secondPicker = new Picker
            {
                Title = "Выберите элемент",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            AddZodiacSignsToPicker(secondPicker);

            firstZodiacImage = new Image
            {
                Aspect = Aspect.AspectFit,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            secondZodiacImage = new Image
            {
                Aspect = Aspect.AspectFit,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            compatibilityLabel = new Label
            {
                Text = "Совместимость: 0%",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            firstPicker.SelectedIndexChanged += FirstPicker_SelectedIndexChanged;
            secondPicker.SelectedIndexChanged += SecondPicker_SelectedIndexChanged;

            clearButton = new Button
            {
                Text = "Очистить",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            clearButton.Clicked += ClearButton_Clicked;

            linkLabel = new Label
            {
                Text = "Подробнее...",
                TextColor = Color.Blue,
                FontAttributes = FontAttributes.Italic,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            linkLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OpenLink()),
                NumberOfTapsRequired = 1
            });

            var stackLayout = new StackLayout
            {
                Children = { firstPicker, secondPicker, firstZodiacImage, secondZodiacImage, compatibilityLabel, linkLabel, clearButton },
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20)
            };
            Content = stackLayout;
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            firstPicker.SelectedIndex = -1;
            secondPicker.SelectedIndex = -1;

            firstZodiacImage.Source = null;
            secondZodiacImage.Source = null;

            compatibilityLabel.Text = "Совместимость: 0%";

            this.BackgroundColor = Color.Default;
        }

        private void AddZodiacSignsToPicker(Picker picker)
        {
            foreach (var zodiacSign in zodiacImages.Keys)
            {
                picker.Items.Add(zodiacSign);
            }
        }

        private void FirstPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = (string)firstPicker.SelectedItem;
            ShowZodiacImage(selectedValue, firstZodiacImage);
            UpdateCompatibilityLabel();
        }

        private void SecondPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = (string)secondPicker.SelectedItem;
            ShowZodiacImage(selectedValue, secondZodiacImage);
            UpdateCompatibilityLabel();
        }

        private void ShowZodiacImage(string zodiacSign, Image image)
        {
            if (zodiacSign != null && zodiacImages.ContainsKey(zodiacSign))
            {
                var imagePath = zodiacImages[zodiacSign];
                image.Source = imagePath;
            }
        }

        private void UpdateCompatibilityLabel()
        {
            var selectedZodiac1 = (string)firstPicker.SelectedItem;
            var selectedZodiac2 = (string)secondPicker.SelectedItem;

            int compatibilityPercentage = CalculateCompatibilityPercentage(selectedZodiac1, selectedZodiac2);
            compatibilityLabel.Text = $"Совместимость: {compatibilityPercentage}%";

            if (compatibilityPercentage >= 70)
            {
                this.BackgroundColor = Color.LightGreen;
            }
            else if (compatibilityPercentage >= 50 && compatibilityPercentage < 70)
            {
                this.BackgroundColor = Color.LightYellow;
            }
            else
            {
                this.BackgroundColor = Color.LightCoral;
            }
        }

        private int CalculateCompatibilityPercentage(string zodiacSign1, string zodiacSign2)
        {
            if (string.IsNullOrEmpty(zodiacSign1) || string.IsNullOrEmpty(zodiacSign2))
            {
                return 0;
            }

            if (compatibilityMatrix.ContainsKey(zodiacSign1))
            {
                if (compatibilityMatrix[zodiacSign1].ContainsKey(zodiacSign2))
                {
                    return compatibilityMatrix[zodiacSign1][zodiacSign2];
                }
            }

            return 0;
        }

        private void OpenLink()
        {
            if (Uri.TryCreate("https://www.kp.ru/woman/goroskop/sovmestimost-znakov-zodiaka/", UriKind.Absolute, out Uri uri))
            {
                Xamarin.Essentials.Browser.OpenAsync(uri);
            }
        }
    }
}