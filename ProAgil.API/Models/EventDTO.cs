using System.Collections.Generic;

namespace ProAgil.API.Models
{
  public class EventDTO
  {
    public int Id { get; set; }

    public string Theme { get; set; }
    public string Local { get; set; }

    public string Date { get; set; }

    public string ImageURL { get; set; }

    public string Tel { get; set; }

    public string Email { get; set; }

    public int PeopleCount { get; set; }

    public List<LotDTO> Lots { get; set; }

    public List<SocialMediaDTO> SocialMedias { get; set; }

    public List<SpeakerDTO> Speakers { get; set; }
  }
}