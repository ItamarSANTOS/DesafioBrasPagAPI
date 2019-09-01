using BraspagAPI.Models;
using BraspagAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BraspagAPI.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMDRService _MDRService;
               
        public MainController(IMDRService MDRService)
        {
            _MDRService = MDRService;
        }

        [Route("api/v1/mdr/")]
        public async Task<IHttpActionResult> GetMDR()
        {
            try
            {
                var Mdr = _MDRService.GetMBR();

                if (!Mdr.Any())
                {
                    return NotFound();
                }

                return Ok(Mdr);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        [Route("api/v1/transaction/")]
        public async Task<IHttpActionResult> Transaction(Transacao t)
        {
            try
            {
                if(t == null)
                {
                    return BadRequest("O Objeto não pode ser vazio");
                }

                var validacao = _MDRService.ValidarTransacao(t);

                if (validacao.Any())
                {
                    return BadRequest(string.Join("/n", validacao));
                }

                var ValorLiquido = _MDRService.GetValorLiquido(t);

                return Ok(ValorLiquido);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }



        }

    }
}