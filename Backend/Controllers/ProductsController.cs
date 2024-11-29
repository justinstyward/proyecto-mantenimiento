using Backend.Adapters;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsAdapter productsAdapter = new ();

        [HttpPost]
        public bool CreateProduct(ProductsRequest model) => productsAdapter.CreateProduct(model);

        [HttpGet]
        public List<ProductsRequest> ReadProducts() => productsAdapter.ReadProducts();

    }
}
