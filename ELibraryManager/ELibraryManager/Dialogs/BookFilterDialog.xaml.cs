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
    /// Interaction logic for BookFilter.xaml
    /// </summary>
    public partial class BookFilter : Window
    {
        private BookFilterViewModel _bookFilterViewModel;

        public BookFilter()
        {
            InitializeComponent();
            _bookFilterViewModel = new BookFilterViewModel();
            this.DataContext = _bookFilterViewModel;
            if (_bookFilterViewModel.CloseAction == null)
                _bookFilterViewModel.CloseAction = new Action(() => this.Close());
        }
    }
}
