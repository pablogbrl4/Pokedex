using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebTeste.Models;

namespace WebTeste.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
       //  #region Escrita
        Task<string> Incluir(T entidade);

        Task<IEnumerable<T>> BuscarTodos();

    }
}
