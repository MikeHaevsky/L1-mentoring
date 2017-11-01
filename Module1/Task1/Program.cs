using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Entities;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileSystemVisitor = new FileSystemVisitor(@"d:\TestFolder\", (x) => x.EndsWith(".xlsx"), new FileProvider());
            var reporter = new Reporter();

            fileSystemVisitor.FileFinded += reporter.FindedMessage;
            fileSystemVisitor.FolderFinded += reporter.FindedMessage;
            fileSystemVisitor.Start += reporter.StartFindMessage;
            fileSystemVisitor.Finish += reporter.FinishFindMessage;

            fileSystemVisitor.Initialize();
            Console.ReadKey();


            fileSystemVisitor.FileFinded -= reporter.FindedMessage;
            fileSystemVisitor.FolderFinded += reporter.FindedMessage;
            fileSystemVisitor.Start -= reporter.StartFindMessage;
            fileSystemVisitor.Finish -= reporter.FinishFindMessage;

        }
    }
}
