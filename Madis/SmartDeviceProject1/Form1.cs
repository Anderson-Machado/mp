using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartDeviceProject1
{
    public partial class Form1 : Form
    {
        int sentido;
        public Form1()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "ENTRADA")
            {
                button1.Text = "SAIDA";
            }
            else if(button1.Text=="SAIDA")
            {
                button1.Text = "ENTRADA";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                localhost.Service consumo = new SmartDeviceProject1.localhost.Service();
                int Matricula = int.Parse(textBox1.Text);
                string resp;
                string Data = DateTime.Now.ToLongDateString();//alterar o formato
                resp = consumo.consulta(textBox1.Text);//pesquisando se a matricula está liberada
                if (resp == "Liberado")
                {
                    if (button1.Text == "ENTRADA")
                    {
                        sentido = 1;
                    }
                    else if (button1.Text == "SAIDA")
                    {
                        sentido = 2;
                    }
                    consumo.insere(Matricula, Data, sentido);
                    MessageBox.Show("Liberado");
                }
                else
                {
                    MessageBox.Show("Não liberado");
                    //salvar e registar
                }
            }
            catch
            {
                MessageBox.Show("Algo de errado");
            }
        }
    }
}