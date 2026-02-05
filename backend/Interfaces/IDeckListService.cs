namespace PokemonBlog.Interfaces
{
    public interface IDeckListService
    {
        void NewDeckList(string Name, string Description);

        void UpdateDeckList(string Name, string Description,int id);
    }
}
