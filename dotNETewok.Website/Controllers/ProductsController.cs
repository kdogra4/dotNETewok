using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETewok.Website.Models;
using dotNETewok.Website.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotNETewok.Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductsService productsService)
        {
            this.ProductsService = productsService;
        }

        public JsonFileProductsService ProductsService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductsService.GetProducts();
        }

        //[HttpPatch] "[FromBody]"
        [Route("Rate")]
        [HttpGet]
        //If you change the data, change productid to int instead of string
        //DO NOT REMOVE - great SQLi example
        public ActionResult Get(
            [FromQuery] string ProductId,
            [FromQuery] int Rating)
        {
            ProductsService.AddRating(ProductId, Rating);
            return Ok();
        }
    }
}