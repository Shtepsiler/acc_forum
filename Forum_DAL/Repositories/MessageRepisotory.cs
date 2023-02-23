using Forum_DAL.Entities;
using Forum_DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Repositories
{
    public class MessageRepisotory : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepisotory(SqlConnection sqlConnection, IDbTransaction dbTransaction) : base(sqlConnection, dbTransaction, "forum.Message")
        {
        }

    }
}
