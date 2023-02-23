using Dapper;
using Forum_DAL.Repositories.Contracts;
using System.Data;
using System.Data.SqlClient;
using Forum_DAL.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Forum_DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "client.User")
        {
        }

        public async Task<IEnumerable<User>> TopFiveUserAsync()
        {
            string sql = @"SELECT TOP 5 * FROM client.User";
            var results = await _sqlConnection.QueryAsync<User>(sql,
                transaction: _dbTransaction);
            return results;
        }
    }
}
