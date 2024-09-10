
using MyWebAPI.Models;

namespace MyWebAPI.Services;
public class UserService : IUserService
{

    public IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> CreateUser(User user)
    {
        await _userRepository.CreateUser(user);
        return user;
    }

    public async Task<List<User>> GetAllUsers()
    {
        List<User> userList = await _userRepository.GetAllUsers();
        return userList;
    }

    public async Task<User> GetUserById(int id)
    {
        User user = await _userRepository.GetUserById(id);
        return user;
    }

}