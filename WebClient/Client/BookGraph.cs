using System.Threading.Tasks;
using GraphQL.Client;
using GraphQL.Common.Request;
using WebClient.Models;

namespace WebClient.Client
{
    public class BookGraph
    {
        private readonly GraphQLClient _client;
        public BookGraph(GraphQLClient client)
        {
            _client = client;
        }
        public async Task<BookModel> GetBookByIsbn(string isbn)
        {
            var query = new GraphQLRequest
            {
                Query = @" 
                query bookQuery($isbn: String!)
                { books(isbn: $isbn) 
                    { title author isbn
                    }
                }",
                Variables = new { isbn }
            };
            var response = await _client.PostAsync(query);

             return response.GetDataFieldAs<BookModel>("books");
        }

        public async Task<BookModel> AddBook(BookInputModel addBook)

        {
            var query = new GraphQLRequest
            {
                Query = @" 
                mutation($addBook: bookInput!)
                {
                    addBook(addBook: $addBook)
                    {
                        title author isbn
                    }
                }",
                Variables = new { addBook }
            };
            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<BookModel>("addBook");
        }
        public async Task<BookModel> DeleteBook(BookInputModel deleteBook)

        {
            var query = new GraphQLRequest
            {
                Query = @" 
                mutation($deleteBook: bookInput!)
                {
                    deleteBook(deleteBook: $deleteBook)
                    {
                        title author isbn
                    }
                }",
                Variables = new { deleteBook }
            };
            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<BookModel>("deleteBook");

        }
       

    }
}
