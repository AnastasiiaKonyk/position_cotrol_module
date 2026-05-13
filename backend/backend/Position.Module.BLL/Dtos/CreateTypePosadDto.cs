namespace backend.Position.Module.BLL.Dtos
{
    public class CreateTypePosadDto
    {
        public string? Name { get; set; }
        public string? NameFull { get; set; }
        public string? Status { get; set; }
        public string? Category { get; set; }
        public bool Active_AD { get; set; }
    }
}
