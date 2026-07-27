using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Member : Person
    {
        public Member(int Id, string FullName, string Phone, string Email, DateTime MembershipDate) : base(Id, FullName, Phone, Email, MembershipDate)
        {
            this.Id = Id;
            this.FullName = FullName;
            this.Email = Email;
            this.Phone = Phone;
            this.MembershipDate = MembershipDate;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Full Name: {FullName}");
            Console.WriteLine($"Phone: {Phone}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Membership Date: {MembershipDate}");
        }
    }
}
