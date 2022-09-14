using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        //Get all Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                //can call the stop proccedure here.
                var products = await this.productRepository.GetItems();

                if(products == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDtos = products.ConvertToDto();

                    return Ok(productDtos);

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to Retireve data from Db");
            }
        }

        //Get Item by specified category
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetItem(int id)
        {
            try
            {
                //can call the stop proccedure here.
                var product = await this.productRepository.GetItem(id);

                if (product == null)
                {
                    return BadRequest();
                }
                else
                {
                    var productDto = product.ConvertToDto();
                    return Ok(productDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to Retireve data from Db");
            }
        }

        [HttpGet]
        [Route(nameof(GetProductCategories))]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetProductCategories ()
        {
            try
            {
                var productCategories = await productRepository.GetCategories();
                var productCategoriesDtos = productCategories.ConvertToDto();

                return Ok(productCategoriesDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to Retireve data from Db");
            }
        }

        [HttpGet]
        [Route("{categoryId}/GetItemsByCategory")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var products = await productRepository.GetItemsByCategory(categoryId);
                var productDtos = products.ConvertToDto();

                return Ok(productDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to Retireve data from Db");
            }
        }
    }
}
