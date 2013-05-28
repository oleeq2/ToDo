using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ToDoGUI
{
    /// <summary>
    /// Логика взаимодействия для InitialWindow.xaml
    /// </summary>
    public partial class InitialWindow : Window
    {



        public string Addr
        {
            get { return (string)GetValue(AddrProperty); }
            set { SetValue(AddrProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Addr.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddrProperty =
            DependencyProperty.Register("Addr", typeof(string), typeof(InitialWindow), new UIPropertyMetadata("http://localhost:8000/Item"));

        
        public InitialWindow()
        {
            //this.DataContext = this;
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow(Addr);
            win.Show();
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
