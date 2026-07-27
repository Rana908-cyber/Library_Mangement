using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get;  set; }

        public Book(
            int id,
            string title,
            string author,
            string category,
            string isbn,
            int publishedYear,
            int totalCopies)
        {
            Id = id;
            Title = title;
            Author = author;
            Category = category;
            ISBN = isbn;
            PublishedYear = publishedYear;
            TotalCopies = totalCopies;
            AvailableCopies = totalCopies;
        }

        public Book()
        {
        }

        public void DisplayBookInfo()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Published Year: {PublishedYear}");
            Console.WriteLine($"Total Copies: {TotalCopies}");
            Console.WriteLine($"Available Copies: {AvailableCopies}");
        }

        // الول اما يستنخحدم البورو ينقص
        public void BorrowCopy()
        {
            if (AvailableCopies > 0)
            {
                AvailableCopies--;
            }
        }

        //هنا لما برجهع بزود
        public void ReturnCopy()
        {
            if (AvailableCopies < TotalCopies)
            {
                AvailableCopies++;
            }
        }

    }
    }
