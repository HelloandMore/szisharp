namespace AtletikaBajnoksag.Database.Entities;

[Table("City")]

public class CityEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Range(1000, 9999)]
    public uint PostalCode { get; set; }

    [Required]
    public string CityName { get; set; }
}
