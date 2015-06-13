using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace teste
{
    class Program
    {
        static void Main(string[] args)
        {
            string arquivo = @"teste.txt";
            StreamWriter writer = new StreamWriter(arquivo);
            if (File.Exists(arquivo))
            {
                writer.WriteLine("teste");
                writer.WriteLine();
                writer.Close();

            }
            else
            {
                File.Create(arquivo);
                writer.WriteLine("teste2");
                writer.Close();

            }



        }
    }
}