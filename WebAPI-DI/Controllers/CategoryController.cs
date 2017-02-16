using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductStore.Models;

namespace ProductStore.Controllers
{
    public class CategoryController : ApiController
    {
        ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        //public IEnumerable<Category> Get()
        //{
        //    return _repository.GetAll();
        //}

        public IHttpActionResult Get(int id)
        {
            var product = _repository.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public IHttpActionResult Post(Category catogry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.Add(catogry);
            return CreatedAtRoute("DefaultApi", new { id = catogry.Id }, catogry);
        }
        [Route("SearchWithPaging")]
    [HttpGet]
        public IEnumerable<Category> SearchWithPaging(SearchModel search)
        {
            return _repository.SearchWithPaging(search);
        }
    }
}
