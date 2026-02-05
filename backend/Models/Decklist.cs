
using System;

namespace PokemonBlog.Models
{
    public class DeckList
    {
        public int Id { get; set; }
        
        public string ListName { get; set; }
        
        public string ListDescription { get; set; }

       

        public DateTime DateCreated { get; set; }
        
        public DateTime DateUpdated { get; set; }


        public int UserId { get; set; }
        
        public User User { get; set; }

    }
}
