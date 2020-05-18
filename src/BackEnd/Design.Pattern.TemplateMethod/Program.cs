using Design.Pattern.TemplateMethod.File;
using System;

namespace Design.Pattern.TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var pflFile = new PdfFile();
            var pdfValues = pflFile.TemplateMethod("diretório para arquivo pdf");
            Console.WriteLine("Resultado pdf File");
            foreach (var row in pdfValues)
            {
                Console.WriteLine(row.Key);
                foreach (var item in row.Value)
                    Console.Write($"  {item}");
                Console.WriteLine();
            }

            var csvFile = new CsvFile();
            var csvValues = csvFile.TemplateMethod("diretório para arquivo csv");
            Console.WriteLine("Resultado csv File");
            foreach (var row in csvValues)
            {
                Console.WriteLine(row.Key);
                foreach (var item in row.Value)
                    Console.Write($"  {item}");
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
