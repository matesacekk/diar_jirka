using System;
using System.Collections.ObjectModel; // Importuje třídu ObservableCollection pro dynamické kolekce
using System.Windows;
using System.Windows.Controls; // Importuje základní WPF komponenty

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        // Veřejná vlastnost Records, která je kolekcí řetězců. ObservableCollection umožňuje automatické aktualizace UI při změně dat.
        public ObservableCollection<string> Records { get; set; }

        // Konstruktor třídy MainWindow
        public MainWindow()
        {
            InitializeComponent(); // Inicializuje komponenty UI
            Records = new ObservableCollection<string>(); // Vytvoří novou prázdnou kolekci
            listBox.ItemsSource = Records; // Nastaví zdroj dat pro listBox na kolekci Records
        }

        // Metoda pro obsluhu kliknutí na tlačítko "AddRecord"
        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            AddEntryWindow addRecordWindow = new AddEntryWindow(); // Vytvoří nové okno pro přidání záznamu
            addRecordWindow.Owner = this; // Nastaví hlavní okno jako vlastníka nového okna
            if (addRecordWindow.ShowDialog() == true) // Otevře okno a čeká na jeho zavření
            {
                Records.Add(addRecordWindow.Record); // Pokud bylo okno zavřeno s výsledkem true, přidá nový záznam do kolekce
            }
        }

        // Metoda pro obsluhu kliknutí na tlačítko "DeleteRecord"
        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null) // Zkontroluje, zda je vybrán nějaký záznam v listBoxu
            {
                Records.Remove(listBox.SelectedItem.ToString()); // Odstraní vybraný záznam z kolekce
            }
            else
            {
                MessageBox.Show("Vyber záznam ke smazání."); // Pokud není vybrán žádný záznam, zobrazí chybovou zprávu
            }
        }
    }
}
