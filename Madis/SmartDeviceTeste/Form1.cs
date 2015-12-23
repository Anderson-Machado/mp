using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartDeviceTeste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int matricula = 44;//int.Parse(textBox1.Text);
            MarcaPonto.Service mp = new SmartDeviceTeste.MarcaPonto.Service();
          MessageBox.Show(mp.consulta(matricula));
        }
    }
}