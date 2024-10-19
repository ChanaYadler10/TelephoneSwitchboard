using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
