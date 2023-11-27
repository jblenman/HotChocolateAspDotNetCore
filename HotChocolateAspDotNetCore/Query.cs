using HotChocolateAspDotNetCore.Configuration;
using HotChocolateAspDotNetCore.ObjectTypes;

namespace HotChocolateAspDotNetCore;

public class Query
{
    [GraphQLName("book")]
    [UsePaging(ConnectionName = "Book_", MaxPageSize = 5000)]
    [UseFiltering]
    [UseSorting]
    public IEnumerable<Book> GetBooks(int? limit) =>
        new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "C# in depth.",
                Author = new Author
                {
                    Id = 1,
                    Name = "Jon Skeet"
                }
            },
            new Book
            {
                Id = 2,
                Title = "Harry Potter and the Sorcerer's Stone",
                Author = new Author
                {
                    Id = 2,
                    Name = "J. K. Rowling"
                }
            }
        };

    [NodeResolver]
    public Book GetBookById(int id)
    {
        if (id == 1)
        {
            return new Book
            {
                Id = 1,
                Title = "C# in depth.",
                Author = new Author
                {
                    Id = 1,
                    Name = "Jon Skeet"
                }
            };
        }

        if (id == 2)
        {
            return new Book
            {
                Id = 2,
                Title = "Harry Potter and the Sorcerer's Stone",
                Author = new Author
                {
                    Id = 2,
                    Name = "J. K. Rowling"
                }
            };
        }

        return new Book
        {
            Id = id,
            Title = "Test Book",
            Author = new Author
            {
                Id = 3,
                Name = "Test Author"
            }
        };
    }

    [GraphQLName("author")]
    [UsePaging(ConnectionName = "Author_", MaxPageSize = 5000)]
    [UseFiltering]
    [UseSorting]
    public IEnumerable<Author> GetAuthors(int? limit) =>
        new List<Author>
        {
            new(){ Id = 1, Name = "Jon Skeet" },
            new(){ Id = 2, Name = "J. K. Rowling" }
        };

    [NodeResolver]
    public Author GetAuthorById(int id)
    {
        if (id == 1) return new Author { Id = 1, Name = "Jon Skeet" };
        if (id == 2) return new Author { Id = 2, Name = "J. K. Rowling" };
        return new Author { Id = 3, Name = "Test Author" };
    }
}