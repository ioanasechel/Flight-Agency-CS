using Flight_Agency.model;

namespace Flight_Agency.repository
{
    public interface IEmployeeRepositoryInterface : IRepository<string, Employee>
    {
        Employee findOne(string username);
    }
}