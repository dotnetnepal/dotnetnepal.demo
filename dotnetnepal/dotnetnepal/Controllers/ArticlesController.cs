using dotnetnepal.Features.Articles;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetnepal.Controllers
{
    [Route("articles")]
    public class ArticlesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticlesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       // [HttpGet]
        //public async Task<ArticlesEnvelope> Get([FromQuery] string tag, [FromQuery] string author, [FromQuery] string favorited, [FromQuery] int? limit, [FromQuery] int? offset)
        //{
        //  //  return await _unitOfWork.Articles.SaveArticle(new List.Query(tag, author, favorited, limit, offset));
        //}

        //[HttpGet("feed")]
        //public async Task<ArticlesEnvelope> GetFeed([FromQuery] string tag, [FromQuery] string author, [FromQuery] string favorited, [FromQuery] int? limit, [FromQuery] int? offset)
        //{
        //    //return await _mediator.Send(new List.Query(tag, author, favorited, limit, offset)
        //    //{
        //    //    IsFeed = true
        //    //});
        //}

        //[HttpGet("{slug}")]
        //public async Task<ArticleEnvelope> Get(string slug)
        //{
        //    //return await _mediator.Send(new Details.Query(slug));
        //}

        //[HttpPost]
        //public async Task<ArticleEnvelope> Create([FromBody]Create.Command command)
        //{
        //    return await _unitOfWork.Articles.SaveArticle(command);
        //}

        //[HttpPut("{slug}")]
        //[Authorize(AuthenticationSchemes = JwtIssuerOptions.Scheme)]
        //public async Task<ArticleEnvelope> Edit(string slug, [FromBody]Edit.Command command)
        //{
        //    command.Slug = slug;
        //    return await _mediator.Send(command);
        //}

        //[HttpDelete("{slug}")]
        //[Authorize(AuthenticationSchemes = JwtIssuerOptions.Scheme)]
        //public async Task Delete(string slug)
        //{
        //    await _mediator.Send(new Delete.Command(slug));
        //}


    }
}

