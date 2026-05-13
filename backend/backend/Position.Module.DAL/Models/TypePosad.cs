namespace backend.Position.Module.DAL.Models
{
    public class TypePosad : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string NameFull { get; set; } = string.Empty;
        public bool Active { get; set; }
        public short Status { get; set; }
        public short Category { get; set; }
        public string? NameTbl1C8 { get; set; }
        public short? PercentForTabel { get; set; }
        public bool Active_AD { get; set; }
        public bool Active_BOS { get; set; }
        public bool CheckDnVidp { get; set; }
        public bool LogLinPers { get; set; }
        public bool TrUtrPodatk { get; set; }
    }
}
