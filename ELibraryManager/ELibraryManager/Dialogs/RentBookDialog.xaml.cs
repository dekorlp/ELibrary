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

namespace ELibraryManager.Dialogs
{
    /// <summary>
    /// Interaction logic for RentBookDialog.xaml
    /// </summary>
    public partial class RentBookDialog : Window
    {
        private RentBookViewModel _rentBookViewModel;
        
        public RentBookDialog()
        {
            InitializeComponent();
            _rentBookViewModel = new RentBookViewModel();
            this.DataContext = _rentBookViewModel;
            if(_rentBookViewModel.CloseAction == null)
            _rentBookViewModel.CloseAction = new Action(() => this.Close());
        }
    }
}
