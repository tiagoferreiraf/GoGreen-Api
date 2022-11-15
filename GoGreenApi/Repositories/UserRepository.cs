using GoGreenApi.Data;
using GoGreenApi.Models;
using GoGreenApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoGreenApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GoGreenDbContext _dbContext;

        public UserRepository(GoGreenDbContext goGreenCompanyContext)
        {
            _dbContext = goGreenCompanyContext;
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> SearchById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> UpdateUser(UserModel users, int id)
        {
            UserModel UserForId = await SearchById(id);

            if (UserForId == null)
            {
                throw new Exception($"Usúario para o ID:{id} não foi encontrado no banco de dados");
            }

            UserForId.Name = users.Name;

            _dbContext.Users.Update(UserForId);
            await _dbContext.SaveChangesAsync();

            return UserForId;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel user = await SearchById(id);

            if (user == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
