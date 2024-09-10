
using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Models;
public class UserRepository : IUserRepository
{
    private readonly UserDbContext _userDbContext;
    public UserRepository(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }
    public Task<User> CreateUser(User user)
    {
        _userDbContext.User.Add(user);
        _userDbContext.SaveChanges();
        return Task.FromResult(user);
    }

    public async Task<List<User>> GetAllUsers()
    {
        List<User> users = await _userDbContext.User.ToListAsync();
        return users;
    }

    public async Task<User> GetUserById(int id)
    {
        User user = await _userDbContext.User.FindAsync(id);
        return user;
    }
}

