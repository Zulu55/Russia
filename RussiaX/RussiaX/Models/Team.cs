namespace RussiaX.Models
{
    using System.Collections.Generic;

    public class Team
    {
        public int TeamId { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImagePath))
                {
                    return "noimage_team";
                }

                return string.Format(
                    "https://russiabackend.azurewebsites.net{0}",
                    ImagePath.Substring(1));
            }
        }

        public List<GroupTeam> GroupTeams { get; set; }

        public List<Match> Locals { get; set; }

        public List<Match> Visitors { get; set; }
    }
}
