using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BraspagAPI.Models
{
    public class Transacao
    {
        public float Valor { get; set; }
        
        public string Adquirente { get; set; }

        public string Bandeira { get; set; }

        public string Tipo { get; set; }

    }
}