using LetsGoToVet.Domain;
using LetsGoToVet.Domain.Interfaces.Services;
using LetsGoToVet.Persistence.Repositories;

namespace LetsGoToVet.Application.Services
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Pet> GetPet(int id)
        {
            var petRepo = _unitOfWork.GetRepository<PetRepository>();
            var pet = await petRepo.GetAsync(id);

            return pet ?? new Pet();
        }

        public async Task<List<Pet>> GetAllPets(string name)
        {
            var petRepo = _unitOfWork.GetRepository<PetRepository>();
            if (name is null)
            {
                return await petRepo.GetAllPetsAsync();
            }
            else
            {
                return await petRepo.SearchPetsByAsync(name);
            }
        }

        public async Task<Pet> CreatePetAsync(Pet pet)
        {
            var petRepo = _unitOfWork.GetRepository<PetRepository>();
            var createdPet = await petRepo.AddAsync(pet);
            await _unitOfWork.SaveChangesAsync();

            return createdPet;
        }
    }
}
