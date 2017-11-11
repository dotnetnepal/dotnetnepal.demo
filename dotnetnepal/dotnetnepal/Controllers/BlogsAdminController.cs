using dotnetnepal.ViewModels;
using Infrastructure;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetnepal.Controllers
{
    public class BlogsAdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly SlugGenerator _slugGenerator;
        private readonly ExcerptGenerator _excerptGenerator;

        public BlogsAdminController(IUnitOfWork unitOfWork , SlugGenerator slugGenerator, ExcerptGenerator excerptGenerator)
        {
            _unitOfWork = unitOfWork;
            _slugGenerator = slugGenerator;
            _excerptGenerator = excerptGenerator;
        }

        public IActionResult Index()
        {
            Func<Post, bool> postFilter = p => p.IsPublic;
            Func<Post, bool> deletedPostFilter = p => !p.IsDeleted;
            IEnumerable<Post> postModels = _unitOfWork.Posts.GetAllPostsData().Where(postFilter).Where(deletedPostFilter);

            IEnumerable<PostSummaryModel> PostSummaries = postModels.Select(p => new PostSummaryModel
            {
                Id = p.Id,
                Slug = p.Slug,
                Title = p.Title,
                Excerpt = p.Excerpt,
                PublishTime = p.PubDate,
                CommentCount = p.Comments.Where(c => c.IsApproved).Count(),
            });


            return View(PostSummaries);
        }


        public IActionResult Post([FromRoute] Guid id)
        {
            var post = _unitOfWork.Posts.GetPost(id);
            return View(post);
        }

        public IActionResult New(PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(postViewModel.Excerpt))
                {
                    postViewModel.Excerpt = _excerptGenerator.CreateExcerpt(postViewModel.Body);
                }

                Post post = new Post
                {
                    Title = postViewModel.Title,
                    Body = postViewModel.Body,
                    Excerpt = postViewModel.Excerpt,
                    Slug = _slugGenerator.CreateSlug(postViewModel.Title),
                    LastModified = DateTimeOffset.Now,
                    IsDeleted = false,
                };

                if (postViewModel.PublishPost)
                {
                    post.PubDate = DateTimeOffset.Now;
                    post.IsPublic = true;
                }
                _unitOfWork.Posts.SavePost(post);
                RedirectToAction(nameof(Index));
            }

            return View(postViewModel);
        }

        public IActionResult Edit()
        {

            return View();
        }

        public IActionResult Delete()
        {

            return View();
        }

    }
}
