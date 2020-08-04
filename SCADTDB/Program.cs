using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADTDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var item = new Context())
            {
                var utilizator = item.SignUp.SingleOrDefault();
                
                Console.ReadLine();
            }
        }
    }
}
