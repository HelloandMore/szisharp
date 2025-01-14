namespace Solution.Core.Interfaces;

public interface IBookService
{
    Task<ErrorOr<BookModel>> CreateAsync(BookModel movie);
}
