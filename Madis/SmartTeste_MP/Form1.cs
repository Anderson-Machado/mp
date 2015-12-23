using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartTeste_MP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "ENTRADA")
            {
                button1.Text = "SAIDA";
            }
            else if (button1.Text == "SAIDA")
            {
                button1.Text = "ENTRADA";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string resp;
            try
            {
                //localhost.Service consumo = new localhost.Service();
                teste.Service consumo = new SmartTeste_MP.teste.Service();
                int Matricula = int.Parse(textBox1.Text);
                
                string Data = DateTime.Now.ToLongDateString();//alterar o formato
                resp = consumo.consulta(textBox1.Text);//pesquisando se a matricula está liberada
                if (resp == "Liberado")
                {
                    if (button1.Text == "ENTRADA")
                    {
                     //   sentido = 1;
                    }
                    else if (button1.Text == "SAIDA")
                    {
                      //  sentido = 2;
                    }
                    //consumo.insere(Matricula, Data, sentido);
                    MessageBox.Show(resp);
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
