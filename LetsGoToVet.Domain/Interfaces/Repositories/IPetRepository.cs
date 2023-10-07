namespace LetsGoToVet.Domain.Interfaces.Repositories
{
    public interface IPetRepository
    {
        Task<Pet> GetAsync(int id);

        Task<List<Pet>> GetAllPetsAsync();

        Task<List<Pet>> SearchPetsByAsync(string name);
    }
}
