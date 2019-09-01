using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BraspagAPI.Models
{
    public class Taxas
    {

        public Taxas(String bandeira, double credito, double debito)
        {
            Bandeira = bandeira;
            Credito = credito;
            Debito = debito;
        }
               
        public string Bandeira { get; set; }

        public double Credito { get; set; }

        public double Debito { get; set; }
    }
}