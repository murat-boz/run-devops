using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping.API.Models;
using System.Collections.Generic;
using System;
using Shopping.API.Data;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private readonly ProductContext context;
        private readonly ILogger<ProductController> logger;

        public ProductController(ProductContext context, ILogger<ProductController> logger)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.logger  = logger  ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await context
                            .Products
                            .Find(p => true)
                            .ToListAsync();
        }
    }
}
