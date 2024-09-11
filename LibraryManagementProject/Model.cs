using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProject
{
    public class Book
    {
        public string BookTitle { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }

    }
    public class Author
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }

    }
    public class Category
    {
        public string Name { get; set; }

    }

}
