using BlogWebAPI.Exceptions;
using BlogWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebAPI.Services
{
    public class SqlPost : IPost
    {
        private readonly PostDbContext _dbContext;

        public SqlPost(PostDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<List<Post>> GetAllPost()
        {
            if(_dbContext != null)
            {
                return await _dbContext.Posts.ToListAsync();
            }

            return null;
        }

        private bool CheckZero(int id)
        {
            if (id <= 0)
            {
                throw new ZeroInputException("Ayush entered invalid id");
            }
            return true;
        }

        public async Task<Post> GetPostById(int id)
        {
            if(_dbContext != null && CheckZero(id))
            {
                return await _dbContext.Posts.FindAsync(id);
            }

            return null;
        }

        public async Task<List<Post>> GetPostByTitle(string title)
        {
            if (_dbContext != null)
            {
                return await _dbContext.Posts.Where(post => (post.Title).ToLower() == (title).ToLower()).ToListAsync();
            }

            return null;
        }

        public async Task<Post> AddPost(Post post)
        {
            if( _dbContext != null)
            {
                _dbContext.Posts.Add(post);
                await _dbContext.SaveChangesAsync();
                return post;
            }

            return null;
        }

        public async Task<Post> UpdatePostTitleById(int id, string title)
        {
            if(_dbContext != null)
            {
                var post = await this.GetPostById(id);
                if(post != null)
                {
                    post.Title = title;
                    _dbContext.Posts.Update(post);
                    await _dbContext.SaveChangesAsync();
                    return post;
                }
            }

            return null;
        }

        public async Task<Post> DeletePostById(int id)
        {
            if(_dbContext != null && CheckZero(id))
            {
                var post = await this.GetPostById(id);
                if(post != null)
                {
                    _dbContext.Posts.Remove(post);
                    await _dbContext.SaveChangesAsync();
                    return post;
                }
            }

            return null;
        }
    }
}
