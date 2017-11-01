using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ELibraryManager.Command;
using ELibraryManager.Model;

namespace ELibraryManager.ViewModel
{
    class FilterViewModel :  BaseViewModel, IFilter
    {
        
        private List<FilterEntry> filterEntries;

        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Action CloseAction { get; set; }


        public virtual void OnStartUp(List<FilterEntry> filterEntrie)
        {
            
        }

        public virtual void OnFilterItem1Changed(List<FilterEntry> filterEntries)
        {
            SetFilterAlgorithm(0, filterEntries);
        }

        public virtual void OnFilterItem2Changed(List<FilterEntry> filterEntries)
        {
            SetFilterAlgorithm(0, filterEntries);
            SetFilterAlgorithm(1, filterEntries);
        }

        public virtual void OnFilterItem3Changed(List<FilterEntry> filterEntries)
        {
            SetFilterAlgorithm(0, filterEntries);
            SetFilterAlgorithm(1, filterEntries);
            SetFilterAlgorithm(2, filterEntries);
        }

        public virtual void OnFilterItem4Changed(List<FilterEntry> filterEntries)
        {
            SetFilterAlgorithm(0, filterEntries);
            SetFilterAlgorithm(1, filterEntries);
            SetFilterAlgorithm(2, filterEntries);
            SetFilterAlgorithm(3, filterEntries);
        }

        public virtual void SetFilterAlgorithm(int index, List<FilterEntry> filterEntries)
        {
            throw new NotImplementedException();
        }

        public FilterViewModel()
        {

            filterEntries = new List<FilterEntry>();
            OkCommand = new ActionCommand(OnOkExecuted, OnOKCanExecute);
            CancelCommand = new ActionCommand(OnCancelExecuted, OnCancelCanExecute);

            for (int i = 0; i < 4; i++)
            {
                FilterEntry Entry = new FilterEntry();
                Entry.FilterOperation = new List<String>();
                Entry.FilterItem = new List<String>();
                Entry.FilterOperation.Add("Greater than");
                Entry.FilterOperation.Add("Less than");
                Entry.FilterOperation.Add("is Equal");
                Entry.FilterValue = "";
                filterEntries.Add(Entry);
            }

            OnStartUp(filterEntries);
        }

        private bool OnCancelCanExecute(object arg)
        {
            return true;
        }

        private void OnCancelExecuted(object obj)
        {
            CloseAction();
        }

        private bool OnOKCanExecute(object arg)
        {
            return true;
        }

        private void OnOkExecuted(object obj)
        {
            CloseAction();
        }

        #region EventHandler

        public int FilterItem0SelectedValue
        {
            get { return filterEntries[0].FilterItemSelectedValue; }
            set
            {
                filterEntries[0].FilterItemSelectedValue = value;
                Changed("FilterItem0");
            }
        }

        public int FilterItem1SelectedValue
        {
            get { return filterEntries[1].FilterItemSelectedValue; }
            set
            {
                filterEntries[1].FilterItemSelectedValue = value;
                Changed("FilterItem1");
            }
        }

        public int FilterItem2SelectedValue
        {
            get { return filterEntries[2].FilterItemSelectedValue; }
            set
            {
                filterEntries[2].FilterItemSelectedValue = value;
                Changed("FilterItem2");
            }
        }

        public int FilterItem3SelectedValue
        {
            get { return filterEntries[3].FilterItemSelectedValue; }
            set
            {
                filterEntries[3].FilterItemSelectedValue = value;
                Changed("FilterItem3");
            }
        }

        public int FilterOperation0SelectedValue
        {
            get { return filterEntries[0].FilterOperationSelectedValue; }
            set
            {
                filterEntries[0].FilterOperationSelectedValue = value;
                Changed("FilterOperation0");
            }            
        }

        public int FilterOperation1SelectedValue
        {
            get { return filterEntries[1].FilterOperationSelectedValue; }
            set
            {
                filterEntries[1].FilterOperationSelectedValue = value;
                Changed("FilterOperation1");
            }
        }

        public int FilterOperation2SelectedValue
        {
            get { return filterEntries[2].FilterOperationSelectedValue; }
            set
            {
                filterEntries[2].FilterOperationSelectedValue = value;
                Changed("FilterOperation2");
            }
        }

        public int FilterOperation3SelectedValue
        {
            get { return filterEntries[3].FilterOperationSelectedValue; }
            set
            {
                filterEntries[3].FilterOperationSelectedValue = value;
                Changed("FilterOperation3");
            }
        }

        public string FilterValue0
        {
            get { return filterEntries[0].FilterValue; }
            set
            {
                filterEntries[0].FilterValue = value;
                Changed("FilterValue0Changed");
            }
        }

        public string FilterValue1
        {
            get { return filterEntries[1].FilterValue; }
            set
            {
                filterEntries[1].FilterValue = value;
                Changed("FilterValue1Changed");
            }
        }

        public string FilterValue2    
        {
            get { return filterEntries[2].FilterValue; }
            set
            {
                filterEntries[2].FilterValue = value;
                Changed("FilterValue2Changed");
            }
        }

        public string FilterValue3
        {
            get { return filterEntries[3].FilterValue; }
            set
            {
                filterEntries[3].FilterValue = value;
                Changed("FilterValue3Changed");
            }
        }

        public override void OnPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case "FilterItem0":
                    OnFilterItem1Changed(filterEntries);
                    break;
                case "FilterItem1":
                    OnFilterItem2Changed(filterEntries);
                    break;
                case "FilterItem2":
                    OnFilterItem3Changed(filterEntries);
                    break;
                case "FilterItem3":
                    OnFilterItem4Changed(filterEntries);
                    break;
                case "FilterOperation0":
                    OnFilterItem1Changed(filterEntries);
                    break;
                case "FilterOperation1":
                    OnFilterItem2Changed(filterEntries);
                    break;
                case "FilterOperation2":
                    OnFilterItem3Changed(filterEntries);
                    break;
                case "FilterOperation3":
                    OnFilterItem4Changed(filterEntries);
                    break;
                case "FilterValue0Changed":
                    OnFilterItem1Changed(filterEntries);
                    filterEntries[0].FilterValue = FilterValue0;
                    break;
                case "FilterValue1Changed":
                    OnFilterItem2Changed(filterEntries);
                    filterEntries[1].FilterValue = FilterValue1;
                    break;
                case "FilterValue2Changed":
                    OnFilterItem3Changed(filterEntries);
                    filterEntries[2].FilterValue = FilterValue2;
                    break;
                case "FilterValue3Changed":
                    OnFilterItem4Changed(filterEntries);
                    filterEntries[3].FilterValue = FilterValue3;
                    break;
            }
        }

        #endregion

        public List<FilterEntry> FilterEntries
        {
            get { return this.filterEntries; }
        }

    }
}
