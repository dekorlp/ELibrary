using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryManager
{
    interface IMedium
    {
        int Id
        {
            get;
            set;
        }

        string Name
        { 
            get;
            set;           
        }

        string Launch
        {
            get;
            set;
        }
    }
}
