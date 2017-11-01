using ELibraryManager.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
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
using ELibraryManager.HelperClasses;
using ELibraryManager.ViewModel;

namespace ELibraryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindowViewModel _mainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _mainWindowViewModel = new MainWindowViewModel();
            this.DataContext = _mainWindowViewModel;
        }

        private void NewBook_OnClick(object sender, RoutedEventArgs e)
        {
            NewBookWindow newBookWindow = new NewBookWindow();
            newBookWindow.Owner = this;
            newBookWindow.ShowDialog();
        }

        private void NewUser_OnClick(object sender, RoutedEventArgs e)
        {
            NewUserDialog newUserWindow = new NewUserDialog();
            newUserWindow.Owner = this;
            newUserWindow.ShowDialog();
        }

        private void RentBook_OnClick(object sender, RoutedEventArgs e)
        {
            if ((BookViewModel.books != null || UserViewModel.Users != null) &&
                (BookViewModel.books.Count != 0 && UserViewModel.Users.Count != 0))
            {
                RentBookDialog rentBookDialog = new RentBookDialog();
                rentBookDialog.Owner = this;
                rentBookDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Create first books and users", "Missing Arguments", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void ReturnBook_OnClick(object sender, RoutedEventArgs e)
        {
            ReturnBookDialog returnBookDialog = new ReturnBookDialog();
            returnBookDialog.Owner = this;
            returnBookDialog.ShowDialog();

        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            BinarySerialization binarySerialization = new BinarySerialization();
            binarySerialization.Serialize();

        }

        private void Open_OnClick(object sender, RoutedEventArgs e)
        {
            BinarySerialization binarySerialization = new BinarySerialization();

            try
            {
                binarySerialization.Deserialize();
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show("File can not be open", "Error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Unsaved data will be lost!", "Save?", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
       
        public static MainWindowViewModel GetMainViewModel()
        {
            return _mainWindowViewModel;
        }



    }
}
