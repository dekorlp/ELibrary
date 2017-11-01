using ELibraryManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryManager
{
    interface IFilter
    {
        int FilterItem0SelectedValue { get; set; }
        int FilterItem1SelectedValue { get; set; }
        int FilterItem2SelectedValue { get; set; }
        int FilterItem3SelectedValue { get; set; }

        int FilterOperation0SelectedValue { get; set; }
        int FilterOperation1SelectedValue { get; set; }
        int FilterOperation2SelectedValue { get; set; }
        int FilterOperation3SelectedValue { get; set; }

        string FilterValue0 { get; set; }
        string FilterValue1 { get; set; }
        string FilterValue2 { get; set; }
        string FilterValue3 { get; set; }

        List<FilterEntry> FilterEntries { get; }

        void OnStartUp(List<FilterEntry> filterEntries);
        void OnFilterItem1Changed(List<FilterEntry> filterEntries);
        void OnFilterItem2Changed(List<FilterEntry> filterEntries);
        void OnFilterItem3Changed(List<FilterEntry> filterEntries);
        void OnFilterItem4Changed(List<FilterEntry> filterEntries);
        void SetFilterAlgorithm(int index, List<FilterEntry> filterEntries);
        void OnPropertyChanged(string propertyName);

    } 
}
