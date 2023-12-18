using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horoskoop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TahtkujudPage : ContentPage
    {
        Editor zodiacEditor;
        Label dateLabel;
        Label descriptionLabel;

        private Dictionary<string, string> zodiacDates = new Dictionary<string, string>{
            { "Jäär", "21.03 - 20.04" },
            { "Sõnn", "21.04 - 21.05" },
            { "Kaksikud", "22.05 - 21.06" },
            { "Vähk", "22.06 - 22.07" },
            { "Lõvi", "23.07 - 22.08" },
            { "Neitsi", "23.08 - 23.09" },
            { "Kaalud", "24.09 - 23.10" },
            { "Skorpion", "24.10 - 21.11" },
            { "Ambur", "22.11 - 20.12" },
            { "Kaljukits", "21.12 - 19.01" },
            { "Veevalaja", "20.01 - 18.02" },
            { "Kalad", "19.02 - 20.03" }
        };

        private Dictionary<string, string> zodiacDescriptions = new Dictionary<string, string>{
            { "Jäär", "ОВЕН\r\nЭнергичные и страстные лидеры, готовые принимать вызовы.\r\nЦитата: \"Огонь в душе, сила в сердце, Овен вперед идет без страха.\"\r\nКамень: Красный яспис." },
            { "Sõnn", "ТЕЛЕЦ\r\nУстойчивые и терпеливые, стремящиеся к комфорту и материальной стабильности.\r\nЦитата: \"Земля под ногами, мир в руках, Телец ведет себя как мудрый мудрец.\"\r\nКамень: Зеленый агат." },
            { "Kaksikud", "БЛИЗНЕЦЫ\r\nОбщительные и адаптивные, с ярким умом и любознательностью.\r\nЦитата: \"Две стороны, два лица, Близнецы танцуют в вальсе чувств.\"\r\nКамень: Цитрин." },
            { "Vähk", "РАК\r\nЗаботливые и семейные, с выраженной интуицией и эмоциональной чувствительностью.\r\nЦитата: \"Луна в сердце, Рак мягко обнимает, Любовь его светит, словно свеча.\"\r\nКамень: Жемчуг." },
            { "Lõvi", "ЛЕВ\r\nУверенные и великодушные лидеры, стремящиеся к признанию и почитанию.\r\nЦитата: \"Лев гордо взирает, силу свою проявляет, Король среди знаков, в великолепии красуется.\"\r\nКамень: Карнеол." },
            { "Neitsi", "ДЕВА\r\nАналитичные и практичные, с острым умом и стремлением к совершенству.\r\nЦитата: \"Дева трудолюбива и чиста, Душа ее ясна, как вода и ветер.\"\r\nКамень: Сапфир." },
            { "Kaalud", "ВЕСЫ\r\nДипломатичные и гармоничные, ищущие баланс и красоту во всем.\r\nЦитата: \"Весы весы в гармонии мечтают, Любовь и справедливость в сердце своем хранят.\"\r\nКамень: Лазурит." },
            { "Skorpion", "СКОРПИОН\r\nСтрастные и уверенные, глубокие и таинственные личности.\r\nЦитата: \"Скорпион, как ночь, темен и горделив, Тайны его - ключ к миру загадочному.\"\r\nКамень: Турмалин." },
            { "Ambur", "СТРЕЛЕЦ\r\nОптимистичные и свободолюбивые, стремящиеся к приключениям и познанию.\r\nЦитата: \"Стрелец стрелы свои в небо запускает, Смех и радость в душе своей хранит.\"\r\nКамень: Топаз." },
            { "Kaljukits", "КОЗЕРОГ\r\nЦелеустремленные и ответственные, строящие свой путь к успеху.\r\nЦитата: \"Козерог гордо вверх взирает, Стремление его к вершинам несокрушимо.\"\r\nКамень: Гранат." },
            { "Veevalaja", "ВОДОЛЕЙ\r\nОригинальные и инновационные, с любовью к свободе и гуманизму.\r\nЦитата: \"Водолей, как ветер перемен, Сердце его бьется в ритме свободы.\"\r\nКамень: Аметист." },
            { "Kalad", "РЫБЫ\r\nЧувствительные и креативные, с богатым внутренним миром и эмпатией.\r\nЦитата: \"Рыбы в мечтах своих плывут, Океан их чувств многогранен и глубок.\"\r\nКамень: Аквамарин." }
        };

        public TahtkujudPage()
        {
            InitializeComponent();

            zodiacEditor = new Editor
            {
                Placeholder = "Введите знак зодиака с большой буквы и на эстонском",
                VerticalOptions = LayoutOptions.StartAndExpand, // Изменено на StartAndExpand
                Margin = new Thickness(20)
            };

            dateLabel = new Label
            {
                Text = "Даты: ",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand, // Изменено на StartAndExpand
                Margin = new Thickness(20, -10, 20, 0) // Отрицательное значение для сокращения расстояния вверх
            };

            descriptionLabel = new Label
            {
                Text = "Описание: ",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand // Изменено на StartAndExpand
            };

            Button showInfoButton = new Button
            {
                Text = "Показать информацию",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand, // Изменено на StartAndExpand
                Margin = new Thickness(20)
            };

            showInfoButton.Clicked += ShowInfoButton_Clicked;

            var stackLayout = new StackLayout
            {
                Children = { zodiacEditor, showInfoButton, dateLabel, descriptionLabel },
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20),
                Spacing = 10 // Задайте значение, которое вам подходит
            };

            Content = stackLayout;
        }

        private void ShowInfoButton_Clicked(object sender, EventArgs e)
        {
            string enteredZodiac = zodiacEditor.Text.Trim();

            if (zodiacDates.ContainsKey(enteredZodiac) && zodiacDescriptions.ContainsKey(enteredZodiac))
            {
                string dates = zodiacDates[enteredZodiac];
                string description = zodiacDescriptions[enteredZodiac];

                dateLabel.Text = $"Даты: {dates}";
                descriptionLabel.Text = $"Описание: {description}";
            }
            else
            {
                DisplayAlert("Ошибка", "Знак зодиака не найден", "OK");
            }
        }

        private string GetZodiacDescription(string zodiacSign)
        {
            if (zodiacDescriptions.ContainsKey(zodiacSign))
            {
                return zodiacDescriptions[zodiacSign];
            }
            else
            {
                return "Описание не найдено";
            }
        }
    }
}