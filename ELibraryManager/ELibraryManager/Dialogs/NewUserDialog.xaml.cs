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
using System.Windows.Shapes;
using ELibraryManager.ViewModel;

namespace ELibraryManager
{
    /// <summary>
    /// Interaction logic for NewBookWindow.xaml
    /// </summary>
    public partial class NewUserDialog : Window
    {
        private UserViewModel _userViewModel;

        public NewUserDialog()
        {
            InitializeComponent();
            _userViewModel = new UserViewModel();
            this.DataContext = _userViewModel;
            if(_userViewModel.CloseAction == null)
            _userViewModel.CloseAction = new Action(() => this.Close());
        }
    }
}
