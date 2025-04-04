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

            /// 5. Feladat
            lblMain.Content += $"5. Feladat: {Cars.Count} autó található a listában.\n";

            /// 6. Feladat
            double osszesEladas = Cars.Select(x => x.EladottDarabszam).Average();
            lblMain.Content += $"6. Feladat: Az autók esetében az átlagosan eladott darabszám {Math.Round(osszesEladas,1)}\n";

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
    }
}