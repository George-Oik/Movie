using Movie.Core.Model;
using Movie.Core.Response;
using Movie.Core.Service.Options.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Service.Interface
{
    public interface IActorService
    {
        Result<Actor> CreateActor(CreateActorOptions options);
    }
}
