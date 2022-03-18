using Microsoft.AspNetCore.Mvc;
using Prova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Controllers
{

    [Route("api/[controller]")]   
    [ApiController]
    public class GetContaPagDetailsController : ControllerQuality
    {      

        [
           Route(""),
           HttpGet
       ]       
        public ActionResult<dynamic> index()
        {
            try
            {

                //var body = await this.GetBody<Data.ContasAReceber>();

                //if (body == null)
                //    throw new Exception("Parâmetros incorretos!");
                //else { }


                Data.ContaPagamento cp = new Data.ContaPagamento
                {
                    idContaPagamento = 1
                };

                cp = (Data.ContaPagamento)Utils.Utils.sr(0).consultar(cp);

                if (cp == null || (cp != null && cp.idContaPagamento == 0))
                {
                    throw new Exception("Pagamento não encontrado!");
                }               

                return UtilsGestao.UtilsApi.Retorno(cp);                

            }
            catch (Exception ex)
            {
                return BadRequest(UtilsGestao.UtilsApi.CatchError(ex));
            }
        }


    }
}
