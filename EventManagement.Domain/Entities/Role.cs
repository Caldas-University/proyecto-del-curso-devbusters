namespace EventManagement.Domain.Entities;
    public class Role
    {
        public Guid id { get; private set; }
        public string name { get; private set; }

        public Role(Guid id, string name)
        {
            this.id = id;
            this.name = name?.ToUpperInvariant();
        }
    }