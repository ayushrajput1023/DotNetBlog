using BlogWebAPI.Exceptions;
using BlogWebAPI.Models;
using BlogWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public readonly IPost iPost;

        public PostsController(IPost iPost)
        {
            this.iPost = iPost;
        }


        [HttpGet]
        [Route("GetAllPost")]
        public async Task<IActionResult> GetAllPost()
        {
            try
            {
                var posts = await iPost.GetAllPost();
                if(posts != null)
                {
                    return Ok(posts);
                }
                else
                {
                    return NotFound("Ayush No Post available");
                }
            }
            catch
            {
                return BadRequest("Ayush is told Database is empty");
            }
        }


        [HttpGet]
        [Route("GetPostById/{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            try
            {
                var post = await iPost.GetPostById(id);
                if (post != null)
                {
                    return Ok(post);
                }
                else
                {
                    return NotFound("Ayush Post with " + id + " Not available");
                }
            }
            catch(ZeroInputException e)
            {
                throw new ZeroInputException(e.Message);
            }
        }


        [HttpGet]
        [Route("GetPostByTitle/{title}")]
        public async Task<IActionResult> GetPostById(string title)
        {
            try
            {
                var posts = await iPost.GetPostByTitle(title);
                if (posts != null)
                {
                    return Ok(posts);
                }
                else
                {
                    return NotFound("Ayush Post with " + title + " Not available");
                }
            }
            catch (ZeroInputException e)
            {
                throw new ZeroInputException(e.Message);
            }
        }


        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> AddPost([FromBody] Post post)
        {
            try
            {
                var addPost = await iPost.AddPost(post);
                if (addPost != null)
                {
                    return Ok(addPost);
                }
                else
                {
                    return NotFound("Ayush Post Not added");
                }
            }
            catch (ZeroInputException e)
            {
                throw new ZeroInputException(e.Message);
            }
        }


        [HttpPatch]
        [Route("UpdatePostTitleById/{id}/{title}")]
        public async Task<IActionResult> UpdatePostTitleById(int id, string title)
        {
            try
            {
                var post = await iPost.UpdatePostTitleById(id, title);
                if (post != null)
                {
                    return Ok(post);
                }
                else
                {
                    return NotFound("Ayush Post Not updated");
                }
            }
            catch (ZeroInputException e)
            {
                throw new ZeroInputException(e.Message);
            }
        }


        [HttpDelete]
        [Route("DeletePostById/{id}")]
        public async Task<IActionResult> DeletePostById(int id)
        {
            try
            {
                var post = await iPost.DeletePostById(id);
                if (post != null)
                {
                    return Ok(post);
                }
                else
                {
                    return NotFound("Ayush Post Not deleted");
                }
            }
            catch (ZeroInputException e)
            {
                throw new ZeroInputException(e.Message);
            }
        }
    }
}
