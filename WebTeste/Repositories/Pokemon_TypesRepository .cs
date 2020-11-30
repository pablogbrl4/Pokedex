using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebTeste.Interfaces.Repositories;
using WebTeste.Models;

namespace WebTeste.Repositories
{
    public class Pokemon_TypesRepository : BaseRepository<Pokemon_Types>, IPokemon_TypesRepository
    {

        public Pokemon_TypesRepository(ApplicationContext context) : base(context)
        {

        }

        //public async Task<IEnumerable<Pokemon_Types>> BuscarTodos()
        //{

        //    var resultados = _context.Pokemon_Types.Join(_context._Pokemon_,
        //        _es => _es.Pokemon_Id, _e => _e.Id,
        //            (_es, _e) => new
        //            {
        //                _edificacoesSimulacoes = _es,
        //                _edificacoes = _e
        //            });

        //    IList<Pokemon_Types> lista = new List<Pokemon_Types>();

        //    foreach (var item in resultados)
        //    {
        //        lista.Add(item._edificacoesSimulacoes);
        //    }

        //    return lista;
        //}

    }
}
