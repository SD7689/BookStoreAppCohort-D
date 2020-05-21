using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BookStoreRepositoryLayer.ApiResponseErroeMessage
{
    public class InternalServerError : ApiError
    {
        public InternalServerError()
            : base(500, HttpStatusCode.InternalServerError.ToString())
        {
        }


        public InternalServerError(string message)
            : base(500, HttpStatusCode.InternalServerError.ToString(), message)
        {
        }
    }
}
