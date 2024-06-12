namespace Gym.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public int AbonimentId { get; set; }

    public int TrainerId { get; set; }

    public virtual Aboniment Aboniment { get; set; } = null!;

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual TrainerInfo Trainer { get; set; } = null!;
}
