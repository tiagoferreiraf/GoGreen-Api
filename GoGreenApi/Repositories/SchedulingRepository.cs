using GoGreenApi.Data;
using GoGreenApi.Models;
using GoGreenApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoGreenApi.Repositories
{
    public class SchedulingRepository : ISchedulingRepository
    {
        private readonly GoGreenDbContext _dbContext;

        public SchedulingRepository(GoGreenDbContext goGreenSchedulingContext)
        {
            _dbContext = goGreenSchedulingContext;
        }



        public async Task<SchedulingModel> AddScheduling(SchedulingModel scheduling)
        {
            await _dbContext.Schedulings.AddAsync(scheduling);
            await _dbContext.SaveChangesAsync();

            return scheduling;
        }

        public async Task<List<SchedulingModel>> GetAllSchedulings()
        {
            return await _dbContext.Schedulings.ToListAsync();
        }

        

        public async Task<SchedulingModel> SearchById(int id)
        {
            return await _dbContext.Schedulings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SchedulingModel> UpdateScheduling(SchedulingModel schedulings, int id)
        {
            try
            {
                SchedulingModel SchedulingForId = await SearchById(id);

                if (SchedulingForId == null)
                {
                    throw new Exception($"Usúario para o ID:{id} não foi encontrado no banco de dados");
                }

                SchedulingForId.Product = schedulings.Product;
                SchedulingForId.StatusScheduling = schedulings.StatusScheduling;
                SchedulingForId.Category = schedulings.Category;
                SchedulingForId.DescriptionProduct = schedulings.DescriptionProduct;
                SchedulingForId.dtCreated = schedulings.dtCreated;

                _dbContext.Schedulings.Update(SchedulingForId);
                await _dbContext.SaveChangesAsync();

                return SchedulingForId;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> DeleteScheduling(int id)
        {
            SchedulingModel scheduling = await SearchById(id);

            if (scheduling == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Schedulings.Remove(scheduling);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
