using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();      


       //+ Task<List<T>> GetAll();      



    }
}
