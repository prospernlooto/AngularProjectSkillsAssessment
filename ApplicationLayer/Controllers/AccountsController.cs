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
    public class AccountsController : ApiController
    {
        private readonly AccountService service = new AccountService();
        private readonly TransactionService transactionService = new TransactionService();


        [HttpGet]
        [Route("api/Accounts/GetAccountsByPersonCode/{id}")]

        public IHttpActionResult GetAccountsByPersonCode(int? id)
        {
            try
            {
                var accounts = service.GetAccountsByPersonCode(id);

                return Ok(accounts);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("api/Accounts/AddAccounts")]

        public IHttpActionResult AddAccounts(Accounts model)
        {

            try
            {
                var account = service.GetAllAccounts().FirstOrDefault(x => x.account_number == model.account_number);

                if (account != null)
                {
                    return BadRequest("You cannot have duplicated account numbers");
                }

                service.InsertNew(model);

                return Ok("Success");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


        [HttpPost]
        [Route("api/Accounts/UpdateAccounts")]

        public IHttpActionResult UpdateAccounts(Accounts model)
        {

            try
            {
                service.Update(model);

                return Ok("Success");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]

        [Route("api/Accounts/DeleteAccount/{code}")]

        public IHttpActionResult DeleteAccount(int? code)
        {

            try
            {
                var model = service.GetAccountByCode(code);

                if(model.outstanding_balance > 0)
                {
                    return BadRequest("You cannot close an account when the balance is not zero");
                }
                else
                {
                    transactionService.Delete(model.code);
                }

                service.Delete(model);

                var accounts = service.GetAccountsByPersonCode(model.person_code);
                return Ok(accounts);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("api/Accounts/GetAccountByCode/{code}")]

        public IHttpActionResult GetAccountByCode(int? code)
        {

            try
            {
                var viewModel = service.GetAccountByCode(code);

                return Ok(viewModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
