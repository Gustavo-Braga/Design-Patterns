using System;
using System.Collections.Generic;

namespace Design.Pattern.TemplateMethod.File
{
    public class CsvFile : FileBase
    {

        public override void OpenFile(string directory)
        {
            Console.WriteLine($"Abre arquivo CSV no diretório ~~ {directory}");
        }

        public override void CloseFile(string directory)
        {
            Console.WriteLine($"Fecha arquivo CSV no diretório ~~ {directory}");
        }

        public override IEnumerable<string> ExtractData()
        {
            return new List<string>()
            {
                "A,B,C",
                "1,2,3",
                "1,2,3",
                "1,2,3",
                "1,2,3",
                "1,2,3"
            };
        }
    }
}
