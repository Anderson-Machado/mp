using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SmartDeviceProject2;

namespace teste2
{
    class Program
    {
        static void Main(string[] args)
        {
            Conecta teste = new Conecta();
            teste.Inserir_Log();
            Console.WriteLine("Ok");
            Console.ReadKey();
        }
    }

}

