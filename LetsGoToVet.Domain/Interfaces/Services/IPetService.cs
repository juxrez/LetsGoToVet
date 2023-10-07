namespace LetsGoToVet.Domain.Interfaces.Services
{
    public interface IPetService
    {
        Task<Pet> GetPet(int id);

        Task<List<Pet>> GetAllPets(string name);

        Task<Pet> CreatePetAsync(Pet pet);
    }
}
