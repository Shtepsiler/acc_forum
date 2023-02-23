using Forum_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Repositories.Contracts
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
    }
}
