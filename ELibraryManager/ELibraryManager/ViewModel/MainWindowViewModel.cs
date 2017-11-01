using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ELibraryManager.HelperClasses;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ELibraryManager.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public List<Book> _books;

        public MainWindowViewModel()
        {
            BinarySerialization binSerialization = new BinarySerialization();
            BookList = new List<Book>();

            try
            {
                binSerialization.Deserialize();
            }
            catch (FileNotFoundException e)
            {
                //MessageBox.Show("File can not be open", "Error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            refreshDataView();

            // save all 5 Minutes 
            Task.Run(() => binSerialization.SaveFilePeriodically());

        }

        public List<Book> BookList
        {
            get { return _books; }
            set
            {
                _books = value;
                Changed("BookList");
            }
        }

        public void refreshDataView()
        {
            BookList = new List<Book>();
            BookList = BookViewModel.books;
        }
    }
}
