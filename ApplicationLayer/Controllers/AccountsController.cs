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
                return BadRequest(ex.ToString());
            }
        }
    }
}
