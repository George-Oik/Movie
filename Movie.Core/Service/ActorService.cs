using Movie.Core.Data;
using Movie.Core.Model;
using Movie.Core.Response;
using Movie.Core.Service.Interface;
using Movie.Core.Service.Options.Create;
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

        /// <summary>
        /// Create a new actor from user input. Only way to store actors for the time being.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Result<Actor> CreateActor(CreateActorOptions options)
        {
            if (options == null)
            {
                return new Result<Actor>()
                {
                    Data = null,
                    ErrorCode = StatusCode.BadRequest,
                    ErrorText = "No info provided.",
                };
            }

            if (string.IsNullOrWhiteSpace(options.FirstName))
            {
                return new Result<Actor>()
                {
                    Data = null,
                    ErrorCode = StatusCode.BadRequest,
                    ErrorText = "No first name provided.",
                };
            }

            if (string.IsNullOrWhiteSpace(options.LastName))
            {
                return new Result<Actor>()
                {
                    Data = null,
                    ErrorCode = StatusCode.BadRequest,
                    ErrorText = "No last name provided.",
                };
            }

            var actor = new Actor()
            {
                FirstName = options.FirstName,
                LastName = options.LastName,
            };

            //actor.BioLink = string.IsNullOrWhiteSpace(options.BioLink) ? "No info" : options.BioLink;
            //actor.Profile = string.IsNullOrWhiteSpace(options.Profile) ? "No info" : options.Profile;

            if (string.IsNullOrWhiteSpace(options.BioLink))
            {
                actor.BioLink = "No info";
            }
            else
            {
                actor.BioLink = options.Profile;
            }

            if(string.IsNullOrWhiteSpace(options.Profile))
            {
                actor.Profile = "No info";
            }
            else
            {
                actor.Profile = options.Profile;
            }

            context.Add(actor);

            var rows = 0;

            try
            {
                rows = context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result<Actor>.ActionFailed(
                    StatusCode.InternalServerError, ex.ToString());
            }

            if (rows <= 0)
            {
                return Result<Actor>.ActionFailed(
                    StatusCode.InternalServerError,
                    "Actor not be added");
            }

            return Result<Actor>.ActionSuccessful(actor);
        }
    }
}
