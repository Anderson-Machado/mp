using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SmartDeviceProject2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   try
            {
                string arquivo_conf = @"\Program Files\MarcaPonto\Config.cfg";
                StreamWriter log;
                if (File.Exists(arquivo_conf))
                {   //se o arquivo não exitir, criar um com as configurações padroes abaixo
                    log = new StreamWriter(arquivo_conf);
                    log.Close();
                    Configura conf = new Configura();
                    conf.escrita(txtEquipamento.Text, txtIP.Text);
<<<<<<< HEAD
                   // conf.escrita(txtEquipamento.Text, txtIP.Text);
                    MessageBox.Show("Dados configurado com sucesso!");
                   Application.Exit();
=======
                    MessageBox.Show("Dados configurado com sucesso!");
>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO:"+ ex.Message);
            
            }
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {   //lendo arquivo de configuração
            string arquivo_conf = @"\Program Files\MarcaPonto\Config.cfg";
            StreamReader leitura = new StreamReader(arquivo_conf);
            txtEquipamento.Text = leitura.ReadLine();
<<<<<<< HEAD
            //string equi = leitura.ReadLine();
            txtIP.Text = leitura.ReadLine();
            leitura.Close();
           //desabilitando Nº Equipamento
            //label1.Visible = false;
            //txtEquipamento.Visible = false;
=======
            txtIP.Text = leitura.ReadLine();
            leitura.Close();
           
>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
        }
    }
}