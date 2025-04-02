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
        FileManager file;
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }
        void Start() {
            file = new FileManager("data.txt");
            List<string> all = file.ReadFile();
            foreach (string item in all)
            {
                everything.Children.Add(new Label() { Content = item, FontSize = 20 });
            }
        }
    }
}
