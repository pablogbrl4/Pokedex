using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebTeste.Interfaces.Repositories;
using WebTeste.Models;

namespace WebTeste.Repositories
{

    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task<IEnumerable<T>> BuscarTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<string> Incluir(T entidade)
        {
            await _context.IniciarTransaction();
            var obj = await _dbSet.AddAsync(entidade);
            await _context.SalvarMudancas();
            return obj.Entity.Id.ToString();
        }


    }
}
