using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace SmartDeviceProject2
{
    public class Conecta
    {
      private string strconn;
      private SqlConnection conn;
        
    public Conecta()
      {
       strconn = @"Server =PROG\SQLEXPRESS;Initial Catalog=RBACESSO_V100;User ID=sa;Password=18";
       //lendo configuração do arquivo
        //strconn = @"Server="+Nome+@"\"+Estancia+";Initial Catalog=RBACESSO_V100;User ID="+Usuario+";Password="+Senha;
        conn = new SqlConnection(strconn);
        conn.Close();
    }

    //inserindo em log_credencial o acesso
    public string Inserir_Log()
    {
        // já inicializada no construtor
        SqlConnection conn = new SqlConnection(strconn);
        // obtém o ID que precisava
        conn.Open();
        SqlTransaction transacao = conn.BeginTransaction();
        StringBuilder sb = new StringBuilder();
        String sqlProduto = "INSERT INTO LOG_CREDENCIAL([CRED_NUMERO],[EQPI_NUMERO],[MOV_DATAHORA],[MOV_ENTRADASAIDA],[LGCRTI_NUMERO],[ARE_NUMERODE],[ARE_NUMEROPARA],[MOV_FUNCAO],[GRP_NUMERO],[PES_NUMERO],[VISI_NUMERO],[VITA_NUMERO]) VALUES (@CRED_NUMERO,@EQPI_NUMERO,@MOV_DATAHORA,@MOV_ENTRADASAIDA,@LGCRTI_NUMERO,@ARE_NUMERODE,@ARE_NUMEROPARA,@MOV_FUNCAO,@GRP_NUMERO,@PES_NUMERO,@VISI_NUMERO,@VITA_NUMERO)";
        SqlCommand cmdProduto = new SqlCommand(sqlProduto, conn, transacao);
        cmdProduto.Parameters.AddWithValue("@CRED_NUMERO", 3310);
        cmdProduto.Parameters.AddWithValue("@EQPI_NUMERO", 18);
        cmdProduto.Parameters.AddWithValue("@MOV_DATAHORA", "18/11/1998");
        cmdProduto.Parameters.AddWithValue("@MOV_ENTRADASAIDA", 2);
        cmdProduto.Parameters.AddWithValue("@LGCRTI_NUMERO", 10);
        cmdProduto.Parameters.AddWithValue("@ARE_NUMERODE", 1);
        cmdProduto.Parameters.AddWithValue("@ARE_NUMEROPARA", 2);
        cmdProduto.Parameters.AddWithValue("@MOV_FUNCAO", 0);
        cmdProduto.Parameters.AddWithValue("@GRP_NUMERO", 3);
        cmdProduto.Parameters.AddWithValue("@PES_NUMERO", 0);
        cmdProduto.Parameters.AddWithValue("@VISI_NUMERO", 0);
        cmdProduto.Parameters.AddWithValue("@VITA_NUMERO", 0);
        cmdProduto.ExecuteNonQuery();
        transacao.Commit();
       // conn.Close();
        return "";
    }
     
        //pesquisando a matricula 
        public string consulta(string matricula)
    {
        //codigo do botão
        string Matricula = "";
        string Flag = "";
        string SqlConsulta = @"Select * From Pessoas where PES_NUMERO=@PES_NUMERO";
        SqlCommand objcomando = new SqlCommand(SqlConsulta, conn);
        objcomando.Parameters.Add("@PES_NUMERO", SqlDbType.VarChar).Value = matricula;
        conn.Open();
        SqlDataReader leitor = objcomando.ExecuteReader();
        while (leitor.Read())
        {
            Matricula = leitor["PES_NUMERO"].ToString();
            Flag = leitor["PESSIT_NUMERO"].ToString();
        }
        conn.Close();
        if ((matricula == Matricula) && (Flag == "8"))
        {
            return "Liberado";
        }
        else
        {
            return "Recusado";
            //salva em uma tabela temp no dispositivo
        }
      
    }

    }
}
