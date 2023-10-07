using LetsGoToVet.Domain;
using LetsGoToVet.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LetsGoToVet.Persistence.Repositories
{
    public class PetRepository : Repository<Pet>, IPetRepository
    {
        private readonly LetsGoToVetDbContext _dbContext;

        public PetRepository(LetsGoToVetDbContext dbContext) :base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Pet> GetAsync(int id)
        {
            return await _dbContext.Pets.FindAsync(id) ?? 
                   throw new KeyNotFoundException();
        }

        public Task<List<Pet>> GetAllPetsAsync()
        {
            return _dbContext.Pets.ToListAsync();
        }

        public Task<List<Pet>> SearchPetsByAsync(string name)
        {
            var data = _dbContext.Pets
                .Where(pet => EF.Functions.Like(pet.Name, $"%{name}%"))
                .ToListAsync();
            return data;
        }
    }
}
