using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IService<TDto>
    {
        List<TDto> GetAll();
        TDto Add(TDto entity);
        TDto Update(TDto entity, int id);
        TDto Delete(int id);
    }
}
