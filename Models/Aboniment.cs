namespace Gym.Models;

public partial class Aboniment
{
    public int AbonimentId { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public DateOnly DeadlineDate { get; set; }

    public decimal Price { get; set; }

    //in sql script set that fk as pk
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
