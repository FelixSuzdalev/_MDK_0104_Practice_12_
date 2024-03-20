using System;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using ConsoleApp1;
using System.Threading;
namespace WpfApp1
{
    public partial class MainWindow : Window
    {
       const  string TITLE = "DataText";
        public MainWindow()
        {
            InitializeComponent();
            Loading();
        }
        async void Loading()
        {
                int i = 0;
            while (i != 100)
            {
                i++;
                await Task.Delay(50);
                this.Text.HorizontalContentAlignment = HorizontalAlignment.Center;
                this.Text.VerticalContentAlignment = VerticalAlignment.Center;
                this.Text.FontSize = 25;
                Text.Text = "Загрузка = " + i + "%";
                this.Title = TITLE + " - Загрузка = " + i + "%";
            }
            Print();
        }
        async void  Print(string TextOutput = "") 
        {
            await Task.Run(() =>
            {
                string[] FileData = File.ReadAllLines(@"..\..\..\ConsoleApp1\bin\Debug\data.txt");
                TextOutput = string.Join(Environment.NewLine, FileData);
            });
            Text.TextAlignment = TextAlignment.Left;
            this.Text.FontSize = 10;
            this.Title = TITLE;
            Text.Text = TextOutput;
        }
    }
}


