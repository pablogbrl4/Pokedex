using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebTeste.Interfaces.Repositories;
using WebTeste.Models;

namespace WebTeste.Repositories
{
    public class TypesRepository : BaseRepository<Types>, ITypesRepository
    {

        public TypesRepository(ApplicationContext context) : base(context)
        {

        }

    }
}
