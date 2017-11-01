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
    /// Interaction logic for ReturnBookDialog.xaml
    /// </summary>
    public partial class ReturnBookDialog : Window
    {
        private ReturnBookViewModel _returnBookViewModel;

        public ReturnBookDialog()
        {
            InitializeComponent();
            _returnBookViewModel = new ReturnBookViewModel();
            this.DataContext = _returnBookViewModel;
            if (_returnBookViewModel.CloseAction == null)
                _returnBookViewModel.CloseAction = new Action(() => this.Close());
        }
    }
}
