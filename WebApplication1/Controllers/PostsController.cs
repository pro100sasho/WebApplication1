using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebSite.Models;
using WebSite.Servises;

namespace WebSite.Controllers
{
    public class PostsController : Controller
    {
        public readonly UserManager<IdentityUser> userManager;

        public readonly IPostServise postServise;

        public PostsController(IPostServise postServise, UserManager<IdentityUser> userManager)
        {
            this.postServise = postServise;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult AllPosts()
        {
            List <PostModel> postModels = postServise.GetAllPosts();

            return View(postModels);
        }


        [Authorize]
        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        public IActionResult GetPost(int id)
        {
            PostModel post = postServise.GetPost(id);


            return View(post);
        }

        public async Task<IActionResult> CreatePost(PostModel postModel)
        {

            var user = await userManager.GetUserAsync(HttpContext.User);
            postModel.PosterName = user.UserName;

            bool result = await this.postServise.CreatePost(postModel);

            return Redirect("/");
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateComment()
        {
            return View();
        }

        public async Task<IActionResult> CreateComment(CommentModel commentModel)
        {


            bool result = await this.postServise.CreateComment(commentModel);

            return Redirect("/");
        }

    }
}
