using System;
using System.Collections.Generic;

namespace ProAgil.Domain
{
  public class Event
  {
    public int Id { get; set; }

    public string Theme { get; set; }
    public string Local { get; set; }

    public DateTime Date { get; set; }

    public string ImageUrl { get; set; }

    public string Tel { get; set; }

    public string Email { get; set; }

    public int PeopleCount { get; set; }

    public List<Lot> Lot { get; set; }

    public List<SocialMedia> SocialMedia { get; set; }

    public List<SpeakerEvent> SpeakerEvents { get; set; }
  }
}