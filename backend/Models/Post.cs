
using System.Diagnostics.Contracts;

namespace PokemonBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;} 
        public string Content { get; set; }


        public int UserId { get; set; } // post belongs to a user
        public User User { get; set; } = null!; // This is here to acces User info thru this Post object

        public ICollection<Comment> Comments { get; set; } = new List<Comment>(); // Navigation property - one post has many comments

    }
}
