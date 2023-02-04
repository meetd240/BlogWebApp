using BlogWebAppProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebAppProj.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);

        List<Post> GetAllPosts(int id);

        void AddPost(Post post);
        
        void RemovePost(int id);
        
        void UpdatePost(Post post);

        Task<bool> SaveChangesAsync();
    }
}
