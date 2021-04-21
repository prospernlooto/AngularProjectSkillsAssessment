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
    public class PersonsController : ApiController
    {
        private readonly PersonService service = new PersonService();
        private readonly AccountService accountService = new AccountService();

        [HttpGet]
        [Route("api/Persons/GetAllPersons")]

        public IHttpActionResult GetAllPersons()
        {

            try
            {
                var persons = service.GetPersons();

                return Ok(persons);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("api/Persons/AddPersons")]

        public IHttpActionResult AddPersons(Persons model)
        {

            try
            {
                var person = service.GetPersons().FirstOrDefault(x=> x.id_number == model.id_number);

                if (person != null)
                {
                    return BadRequest("A person can only be created once with the same ID Number.");
                }

               service.InsertNew(model);

                return Ok("Success");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        [Route("api/Persons/UpdatePersons")]

        public IHttpActionResult UpdatePersons(Persons model)
        {

            try
            {
                service.Update(model);

                return Ok("Success");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
      
        [Route("api/Persons/DeletePersons/{code}")]

        public IHttpActionResult DeletePersons(int? code)
        {

            try
            {
                var model = service.GetPersonsById(code);

                var personAccountsList = accountService.GetAccountsByPersonCode(model.code);

                if (personAccountsList.Count > 0)
                {
                    return BadRequest("Only persons with no accounts or where all accounts are closed may be deleted.");
                }

                service.Delete(model);
                var persons = service.GetPersons();
                return Ok(persons);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("api/Persons/GetPersonByCode/{code}")]

        public IHttpActionResult GetPersonByCode(int? code)
        {

            try
            {
                var viewModel = service.GetPersonsById(code);

                return Ok(viewModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet]

        [Route("api/Persons/Search/{term}")]

        public IHttpActionResult Search(string term)
        {

            try
            {
                var model = service.SearchPersons(term);

                return Ok(model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
