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
using System.IO;
using WpfApp1;
using ConsoleApp1;
using System.Runtime.CompilerServices;

namespace _MDK_0104_Practice_12_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Button_Safe(object sender, RoutedEventArgs e)
        {
            string NameSurname = Name.Text + " " + Surname.Text;
            string FileWay = @"..\..\..\ConsoleApp1\bin\Debug\data.txt";
            using (StreamWriter writer = File.AppendText(FileWay))
            {
                writer.WriteLine(NameSurname);
            }
            var result = MessageBox.Show("Имя и фамилия сохранены.\nХотите отобразить все данные из файла?","Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                Print();
            }
            
            /*if (result == MessageBoxResult.Yes)
            {
                Button_Safe1.Background = Brushes.LightCoral;
                WpfApp1.MainWindow mainWindow = new WpfApp1.MainWindow();
                mainWindow.Show();
            }*/
        }
        
        public void Print() 
        {
            WpfApp1.MainWindow mainWindow = new WpfApp1.MainWindow();
            mainWindow.Show();
        }
    }
}