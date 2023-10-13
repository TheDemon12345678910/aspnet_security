using infrastructure.DataModels;
using infrastructure.Repositories;

namespace service;

public class UserService
{
    private readonly UserRepository _repository;

    public UserService(UserRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<User> GetAll()
    {
        return _repository.GetAll();
    }
    public User? Get(SessionData data)
    {
        return _repository.GetById(data.UserId);
    }
}