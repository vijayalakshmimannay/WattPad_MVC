using System.Collections.Generic;
using WattPad.Models;

namespace WattPad.Repository
{
    public interface IBlogRL
    {
        public BlogModel AddBlog(BlogModel blog);
        public IEnumerable<BlogModel> GetAllBlogs();
        public BlogModel UpdateBlog(BlogModel blog);
        public BlogModel Delete(BlogModel blog);
        public IEnumerable<BlogModel> GetAllBlogsbyId(int Id);

    }
}
