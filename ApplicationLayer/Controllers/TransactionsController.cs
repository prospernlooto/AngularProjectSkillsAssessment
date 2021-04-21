using DAL.Models;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers
{
    public class TransactionsController : ApiController
    {

        private readonly TransactionService service = new TransactionService();

        [HttpGet]
        [Route("api/Transactions/GetTransactionsByAccountCode/{id}")]

        public IHttpActionResult GetTransactionsByAccountCode(int? id)
        {
            try
            {
                var accounts = service.GetTransactionsByAccountCode(id);

                return Ok(accounts);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("api/Transactions/AddTransactions")]

        public IHttpActionResult AddTransactions(Transactions model)
        {

            try
            {
                service.Validate(model);
                service.InsertNew(model);

                return Ok("Success");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("api/Transactions/UpdateTransaction")]

        public IHttpActionResult UpdateTransaction(Transactions model)
        {

            try
            {
                service.Validate(model);

                service.Update(model);

                return Ok("Success");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
