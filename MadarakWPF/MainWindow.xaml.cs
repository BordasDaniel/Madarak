using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MadarakWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<MadarakCLI.Madar> madarak = new();
        public MainWindow()
        {
            InitializeComponent();
            string allomany = "madarak.txt";
            madarak = MadarakCLI.Program.Beolvas(allomany);
            dgMadarak.ItemsSource = madarak;

        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            if (dgMadarak.SelectedItem != null)
            {
                var madar = (MadarakCLI.Madar)dgMadarak.SelectedItem;

                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "Mentés másként";
                fileDialog.Filter = "Szöveges állomány|*.txt|Minden|*.*";
                fileDialog.FileName = $"{madar.MagyarNev}.txt";
                fileDialog.ShowDialog();
         
                try
                {
                    using (StreamWriter ir = new(fileDialog.FileName))
                    {
                        ir.WriteLine($"{madar.MagyarNev} ({madar.LatinNev})\n" +
                                          $"Eszmei értéke: {madar.Ertek}Ft\n" +
                                          $"Védetté nyílvánítva: {madar.Ev}");
                    }
                    MessageBox.Show("Sikeres mentés!");
                    }
                catch (Exception ex)
                {
                    MessageBox.Show("Sikertelen mentés! " + ex);
                }
            }
            else
            {
                MessageBox.Show("Nincs menthető adat!");
            }
        }
    }
}