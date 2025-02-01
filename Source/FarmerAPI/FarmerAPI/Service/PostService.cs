using AutoMapper;
using FarmerAPI.Domain.Contracts;
using FarmerAPI.Domain.Entities;
using FarmerAPI.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FarmerAPI.Service
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PostService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PostResponse> CreatePostAsync(PostRequest request)
        {
            var post = _mapper.Map<Post>(request);
            post.Id = Guid.NewGuid();
            post.CreatedAt = DateTime.UtcNow;
            post.UpdatedAt = DateTime.UtcNow;

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return _mapper.Map<PostResponse>(post);
        }

        public async Task<PostResponse> GetPostByIdAsync(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) throw new Exception("Post not found");
            return _mapper.Map<PostResponse>(post);
        }

        public async Task<IEnumerable<PostResponse>> GetAllPostsAsync()
        {
            var posts = await _context.Posts.ToListAsync();
            return _mapper.Map<IEnumerable<PostResponse>>(posts);
        }

        public async Task<PostResponse> UpdatePostAsync(Guid id, PostRequest request)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) throw new Exception("Post not found");

            post.Title = request.Title;
            post.Content = request.Content;
            post.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return _mapper.Map<PostResponse>(post);
        }

        public async Task DeletePostAsync(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) throw new Exception("Post not found");

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
