using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public delegate void LibraryNot(string message);
    public class Events
    {
        public event LibraryNot libraryNoti;

        public void invoke(string message)
        {
            libraryNoti?.Invoke(message);
        }
    }
}
