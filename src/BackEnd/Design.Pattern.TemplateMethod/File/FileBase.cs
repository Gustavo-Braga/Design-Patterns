using System;
using System.Collections.Generic;
using System.Linq;

namespace Design.Pattern.TemplateMethod.File
{
    public abstract class FileBase
    {

        public Dictionary<string, IEnumerable<int>> TemplateMethod(string directory)
        {
            var response = new Dictionary<string, IEnumerable<int>>();
            OpenFile(directory);
            var index = 1;
            foreach (var item in ExtractData().Skip(1))
            {
                response.Add($"Linha - {index}", ParseData(item));
                index++;
            }
            CloseFile(directory);
            return response;
        }


        public virtual void OpenFile(string directory)
        {
            Console.WriteLine($"Abre arquivo no diretório {directory}");
        }

        public virtual void CloseFile(string directory)
        {
            Console.WriteLine($"Fecha arquivo no diretório {directory}");
        }

        public virtual IEnumerable<string> ExtractData()
        {
            return new List<string>()
            {
                "um,dois,três,quatro,cinco,seis,sete,oito,nove,dez",
                "1,2,3,4,5,6,7,8,9,10",
                "1,2,3,4,5,6,7,8,9,10",
                "1,2,3,4,5,6,7,8,9,10",
                "1,2,3,4,5,6,7,8,9,10",
                "1,2,3,4,5,6,7,8,9,10"
            };
        }

        public virtual IEnumerable<int> ParseData(string row)
        {
            var response = new List<int>();
            foreach (var item in row.Split(','))
                response.Add(int.Parse(item));

            return response;
        }
    }
}
