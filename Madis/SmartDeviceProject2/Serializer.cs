using System;

using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MarcaPonto
{
    public class Serializer
    {
        public void salvar_arquivoSerializado(int matricula,int sentido, int _area_de, int _area_para, int equipamento)
        {
            Acesso myObject = new Acesso();
            myObject.Data11 = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            myObject.Equipamento = equipamento;
            myObject.Matricula = matricula;
            myObject.Status_sentido = sentido;
            myObject.Area_de = _area_de;
            myObject.Area_para = _area_para;
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
            XmlSerializer mySerializer = new XmlSerializer(typeof(Acesso));
            // To read the file, create a FileStream.
            FileStream myFileStream = new FileStream("myFileName.xml", FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            myObject = (Acesso)mySerializer.Deserialize(myFileStream);

        }
     
    }
}
