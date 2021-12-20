using Movie.Core.Data;
using Movie.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Service
{
    public class ActorService : IActorService
    {
        private MovieDbContext context;

        public ActorService(MovieDbContext dbcontext)
        {
            context = dbcontext;
        }
    }
}
