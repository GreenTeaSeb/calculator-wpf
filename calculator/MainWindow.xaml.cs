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

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
        }

        private void close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void but(object sender, RoutedEventArgs e)
        {
            var name = ((Button)sender).Content.ToString();
            output.Text += name;
        }

        private void delete_last(object sender, RoutedEventArgs e)
        {
            var cur = output.Text;
            if(!string.IsNullOrEmpty(cur))
            output.Text = cur.Remove(cur.Length - 1);
        }

        private void equals(object sender, RoutedEventArgs e)
        {
            try
            {
                var res = new System.Data.DataTable().Compute(output.Text.ToString(), "");
                output.Text = res.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void textbox_key(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    var res = new System.Data.DataTable().Compute(output.Text.ToString(), "");
                    output.Text = res.ToString();
                    output.SelectionStart = output.Text.Length;
                    output.SelectionLength = 0;
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
