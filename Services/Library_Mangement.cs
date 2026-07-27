using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class Library_Mangement
    {
        public int Mizaniaa;
        List<Book> books = new List<Book>();
        List<Member> members = new List<Member>();
        List<BorrowRecord> borrowRecords = new List<BorrowRecord>();
        #region Boorow
        public void BorrowBook(int memberId, int bookId)
        {
            var check1 = members.Find(m => m.Id == memberId);
            var check2 = books.Find(b => b.Id == bookId);
            if (check1 == null || check2 == null)
            {
                Console.WriteLine("Invalid Member or Book");
            }
            else
            {
                var c = books.FirstOrDefault(b => b.Id == bookId);
                if (c.AvailableCopies < 1)
                {
                    Console.WriteLine("There isn't enough number of Book");
                }
                else
                {
                    c.AvailableCopies--;
                    var borrowRecord = new BorrowRecord(borrowRecords.Count + 1, c, check1, DateTime.Now, DateTime.Now.AddDays(12), DateTime.MinValue, false);
                    borrowRecords.Add(borrowRecord);
                    Console.WriteLine($"Book {c.Title} borrowed by {check1.FullName}");
                }
            }

        }
        public void ReturnBook(int memberId, int bookId)
        {
            var check1 = members.Find(m => m.Id == memberId);
            var check2 = books.Find(b => b.Id == bookId);
            if (check1 == null || check2 == null)
            {
                Console.WriteLine("Invalid Member or Book");
            }
            else
            {
                var borrowRecord = borrowRecords.FirstOrDefault(br => br.book.Id == check2.Id && br.member.Id == check1.Id && !br.isReturned);
                if (borrowRecord == null)
                {
                    Console.WriteLine("No borrow record found for this member and book");
                }
                else
                {
                    if (DateTime.Now > borrowRecord.dueDate)
                    {
                        int Money = (DateTime.Now- borrowRecord.dueDate).Days * 5;
                        Console.WriteLine($"The Book {check2.Title} is Overdue and should be returned at {borrowRecord.dueDate} So You Must pay Late return fine amount {Money}");
                        Mizaniaa += Money;
                    }
                    borrowRecord.isReturned = true;
                    borrowRecord.returnDate = DateTime.Now;
                    check2.AvailableCopies++;
                    Console.WriteLine($"Book {check2.Title} returned by {check1.FullName}");
                }
            }
        }
        public void viewBorrowHistory()
        {

            for (int i = 0; i < borrowRecords.Count; i++)
            {
                Console.WriteLine($"Borrow History num {i + 1} ");
                borrowRecords[i].DisplayRecord();
                Console.WriteLine("----------------------------------------------------");
            }
        }
        public void Report()
        {
            List<string> reports = new List<string>();
            var availableBooks = books.Where(b => b.AvailableCopies > 0);
            var borrowedBooks = books.Where(b => b.AvailableCopies < b.TotalCopies);
            var overdueBooks = borrowRecords.Where(b => !b.isReturned && b.dueDate < DateTime.Now);
            var topBorrowedBooks = borrowRecords.GroupBy(b => b.book.Title).OrderByDescending(g => g.Count());
            var Member_BorrowedBooks = borrowRecords.Where(b => b.isReturned == false).Select(b => b.member.FullName);
            Console.WriteLine($"The Report for The Library ");
            reports.Add($"The Report for The Library ");
            Console.WriteLine($"The AvailableBooks :");
            reports.Add($"The AvailableBooks :");
            foreach (var m in availableBooks)
            {
                Console.WriteLine($"The Book {m.Title} with ID {m.Id} has {m.AvailableCopies} Available Copies");
                reports.Add($"The Book {m.Title} with ID {m.Id} has {m.AvailableCopies} Available Copies");

            }
            Console.WriteLine("----------------------------------------------------");
            reports.Add("----------------------------------------------------");

            Console.WriteLine($"The Borrowed Books :");
            reports.Add($"The Borrowed Books :");

            foreach (var m in borrowedBooks)
            {
                Console.WriteLine($"The Book {m.Title} with ID {m.Id} is Borrowed and there is {m.AvailableCopies} Available Copies");
                reports.Add($"The Book {m.Title} with ID {m.Id} is Borrowed and there is {m.AvailableCopies} Available Copies");

            }
            Console.WriteLine("----------------------------------------------------");
            reports.Add("----------------------------------------------------");

            Console.WriteLine($"The Overdue Books :");
            reports.Add($"The Overdue Books :");
            foreach (var m in overdueBooks)
            {
                Console.WriteLine($"The Book {m.book.Title} with ID {m.book.Id} is Overdue and it should be returned at {m.dueDate}");
                reports.Add($"The Book {m.book.Title} with ID {m.book.Id} is Overdue and it should be returned at {m.dueDate}");

            }
            Console.WriteLine("----------------------------------------------------");
            reports.Add("----------------------------------------------------");

            Console.WriteLine($"The top Borrowed Books :");
            reports.Add($"The top Borrowed Books :");

            foreach (var m in topBorrowedBooks)
            {
                Console.WriteLine($"The Book {m.Key} is Borrowed {m.Count()} times");
                reports.Add($"The Book {m.Key} is Borrowed {m.Count()} times");

            }
            Console.WriteLine("----------------------------------------------------");
            reports.Add("----------------------------------------------------");

            Console.WriteLine($"The Members who Borrowed Books :");
            reports.Add($"The Members who Borrowed Books :");

            foreach (var m in Member_BorrowedBooks)
            {
                Console.WriteLine($"The Member {m} has Borrowed Books");
                reports.Add($"The Member {m} has Borrowed Books");

            }
            File.WriteAllLines("Report.txt", reports);
            Console.WriteLine("Report.txt Done");

        }
        #endregion

        #region Book 
        public void AddBook(Book book)
        {
            // بشوف العنوان availoable ولا لا 
            // لو لا هرمي اكسبيكتيشن واطلعله رساله لو ااه هضيفه
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                throw new ArgumentException("Book title cannot be empty");
            }

            // هنا بتشك علي ISBN
            if (books.Any(b => b.ISBN == book.ISBN))
            {
                throw new ArgumentException("ISBN must be uniqe.");
            }

            // هنا بتشك علي النسخ اتللي عندي
            if (book.TotalCopies <= 0)
            {
                throw new ArgumentException("copies must be greater than zero. ");
            }

            books.Add(book);
        }
        // Erorrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr

        public void UpdateBook(int id, string title, string author, string category, int totalCopies)
        {
            // بدور علي الكتاب ب id 
            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                throw new Exception("Book not found..");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Book title cannot be empty..");
            }
            // مينفعش اغير عدد النسخ لواحده وانا عندي مستعار اصلا 2 
            int borrowedCopies = book.TotalCopies - book.AvailableCopies;
            if (totalCopies < borrowedCopies)
            {
                throw new ArgumentException("Total copies cannot be less than borrowed copies.");
            }
            book.Title = title;
            book.Author = author;
            book.Category = category;
            int d = book.TotalCopies;
            book.TotalCopies = totalCopies ;
            int diff = totalCopies - d;
            if (diff > 0)
            {
                book.AvailableCopies += diff;
            }
        }

        public void DeleteBook(int id)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                throw new Exception("Book not found..");

            }

            if (book.AvailableCopies != book.TotalCopies)
            {
                throw new Exception("cannot delete a borrowed book");
            }

            books.Remove(book);
        }

        public void DisplayallBooks()
        {
            foreach (Book book in books)
            {
                Console.WriteLine($"ID: {book.Id}");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Category: {book.Category}");
                Console.WriteLine($"Available Copies: {book.AvailableCopies}");
                Console.WriteLine("------------------------------------------");
            }
        }

        public List<Book> SearchBooks(string s)
        {
            // فادينا جزء او دخلي كابتل او سمول
            return books.Where(b => b.Title.Contains(s, StringComparison.OrdinalIgnoreCase) ||
            b.Author.Contains(s, StringComparison.OrdinalIgnoreCase) ||
            b.Category.Contains(s, StringComparison.OrdinalIgnoreCase) ||
            b.ISBN.Contains(s, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        #endregion

        #region member
        public void RegisterMember()
        {
            Console.Write("Enter ID: ");
            string nm = Console.ReadLine();
            int Id = int.Parse(nm)!;

            Console.Write("Enter Full Name: ");
            string FullName = Console.ReadLine()!;

            Console.Write("Enter Phone: ");
            string Phone = Console.ReadLine()!;

            Console.Write("Enter Email: ");
            string Email = Console.ReadLine()!;
            members.Add(new Member(Id, FullName, Phone, Email,DateTime.Now));
        }

        public void DisplayMembers()
        {
            foreach (Member member in members)
            {
                member.DisplayInfo();
                Console.WriteLine("----------------------");
            }
        }
        public void DeleteMember()
        {

            Console.Write("Enter Member ID: ");
            string nm = Console.ReadLine();
            int id = int.Parse(nm)!;
            var b = borrowRecords.Any(b=>b.member.Id == id && !(b.isReturned));
            if (b)
            {
                Console.WriteLine($"Can't Delete this Member");
            }
            Member member = members.Find(m => m.Id == id);

            if (member != null)
            {
                members.Remove(member);
                Console.WriteLine("Member Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Member Not Found.");
            }
        }
        #endregion

    }
}

