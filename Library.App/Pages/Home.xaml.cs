using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (BookList.Count() != 0)
            {
                string appRootPath = AppDomain.CurrentDomain.BaseDirectory;
                imgOldBook.Source = new BitmapImage(new Uri((appRootPath + BookList.OrderBy(u => u.Date).Take(1).FirstOrDefault().Image)));
                imgNewestBook.Source = new BitmapImage(new Uri((appRootPath + BookList.OrderByDescending(u => u.Date).Take(1).FirstOrDefault().Image)));
                imgFavoriteBook.Source = new BitmapImage(new Uri((appRootPath + BookList.OrderByDescending(u => u.Likes).Take(1).FirstOrDefault().Image)));
                imgBestBook.Source = new BitmapImage(new Uri((appRootPath + BookList.OrderByDescending(u => u.Scores).Take(1).FirstOrDefault().Image)));
                btnOldBook.IsEnabled = btnNewestBook.IsEnabled = btnFavoriteBook.IsEnabled = btnBestBook.IsEnabled = true;
            }
        }
    }
}
