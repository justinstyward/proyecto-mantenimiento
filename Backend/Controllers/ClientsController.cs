using Backend.Adapters;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsAdapter clientsAdapter = new();

        [HttpPost]
        public bool CreateProduct(ClientsRequest model) => clientsAdapter.CreateClient(model);

        [HttpGet]
        public List<ClientsRequest> ReadProducts() => clientsAdapter.ReadClients();
    }
}
