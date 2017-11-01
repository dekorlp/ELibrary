using ELibraryManager.Command;
using ELibraryManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ELibraryManager.ViewModel
{
    class BookFilterViewModel : FilterViewModel
    {
        private List<Book> _bookList;
        private Book _selectedBookItem;

        public override void OnStartUp(List<FilterEntry> filterEntries)
        {
            //_bookList = BookViewModel.books;
            _bookList = (from bList in BookViewModel.books
                where (bList.RentToUser == null)
                select bList).ToList();
       
            for (int i = 0; i < 4; i++)
            {
                filterEntries[i].FilterItem.Add("ISBN");
                filterEntries[i].FilterItem.Add("Name");
            }

        }

        public override void OnFilterItem1Changed(List<FilterEntry> filterEntries)
        {
            _bookList = BookViewModel.books;
            SetFilterAlgorithm(0, filterEntries);
            
        }

        public override void OnFilterItem2Changed(List<FilterEntry> filterEntries)
        {
            _bookList = BookViewModel.books;
            SetFilterAlgorithm(0, filterEntries);
            SetFilterAlgorithm(1, filterEntries);
        }

        public override void OnFilterItem3Changed(List<FilterEntry> filterEntries)
        {
            _bookList = BookViewModel.books;
            SetFilterAlgorithm(0, filterEntries);
            SetFilterAlgorithm(1, filterEntries);
            SetFilterAlgorithm(2, filterEntries);
        }

        public override void OnFilterItem4Changed(List<FilterEntry> filterEntries)
        {
            _bookList = BookViewModel.books;
            SetFilterAlgorithm(0, filterEntries);
            SetFilterAlgorithm(1, filterEntries);
            SetFilterAlgorithm(2, filterEntries);
            SetFilterAlgorithm(3, filterEntries);
        }

        public override void SetFilterAlgorithm(int Index, List<FilterEntry> filterEntries)
        {
            if (filterEntries[Index].FilterItemSelectedValue == 1) // NAME
            {
                if (filterEntries[Index].FilterOperationSelectedValue == 0) // IS GREATER THAN
                {
                    try
                    {
                        _bookList = (from s in _bookList
                            where (s.Name.Length > Convert.ToInt32(filterEntries[Index].FilterValue))
                            select s).ToList();
                    }
                    catch (Exception e)
                    {

                    }

                }

                if (filterEntries[Index].FilterOperationSelectedValue == 1) // IS LESS THAN
                {
                    try
                    {

                        _bookList = (from s in _bookList
                                     where (s.Name.Length < Convert.ToInt32(filterEntries[Index].FilterValue))
                            select s).ToList();
                    }
                    catch (Exception e)
                    {

                    }
                }

                if (filterEntries[Index].FilterOperationSelectedValue == 2) // IS EQUAL
                {
                    if (!String.IsNullOrEmpty(filterEntries[Index].FilterValue))
                    {
                        _bookList = (from s in _bookList
                                     where (s.Name.Contains(filterEntries[Index].FilterValue))
                            select s).ToList();
                    }
                }
            }

            if (filterEntries[Index].FilterItemSelectedValue == 0) // ISBN
            {
                if (filterEntries[Index].FilterOperationSelectedValue == 0) // IS GREATER THAN
                {
                    try
                    {
                        _bookList = (from s in _bookList
                            where ( s.Isbn.Length > Convert.ToInt32(filterEntries[Index].FilterValue))
                            select s).ToList();
                    }
                    catch (Exception e)
                    {

                    }

                }

                if (filterEntries[Index].FilterOperationSelectedValue == 1) // IS LESS THAN
                {
                    try
                    {
                        _bookList = (from s in _bookList
                            where (s.Isbn.Length < Convert.ToInt32(filterEntries[Index].FilterValue))
                            select s).ToList();
                    }
                    catch (Exception e)
                    {

                    }
                }

                if (filterEntries[Index].FilterOperationSelectedValue == 2) // IS EQUAL
                {
                    if (!String.IsNullOrEmpty(filterEntries[Index].FilterValue))
                    {
                        _bookList = (from s in _bookList
                            where ( s.Isbn.Contains(filterEntries[Index].FilterValue))
                            select s).ToList();
                    }
                }
            }

            Changed("BookList");
        }


        public List<Book> BookList
        {
            get { return this._bookList; }
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
