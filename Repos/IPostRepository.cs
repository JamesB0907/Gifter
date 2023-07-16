using Gifter.Models;

namespace Gifter.Repositories
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Delete(int id);
        List<Post> GetAll();
        public List<Post> GetAllWithComments();
        Post GetById(int id);
        void Update(Post post);
        public List<Post> Search(string criterion, bool sortDescending);
        public List<Post> HottestPosts(DateTime since);
        public Post GetPostByIdWithComments(int id);

    }
}