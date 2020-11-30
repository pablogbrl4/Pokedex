using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebTeste.Interfaces.Repositories;
using WebTeste.Models;

namespace WebTeste.Repositories
{
    public class _Pokemon_Repository : BaseRepository<_Pokemon_>, I_Pokemon_Repository
    {

        public _Pokemon_Repository(ApplicationContext context) : base(context)
        {

        }



    }
}
