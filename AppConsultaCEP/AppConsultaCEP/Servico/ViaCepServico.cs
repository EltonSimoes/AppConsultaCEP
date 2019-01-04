using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using AppConsultaCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace AppConsultaCEP.Servico
{
    public class ViaCepServico
    {
        private static readonly string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);
            WebClient wc = new WebClient();

            string Conteudo = wc.DownloadString(NovoEnderecoURL);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) { return null; }

            /*Caso emulador não acessa net*/
            /*string json = @"{ ""cep"" : ""32073-290"", 
                                ""logradouro"" : ""Rua Barra Longa"", 
                                ""complemento"": ""casa"",
                                ""bairro"": ""Industrial São Luiz"", 
                                ""localidade"": ""Contagem"",
                                ""uf"": ""MG"" }";
            Endereco end = JsonConvert.DeserializeObject<Endereco>(json);
            */
            return end;
        }
    }
}
