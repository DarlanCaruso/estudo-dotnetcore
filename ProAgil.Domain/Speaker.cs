using System.Collections.Generic;

namespace ProAgil.Domain
{
  public class Speaker
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Curriculum { get; set; }

    public string ImageURL { get; set; }

    public string Tel { get; set; }

    public string Email { get; set; }

    public List<SocialMedia> SocialMedia { get; set; }

    public List<SpeakerEvent> SpeakerEvents { get; set; }
  }
}