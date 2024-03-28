using ContactApi.ViewModels;
using ContactDataAccess.Models;
using ContactDataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsApiController : ControllerBase
    {
        private readonly ContactsRepository _repo;

        public ContactsApiController()
        {
            _repo = new ContactsRepository();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody]CreateContactViewModel model)
        {
            var created = new ContactsModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName, 
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                IsDelete = model.IsDelete
            };

            var result = await _repo.CreateAsync(created);

            var viewModel = new CreateContactViewModel
            {
                FirstName = result.FirstName,
                LastName = result.LastName, 
                Email = result.Email,
                PhoneNumber = result.PhoneNumber, 
                IsDelete = result.IsDelete
            };

            return Ok(viewModel);
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> DeleteEventAsync(int Id)
        {
            var toArchive = new ContactsModel
            {
                ID = Id,
            };

            await _repo.DeleteAsync(toArchive);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var result = await _repo.IsDeleted(false);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContactById(UpdateContactViewModel model)
        {
            var events = new ContactsModel
            {
                ID = model.ID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _repo.UpdateAsync(events);

            var response = new UpdateContactViewModel
            {
                ID = result.ID,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber
            };

            return Ok(response);
        }
    }
}
