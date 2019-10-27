namespace ProAgil.API.Models
{
  public class LotDTO
  {

    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string BeginDate { get; set; }
    public string EndDate { get; set; }
    public int Count { get; set; }
  }
}