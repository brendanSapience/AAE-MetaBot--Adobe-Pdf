using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutomationAnywhere
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClassTest obj = new MyClassTest();
            obj.DoStuff();


         
            Console.WriteLine("\nNumbers of Pages: ");
            Console.ReadKey();
        }
    }
}
