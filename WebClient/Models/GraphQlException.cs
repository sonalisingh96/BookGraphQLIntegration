using System;

namespace WebClient.Models
{
    public class GraphQlException:ApplicationException
    {
        public GraphQlException(string message) : base(message)
        {
        }
    }
}
