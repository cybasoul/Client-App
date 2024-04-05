using Client_App.Data;
using Client_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Client_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly DBConnection _context;

        public ClientsController(DBConnection context)
        {
            _context = context;
        }

        // Implement your CRUD actions here

        //Create (POST):
        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return Ok(client.Id); // Return the newly created client's ID
            }
            return BadRequest(ModelState);
        }

        //Read (GET):
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _context.Clients.ToListAsync();
            return Ok(clients);
        }


        //Update (PUT):
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Client updatedClient)
        {
            var existingClient = await _context.Clients.FindAsync(id);
            if (existingClient == null)
                return NotFound();

            // Update properties
            existingClient.FirstName = updatedClient.FirstName;
            existingClient.LastName = updatedClient.LastName;
            existingClient.MobileNumber = updatedClient.MobileNumber;
            existingClient.IDNumber = updatedClient.IDNumber;
            existingClient.PhysicalAddress = updatedClient.PhysicalAddress;

            await _context.SaveChangesAsync();
            return Ok(existingClient);
        }

        //Delete (DELETE)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return NotFound();

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
