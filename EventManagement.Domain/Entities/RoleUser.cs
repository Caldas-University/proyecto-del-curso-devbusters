namespace EventManagement.Domain.Entities;

    public class RoleUser
    {
        public Guid id { get; private set; }
        public Guid idRole { get; private set; }
        public Guid idUser { get; private set; }

        public RoleUser(Guid id, Guid idRole, Guid idUser)
        {
            this.id = id;
            this.idRole = idRole;
            this.idUser = idUser;
        }
    }
    