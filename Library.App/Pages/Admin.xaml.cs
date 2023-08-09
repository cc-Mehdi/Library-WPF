﻿using Datalayer.Repository.IRepository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

namespace Library.App.Pages
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Datalayer.Books> BookList { get; set; }
        public IEnumerable<Datalayer.Users> UserList { get; set; }

        OpenFileDialog openFileUser, openFileBook;
        public Admin(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BookList = _unitOfWork.Book.GetAll();
            UserList = _unitOfWork.User.GetAll();
            dgvUsers.ItemsSource = UserList;
            dgvBooks.ItemsSource = BookList;
        }

        private void dgvUsers_AutoGeneratedColumns(object sender, EventArgs e)
        {
            if (dgvUsers.Columns.Count > 0)
            {
                dgvUsers.Columns.Where(a => a.Header.ToString() == "Id").First().Header = "کد";
                dgvUsers.Columns.Where(a => a.Header.ToString() == "UserName").First().Header = "نام کاربری";
                dgvUsers.Columns.Where(a => a.Header.ToString() == "Email").First().Header = "ایمیل";
                dgvUsers.Columns.Where(a => a.Header.ToString() == "Password").First().Header = "کلمه عبور";
                dgvUsers.Columns.Where(a => a.Header.ToString() == "isSpecial").First().Header = "کاربر ویژه";
                dgvUsers.Columns[5].Visibility = Visibility.Collapsed;
                dgvUsers.Columns[6].Visibility = Visibility.Collapsed;
            }
        }

        private void dgvBooks_AutoGeneratedColumns(object sender, EventArgs e)
        {
            if (dgvBooks.Columns.Count > 0)
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

        private void btnSelectUserImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files(*.png; *.jpeg)| *.png; *.jpeg | All files(*.*) | *.* ";
            if (openFile.ShowDialog() == true)
                imgUser.Source = new BitmapImage(new Uri(openFile.FileName));
            openFileUser = openFile;
        }

        private void btnSelectBookImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files(*.png; *.jpeg)| *.png; *.jpeg | All files(*.*) | *.* ";
            if (openFile.ShowDialog() == true)
                imgBook.Source = new BitmapImage(new Uri(openFile.FileName));
            openFileBook = openFile;
        }

        private void txtCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtCount.Text != "")
            checkjustNumber(txtCount);
        }

        private void checkjustNumber(TextBox txt)
        {
            try
            {
                int.Parse(txt.Text);
            }
            catch (Exception)
            {
                txt.Text = "";
                MessageBox.Show("لطفا فقط عدد وارد کنید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            if (txtBookName.Text != "" && txtCategory.Text != "" && txtPrice.Text != "" && int.Parse(txtCount.Text) < 1)
            {
                if (openFileUser.FileName != "")
                {
                    //create new uniq name
                    string imageName_new = Guid.NewGuid().ToString();
                    //get images save directory
                    var appRootPath = AppDomain.CurrentDomain.BaseDirectory;
                    //get image extension
                    var extension = Path.GetExtension(imgUser.Source.ToString());
                    //get complete image path for save
                    string fullImagePath = @"images\" + imageName_new + extension;

                    File.Copy(openFileUser.FileName, AppDomain.CurrentDomain.BaseDirectory + fullImagePath);

                    Datalayer.Users newUser = new Datalayer.Users()
                    {
                        UserName = txtUserName.Text,
                        Email = txtEmail.Text,
                        Password = txtPassword.Text,
                        isSpecial = false,
                        Image = fullImagePath
                    };

                    _unitOfWork.User.Add(newUser);
                    _unitOfWork.Save();

                    dgvUsers.ItemsSource = _unitOfWork.User.GetAll();
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفق", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                    MessageBox.Show("لطفا یک تصویر انتخاب کنید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("لطفا فیلدها را پر کنید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void txtLikes_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtLikes.Text != "")
                checkjustNumber(txtLikes);
        }

        private void txtScores_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtScores.Text != "")
                checkjustNumber(txtScores);
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if(txtUserName.Text != "" && txtEmail.Text != "" && txtPassword.Text != "")
            {
                if(openFileUser.FileName != "")
                {
                    //create new uniq name
                    string imageName_new = Guid.NewGuid().ToString();
                    //get images save directory
                    var appRootPath = AppDomain.CurrentDomain.BaseDirectory;
                    //get image extension
                    var extension = Path.GetExtension(imgUser.Source.ToString());
                    //get complete image path for save
                    string fullImagePath = @"images\" + imageName_new + extension;

                    File.Copy(openFileUser.FileName, AppDomain.CurrentDomain.BaseDirectory + fullImagePath);

                    Datalayer.Users newUser = new Datalayer.Users()
                    {
                        UserName = txtUserName.Text,
                        Email = txtEmail.Text,
                        Password = txtPassword.Text,
                        isSpecial = false,
                        Image = fullImagePath
                    };

                    _unitOfWork.User.Add(newUser);
                    _unitOfWork.Save();

                    dgvUsers.ItemsSource = _unitOfWork.User.GetAll();
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفق", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                    MessageBox.Show("لطفا یک تصویر انتخاب کنید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("لطفا فیلدها را پر کنید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
