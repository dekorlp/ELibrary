using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using ELibraryManager.Model;
using ELibraryManager.ViewModel;

namespace ELibraryManager
{
    [Serializable]
    public class Book : IMedium ,IEquatable<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Launch { get; set; }
        public string Isbn { get; set; }
        public User RentToUser { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Book objAsBook = obj as Book;
            if (objAsBook == null) return false;
            else return Equals(objAsBook);
        }

        public override int GetHashCode()
        {
            return Isbn.GetHashCode();
        }

        public bool Equals(Book other)
        {
            if (other == null) return false;
            if (this.Isbn == null) return true; // Workaround, could be bugy
            return (this.Isbn.Equals(other.Isbn));
        }

    }
}
