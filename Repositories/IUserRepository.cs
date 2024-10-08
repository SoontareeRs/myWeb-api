namespace MyWebAPI.Models;
public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task<User> CreateUser(User user);

    Task<User> GetUserById(int id);
    Task<User> UpdateUserAsync(int id,User user);
    Task<bool> DeleteUserAsync(int id);
}