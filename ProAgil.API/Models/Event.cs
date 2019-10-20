namespace ProAgil.API.Models
{
  public class Event
  {
    public int EventId { get; set; }

    public string Theme { get; set; }
    public string Local { get; set; }

    public string Date { get; set; }

    public string ImageUrl { get; set; }

    public int PeopleCount { get; set; }

    public string Lot { get; set; }
  }
}