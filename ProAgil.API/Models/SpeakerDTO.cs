using System.Collections.Generic;

namespace ProAgil.API.Models
{
  public class SpeakerDTO
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Curriculum { get; set; }

    public string ImageURL { get; set; }

    public string Tel { get; set; }

    public string Email { get; set; }

    public List<SocialMediaDTO> SocialMedia { get; set; }

    public List<EventDTO> Events { get; set; }
  }
}