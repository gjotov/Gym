namespace Gym.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<TrainerInfo> TrainerInfos { get; set; } = new List<TrainerInfo>();
}
