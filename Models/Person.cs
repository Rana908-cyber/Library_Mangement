using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public abstract class Person
    {
        public int Id;
        public string FullName;
        public string Phone;

        public string Email;
        public DateTime MembershipDate;
          
        public Person(int Id, string FullName, string Phone, string Email, DateTime MembershipDate)
        {
            this.Id = Id;
            this.FullName = FullName;
            this.Email = Email;
            this.Phone = Phone;
            this.MembershipDate=MembershipDate;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Full Name: {FullName}");
            Console.WriteLine($"Phone: {Phone}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Membership Date: {MembershipDate}");
        }
    }
}
