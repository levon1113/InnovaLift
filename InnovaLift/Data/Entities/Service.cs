namespace InnovaLift.Data.Entities
{
    public class Service : EntityBase
    {
        public string Name { get; set; }

        public byte[] Image { get; set; }
        public byte[] Pdf { get; set; }
    }
}
