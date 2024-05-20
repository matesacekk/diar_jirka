using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class AddEntryWindow : Window
    {
        // Veřejná vlastnost pro ukládání textového záznamu
        public string Record { get; set; }

        // Konstruktor třídy
        public AddEntryWindow()
        {
            // Inicializace komponent (UI prvků)
            InitializeComponent();
        }

        // Metoda pro obsluhu kliknutí na tlačítko "Add"
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Načtení vybraného data a formátování jako řetězec
            string selectedDate = datePicker.SelectedDate?.ToString("dd.MM.yyyy");

            // Kontrola, zda bylo vybráno datum
            if (string.IsNullOrEmpty(selectedDate))
            {
                // Zobrazení chybové zprávy, pokud datum nebylo vybráno
                MessageBox.Show("Vyber Datum!!!", "POZOR", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            // Vytvoření textového záznamu spojením data a textu události
            Record = $"{selectedDate} - {eventTextBox.Text}";

            // Nastavení výsledku dialogu na true (úspěšné přidání záznamu)
            DialogResult = true;

            // Zobrazení informační zprávy o úspěšném přidání záznamu
            MessageBox.Show("Gratuluji, Úspěšný zápis", "Informace", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        // Metoda pro obsluhu kliknutí na tlačítko "Cancel"
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Nastavení výsledku dialogu na false (zrušení akce)
            DialogResult = false;
        }
    }
}
