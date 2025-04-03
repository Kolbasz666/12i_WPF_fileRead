using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _12i_WPF_fileRead
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int num = -1;
        FileManager file;
        List<Cars> all;
        public MainWindow()
        {
            InitializeComponent();
            file = new FileManager("data.txt");
            Start();
        }
        void Start()
        {
            all = file.ReadFile();
            everything.Children.Clear();
            foreach (Cars item in all)
            {
                Label oneLabel = new Label() { Content = item.Model, FontSize = 20, Tag = item };
                oneLabel.MouseLeftButtonUp += CarClick;
                oneLabel.MouseRightButtonUp += EditClick;
                everything.Children.Add(oneLabel);
            }
        }
        void EditClick(object s, EventArgs e)
        {
            Label oneLabel = s as Label;
            Cars oneCar = oneLabel.Tag as Cars;
            num = all.IndexOf(oneCar);
            ManufacturerInput.Text = oneCar.Manufacturer;
            ModelInput.Text = oneCar.Model;
            PowerInput.Text = oneCar.Power.ToString();
            WeightInput.Text = oneCar.Weight.ToString();
            EditButton.IsEnabled = true;
        }
        void CarClick(object sender, EventArgs e)
        {
            Label oneLabel = sender as Label;
            Cars oneCar = oneLabel.Tag as Cars;
            MessageBox.Show($"Gyártó: {oneCar.Manufacturer}, Modell: {oneCar.Model}, Teljesítmény: {oneCar.Power}, Súly: {oneCar.Weight}");
        }
        void CreateEvent(object s, EventArgs e)
        {
            if (EditButton.IsEnabled)
            {
                EditButton.IsEnabled = false;
                ManufacturerInput.Text = "";
                ModelInput.Text = "";
                PowerInput.Text = "";
                WeightInput.Text = "";
                return;
            }
            string manufacturer = ManufacturerInput.Text;
            string model = ModelInput.Text;
            int power = -1;
            int weight = -1;
            if (!CheckEvrything(manufacturer, model, ref power, ref weight)) return;
            Cars oneCar = new Cars(manufacturer, model, power, weight);
            file.WriteOneLine(oneCar);
            Start();
        }
        bool CheckEvrything(string manufacturer, string model, ref int power, ref int weight)
        {
            string powerString = PowerInput.Text;
            string weightString = WeightInput.Text;

            if (manufacturer.Length < 2)
            {
                MessageBox.Show("Kérlek helyesen add meg a gyártót");
                return false;
            }
            if (model.Length < 2)
            {
                MessageBox.Show("Kérlek helyesen add meg a modellt");
                return false;
            }
            if (powerString.Length < 1)
            {
                MessageBox.Show("Kérlek add meg helyesen a teljesítményt");
                return false;
            }
            if (!int.TryParse(powerString, out power))
            {
                MessageBox.Show("A teljesítménynek számnak kell lenni!");
                return false;
            }
            if (weightString.Length < 3)
            {
                MessageBox.Show("Add meg helyesen az autó súlyát");
                return false;
            }
            if (!int.TryParse(weightString, out weight))
            {
                MessageBox.Show("A súlynak számnak kell lenni!");
                return false;
            }
            //MessageBox.Show("Check power: " + power);
            return true;
        }
        void EditEvent(object s, EventArgs e)
        {
            all[num].Manufacturer = ManufacturerInput.Text;
            all[num].Model = ModelInput.Text;
            all[num].Power = int.Parse(PowerInput.Text);
            all[num].Weight = int.Parse(WeightInput.Text);
            file.WriteEverything(all);
            Start();
        }
    }
}
