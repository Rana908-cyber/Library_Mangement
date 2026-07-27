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

            Console.WriteLine($"Hello {name} , Welcome To Library 'Ink & Grace' ");
            await Task.Delay(2000);
            Console.WriteLine($"Put a smile on your face and enjoy your reading journey");
            await Task.Delay(4000);
            Console.WriteLine($"Now , Tell me what are you need ?!");
            Console.WriteLine($"1 : Borrow Book ");
            Console.WriteLine($"2 : Return Book ");
            Console.WriteLine($"3 : anther order ");
        }
        static async Task Main(string[] args)
        {
            await print();


        }

    }
}

