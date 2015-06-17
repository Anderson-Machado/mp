using System;

using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SmartDeviceProject2
{   
    /// <summary>
    ///  Esta clase é resposável pela escrtita de configuração do arquivo
    /// </summary>

    class Configura
    {
        string arquivo = @"\Program Files\MarcaPonto\Config.cfg";
        
        public void escrita(string Equipamento,string maquina)
        {
            StreamWriter escreva = new StreamWriter(arquivo);
            escreva.WriteLine(Equipamento);
            escreva.WriteLine(maquina);
            escreva.Close();
            
          
        }
    }
}
