using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BraspagAPI.Models
{
    public class Adquirente
    {
        public Adquirente()
        {
            Taxas = new List<Taxas>();
        }
        
        public string Nome { get; set; }

        public List<Taxas> Taxas { get; set; }
            

    }
}