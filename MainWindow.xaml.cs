using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VIZSGA_KOROM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Auto> Cars { get; set; } = new();
        public MainWindow()
        {
            InitializeComponent();
            ReadFile("autok.csv");

            ConsoleFeladat();

        }
        public void ReadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath).ToList();

                lines.RemoveAt(0);

                foreach (var line in lines)
                {
                    Cars.Add(new Auto(line));
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void ConsoleFeladat()
        {
            /// 5. Feladat
            lblMain.Content += $"5. Feladat: {Cars.Count} autó található a listában.\n";

            /// 6. Feladat
            double osszesEladas = Cars.Select(x => x.EladottDarabszam).Average();
            lblMain.Content += $"6. Feladat: Az autók esetében az átlagosan eladott darabszám {Math.Round(osszesEladas, 1)}\n";

            /// 7. Feladat
            lblMain.Content += ("7. feladat: Az elmúlt 5 évben gyártott autók:\n");

            int currentYear = DateTime.Now.Year;

            foreach (var item in Cars)
            {
                if (item.GyartasiEv > currentYear - 5)
                {
                    lblMain.Content += $"\t- {item.Marka} {item.Modell}: {item.GyartasiEv}\n";
                }
            }

            /// 8. Feladat
            lblMain.Content += "8. feladat: Legsikeresebb márkák listája az eladott darabszám alapján:\n";

            List<string> Manufacturers = Cars.Select(x=> x.Marka).Distinct().ToList();

            foreach (var manufacturer in Manufacturers)
            {
                lblMain.Content += $"\t- {manufacturer}: {Cars.Where(x => x.Marka == manufacturer).Select(x => x.EladottDarabszam).Sum()} darab\n";
            }

        }
    }
}