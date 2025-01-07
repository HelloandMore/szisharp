namespace OOT.Database.Entities;

[Table("Location")]

public class LocationEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Range(1000,9999)]
    public uint PostalCode { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Street { get; set; }

    [Required]
    public int HouseNumber { get; set; }

    public virtual IReadOnlyCollection<MemberEntity> Members { get; set; }
}
