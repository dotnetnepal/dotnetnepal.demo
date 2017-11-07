using Infrastructure;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetnepal.Pages.Blogs
{
    public class NewModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SlugGenerator _slugGenerator;
        private readonly ExcerptGenerator _excerptGenerator;
        public NewModel(IUnitOfWork unitOfWork, SlugGenerator slugGenerator, ExcerptGenerator excerptGenerator)
        {
            _unitOfWork = unitOfWork;
            _slugGenerator = slugGenerator;
            _excerptGenerator = excerptGenerator;
        }

        [BindProperty]
        public NewPostViewModel NewPost { get; set; }

        public void OnGet()
        {
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPostPublish()
        {
            if (ModelState.IsValid)
            {
                SavePost(NewPost, true);
                return Redirect("/Index");
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPostSaveDraft()
        {
            if (ModelState.IsValid)
            {
                SavePost(NewPost, false);
                return Redirect("/Drafts");
            }

            return Page();
        }

        private void SavePost(NewPostViewModel newPost, bool publishPost)
        {
            if (string.IsNullOrEmpty(newPost.Excerpt))
            {
                newPost.Excerpt = _excerptGenerator.CreateExcerpt(newPost.Body);
            }

            Post post = new Post
            {
                Title = newPost.Title,
                Body = newPost.Body,
                Excerpt = newPost.Excerpt,
                Slug = _slugGenerator.CreateSlug(newPost.Title),
                LastModified = DateTimeOffset.Now,
                IsDeleted = false,
            };

            if (publishPost)
            {
                post.PubDate = DateTimeOffset.Now;
                post.IsPublic = true;
            }

            if (Request != null)
            {
             //   _unitOfWork.Blogs.SaveFiles(Request.Form.Files.ToList());
            }

          //  _unitOfWork.Blogs.SavePost(post);
        }

        public class NewPostViewModel
        {
            [Required]
            public string Title { get; set; }
            [Required]
            public string Body { get; set; }
            public string Excerpt { get; set; }
        }


    }
}
