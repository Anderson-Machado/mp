using System;

using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SmartDeviceProject2
{
    class Configura
    {
        string arquivo = @"Config.cfg";
        
        public void escrita(string Equipamento,string maquina, string estancia,string admin, string senha)
        {
            StreamWriter escreva = new StreamWriter(arquivo);
            escreva.WriteLine(Equipamento);
            escreva.WriteLine(maquina);
            escreva.WriteLine(estancia);
            escreva.WriteLine(admin);
            escreva.WriteLine(senha);
            escreva.Close();
        }
    }
}
