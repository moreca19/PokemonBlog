using Microsoft.EntityFrameworkCore;
using PokemonBlog.Models;
namespace PokemonBlog.Model
{
    public class PokemonContext : DbContext 
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Decklist> DeckLists { get; set; } 


        
    }
}
