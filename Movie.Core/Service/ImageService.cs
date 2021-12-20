using Movie.Core.Data;
using Movie.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Service
{
    public class ImageService : IImageService
    {
        private MovieDbContext context;

        public ImageService(MovieDbContext dbcontext)
        {
            context = dbcontext;
        }
    }
}
