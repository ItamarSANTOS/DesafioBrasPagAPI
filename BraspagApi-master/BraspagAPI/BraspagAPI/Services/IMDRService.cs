using BraspagAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraspagAPI.Services
{
    public interface IMDRService
    {
       List<Adquirente> GetMBR();
       List<string> ValidarTransacao(Transacao t);
       Resposta GetValorLiquido(Transacao t);
    }
}
