namespace EventManagement.Domain.Entities;

public class RoleUserHistory
{
    public Guid id { get; private set; }
    public Guid userRoleId { get; private set; }
    // User Id who is changing the role
    public Guid userId { get; private set; }
    public DateTime dateChange { get; private set; }
    public string changeDescription { get; private set; }

    public RoleUserHistory(Guid id, Guid userId, Guid userRoleId, DateTime dateChange, string changeDescription)
    {
        this.id = id;
        this.userId = userId;
        this.userRoleId = userRoleId;
        this.dateChange = dateChange;
        this.changeDescription = changeDescription;
    }
}