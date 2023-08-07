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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void btnAllBooks_Click(object sender, RoutedEventArgs e)
        {
            btnAllBooks.Background = new SolidColorBrush(Color.FromArgb(200, 37, 37, 43));
            btnUnreadBooks.Background = btnUnreturnedBooks.Background = new SolidColorBrush(Color.FromArgb(200, 85, 101, 123));
        }

        private void btnUnreadBooks_Click(object sender, RoutedEventArgs e)
        {
            btnUnreadBooks.Background = new SolidColorBrush(Color.FromArgb(200, 37, 37, 43));
            btnAllBooks.Background = btnUnreturnedBooks.Background = new SolidColorBrush(Color.FromArgb(200, 85, 101, 123));
        }

        private void btnUnreturnedBooks_Click(object sender, RoutedEventArgs e)
        {
            btnUnreturnedBooks.Background = new SolidColorBrush(Color.FromArgb(200, 37, 37, 43));
            btnUnreadBooks.Background = btnAllBooks.Background = new SolidColorBrush(Color.FromArgb(200, 85, 101, 123));
        }

        private void btnDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("آیا از حذف حساب خود مطمعن هستید ؟", "توجه", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnEditImage.Visibility = Visibility.Visible;
        }
    }
}
