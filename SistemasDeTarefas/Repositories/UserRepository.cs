using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public UserRepository(TaskSystemDBContext taskSystemDBContext) 
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await GetUserById(id);

            if(userById == null)
            {
                throw new Exception($"Can't find User by this Id: {id}");
            }

            userById.Name  = user.Name;
            userById.Email = user.Email;

            _dbContext.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"Can't find User by this Id: {id}");
            }

            _dbContext.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        
    }
}
