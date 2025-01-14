namespace Solution.Database.Entities;

[Table("Book")]
public class BookEntity
{
    [Key]
    public uint Id { get; set; }

    [Required]
    [Range(1000000000, 9999999999999)]
    public ulong ISBN { get; set; }

    [Required]
    public string Author { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public uint PublishYear { get; set; }

    [Required]
    public string Publisher { get; set; }
}
