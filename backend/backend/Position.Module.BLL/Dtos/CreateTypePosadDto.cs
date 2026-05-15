using System.ComponentModel.DataAnnotations;

namespace backend.Position.Module.BLL.Dtos
{
    public class CreateTypePosadDto
    {
        public string? Name { get; set; }
        public string? NameFull { get; set; }
        public short Status { get; set; }
        public short Category { get; set; }
        public bool Active_AD { get; set; }
    }
}
