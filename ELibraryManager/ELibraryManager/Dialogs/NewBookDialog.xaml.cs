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
    public partial class NewBookWindow : Window
    {
        private BookViewModel _bookViewModel;

        public NewBookWindow()
        {
            InitializeComponent();
            _bookViewModel = new BookViewModel();
            this.DataContext = _bookViewModel;
            if(_bookViewModel.CloseAction == null)
            _bookViewModel.CloseAction = new Action(() => this.Close());
        }
    }
}
