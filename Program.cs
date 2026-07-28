using Library.Models;
using Library.Services;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Library
{
    internal class Program
    {
        static async Task print()
        {
            Console.WriteLine("Enter Your Name : ");
            string name = Console.ReadLine();

            Console.WriteLine($"Hello {name} , Welcome To Library Ala Matofraggg !!!!!! ");
            await Task.Delay(2000);
            Console.WriteLine($"Put a Smile on your face and enjoy your  journey");
            await Task.Delay(4000);
            Console.WriteLine();
                Console.WriteLine($"Now , Tell me what are you need ?!");
        }
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            await print();
            Library_Mangement library = new Library_Mangement();
            library.Nlibrary.libraryNoti += (msgg) =>
            {
                Console.WriteLine($"{msgg}");
            };
       
            List<Book> books = new List<Book>();
            List<Member> members = new List<Member>();
            List<BorrowRecord> borrowRecords = new List<BorrowRecord>();

            bool f = true;
            while (f)
            {

                Console.WriteLine($" 1-> Book Operations");
                Console.WriteLine($" 2-> Member Operations");
                Console.WriteLine($" 3-> Booroow_Book Operations");
                Console.WriteLine($" 4-> Exit ");
                 int c= int.Parse(Console.ReadLine());
                if (c == 1)
                {
                    Console.WriteLine("What would you like to do ?!");
                    Console.WriteLine($" 1 : Add Book ");
                    Console.WriteLine($" 2 : Update Book ");
                    Console.WriteLine($" 3 : Delete Book ");
                    Console.WriteLine($" 4 : Display all Books");
                    Console.WriteLine($" 5 : Search For Book");
             
                    int c2 = int.Parse(Console.ReadLine());
                    if (c2 == 1)
                    {
                        Console.Write("Enter Book ID");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Book Title");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author Name");
                        string author = Console.ReadLine();
                        Console.Write("Enter Category");
                        string category = Console.ReadLine();
                        Console.Write("Enter ISBN");
                        string isbn = Console.ReadLine();
                        Console.Write("Enter Published Year");
                        int publishedYear = int.Parse(Console.ReadLine());
                        Console.Write("Enter Total Copies");
                        int totalCopies = int.Parse(Console.ReadLine());
                        library.AddBook(new Book(id, title, author, category, isbn, publishedYear, totalCopies));
                    }
                    else if (c2 == 2)
                    {
                        Console.Write("Enter Book ID");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Book Title");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author Name");
                        string author = Console.ReadLine();
                        Console.Write("Enter Category");
                        string category = Console.ReadLine();
                        Console.Write("Enter Total Copies");
                        int totalCopies = int.Parse(Console.ReadLine());
                        library.UpdateBook(id, title, author, category, totalCopies);
                    }
                    else if (c2 == 3)
                    {
                        Console.Write("Enter Book ID");
                        int id = int.Parse(Console.ReadLine());
                        library.DeleteBook(id);

                    }
                    else if (c2 == 4)
                    {
                        library.DisplayallBooks();
                    }
                    else if (c2 == 5)
                    {
                        Console.Write("Enter Book Title");
                        string title = Console.ReadLine();
                        library.SearchBooks(title);
                    }
                    
                    else
                    {
                        Console.WriteLine("Invalid Chosse");
                        Console.WriteLine("chosse Again ");
                    }
                }
                if (c == 2)
                {
                    Console.WriteLine("What would you like to do ?!");
                    Console.WriteLine($" 1 : Register Member ");
                    Console.WriteLine($" 2 : Update Member ");
                    Console.WriteLine($" 3 : Delete Member ");
                    Console.WriteLine($" 4 : Display all Members");
                    int c2 =int.Parse(Console.ReadLine());
                    if (c2 == 1)
                    {
                        library.RegisterMember();
                    }
                    else if (c2 == 2)
                    {
                        library.UpdateMember();
                    }
                    else if (c2 == 3)
                    {
                        library.DeleteMember();
                    }
                    else if (c2 == 4)
                    {
                        library.DisplayMembers();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Chosse");
                        Console.WriteLine("chosse Again ");
                    }
                }
                if (c == 3)
                {
                    Console.WriteLine("What would you like to do ?!");
                    Console.WriteLine($" 1 : Borrow Book ");
                    Console.WriteLine($" 2 : Return Book ");
                    Console.WriteLine($" 3 : View Borrow History");
                    Console.WriteLine($" 4 : Report About Library");
                   
                        int c2= int.Parse( Console.ReadLine());
                    if (c2 == 1)
                    {
                        Console.WriteLine("Enter Your Member Id");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Your Book Id");
                        int id2 = int.Parse(Console.ReadLine());
                        library.BorrowBook(id, id2);
                    }
                    else if (c2 == 2)
                    {
                        Console.WriteLine("Enter Your Member Id");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Your Book Id");
                        int id2 = int.Parse(Console.ReadLine());
                        library.ReturnBook(id, id2);
                    }
                    else if (c2 == 3)
                    {
                        library.viewBorrowHistory();
                    }
                    else if (c2 == 4)
                    {
                        library.Report();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Chosse");
                        Console.WriteLine("chosse Again ");
                    }
                }
                else if (c == 4)
                {
                    f = false;
                    Console.WriteLine("========================================");
                    Console.WriteLine("  Thank you for using Library Ala Matofraggg !!!!!!!  ");
                    Console.WriteLine("  We hope you enjoyed your experience. ");
                    Console.WriteLine("        Please come back soon!          ");
                    Console.WriteLine("========================================");
                }
                else
                {
                    Console.WriteLine("Invalid Chosse");
                    Console.WriteLine("chosse Again ");
                    Console.WriteLine("-----------------------------------------------------------------");
                }

            }



        }

    }
}

