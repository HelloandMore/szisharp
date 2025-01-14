namespace Solution.Core.Models;

public class BookModel
{
    public uint Id { get; set; }

    public ValidatableObject<ulong> ISBN { get; set; }

    public ValidatableObject<string> Author { get; set; }

    public ValidatableObject<string> Title { get; set; }

    public ValidatableObject<uint> PublishYear { get; set; }

    public ValidatableObject<string> Publisher { get; set; }

    public BookModel()
    {
        this.ISBN = new ValidatableObject<ulong>();
        this.Author = new ValidatableObject<string>();
        this.Title = new ValidatableObject<string>();
        this.PublishYear = new ValidatableObject<uint>();
        this.Publisher = new ValidatableObject<string>();

        AddValidators();
    }

    public BookModel(BookEntity entity) : this()
    {
        Id = entity.Id;
        ISBN.Value = entity.ISBN;
        Author.Value = entity.Author;
        Title.Value = entity.Title;
        PublishYear.Value = entity.PublishYear;
        Publisher.Value = entity.Publisher;
    }

    public BookEntity ToEntity()
    {
        return new BookEntity
        {
            Id = Id,
            ISBN = ISBN.Value,
            Author = Author.Value,
            Title = Title.Value,
            PublishYear = PublishYear.Value,
            Publisher = Publisher.Value
        };
    }

    public void ToEntity(BookEntity entity)
    {
        entity.Id = Id;
        entity.ISBN = ISBN.Value;
        entity.Author = Author.Value;
        entity.Title = Title.Value;
        entity.PublishYear = PublishYear.Value;
        entity.Publisher = Publisher.Value;
    }

    private void AddValidators()
    {
        ISBN.Validations.Add(new ISBNRule<ulong> { ValidationMessage = "ISBN format incorrect"});
        ISBN.Validations.Add(new IsNotNullOrEmptyRule<ulong> { ValidationMessage = "ISBN is required." });
        Author.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Author is required." });
        Title.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Title is required." });
        PublishYear.Validations.Add(new IsNotNullOrEmptyRule<uint> { ValidationMessage = "Publish year is required." });
        PublishYear.Validations.Add(new NullableIntegerRule<uint> { ValidationMessage = "Publish year must be a number." });
        PublishYear.Validations.Add(new MinValueRule<uint>(1) { ValidationMessage = "Publish year must be greater than 1."});
        PublishYear.Validations.Add(new MaxValueRule<uint>(DateTime.Now.Year) { ValidationMessage = $"Publish year must be less than or equal to the current year. {DateTime.Now.Year}" });

        Publisher.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Publisher is required." });
    }
}
