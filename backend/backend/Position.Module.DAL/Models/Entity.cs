using System.ComponentModel.DataAnnotations;

namespace backend.Position.Module.DAL.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
