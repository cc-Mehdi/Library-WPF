﻿using Datalayer.Repository;
using Datalayer.Repository.IRepository;
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
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Datalayer.Books> BookList { get; set; }
        public Books(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            btnAll.Background = new SolidColorBrush(Color.FromArgb(200, 37, 138, 47));
            btnMoney.Background = btnFree.Background = new SolidColorBrush(Color.FromArgb(200, 85, 101, 123));
            dgvBooks.ItemsSource = BookList;
            FixInterference();
        }

        private void btnMoney_Click(object sender, RoutedEventArgs e)
        {
            btnMoney.Background = new SolidColorBrush(Color.FromArgb(200, 37, 138, 47));
            btnAll.Background = btnFree.Background = new SolidColorBrush(Color.FromArgb(200, 85, 101, 123));
            dgvBooks.ItemsSource = BookList.Where(u => u.Price != 0);
            FixInterference();
        }

        private void btnFree_Click(object sender, RoutedEventArgs e)
        {
            btnFree.Background = new SolidColorBrush(Color.FromArgb(200, 37, 138, 47));
            btnAll.Background = btnMoney.Background = new SolidColorBrush(Color.FromArgb(200, 85, 101, 123));
            dgvBooks.ItemsSource = BookList.Where(u => u.Price == 0);
            FixInterference();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BookList = _unitOfWork.Book.GetAll();
            dgvBooks.ItemsSource = BookList;
            lstCategories.ItemsSource = BookList.Select(u=> u.Category);
        }

        private void dgvBooks_AutoGeneratedColumns(object sender, EventArgs e)
        {
            if(dgvBooks.Columns.Count > 0)
            {
                dgvBooks.Columns.Where(a => a.Header.ToString() == "Id").First().Header = "کد";
                dgvBooks.Columns.Where(a => a.Header.ToString() == "BookName").First().Header = "نام کتاب";
                dgvBooks.Columns.Where(a => a.Header.ToString() == "Category").First().Header = "دسته بندی";
                dgvBooks.Columns.Where(a => a.Header.ToString() == "Price").First().Header = "قیمت";
                dgvBooks.Columns.Where(a => a.Header.ToString() == "Count").First().Header = "تعداد";
                dgvBooks.Columns.Where(a => a.Header.ToString() == "Likes").First().Header = "علاقه‌‌مندی";
                dgvBooks.Columns.Where(a => a.Header.ToString() == "Scores").First().Header = "امتیاز";
                dgvBooks.Columns.Where(a => a.Header.ToString() == "isSpecial").First().Header = "کتاب ویژه";
                dgvBooks.Columns.Where(a => a.Header.ToString() == "Date").First().Header = "تاریخ انتشار";
                dgvBooks.Columns[9].Visibility = Visibility.Collapsed;
                dgvBooks.Columns[10].Visibility = Visibility.Collapsed;
            }
        }


        private void lstSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (lstSort.SelectedValue)
            {
                case "مرتب سازی بر اساس تعداد امتیاز":
                    dgvBooks.ItemsSource = BookList.OrderBy(u => u.Scores);
                    break;
                case "مرتب سازی بر اساس تعداد لایک":
                    dgvBooks.ItemsSource = BookList.OrderBy(u => u.Likes);
                    break;
                case "مرتب سازی بر اساس تاریخ انتشار":
                    dgvBooks.ItemsSource = BookList.OrderBy(u => u.Date);
                    break;
                case "مرتب سازی بر اساس نام کتاب":
                    dgvBooks.ItemsSource = BookList.OrderBy(u => u.BookName);
                    break;
            }
            FixInterference();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgvBooks.ItemsSource = BookList.Where(u => u.BookName.Contains(txtSearch.Text) || u.Category.Contains(txtSearch.Text) || u.Date.ToString().Contains(txtSearch.Text));
            FixInterference();
        }

        //Fix interference in columns from book data grid
        private void FixInterference()
        {
            if(dgvBooks.Items.Count > 0)
            {
                dgvBooks.Columns[0].Visibility = Visibility.Collapsed;
                dgvBooks.Columns[9].Visibility = Visibility.Visible;
            }
        }

        private void btnSpecial_Click(object sender, RoutedEventArgs e)
        {
            dgvBooks.ItemsSource = BookList.Where(u => u.isSpecial == true);
            FixInterference();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (lstCategories.Text != "")
            {
                dgvBooks.ItemsSource = BookList.Where(u => u.Category == lstCategories.Text);
                FixInterference();
            }
            else
                MessageBox.Show("یک دسته بندی انتخاب کنید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
