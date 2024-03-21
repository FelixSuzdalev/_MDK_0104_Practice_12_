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
using ConsoleApp1;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System;

namespace _MDK_0104_Practice_12_
{
    public partial class MainWindow : Window
    {
        const string TITLE = "DataText";
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
            var result = MessageBox.Show("Имя и фамилия сохранены.\nХотите отобразить все данные из файла?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                this.Height = 500;
                this.Output.IsHitTestVisible = true;
                await Loading();
                await Print();
            }
            else Close();
        }

        async Task Loading()
        {
            int i = 0;
            while (i != 100)
            {
                i++;
                await Task.Delay(50);
                this.Output.HorizontalContentAlignment = HorizontalAlignment.Center;
                this.Output.VerticalContentAlignment = VerticalAlignment.Center;
                this.Output.FontSize = 20;
                Output.Text = "Загрузка = " + i + "%";
                this.Title = TITLE + " - Загрузка = " + i + "%";
            }
        }
        async Task Print(string TextOutput = "")
        {
            await Task.Run(() =>
            {
                string[] FileData = File.ReadAllLines(@"..\..\..\ConsoleApp1\bin\Debug\data.txt");
                TextOutput = string.Join(Environment.NewLine, FileData);
            });
            Output.TextAlignment = TextAlignment.Left;
            this.Output.FontSize = 10;
            this.Title = TITLE;
            Output.Text = TextOutput;
        }
        

        /*if (result == MessageBoxResult.Yes)
        {
            Button_Safe1.Background = Brushes.LightCoral;
            WpfApp1.MainWindow mainWindow = new WpfApp1.MainWindow();
            mainWindow.Show();
        }*/
    }
}
