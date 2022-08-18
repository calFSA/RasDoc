namespace RasDoc.Entities.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        public DateTimeOffset? DataAlt { get; set; }
    }
}
