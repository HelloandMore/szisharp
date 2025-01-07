namespace AtletikaBajnoksag.Database.Entities;

[Table("CompetitionNumber")]
public class CompetitionNumberEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    public GenderEnum Gender { get; set; }
    
    public CategoryEnum Category { get; set; }

    public SubcategoryEnum Subcategory { get; set; }

    public AgeGroupEnum AgeGroup { get; set; }

    public virtual IReadOnlyCollection<CompetitorEntity> Competitors { get; set; }

    [ForeignKey("Competition")]
    public uint CompetitionNumberId { get; set; }
    public virtual CompetitionEntity Competition { get; set; }
}
