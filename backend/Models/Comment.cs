

namespace PokemonBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int UserId { get; set; } // foreign key to user who owns comment
        public User User { get; set; } = null!; // this is here to be able to access User info thru this Comment object
        public int PostId {  get; set; } // foreign key 
        public Post Post { get; set; } = null!; // this is here to be able to access Post info thru this Comment object


    }
}
