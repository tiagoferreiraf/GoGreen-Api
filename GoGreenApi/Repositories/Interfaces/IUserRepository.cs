using GoGreenApi.Models;

namespace GoGreenApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> SearchById(int id);
        Task<UserModel> AddUser(UserModel company);
        Task<UserModel> UpdateUser(UserModel company, int id);
        Task<bool> DeleteUser(int id);
    }
}
