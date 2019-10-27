using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProAgil.Domain
{
  [Table("Lot")]
  public class Lot
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int Count { get; set; }
    public int EventId { get; set; }
    public Event Event { get; }
  }
}