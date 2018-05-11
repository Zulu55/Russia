namespace RussiaX.Models
{
    using System.Collections.Generic;

    public class StatusMatch
    {
        public int StatusMatchId { get; set; }

        public string Name { get; set; }

        public List<Match> Matches { get; set; }
    }
}
