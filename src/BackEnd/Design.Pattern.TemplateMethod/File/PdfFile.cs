using System;

namespace Design.Pattern.TemplateMethod.File
{
    public class PdfFile : FileBase
    {

        public override void OpenFile(string directory)
        {
            Console.WriteLine($"Abre arquivo PDF no diretório ~~ {directory}");
        }

        public override void CloseFile(string directory)
        {
            Console.WriteLine($"Fecha arquivo PDF no diretório ~~ {directory}");
        }

    }
}
