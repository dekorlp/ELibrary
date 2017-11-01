using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryManager
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Matrikelnumber { get; set; }
        public string Name { get; set; }
        public List<Book> RentedBooks;
    }
}
