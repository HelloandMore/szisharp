namespace Solution.Services;

public class BookService(AppDbContext dbContext) : IBookService
{
    public Task<ErrorOr<BookModel>> CreateAsync(BookModel movie)
    {
        throw new NotImplementedException();
    }
}
