namespace AtletikaBajnoksag.Database.Entities;

[Table("Organization")]
public class OrganizationEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email {get; set;}

    [Required]
    public string PhoneNumber {get; set;}

    [ForeignKey("Location")]
    public uint LocationPostalCode {get; set;}

    public virtual LocationEntity Location { get; set; }

    public virtual IReadOnlyCollection<CompetitorEntity> Competitors { get; set; }
}
