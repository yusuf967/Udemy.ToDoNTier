using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.ToDoNTier.Common.ResponseObjects
{
    public class Response<T>:Response,IResponse<T>
    {
        public T Data { get; set; }

        public Response(ResponseType responseType,T data):base(responseType)
        {
            ResponseType = responseType;
        }

        public Response(ResponseType responseType,string message):base(responseType, message)         {
            
        }

        public Response(ResponseType responseType,T data,List<CustomValidationErrors> customValidationErrors):base(responseType)
        {
            Data = data;
            customValidatorErrors = customValidationErrors;
        }

        public List<CustomValidationErrors> customValidatorErrors { get; set; }
    }
}
