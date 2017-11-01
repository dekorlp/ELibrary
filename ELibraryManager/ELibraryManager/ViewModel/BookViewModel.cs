using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ELibraryManager.Command;
using System.Windows;

namespace ELibraryManager.ViewModel
{
    public class BookViewModel : BaseViewModel
    {
        private Book _book;
        public static List<Book> books;
        public ICommand CreateBookCommand { get; private set; }
        public Action CloseAction { get; set; }




        public BookViewModel()
        {
            _book = new Book();

            if(books == null) books = new List<Book>();
            CreateBookCommand = new ActionCommand(OnCreateBookExecuted, OnCreateBookCanExecute);
        }

        private bool OnCreateBookCanExecute(object arg)
        {

            if (String.IsNullOrEmpty(ISBN) || String.IsNullOrEmpty(Name)) return false;
            return true;
        }

        private void OnCreateBookExecuted(object obj)
        {
            if (String.IsNullOrEmpty(ISBN) || String.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Name or ISBN is missing", "Missing Arguments", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                _book.Id = BookViewModel.books.Count;
                BookViewModel.books.Add(_book);
                MainWindow.GetMainViewModel().refreshDataView();
                CloseAction();
            }
        }

        public int Id
        {
            get { return _book.Id; }
        }


        public string Name
        {
            get { return _book.Name; }
            set
            {
                _book.Name = value;
                Changed("Name");
            }
        }

        public string ISBN
        {
            get { return _book.Isbn; }
            set
            {
                _book.Isbn = value;
                Changed("ISBN");
            }
        }

        

    }
}
