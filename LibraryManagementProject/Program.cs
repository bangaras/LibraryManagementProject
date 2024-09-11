using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProject
{
    public class Program
    {
        public static DBOperations dbOperations = new DBOperations();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($@"---------------------------- \nLibrary Management Project \n ----------------------------
1. Add Book Record
2. Add Author Record
3. Add Category Record
4. Print Books By Published Date 
5. Print Author Data
6. Print Books Grouped Data by Author
7. Print Books By Category
8. Search Books Data
9. Delete Book Record
10. Exit Project");

                Console.WriteLine("Enter your choice:");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        AddAuthor();
                        break;
                    case 3:
                        AddCategory();
                        break;
                    case 4:
                        dbOperations.PrintBooksByPublishDate();
                        break;
                    case 5:
                        dbOperations.PrintAuthors();
                        break;
                    case 6:
                        dbOperations.PrintBooksGroupByAuthor();
                        break;
                    case 7:
                        try
                        {
                            Console.WriteLine("Enter category name");
                            var categoryName = Console.ReadLine();
                            dbOperations.PrintBooksByCategory(categoryName);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please check data and try again.");
                        }
                        break;
                    case 8:
                        try
                        {
                            Console.WriteLine("Enter search text");
                            var search = Console.ReadLine();
                            dbOperations.SearchBooks(search);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please check data and try again.");
                        }
                        break;
                    case 9:
                        try
                        {
                            Console.WriteLine("Enter ISBN value");
                            var isbn = Console.ReadLine();
                            dbOperations.DeleteBook(isbn);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please check ISBN value and try again.");
                        }
                        break;
                    case 10:
                        return;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice, Try Again!");
                        break;
                }

            }

        }
        public static void AddBook()
        {
            try
            {
                Console.WriteLine("Enter Title");
                var title = Console.ReadLine();

                Console.WriteLine("Enter ISBN");
                var ISBN = Console.ReadLine();

                Console.WriteLine("Enter published date (yyyy-mm-dd):");
                var date = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter Author:");
                var authorName = Console.ReadLine();

                Console.WriteLine("Enter Category:");
                var categoryName = Console.ReadLine();

                var author = dbOperations.Authors.FirstOrDefault(x => x.Name == authorName) ?? new Author { Name = authorName };
                var category = dbOperations.Categories.FirstOrDefault(x => x.Name == categoryName) ?? new Category { Name = categoryName };

                dbOperations.AddAuthor(author);
                dbOperations.AddCategory(category);

                dbOperations.AddBook(new Book { Category = category, Author = author, BookTitle = title, PublishedDate = date, ISBN = ISBN });

                Console.WriteLine("Book Added");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Please add correct values and try again");

            }

        }
        public static void AddAuthor()
        {
            try
            {
                Console.WriteLine("Enter Name");
                var name = Console.ReadLine();

                Console.WriteLine("Enter DOB(yyyy-mm-dd):");
                var date = DateTime.Parse(Console.ReadLine());


                var author = new Author { Name = name, DOB = date };

                dbOperations.AddAuthor(author);

                Console.WriteLine("Author Added");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Please add correct values and try again");

            }

        }
        public static void AddCategory()
        {
            try
            {
                Console.WriteLine("Enter Category Name");
                var name = Console.ReadLine();

                dbOperations.AddCategory(new Category { Name = name });

                Console.WriteLine("Category Added");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Please add correct values and try again");

            }

        }
    }
}
