using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;



[WebService(Namespace = "http://127.0.0.1/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void insere(int Matricula, int equipamento, string Data, Int16 Sentido, Int16 status_sentido, Int16 area_de, Int16 area_para) {
        Config comunica = new Config();
        comunica.Inserir_Log(Matricula, equipamento, Data, Sentido, status_sentido, area_de, area_para);   
    }
    [WebMethod]
    public string consulta(string matricula)
    {
        Config pesquisa = new Config();
        return pesquisa.consulta(matricula);
        
    }
   
        
}
