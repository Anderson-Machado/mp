using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for Config
/// </summary>
public class Config
{
    private string strconn;
    private SqlConnection conn;
    
    public Config()
    {
        strconn =ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        conn = new SqlConnection(strconn);
        conn.Close();
    }


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
    public string Inserir_Log(int matricula, int equipamento, string Data, Int16 sentido, Int16 status_sentido, Int16 area_de, Int16 area_para)
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
        cmdProduto.Parameters.AddWithValue("@EQPI_NUMERO", equipamento);
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
