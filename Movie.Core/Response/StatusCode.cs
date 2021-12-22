using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Response
{
    /// <summary>
    /// Returns the same status as the request responses for coherence.
    /// </summary>
    public enum StatusCode
    {
        OK = 200,
        NotFound = 404,
        BadRequest = 400,
        InternalServerError = 500
    }
}
