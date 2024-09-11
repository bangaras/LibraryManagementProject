using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProject
{
    public class DBOperations
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Author> Authors { get; set; } = new List<Author>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public void AddAuthor(Author author)
        {
            Authors.Add(author);
        }
        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }

        public void DeleteBook(string bookISBN)
        {
            try
            {
                var book = Books.FirstOrDefault(x => x.ISBN == bookISBN);
                if (book != null)
                {
                    Books.Remove(book);
                    Console.WriteLine("Book Deleted Successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please check the error and try again!: "+ex.Message);
            }


        }
        public void PrintBooksByPublishDate()
        {
            try
            {
                var sortedList = Books.OrderBy(x => x.PublishedDate).ToList();
                foreach (var book in sortedList)
                {
                    Console.WriteLine($"Title: {book.BookTitle} Author: {book.Author.Name} Category: {book.Category.Name} Published Date: {book.PublishedDate}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please check the error and try again!: " + ex.Message);
            }
        }

        public void PrintBooksGroupByAuthor()
        {
            try
            {
                var groupedList = Books.GroupBy(x => x.Author.Name).Select(y => new { Author = y.Key, Books = y.ToList() });
                foreach (var book in groupedList)
                {
                    Console.WriteLine($"Author Name: {book.Author} Count: {book.Books.Count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please check the error and try again!: " + ex.Message);
            }
        }
        public void PrintBooksByCategory(string categoryName)
        {
            try
            {
                var BookListByCateogory = Books.Where(x => x.Category.Name == categoryName).ToList();
                foreach (var book in BookListByCateogory)
                {
                    Console.WriteLine($"Title: {book.BookTitle} Author: {book.Author.Name} Category: {book.Category.Name} Published Date: {book.PublishedDate}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please check the error and try again!: " + ex.Message);
            }
        }
        public void SearchBooks(string searchValue)
        {
            try
            {
                if(!String.IsNullOrEmpty(searchValue))
                {
                    var Resultdata = Books.Where(x=>x.BookTitle.Contains(searchValue) || x.Author.Name.Contains(searchValue) || x.Category.Name.Contains(searchValue));

                    if(Resultdata != null)
                    {
                        foreach (var book in Resultdata)
                        {
                            Console.WriteLine($"Title: {book.BookTitle} Author: {book.Author.Name} Category: {book.Category.Name} Published Date: {book.PublishedDate}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No results found!");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please check the error and try again!: " + ex.Message);
            }
        }
        public void PrintAuthors()
        {
            try
            {
                var UniqueAuthors = Authors.Select(x => x.Name).Distinct().ToList();
                foreach (var author in UniqueAuthors)
                {
                    Console.WriteLine($"{author}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please check the error and try again!: " + ex.Message);
            }
        }

    }


}
