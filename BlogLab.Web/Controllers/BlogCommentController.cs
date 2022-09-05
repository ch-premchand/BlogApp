using BlogLab.Models.BlogComment;
using BlogLab.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BlogLab.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCommentController : ControllerBase
    {
        private readonly IBlogCommentRepository _blogCommentPepository;

        public BlogCommentController(IBlogCommentRepository blogCommentPepository)
        {
            _blogCommentPepository = blogCommentPepository;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<BlogComment>> Create(BlogCommentCreate blogCommentCreate)
        {
            int applcationUseId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

            var createdBlogComment = await _blogCommentPepository.UpsertAsync(blogCommentCreate, applcationUseId);

            return Ok(createdBlogComment);

        }

        [HttpGet("{blogId}")]
        public async Task<ActionResult<List<BlogComment>>> GetAll(int blogId)
        {
            var blogComments = await _blogCommentPepository.GetAllAsync(blogId);

            return Ok(blogComments);
        }

        [Authorize]
        [HttpDelete("blogCommentId")]
        public async Task<ActionResult<int>> Delete(int blogCommentId)
        {
            int applcationUseId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

            var foundBlogComment = await _blogCommentPepository.GetAsync(blogCommentId);

            if (blogCommentId == null) return BadRequest("comment does not Exist");

            if (foundBlogComment.ApplicationUserId == applcationUseId)
            {
                var affectedRows = await _blogCommentPepository.DeleteAsync(blogCommentId);
                return Ok(affectedRows);
            }
            else 
            {
                return BadRequest("this comment not created by current user");
            }
        }
    }
}
