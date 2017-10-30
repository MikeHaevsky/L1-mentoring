using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Entities;

namespace Task1
{
    public class Reporter
    {
        public void FindedMessage(object sender, string message)
        {
            Console.WriteLine($"{message}");
        }
        public void StartFindMessage(object sender, EventArgs e)
        {
            Console.WriteLine($"Start searching");
        }
        public void FinishFindMessage(object sender, EventArgs e)
        {
            Console.WriteLine($"End searching");
        }

    }
}
