using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Library.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Datalayer.Library_DbEntities _db = new Datalayer.Library_DbEntities();
            Datalayer.Repository.IRepository.IUnitOfWork _unitOfWork = new Datalayer.Repository.UnitOfWork(_db);
            MainWindow st = new MainWindow(_unitOfWork);
            st.ShowDialog();
        }
    }
}
