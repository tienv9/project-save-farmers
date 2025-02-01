using FarmerAPI.Domain.Contracts;
using FarmerAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmerAPI.Controllers
{
    [Route("api/posts")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostRequest request)
        {
            var response = await _postService.CreatePostAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(Guid id)
        {
            var response = await _postService.GetPostByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var response = await _postService.GetAllPostsAsync();
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, [FromBody] PostRequest request)
        {
            var response = await _postService.UpdatePostAsync(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            await _postService.DeletePostAsync(id);
            return NoContent();
        }
    }
}
