using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Teste_Conversao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long Novo_Formato = long.Parse(textBox1.Text);
            textBox1.Text = Convert.ToString(Novo_Formato);
            //fim da conversão
            string matricula = textBox1.Text;
            MessageBox.Show(matricula);   
        }
    }
}
