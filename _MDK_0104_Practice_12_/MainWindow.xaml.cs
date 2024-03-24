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
using System.Threading;
using System.Collections.Generic;

namespace _MDK_0104_Practice_12_
{
    public partial class MainWindow : Window
    {
        const string TITLE = "DataText";
        bool loaded = false;
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Safe(object sender, RoutedEventArgs e)
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

                Loading();
                Print();
            }
            else Close();
        }

        async void Loading()
        {
            this.Output.HorizontalContentAlignment = HorizontalAlignment.Center;
            this.Output.VerticalContentAlignment = VerticalAlignment.Center;
            this.Output.FontSize = 20;

            while (i != 100)
            {
                i++;
                await Task.Delay(50);
                if (loaded)
                    break;

                Output.Text = "Загрузка = " + i + "%";
                this.Title = TITLE + " - Загрузка = " + i + "%";
            }
            loaded = true;

        }

        async void Print()
        {
            string TextOutput = "";
            await Task.Run(() =>
            {

                Thread.Sleep(5000);
                TextOutput = File.ReadAllText(@"..\..\..\ConsoleApp1\bin\Debug\data.txt");
                Dispatcher.Invoke(() =>
                {
                    loaded = true;
                    this.Output.Text = TextOutput;

                });
            });

            Output.TextAlignment = TextAlignment.Left;
            this.Output.FontSize = 10;
            this.Title = TITLE;

        }
    }
}
