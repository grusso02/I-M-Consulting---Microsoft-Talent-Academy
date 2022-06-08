using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUserDAL
    {
        Task<IEnumerable<User>> GetUsersAsync();
        List<User> Users { get; }
    }
}
