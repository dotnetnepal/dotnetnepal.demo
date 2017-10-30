using AutoMapper;
using dotnetnepal.ViewModels;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetnepal.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;


        public BlogController(IUnitOfWork unitOfWork, ILogger<BlogController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }



        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var allBlogs = _unitOfWork.Blogs.GetAllBlogsData();
            return Ok(Mapper.Map<IEnumerable<BlogViewModel>>(allBlogs));
        }

        
        [HttpGet("throw")]
        public IEnumerable<BlogViewModel> Throw()
        {
            throw new InvalidOperationException("This is a test exception: " + DateTime.Now);
        }

        
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value: " + id;
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }



        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
