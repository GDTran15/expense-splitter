
using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IGroupRepository
    {
        Task CreateGroup(Group group);

    }
}
