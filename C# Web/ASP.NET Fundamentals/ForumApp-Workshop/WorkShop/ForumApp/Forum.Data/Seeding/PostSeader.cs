using ForumApp.Data.Models;

namespace ForumApp.Data.Seeding
{
    class PostSeader
    {

        ICollection<Post> posts = new HashSet<Post>();
        Post currentPost;
        internal Post[] GeneratePosts()
        {         
            currentPost = new Post()
            {

                Title = "My first post",
                Content = "My first post will be about performing " +
                "CRUD operations in MVC. It's so much fun!"
            };
            posts.Add(currentPost);
            currentPost = new Post()
            {

                Title = "My second post.",
                Content = "This is my second post. " +
                "CRUD operations in MVC are getting more and more interesting!"
            };
            posts.Add(currentPost);
            currentPost = new Post()
            {

                Title = "My third post",
                Content = "Hello there! I'm getting better and better with the" +
                "CDUD operation in MVC. Stay tuned!"
            };
            posts.Add(currentPost);
            return posts.ToArray();
        }
    }
}
