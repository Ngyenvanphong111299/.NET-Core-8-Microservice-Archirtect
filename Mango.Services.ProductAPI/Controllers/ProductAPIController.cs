using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _ProductRepository;
        public ProductAPIController(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
            this._response = new ResponseDto();
        }

        [Authorize]
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _ProductRepository.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDto = await _ProductRepository.GetProductById(id);
                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [Authorize]
        [HttpPost, HttpPut]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto product = await _ProductRepository.CreateUpdateProduct(productDto);
                _response.Result = product;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
                throw;
            }

            return _response;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var result = await _ProductRepository.DeleteProduct(id);
                _response.Result = result;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
                throw;
            }

            return _response;
        }
    }
}
