using Datalayer.Repository.IRepository;
using System.Windows;
using System.Windows.Input;

namespace Library.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUnitOfWork _unitOfWork;
        Pages.Home homePage;
        Pages.Books booksPage;
        Pages.Profile profilePage;
        Pages.Admin adminPage;

        bool isMouseDown = false;

        public MainWindow(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        public MainWindow()
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Send Home Page to panel from main layout
            homePage = new Pages.Home(_unitOfWork);
            frame.Content = homePage;
        }

        private void btnMinimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized; 
        }

        private void btnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("آیا از خروج مطمعن هستید ؟", "توجه", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                this.Close();
        }

        private void btnExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(MessageBox.Show("آیا از خروج مطمعن هستید ؟", "توجه", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                this.Close();
        }

        private void btnRefresh_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void btnHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Send Home Page to panel from main layout
            frame.Content = homePage;
        }

        private void btnBooks_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Send Books Page to panel from main layout
            booksPage = new Pages.Books(_unitOfWork);
            frame.Content = booksPage;
        }

        public void openBooks()
        {
            frame.Content = booksPage;
        }


        // App Movement
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            //Get mouse position from app window
            Point pointToWindow = Mouse.GetPosition(this);
            //Get mouse position from whole screen
            Point pointToScreen = PointToScreen(pointToWindow);

            if (isMouseDown)
            {
                this.Top = pointToScreen.Y - 20;
                this.Left = pointToScreen.X - 400;
            }
        }

        private void navbar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = true;
        }

        private void navbar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = false;
        }

        private void navbar_MouseLeave(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
        //End App Movement

        private void btnProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Send Profile Page to panel from main layout
            profilePage = new Pages.Profile();
            frame.Content = profilePage;
        }

        private void btnAdmin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Send Admin Page to panel from main layout
            adminPage = new Pages.Admin();
            frame.Content = adminPage;
        }
    }
}
