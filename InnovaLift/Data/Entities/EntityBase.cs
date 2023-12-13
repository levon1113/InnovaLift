using System.ComponentModel.DataAnnotations;

namespace InnovaLift.Data.Entities
{
    public class EntityBase
    {
        [Key]
        public string? Id { get; set; }
    }
}
