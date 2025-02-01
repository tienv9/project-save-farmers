using FarmerAPI.Domain.Contracts;

namespace FarmerAPI.Service
{
    public interface IPostService
    {
        Task<PostResponse> CreatePostAsync(PostRequest request);
        Task<PostResponse> GetPostByIdAsync(Guid id);
        Task<IEnumerable<PostResponse>> GetAllPostsAsync();
        Task<PostResponse> UpdatePostAsync(Guid id, PostRequest request);
        Task DeletePostAsync(Guid id);
    }
}
