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
        Task<List<Adquirente>> GetMBR();
        Task<List<string>> ValidarTransacao(Transacao t);
        Task<Resposta> GetValorLiquido(Transacao t);
    }
}
