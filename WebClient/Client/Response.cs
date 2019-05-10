using System.Collections.Generic;
using System.Linq;
using WebClient.Models;

namespace WebClient.Client
{
    public class Response<T>
    {
        public T Data { get; set; }
        public List<ErrorModel> Errors { get; set; }

        public void ThrowErrors()
        {
            if (Errors != null && Errors.Any())
                throw new GraphQlException(
                    $"Message: {Errors[0].Message} Code: {Errors[0].Code}");
        }
       
    }
    public class BooksContainer
    {
        public List<BookModel> Book { get; set; }
    }
}
