using System;

using System.Collections.Generic;
using System.Text;

namespace SmartDeviceProject2
{
   public class Conecta_TO
    {
        private int matricula;

        public int Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        private int equipamento;

        public int Equipamento
        {
            get { return equipamento; }
            set { equipamento = value; }
        }
        private string data;

        public string Data
        {
            get { return data; }
            set { data = value; }
        }


        private int sentido;

        public int Sentido
        {
            get { return sentido; }
            set { sentido = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private int area_de;

        public int Area_de
        {
            get { return area_de; }
            set { area_de = value; }
        }
        private int area_para;

        public int Area_para
        {
            get { return area_para; }
            set { area_para = value; }
        }
    }
}
