using Backend.Adapters;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImptoController : ControllerBase
    {
        private readonly ImptoAdapter imptoAdapter = new();

        [HttpPost]
        public bool CreateProduct(ImptoRequest model) => imptoAdapter.CreateImpto(model);

        [HttpGet]
        public List<ImptoRequest> ReadProducts() => imptoAdapter.ReadImptos();
    }
}
