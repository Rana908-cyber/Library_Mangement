using Microsoft.VisualBasic;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BorrowRecord
    {

        private int Id;
        private Book Book ;
        private Member Member ;
        private DateTime BorrowDate;
        private DateTime DueDate;
        private DateTime ReturnDate;
        private bool IsReturned;

        public int id { get { return Id; } set { if (value < 0) Console.WriteLine($"Invalid Id"); else Id = value; } }
        public Book book { get { return Book; } set { if ( value ==null) Console.WriteLine($"Invalid Book Name"); else Book = value; } }
        public Member member { get { return Member; } set { if ( value == null) Console.WriteLine($"Invalid Member Name"); else Member = value; } }
        public DateTime borrowDate { get { return BorrowDate; } set { if (value==DateTime.MinValue) Console.WriteLine($"Invalid BorrowDate"); else BorrowDate = value; } }
        public DateTime dueDate { get { return DueDate; } set { if (value == DateTime.MinValue) Console.WriteLine($"Invalid DueDate"); else DueDate = value; } }
        public DateTime returnDate { get { return ReturnDate; } set { if (value == DateTime.MinValue) Console.WriteLine($"Invalid ReturnDate"); else ReturnDate = value; } }
        public bool isReturned { get { return IsReturned; } set { if (value != false && value !=true) Console.WriteLine($"Invalid IsReturned"); IsReturned = value; } }

        public BorrowRecord(int Id,Book Book, Member Member, DateTime BorrowDate, DateTime DueDate, DateTime ReturnDate, bool IsReturned)
        {
            this.id = Id;
            this.book = Book;
            this.member= Member;
            this.borrowDate = BorrowDate;
            this.dueDate= DueDate;
            this.returnDate= ReturnDate;
            this.isReturned = IsReturned;
        }
        public void DisplayRecord()
        {
            Console.WriteLine($"The Book {Book}");
            Console.WriteLine($"With ID {Id}");
            Console.WriteLine($"is Borrwed to {Member}");
            Console.WriteLine($"at the data {BorrowDate}");
            Console.WriteLine($"it Should Return at data {DueDate}");
            Console.WriteLine($"she Return it at {ReturnDate}");
            Console.WriteLine($"The Book Return Status is {IsReturned}");
        }
    }
}
