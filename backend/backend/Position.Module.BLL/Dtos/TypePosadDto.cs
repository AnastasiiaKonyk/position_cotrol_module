namespace backend.Position.Module.BLL.Dtos
{
    public class TypePosadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameFull { get; set; }
        public short Status { get; set; }
        public short Category { get; set; }
        public bool Active_AD { get; set; }
        public bool Active { get; set; }
    }
}
