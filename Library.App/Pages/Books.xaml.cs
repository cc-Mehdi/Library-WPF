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

namespace Library.App.Pages
{
    /// <summary>
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class Books : Page
    {
        public Books()
        {
            InitializeComponent();
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            btnAll.Background = new SolidColorBrush(Color.FromArgb(200, 37, 138, 47));
            btnMoney.Background = btnFree.Background = new SolidColorBrush(Color.FromArgb(200, 85, 101, 123));
        }

        private void btnMoney_Click(object sender, RoutedEventArgs e)
        {
            btnMoney.Background = new SolidColorBrush(Color.FromArgb(200, 37, 138, 47));
            btnAll.Background = btnFree.Background = new SolidColorBrush(Color.FromArgb(200, 85, 101, 123));
        }

        private void btnFree_Click(object sender, RoutedEventArgs e)
        {
            btnFree.Background = new SolidColorBrush(Color.FromArgb(200, 37, 138, 47));
            btnAll.Background = btnMoney.Background = new SolidColorBrush(Color.FromArgb(200, 85, 101, 123));
        }
    }
}
