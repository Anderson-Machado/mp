using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MarcaPonto;
using System.Xml.Serialization;
namespace SmartDeviceProject2
{
    public partial class Form1 : Form
    {
        byte sentido;
        Int16 area_para;
        Int16 area_de;
        Int16 status_sentido;
        int equipamento;
<<<<<<< HEAD
        long pes;
        string arquivo = @"\Program Files\MarcaPonto\ArquivoPronto.txt";
        string arquivo_conf = @"\Program Files\MarcaPonto\Config.cfg";
        //Serializer arqz = new Serializer();
=======
        string arquivo = @"\Program Files\MarcaPonto\ArquivoPronto.txt";
        string arquivo_conf = @"\Program Files\MarcaPonto\Config.cfg";   
     
>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
        public Form1()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        /// <summary>
        /// Lógica funcional de acesso(entrada/saida)
        /// </summary>
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
        /// <summary>
        /// verificação, caso seja enter(13) verfificar
        /// </summary>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//pegando enter
            {   //chamar o metodo para salvar on
                insere_webService();
                textBox1.Text = "";
            }
        }
        /// <summary>
        /// Inserindo no banco de dados através de web services
        /// </summary>
         public void insere_webService()
<<<<<<< HEAD
        {
            try  //numero.substring(numero.length() - 10));
            {   
                equipamento =  retorna_equipamento();//pegando o numero do equipamento no config.cfg
               //retirando o zero via conversão
                long Novo_Formato = long.Parse(textBox1.Text);
                textBox1.Text = Convert.ToString(Novo_Formato);
                //fim da conversão
                string matricula = textBox1.Text;
                pes = long.Parse(matricula);
                DateTime Dataa1 = DateTime.Now;
                string Data1 = Dataa1.ToString("yyyy-MM-dd HH:mm:ss");
=======
        {            
            try
            {
                equipamento =  retorna_equipamento();//pegando o numero do equipamento no config.cfg
                int matricula = int.Parse(textBox1.Text);
                string Data1 = DateTime.Now.ToShortDateString();
                string Data2 = DateTime.Now.ToLongTimeString();
>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
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
<<<<<<< HEAD
                    //**********passando para o banco aqui********
                    teste.insere(matricula,pes, equipamento, Data1, sentido, status_sentido, area_de, area_para);
                    // bo.Inserir_Log(matricula,equipamento,dataa,sentido,status_sentido,area_de,area_para);
                    LbStatus.Text = "ONLINE";
                    MessageBox.Show("Liberado!");
                    //**********************FIM**********************************

                    //verificar se arquivo existe e salvar o que esta nele e apagar ao acabar de ler*****
                    //LerArquivo_ParaBanco();
                    //arqz.salvar_arquivoSerializado(matricula, sentido, area_de, area_para, equipamento);
                    
=======
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

>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
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
<<<<<<< HEAD
                    //pes recebendo zero devido ao relatorio madis
                    pes = 0;
                    //**********passando para o banco aqui********
                    teste.insere(matricula, pes, equipamento, Data1, sentido, status_sentido, area_de, area_para);
                    LbStatus.Text = "ONLINE";
                    //**********************FIM**********************************
                    //verificar se arquivo existe e salvar o que esta nele e apagar ao acabar de ler*****
                   // LerArquivo_ParaBanco();
                    //arqz.salvar_arquivoSerializado(matricula, sentido, area_de, area_para, equipamento);
                    
                    MessageBox.Show("Acesso Negado!");
=======
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
>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
                    
                }
                
              }
            catch //caso esteja off line ele vai salvar no banco local
<<<<<<< HEAD
            {  // Salva_Arquivo();
                MessageBox.Show("Erro de Comunicação");
=======
            {   Salva_Arquivo();
>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
            }
        }
         /// <summary>
         /// Leitura do arquivo de configuração ao abrir o programa
         /// </summary>
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
        /// <summary>
        /// Metodo para retorno do numero de equipamento registrado no arquivo de configuração.
        /// </summary>
        public int retorna_equipamento()
        {
            StreamReader leitura = new StreamReader(arquivo_conf);
             int equipamento = int.Parse(leitura.ReadLine());
              leitura.Close();
               return equipamento;
        }
        /// <summary>
        /// Metodo para retorno de URL do webservice
        /// </summary>
        public string Retorna_Url()
        {
            StreamReader leitura = new StreamReader(arquivo_conf);
            int eq = int.Parse(leitura.ReadLine());
            string ip = leitura.ReadLine();
            return ip;
        }
        /// <summary>
        /// Metodo para varredura do arquivo e salvando no banco de dados via webservices
        /// </summary>
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
<<<<<<< HEAD
                        string matriculaa = quebra[0];
                        long pess = long.Parse(quebra[1]);
                        equipamento = int.Parse(quebra[2]);
                        string Data_ = quebra[3];
                        Int16 sentido_ = Int16.Parse(quebra[4]);
                        Int16 status_sentido_= Int16.Parse(quebra[5]);
                        Int16 area_de_ = Int16.Parse(quebra[6]);
                        Int16 area_para_ = Int16.Parse(quebra[7]);
                        conecta.insere(matriculaa,pess, equipamento, Data_, sentido, status_sentido_, area_de_, area_para_);
=======
                        int matricula = int.Parse(quebra[0]);
                        equipamento = int.Parse(quebra[1]);
                        string Data_ = quebra[2];
                        Int16 sentido_ = Int16.Parse(quebra[3]);
                        Int16 status_sentido_= Int16.Parse(quebra[4]);
                        Int16 area_de_ = Int16.Parse(quebra[5]);
                        Int16 area_para_ = Int16.Parse(quebra[6]);
                        conecta.insere(matricula, equipamento, Data_, sentido, status_sentido_, area_de_, area_para_);
>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
                        progressBar1.Value = cont++;
                    }
                progressBar1.Visible = false;
                //deletando o arquivo
                    
                File.Delete(arquivo);
                LbStatus.Text = "ONLINE";
            }
        }
        /// <summary>
        /// Metodo para salvar arquivo caso não haja conexão com o servidor
        /// </summary>
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
<<<<<<< HEAD
           int pess = 0;
