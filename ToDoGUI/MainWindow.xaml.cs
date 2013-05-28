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


        public ItemListWrapper List
        {
            get { return (ItemListWrapper)GetValue(ListProperty); }
            set { SetValue(ListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for List.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListProperty =
            DependencyProperty.Register("List", typeof(ItemListWrapper), typeof(MainWindow), new UIPropertyMetadata(null));



        public MainWindow(string addr)
        {
            this.DataContext = this;
            InitializeComponent();
            List = new ItemListWrapper();
            List.Add(new Item("title","",DateTime.Now,new List<string>()));
        }
    }
}
