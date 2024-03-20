using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.IO;
using System.Diagnostics;
using ConsoleApp1;
using System.Data.SqlTypes;
using System.Windows.Markup;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

         public MainWindow()
        {
           InitializeComponent();
           Print();
        }
          async public Task Print() 
         {
            string fileContent = await Task.Run(() => File.ReadAllText(@"..\..\..\ConsoleApp1\bin\Debug\data.txt"));
            Text.Text = fileContent;
        }
    }
}


