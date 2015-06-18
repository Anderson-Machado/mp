using System;
using System.Collections.Generic;
using System.Text;

namespace teste2
{
   public class Acesso
    {
        private int matricula;

        public int Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        private string Data1;

        public string Data11
        {
            get { return Data1; }
            set { Data1 = value; }
        }
        private string Data2;

        public string Data21
        {
            get { return Data2; }
            set { Data2 = value; }
        }
        private int equipamento;

        public int Equipamento
        {
            get { return equipamento; }
            set { equipamento = value; }
        }
        private int status_sentido;

        public int Status_sentido
        {
            get { return status_sentido; }
            set { status_sentido = value; }
        }

    }
}
