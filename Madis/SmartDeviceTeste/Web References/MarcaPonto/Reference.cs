﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.6421
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.6421.
// 
namespace SmartDeviceTeste.MarcaPonto {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceSoap", Namespace="http://127.0.0.1/")]
    public partial class Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Service() {
            this.Url = "http://10.0.6.91/web/service.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://127.0.0.1/insere", RequestNamespace="http://127.0.0.1/", ResponseNamespace="http://127.0.0.1/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void insere(int Matricula, int pes, int equipamento, string Data, short Sentido, short status_sentido, short area_de, short area_para) {
            this.Invoke("insere", new object[] {
                        Matricula,
                        pes,
                        equipamento,
                        Data,
                        Sentido,
                        status_sentido,
                        area_de,
                        area_para});
        }
        
        /// <remarks/>
        public System.IAsyncResult Begininsere(int Matricula, int pes, int equipamento, string Data, short Sentido, short status_sentido, short area_de, short area_para, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("insere", new object[] {
                        Matricula,
                        pes,
                        equipamento,
                        Data,
                        Sentido,
                        status_sentido,
                        area_de,
                        area_para}, callback, asyncState);
        }
        
        /// <remarks/>
        public void Endinsere(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://127.0.0.1/consulta", RequestNamespace="http://127.0.0.1/", ResponseNamespace="http://127.0.0.1/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string consulta(string matricula) {
            object[] results = this.Invoke("consulta", new object[] {
                        matricula});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult Beginconsulta(string matricula, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("consulta", new object[] {
                        matricula}, callback, asyncState);
        }
        
        /// <remarks/>
        public string Endconsulta(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
}