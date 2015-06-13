using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Banco
{
    public class Blanco
    {
        private string strconn;
      private SqlConnection conn;
        
    public Blanco()
	{
        // strconn = "Server = workstation id=Pousadaa.mssql.somee.com;packet size=4096;user id=jimi;pwd=ledankn218;data source=Pousadaa.mssql.somee.com;persist security info=False;initial catalog=Pousadaa";
        //strconn = @"Data Source= mssql.continentino.com;Initial Catalog=recad;User ID=recad;Password=nkn218";
        strconn = @"Server =PROG\SQLEXPRESS;Initial Catalog=RBACESSO_V100;User ID=sa;Password=18 ";
        conn = new SqlConnection(strconn);
        conn.Close();
    }


    public string Inserir_Log(int Matricula, string Data, int Sentido)
    {
        // já inicializada no construtor
        SqlConnection conn = new SqlConnection(strconn);
        // obtém o ID que precisava
        conn.Open();
        SqlTransaction transacao = conn.BeginTransaction();
        StringBuilder sb = new StringBuilder();
        String sqlProduto = "INSERT INTO Teste ([Matricula],[Data],[Sentido]) VALUES (@Matricula,@Data,@Sentido)";
        SqlCommand cmdProduto = new SqlCommand(sqlProduto, conn, transacao);
        cmdProduto.Parameters.AddWithValue("@Matricula", Matricula);
        cmdProduto.Parameters.AddWithValue("@Data", Data);
        cmdProduto.Parameters.AddWithValue("@Sentido", Sentido);
        cmdProduto.ExecuteNonQuery();
        transacao.Commit();
        return "";
    }
    public string consulta(string matricula)
    {
        //codigo do botão
        string Matricula="";
        string Flag="";
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
        if (( matricula == Matricula) && (Flag == "8"))
        {
            return "Liberado";
        }
        else
        {
            return "Recusado";
            //salva em uma tabela temp no dispositivo
        }
    }
    public string Inserir_Log2(int matricula, int equipamento, string Data, Int16 sentido, Int16 status_sentido, Int16 area_de, Int16 area_para)
    {
        // já inicializada no construtor
        SqlConnection conn = new SqlConnection(strconn);
        // obtém o ID que precisava
        conn.Open();
        SqlTransaction transacao = conn.BeginTransaction();
        StringBuilder sb = new StringBuilder();
        String sqlProduto = "INSERT INTO LOG_CREDENCIAL([CRED_NUMERO],[EQPI_NUMERO],[MOV_DATAHORA],[MOV_ENTRADASAIDA],[LGCRTI_NUMERO],[ARE_NUMERODE],[ARE_NUMEROPARA],[MOV_FUNCAO],[GRP_NUMERO],[PES_NUMERO],[VISI_NUMERO],[VITA_NUMERO]) VALUES (@CRED_NUMERO,@EQPI_NUMERO,@MOV_DATAHORA,@MOV_ENTRADASAIDA,@LGCRTI_NUMERO,@ARE_NUMERODE,@ARE_NUMEROPARA,@MOV_FUNCAO,@GRP_NUMERO,@PES_NUMERO,@VISI_NUMERO,@VITA_NUMERO)";
        SqlCommand cmdProduto = new SqlCommand(sqlProduto, conn, transacao);
        cmdProduto.Parameters.AddWithValue("@CRED_NUMERO", matricula);
        cmdProduto.Parameters.AddWithValue("@EQPI_NUMERO",equipamento);
        cmdProduto.Parameters.AddWithValue("@MOV_DATAHORA", Data);
        cmdProduto.Parameters.AddWithValue("@MOV_ENTRADASAIDA", sentido);
        cmdProduto.Parameters.AddWithValue("@LGCRTI_NUMERO", status_sentido);
        cmdProduto.Parameters.AddWithValue("@ARE_NUMERODE", area_de);
        cmdProduto.Parameters.AddWithValue("@ARE_NUMEROPARA", area_para);
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


    }
}
