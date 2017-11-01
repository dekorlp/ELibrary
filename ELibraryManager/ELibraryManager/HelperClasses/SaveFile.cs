using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryManager.HelperClasses
{
    [Serializable]
    class SaveFile
    {
        public List<Book> books { get; set; }
        public List<User> users { get; set; }
    }
}
