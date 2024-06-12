namespace Gym.Models;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}
