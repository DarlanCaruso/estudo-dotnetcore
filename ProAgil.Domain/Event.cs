using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProAgil.Domain
{
  [Table("Event")]
  public class Event
  {
    public int Id { get; set; }

    public string Theme { get; set; }
    public string Local { get; set; }

    public DateTime Date { get; set; }

    public string ImageURL { get; set; }

    public string Tel { get; set; }

    public string Email { get; set; }

    public int PeopleCount { get; set; }

    public List<Lot> Lots { get; set; }

    public List<SocialMedia> SocialMedias { get; set; }

    public List<SpeakerEvent> SpeakerEvents { get; set; }
  }
}