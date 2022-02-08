using Domain.Contract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace GenericRepository.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImplementationController : ControllerBase
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Country> _countryRepository;

        public ImplementationController(IRepository<Person> personRepository, IRepository<Country> countryRepository)
        {
            _personRepository = personRepository;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        [Route("/persons")]
        public IEnumerable<Person> GetPersons()
        {
            var persons = _personRepository.GetAll();
            var person = _personRepository.GetOne(x => x.Id == 1);
            var create = _personRepository.Create(new Person());
            var update = _personRepository.Update(new Person());
            var delete = _personRepository.Delete(new Person());
            var personsByName = _personRepository.GetByExpression(x => x.Name.Contains("Victor"));
            var personCountByName = _personRepository.CountByExpression(x => x.LastName.Contains("Jameus"));

            return persons;
        }

        [HttpGet]
        [Route("/countries")]
        public IEnumerable<Country> GetCountries()
        {
            var countries = _countryRepository.GetAll();
            var country = _countryRepository.GetOne(x => x.Id == 1);
            var create = _countryRepository.Create(new Country());
            var update = _countryRepository.Update(new Country());
            var delete = _countryRepository.Delete(new Country());
            var countryByName = _countryRepository.GetByExpression(x => x.Name.Contains("Chile"));
            var countryCountByName = _countryRepository.CountByExpression(x => x.Name.Contains("Chile"));

            return countries;
        }
    }
}