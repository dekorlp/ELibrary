using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELibraryManager.ViewModel;

namespace ELibraryManager.Model
{
    public class FilterEntry
    {
        public List<String> FilterItem { get; set; }
        public List<String> FilterOperation { get; set; }
        public String FilterValue { get; set; }
        public int FilterItemSelectedValue { get; set; }
        public int FilterOperationSelectedValue { get; set; }
    }
}
