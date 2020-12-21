namespace amazen_server.Models
{
  public class Product
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public int Id { get; set; }

    public float Price { get; set; }
    public string Picture { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }

  }
}