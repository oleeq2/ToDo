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
using ToDoLib;

namespace ToDoGUI
{
    public partial class MainWindow : Window
    {



        public ViewModel.ToDoListView List
        {
            get { return (ViewModel.ToDoListView)GetValue(ListProperty); }
            set { SetValue(ListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for List.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListProperty =
            DependencyProperty.Register("List", typeof(ViewModel.ToDoListView), typeof(MainWindow), new UIPropertyMetadata(null));

        

        public MainWindow(ItemListClient cli)
        {
            List = new ViewModel.ToDoListView(cli);
            this.DataContext = this;
            InitializeComponent();
        }

        private void MenuAdd(object sender, RoutedEventArgs e)
        {
            AddTask win = new AddTask(List);
            win.Show();
        }

    }
}
