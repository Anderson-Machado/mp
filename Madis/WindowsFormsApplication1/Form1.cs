using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int sentido;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            Int64 Novo_Formato;
            Novo_Formato = Convert.ToInt64(textBox1.Text);

            string old = Convert.ToString(Novo_Formato);
            MessageBox.Show(old);
               
=======
            if (button1.Text == "ENTRADA")
            {
                button1.Text = "SAIDA";
            }
            else if (button1.Text == "SAIDA")
            {
                button1.Text = "ENTRADA";
            }
>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string resp;
            try
            {
                localhost.Service consumo = new localhost.Service();
<<<<<<< HEAD
                int Matricula = int.Parse(textBox1.Text.Remove(0,1));
               // textBox1.Text = Matricula;
=======
                int Matricula = int.Parse(textBox1.Text);
                
>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
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
<<<<<<< HEAD
                    //consumo.insere(Matricula, Data, sentido);
=======
                    consumo.insere(Matricula, Data, sentido);
>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
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
