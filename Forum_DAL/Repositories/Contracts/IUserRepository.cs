using Forum_DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum_DAL.Repositories.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> TopFiveUserAsync();
    }
}
