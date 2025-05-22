namespace EventManagement.Domain.Entities;

    public class Permission
    {
        public Guid id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }

        public Permission(Guid id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }
    }