=======

>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
            //passar também o equipamento e salvar no banco
            //retorna_equipamento();
            status_sentido = 12;
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
<<<<<<< HEAD
            log.WriteLine(matricula + ";" + pes + ";" + equipamento + ";" + Data1 + " " + Data2 + ";" + sentido + ";" + status_sentido + ";" + area_de + ";" + area_para);
=======
            log.WriteLine(matricula + ";" + equipamento + ";" + Data1 + " " + Data2 + ";" + sentido + ";" + status_sentido + ";" + area_de + ";" + area_para);
>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
            //log.WriteLine();//verificar se ele ta incluindo algo em branco no banco 
            log.Close();
               //testando arquivo serializer
            //salvar_arquivoSerializado(status_sentido);
        }

<<<<<<< HEAD
        }
=======
        public void salvar_arquivoSerializado(int Ssentido)
        {
            Acesso myObject = new Acesso();
            myObject.Data11 = DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
            myObject.Equipamento = retorna_equipamento();
            myObject.Matricula = int.Parse(textBox1.Text);
            myObject.Status_sentido = Ssentido;
            //serializando arquivo
            // Insert code to set properties and fields of the object.
            XmlSerializer mySerializer = new XmlSerializer(typeof(Acesso));
            // To write to a file, create a StreamWriter object.
            StreamWriter myWriter = new StreamWriter("myFileName.xml");
            mySerializer.Serialize(myWriter, myObject);

        }
        public void Ler_arquivo_Serialize_para_banco()
        {
            Acesso myObject;
// Construct an instance of the XmlSerializer with the type
// of object that is being deserialized.
            XmlSerializer mySerializer =new XmlSerializer(typeof(Acesso));
// To read the file, create a FileStream.
            FileStream myFileStream = new FileStream("myFileName.xml", FileMode.Open);
// Call the Deserialize method and cast to the object type.
            myObject = (Acesso)mySerializer.Deserialize(myFileStream);
           
        }
     }
>>>>>>> f3f47d0cc5bfbfd5371eeae9b4216f12b18821d5
}