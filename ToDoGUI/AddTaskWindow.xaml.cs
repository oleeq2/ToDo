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
using System.Collections.Generic;
using ToDoLib;
using ToDoGUI.ViewModel;

namespace ToDoGUI
{
    [ValueConversion(typeof(string), typeof(List<string>))]
    public class TagsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Join(",", (List<string>)value);
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = (string)value;
            List<string> ret = new List<string>(str.Split(',').ToList());
            return ret;
        }
    }

    public partial class AddTaskWindow : Window
    {
        
        //public List<String> Tags
        //{
        //    get { return (List<String>)GetValue(TagsProperty); }
        //    set { SetValue(TagsProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Tags.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty TagsProperty =
        //    DependencyProperty.Register("Tags", typeof(List<String>), typeof(AddTask), new UIPropertyMetadata(null));





        //public string ItemTitle
        //{
        //    get { return (string)GetValue(ItemTitleProperty); }
        //    set { SetValue(ItemTitleProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ItemTitle.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ItemTitleProperty =
        //    DependencyProperty.Register("ItemTitle", typeof(string), typeof(AddTask), new UIPropertyMetadata(""));

        

        //public string Description
        //{
        //    get { return (string)GetValue(DescriptionProperty); }
        //    set { SetValue(DescriptionProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty DescriptionProperty =
        //    DependencyProperty.Register("Description", typeof(string), typeof(AddTask), new UIPropertyMetadata(""));




        //public DateTime DeadLine
        //{
        //    get { return (DateTime)GetValue(DeadLineProperty); }
        //    set { SetValue(DeadLineProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for DeadLine.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty DeadLineProperty =
        //    DependencyProperty.Register("DeadLine", typeof(DateTime), typeof(AddTask), new UIPropertyMetadata(DateTime.Now));

        public Item CurrentItem { get; private set; }

        public AddTaskWindow(Item itm = null)
        {
            this.CurrentItem = new Item(itm);
            this.DataContext = CurrentItem;
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
