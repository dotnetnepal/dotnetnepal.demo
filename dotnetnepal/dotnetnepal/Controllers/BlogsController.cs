using AutoMapper;
using dotnetnepal.ViewModels;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace dotnetnepal.Controllers
{
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        
        public BlogsController(IUnitOfWork unitOfWork, ILogger<BlogsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var allBlogs = _unitOfWork.Posts.GetAllPostsData();
            return Ok(Mapper.Map<IEnumerable<PostViewModel>>(allBlogs));
        }

        
        [HttpGet("throw")]
        public IEnumerable<PostViewModel> Throw()
        {
            throw new InvalidOperationException("This is a test exception: " + DateTime.Now);
        }

 
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var post = _unitOfWork.Posts.GetPost(Guid.Parse(id));
            return Ok(Mapper.Map<PostViewModel>(post));
        }


        [HttpPost]
        public void Post([FromBody]PostViewModel model)
        {
            if (ModelState.IsValid)
            {        
            _unitOfWork.Posts.SavePost(Mapper.Map<Post>(model));
            }
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _unitOfWork.Posts.DeletePost(Guid.Parse(id));
        }
    }
}
