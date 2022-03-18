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
    public class GetContaPagController : ControllerQuality
    {      

        [
           Route(""),
           HttpGet
       ]
        public ActionResult<dynamic> Index()
        {

            try
            {

                int EmpresaId = 1;

                //recebe o POst do HTML
                //var body = await this.GetBody<Data.ContaPagamento>();

                Data.ContaPagamento contapagamento = new Data.ContaPagamento
                {
                    idEmpresa = EmpresaId
                    // descricao = "descricao"                
                };


                List<Utils.NameValue> _params = new List<Utils.NameValue>();
                _params.Add(new Utils.NameValue { name = "Order", value = "ContaPagamento.order" });

                //Se nao for null, cria o List
                int startRowIndex = 1;
                int maxRowsPerPage = 10; // 10 linhas -- select top 10
                List<Data.Base> results = Utils.Utils.listaDados(EmpresaId, contapagamento, maxRowsPerPage, _params);

                //retorno ao frond
                var obj = new
                {
                    totalRows = Utils.Utils.getCount(EmpresaId, contapagamento, _params),
                    maxRowsPerPage,
                    startRowIndex,
                    results,

                    /* A função FillFormComponentFields é responsável por gerar um GRID automático, de acordo com a estrutura da classe em questão. 
                    * Esse grid é enviado ao front end e transformado em HTML.
                    */
                    grid = GenerateGrid ? new UtilsApi.Grid().FillFormComponentFields(contapagamento.GetType(), false) : new GridModel { }


                };

                return UtilsGestao.UtilsApi.Retorno(obj);

            }
            catch (Exception ex)
            {
                return BadRequest(UtilsGestao.UtilsApi.CatchError(ex));
            }


        }


    }
}
