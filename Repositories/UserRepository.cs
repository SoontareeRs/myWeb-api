
using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Models;
public class UserRepository : IUserRepository
{
    private readonly UserDbContext _userDbContext;
    private readonly DateTime currentTimeInTimeZone = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);

    public UserRepository(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }
    public async Task<User> CreateUser(User user)
    {
        var queryUser = _userDbContext.User.FirstOrDefault(u => u.Email == user.Email);
        if (queryUser == null)
        {
            try
            {
                user.CreatedAt = currentTimeInTimeZone;
                user.UpdatedAt = currentTimeInTimeZone;
                user.IsDeleted = false;
                _userDbContext.User.Add(user);
                await _userDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
        else
        {
            throw new Exception("This email already exists.");
        }

    }

    public async Task<List<User>> GetAllUsers()
    {
        List<User> users = await _userDbContext.User
                            .Where(u => !u.IsDeleted)
                            .ToListAsync();
        return users;
    }

    public async Task<User> GetUserById(int id)
    {
        User? user = await _userDbContext.User
                    .Where(u => !u.IsDeleted && u.UserId == id)
                    .FirstOrDefaultAsync();
        if (user == null)
        {
            throw new KeyNotFoundException($"User with ID {id} was not found.");
        }
        return user;
    }

    public async Task<User> UpdateUserAsync(int id, User user)
    {
        var queryUser = await _userDbContext.User.FindAsync(id);
        if (queryUser != null)
        {
            queryUser.FirstName = user.FirstName;
            queryUser.LastName = user.LastName;
            queryUser.Gender = user.Gender;
            queryUser.BirthDay = user.BirthDay;
            queryUser.Email = user.Email;
            queryUser.PhoneNumber = user.PhoneNumber;
            queryUser.Role = user.Role;
            queryUser.UpdatedAt = currentTimeInTimeZone;
            await _userDbContext.SaveChangesAsync();

            return queryUser;
        }
        throw new KeyNotFoundException($"User with ID {user.UserId} not found.");
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var queryUser = await _userDbContext.User.FindAsync(id);
        if (queryUser == null)
        {
            throw new KeyNotFoundException($"User with ID {id} was not found.");
        }
        queryUser.IsDeleted = true;
        queryUser.UpdatedAt = currentTimeInTimeZone;
        await _userDbContext.SaveChangesAsync();
        return true;
    }

}

