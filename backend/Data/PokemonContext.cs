using Microsoft.EntityFrameworkCore;
using PokemonBlog.Models;


namespace PokemonBlog.Data // This is what creates the database
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
            
            modelBuilder.Entity<User>() // user to freindship relationship
                .HasMany(U=>U.FriendShipsSent) // user has many sent request in his collention
                .WithOne(U=>U.Sender) // only one sender
                .HasForeignKey(U=>U.SenderId) // sender Id
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>() // another uses to frienshisp relationship 
                .HasMany(U => U.FriendShipsRecieved)
                .WithOne(U => U.Reciever)
                .HasForeignKey(U => U.RecieverId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Status>()
                .HasMany(F => F.FriendShips) //Status can be part of many friendships
                .WithOne(S => S.status) // Frienships table shows status
                .HasForeignKey(F => F.StatusId) // the foreign key to that status
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasMany(P=>P.Comments)
                .WithOne(C => C.Post)
                .HasForeignKey(C => C.PostId) // the Fk tha connects them lives in comments
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasMany(P => P.Likes)
                .WithOne(L => L.Post)
                .HasForeignKey(L => L.PostId)
                .OnDelete(DeleteBehavior.Cascade);
           




        }



    }
}
