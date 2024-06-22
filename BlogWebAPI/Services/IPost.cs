using BlogWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebAPI.Services
{
    public interface IPost
    {
        Task<List<Post>> GetAllPost();

        Task<Post> GetPostById(int id);

        Task<List<Post>> GetPostByTitle(string title);

        Task<Post> AddPost(Post post);

        Task<Post> UpdatePostTitleById(int id, string title);

        Task<Post> DeletePostById(int id);
    }
}
