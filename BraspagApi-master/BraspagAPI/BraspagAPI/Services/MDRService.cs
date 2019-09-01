using BraspagAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BraspagAPI.Services
{
    public class MDRService : IMDRService
    {

        public List<Adquirente> GetMBR()
        {

            var Adquirentes = new List<Adquirente>();
                      
            Adquirente adq = new Adquirente();

            adq.Nome = "Adquirente A";
            adq.Taxas.Add(new Taxas("Visa", 2.25, 2.00));
            adq.Taxas.Add(new Taxas("Master",2.35, 1.98));

            Adquirentes.Add(adq);

            adq = new Adquirente();

            adq.Nome = "Adquirente B";
            adq.Taxas.Add(new Taxas("Visa", 2.50, 2.08));
            adq.Taxas.Add(new Taxas("Master", 2.65, 1.75));

            Adquirentes.Add(adq);

            adq = new Adquirente();

            adq.Nome = "Adquirente C";
            adq.Taxas.Add(new Taxas("Visa", 2.75, 2.16));
            adq.Taxas.Add(new Taxas("Master", 3.10, 1.58));

            Adquirentes.Add(adq);

            return Adquirentes;
             
        }

        public List<string> ValidarTransacao(Transacao t)
        {
            var listaErros = new List<string>();

            if(t.Valor <= 0)
            {
                listaErros.Add("O campo Valor é obrigatório");
            }

            if (string.IsNullOrEmpty(t.Adquirente))
            {
                listaErros.Add("O campo Adquirente é obrigatório");
            }

            if (string.IsNullOrEmpty(t.Bandeira))
            {
                listaErros.Add("O campo Bandeira é obrigatório");
            }
            if (string.IsNullOrEmpty(t.Tipo))
            {
                listaErros.Add("O campo Tipo é obrigatório");
            }

            if (!t.Tipo.Equals("Credito") && !t.Tipo.Equals("Debito"))
            {
                listaErros.Add("O conteúdo do campo tipo é inválido");
            }

            return listaErros;
        }

        public Resposta GetValorLiquido(Transacao t)
        {
            var adquirente = GetMBR().FirstOrDefault(x => x.Nome.Contains(t.Adquirente));

            var taxasAdquirente = adquirente.Taxas.FirstOrDefault(x => x.Bandeira == t.Bandeira);

            var Resposta = new Resposta();

            if (t.Tipo == "Credito")
            {
                Resposta.ValorLiquido = t.Valor - (t.Valor * (taxasAdquirente.Credito/100));
            }
            else
            {
                Resposta.ValorLiquido = t.Valor - (t.Valor * (taxasAdquirente.Debito / 100));
            }

            return Resposta;
        }
    }
}