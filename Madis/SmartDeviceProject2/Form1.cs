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
    public partial class Form1 : Form
    {
        byte sentido;
        Int16 area_para;
        Int16 area_de;
        Int16 status_sentido;
        int equipamento;
        string arquivo = @"\Program Files\MarcaPonto\ArquivoPronto.txt";
        string arquivo_conf = @"\Program Files\MarcaPonto\Config.cfg";   
     
        public Form1()
        {
            InitializeComponent();
            textBox1.Focus();
        }
        
        //botão para a lógica de funcionamento
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "ENTRADA")
            {
                button1.Text = "SAIDA";
                textBox1.Focus();
            }
            else if (button1.Text == "SAIDA")
            {
                button1.Text = "ENTRADA";
                textBox1.Focus();
            }
            if (textBox1.Text == "admin")
            {
                Form2 frm = new Form2();
                frm.Show();
            }
        }

        //verificação, caso seja enter verfificar
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//pegando enter
            {   //chamar o metodo para salvar on
                insere_webService();
                textBox1.Text = "";
            }
        }
        
        //insere on/off-1
        public void insere_webService()
        {            
            try
            {
                equipamento =  retorna_equipamento();//pegando o numero do equipamento no config.cfg
                int matricula = int.Parse(textBox1.Text);
                string Data1 = DateTime.Now.ToShortDateString();
                string Data2 = DateTime.Now.ToLongTimeString();
                Conecta_TO to = new Conecta_TO();
                MarcaPonto.MarcaPonto.Service teste = new MarcaPonto.MarcaPonto.Service();
                teste.Url = Retorna_Url();
                string status = teste.consulta(textBox1.Text);
                //******************************====================*************
               
                if (status == "Liberado") //SE O USUARIO ESTIVER LIBERADO ELE SALVA COM 10
                {
                    status_sentido = 10;
                    if (button1.Text == "ENTRADA")
                    {
                        sentido = 1;
                        area_de = 1;
                        area_para = 2;
                    }
                    else if (button1.Text == "SAIDA")
                    {
                        sentido = 2;
                        area_de = 2;
                        area_para = 1;
                    }
                    //inserindo no banco de dados se ele estiver liberado********
                    to.Matricula = matricula;
                    string dataa = Data1 + " " + Data2;
                    to.Equipamento = equipamento;
                    to.Sentido = sentido;
                    to.Status = status_sentido;
                    to.Area_de = area_de;
                    to.Area_para = area_para;
                    //**********passando para o banco aqui********
                    teste.insere(matricula, equipamento, dataa, sentido, status_sentido, area_de, area_para);
                    // bo.Inserir_Log(matricula,equipamento,dataa,sentido,status_sentido,area_de,area_para);
                    LbStatus.Text = "ONLINE";
                    MessageBox.Show("Liberado");
                    //**********************FIM**********************************

                    //verificar se arquivo existe e salvar o que esta nele e apagar ao acabar de ler*****
                    LerArquivo_ParaBanco();

                }
                else // se for negado salvar da mesma forma
                {
                    status_sentido = 9;
                    if (button1.Text == "ENTRADA")
                    {
                        sentido = 1;
                        area_de = 1;
                        area_para = 2;
                    }
                    else if (button1.Text == "SAIDA")
                    {
                        sentido = 2;
                        area_de = 2;
                        area_para = 1;
                    }
                    //inserindo no banco de dados se ele estiver liberado********
                    to.Matricula = matricula;
                    string dataa = Data1 + " " + Data2;
                    to.Equipamento = equipamento;
                    to.Sentido = sentido;
                    to.Status = status_sentido;
                    to.Area_de = area_de;
                    to.Area_para = area_para;
                    //**********passando para o banco aqui********
                    teste.insere(matricula, equipamento, dataa, sentido, status_sentido, area_de, area_para);
                    LbStatus.Text = "ONLINE";
                    //**********************FIM**********************************
                    //verificar se arquivo existe e salvar o que esta nele e apagar ao acabar de ler*****
                    LerArquivo_ParaBanco();
                    MessageBox.Show("Acesso Negado");
                    
                }
                
              }
            catch //caso esteja off line ele vai salvar no banco local
            {   Salva_Arquivo();
            }
        }
       
        //inserindo apenas online
        public void insere_online_only()
        {
            try
            {
                equipamento = retorna_equipamento();//pegando o numero do equipamento no config.cfg
                int matricula = int.Parse(textBox1.Text);
                string Data1 = DateTime.Now.ToShortDateString();
                string Data2 = DateTime.Now.ToLongTimeString();
                Conecta bo = new Conecta();
                Conecta_TO to = new Conecta_TO();
                string status = bo.consulta(textBox1.Text);
                
                //******************************====================*************
                if (status == "Liberado") //SE O USUARIO ESTIVER LIBERADO ELE SALVA COM 10
                {
                    status_sentido = 10;
                    if (button1.Text == "ENTRADA")
                    {
                        sentido = 1;
                        area_de = 1;
                        area_para = 2;
                    }
                    else if (button1.Text == "SAIDA")
                    {
                        sentido = 2;
                        area_de = 2;
                        area_para = 1;
                    }
                    //inserindo no banco de dados se ele estiver liberado********
                    to.Matricula = matricula;
                    to.Data = Data1 + " " + Data2;
                    to.Equipamento = equipamento;
                    to.Sentido = sentido;
                    to.Status = status_sentido;
                    to.Area_de = area_de;
                    to.Area_para = area_para;
                    //**********passando para o banco aqui********
                   //bo.Inserir_Log(to);
                    LbStatus.Text = "ONLINE";
                    MessageBox.Show("Liberado");

                }
                else//CASO SEJA ACESSO NEGADO ELE SALVA DA MESMA FORMA 
                {
                    status_sentido = 09;
                    if (button1.Text == "ENTRADA")
                    {
                        sentido = 1;
                        area_de = 1;
                        area_para = 2;

                    }
                    else if (button1.Text == "SAIDA")
                    {
                        sentido = 2;
                        area_de = 2;
                        area_para = 1;

                    }
                    //inserindo no banco de dados se ele estiver NEGADO********
                    to.Matricula = matricula;
                    to.Data = Data1 + " " + Data2;
                    to.Equipamento = equipamento;
                    to.Sentido = sentido;
                    to.Status = status_sentido;
                    to.Area_de = area_de;
                    to.Area_para = area_para;
                    //**********passando para o banco aqui********
                    //bo.Inserir_Log(to);
                    LbStatus.Text = "ONLINE";
                    MessageBox.Show("Liberado");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);//verificando o erro
            }
        
        }
            
        //verificando arquivo
        private void Form1_Load(object sender, EventArgs e)
        {  
            //ler o equipamento do arquivo e salvar em uma variavel
            //verificando se arquivo de configuração não existe, caso não exista criar vazio!
            StreamWriter log;

            if (!File.Exists(arquivo_conf))
            {   //se o arquivo não exitir, criar um com as configurações padroes abaixo
                log = new StreamWriter(arquivo_conf);
                log.Close();
                Configura conf = new Configura();
                conf.escrita("01", "http://127.0.0.1/Web/service.asmx");
            
            }
            else
            {
                log = File.AppendText(arquivo_conf);
                log.Close();
                
            }
           
            
        }
        
        //inserindo on/off-2 por metodos
        public void insere_on_off2()
        {
            try
            {
                equipamento = 1;//retorna_equipamento();//pegando o numero do equipamento no config.cfg
                int matricula = int.Parse(textBox1.Text);
                string Data1 = DateTime.Now.ToShortDateString();
                string Data2 = DateTime.Now.ToLongTimeString();
                Conecta bo = new Conecta();
                Conecta_TO to = new Conecta_TO();
                string status = bo.consulta(textBox1.Text);
                
                //******************************====================*************
                if (status == "Liberado") //SE O USUARIO ESTIVER LIBERADO ELE SALVA COM 10
                {
                    status_sentido = 10;
                    if (button1.Text == "ENTRADA")
                    {
                        sentido = 1;
                        area_de = 1;
                        area_para = 2;
                    }
                    else if (button1.Text == "SAIDA")
                    {
                        sentido = 2;
                        area_de = 2;
                        area_para = 1;
                    }
                    //inserindo no banco de dados se ele estiver liberado********
                    to.Matricula = matricula;
                    to.Data = Data1 + " " + Data2;
                    to.Equipamento = equipamento;
                    to.Sentido = sentido;
                    to.Status = status_sentido;
                    to.Area_de = area_de;
                    to.Area_para = area_para;
                    //**********passando para o banco aqui********
                    //LerArquivo_ParaBanco();
                    //bo.Inserir_Log(to);
                    LbStatus.Text = "ONLINE";
                    MessageBox.Show("Liberado");

                }
                
            }
            catch
            {   //salvando dados no arquivo
                Salva_Arquivo();
                MessageBox.Show("erro");
            }

        }

        //pesquisa o equipamento no banco
        public int retorna_equipamento()
        {
            StreamReader leitura = new StreamReader(arquivo_conf);
             int equipamento = int.Parse(leitura.ReadLine());
              leitura.Close();
               return equipamento;
        }

        public string Retorna_Url()
        {
            StreamReader leitura = new StreamReader(arquivo_conf);
            int eq = int.Parse(leitura.ReadLine());
            string ip = leitura.ReadLine();
            return ip;
        }

        //ler do arquivo para salvar no banco
        public void LerArquivo_ParaBanco()
        {
            //verificar se arquivo existe e salvar o que esta nele e apagar ao acabar de ler*****
            if (File.Exists(arquivo))
            {   
                progressBar1.Visible = true;
                int cont = 1;
                 MarcaPonto.MarcaPonto.Service conecta = new MarcaPonto.MarcaPonto.Service();
                 conecta.Url = Retorna_Url(); 
                LbStatus.Text = "Aguarde sinconizando dados...";    
                using (StreamReader fluxotexto = new StreamReader(arquivo))
                    while (true)
                    { 
                        string linhatexto = fluxotexto.ReadLine();
                        if (linhatexto == null)
                        {
                            break;
                        }
                        string[] quebra = linhatexto.Split(';');
                        //cadastra(quebra[0],quebra[1],quebra[2]);
                        int matricula = int.Parse(quebra[0]);
                        equipamento = int.Parse(quebra[1]);
                        string Data_ = quebra[2];
                        Int16 sentido_ = Int16.Parse(quebra[3]);
                        Int16 status_sentido_= Int16.Parse(quebra[4]);
                        Int16 area_de_ = Int16.Parse(quebra[5]);
                        Int16 area_para_ = Int16.Parse(quebra[6]);
                        conecta.insere(matricula, equipamento, Data_, sentido, status_sentido_, area_de_, area_para_);
                        progressBar1.Value = cont++;
                    }
                progressBar1.Visible = false;
                //deletando o arquivo
                    
                File.Delete(arquivo);
                LbStatus.Text = "ONLINE";
            }
        }
        
        //salva do programa para txt
        public void Salva_Arquivo()
        {
            LbStatus.Text = "OFFLINE";
            //caso não exista o arquivo, criar um novo.
            //escrever e salvar no arquivo de texto
            //************CODIGO FUNCIONAL ABAIXO**********************
            int matricula = int.Parse(textBox1.Text);
            string Data1 = DateTime.Now.ToShortDateString();
            string Data2 = DateTime.Now.ToLongTimeString();
            equipamento = retorna_equipamento();
            int status_sentido;

            //passar também o equipamento e salvar no banco
            //retorna_equipamento();
            status_sentido = 10;
            if (button1.Text == "ENTRADA")
            {
                sentido = 1;
                area_de = 1;
                area_para = 2;

            }
            else if (button1.Text == "SAIDA")
            {
                sentido = 2;
                area_de = 2;
                area_para = 1;

            }

            StreamWriter log;

            if (!File.Exists(arquivo))
            {
                log = new StreamWriter(arquivo);
            }
            else
            {
                log = File.AppendText(arquivo);
            }
            log.WriteLine(matricula + ";" + equipamento + ";" + Data1 + " " + Data2 + ";" + sentido + ";" + status_sentido + ";" + area_de + ";" + area_para);
            //log.WriteLine();//verificar se ele ta incluindo algo em branco no banco 
            log.Close();
               
        }

              }
}