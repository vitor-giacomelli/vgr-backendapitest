using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VacationRental.Contact.Api.Models;
using VacationRental.Contact.Api.Models.DataManager;
using VacationRental.Contact.Api.Models.DataRepository;

namespace VacationRental.Contact.Api.Controllers
{
    [Route("api/v1/vacationrental/{rentalId:int}/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IDataRepository<ContactViewModel> _dataRepository;

        public ContactController(IDataRepository<ContactViewModel> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get([FromRoute] int rentalId)
        {
            ContactViewModel model = _dataRepository.GetById(rentalId);

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpPut]
        public IActionResult Put([FromRoute] int rentalId, [FromBody] ContactViewModel model)
        {
            if (model.Phone == null)
                return BadRequest();

            ContactViewModel dbEntity = _dataRepository.GetById(rentalId);

            if (dbEntity == null)
                return NotFound();

            _dataRepository.Update(dbEntity, model);

            return NoContent();
        }
    }
}
