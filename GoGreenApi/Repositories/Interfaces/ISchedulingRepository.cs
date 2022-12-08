using GoGreenApi.Models;

namespace GoGreenApi.Repositories.Interfaces
{
    public interface ISchedulingRepository
    {
    
        Task<List<SchedulingModel>> GetAllSchedulings();
        Task<SchedulingModel> SearchById(int id);
        Task<SchedulingModel> AddScheduling(SchedulingModel scheduling);
        Task<SchedulingModel> UpdateScheduling(SchedulingModel scheduling, int id);
        Task<bool> DeleteScheduling(int id);
    }
}
