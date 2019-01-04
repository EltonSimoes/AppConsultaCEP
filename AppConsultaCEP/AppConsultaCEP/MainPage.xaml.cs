using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppConsultaCEP.Servico.Modelo;
using AppConsultaCEP.Servico;

namespace AppConsultaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //Parou aula 25
            if (!string.IsNullOrEmpty(CEP.Text))
            {
                string cep = CEP.Text.Trim();
                if (isValidCEP(cep))
                {
                    try
                    {
                        Endereco end = ViaCepServico.BuscarEnderecoViaCEP(cep);
                        if (end != null)
                        {
                            RESULTADO.Text = string.Format("Endereço: {2} de {3} {0}, {1}", end.localidade, end.uf, end.logradoro, end.bairro);
                        }
                        else
                        {
                            DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado" + cep, "Ok");
                        }
                    }
                    catch(Exception e)
                    {
                        DisplayAlert("Erro", e.Message, "OK");
                    }
                }
            }

        }

        private bool isValidCEP(string cep)
        {
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                return false;
            }

            if (!int.TryParse(cep, out int NovoCep))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas por números", "OK");
                return false;
            }

            return true;
        }
    }
}
