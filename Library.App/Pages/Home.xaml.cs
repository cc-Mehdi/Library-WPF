using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Datalayer.Repository.IRepository;

namespace Library.App.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Datalayer.Books> BookList { get; set; }

        public Home(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BookList = _unitOfWork.Book.GetAll();
            if (BookList != null)
            {
                //imgOldBook.Source = new BitmapImage(new Uri(@"\images\" + _unitOfWork.Book.GetOldestBook().Image));
                //imgNewestBook.Source = new BitmapImage(new Uri(@"\images\" + _unitOfWork.Book.GetNewestBook().Image));
                //imgFavoriteBook.Source = new BitmapImage(new Uri(@"\images\" + _unitOfWork.Book.GetFavoriteBook().Image));
                //imgBestBook.Source = new BitmapImage(new Uri(@"\images\" + _unitOfWork.Book.GetBestBook().Image));
            }
        }
    }
}
