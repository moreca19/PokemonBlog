using Microsoft.EntityFrameworkCore;

namespace PokemonBlog.Models
{
    public class PokemonContext : DbContext 
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DeckList> DeckLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>() //user to post relationship
                .HasMany(U => U.Posts)
                .WithOne(P => P.User)
                .HasForeignKey(P => P.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>() // user to comment realtionship
                .HasMany(U => U.Comments)
                .WithOne(C => C.User)
                .HasForeignKey(C => C.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>() //user to decklist relationship
                .HasMany(U => U.Decklists)
                .WithOne(D => D.User)
                .HasForeignKey(D => D.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasMany(P=>P.Comments)
                .WithOne(C => C.Post)
                .HasForeignKey(C => C.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasIndex(U => U.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(U => U.UserName)
                .IsUnique();





        }



    }
}
