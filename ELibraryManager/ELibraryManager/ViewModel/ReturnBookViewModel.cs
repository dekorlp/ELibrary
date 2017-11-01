using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ELibraryManager.Command;

namespace ELibraryManager.ViewModel
{
    public class ReturnBookViewModel : BaseViewModel
    {
        private List<Book> _filteredBookList;
        private Book _selectedBookItem;

        public ICommand ReturnBookCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public Action CloseAction { get; set; }

        public ReturnBookViewModel()
        {
            ReturnBookCommand = new ActionCommand(ReturnBookExecute, ReturnBookCanExecute);
            CancelCommand = new ActionCommand(x => CloseAction(), x =>  true);

            RefreshListView();
        }

        public void RefreshListView()
        {
            _filteredBookList = new List<Book>();
            _filteredBookList = (from bList in BookViewModel.books
                where (bList.RentToUser != null)
                select bList).ToList();
        }

        private bool ReturnBookCanExecute(object arg)
        {
            if (SelectedBookItem == null) return false;
            return true;
        }

        private void ReturnBookExecute(object obj)
        {
            _selectedBookItem.RentToUser.RentedBooks.Remove(_selectedBookItem);
            _selectedBookItem.RentToUser = null;
            RefreshListView();
            MainWindow.GetMainViewModel().refreshDataView();
            Changed("FilteredBookList");
        }

        public List<Book> FilteredBookList
        {
            get { return _filteredBookList; }
            set
            {
                _filteredBookList = value;
                Changed("FilteredBookList");
            }
        }

        public Book SelectedBookItem
        {
            get { return _selectedBookItem; }
            set
            {
                _selectedBookItem = value;
                Changed("SelectedBookItem");
            }
        }

    }
}
