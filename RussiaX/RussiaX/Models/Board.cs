namespace RussiaX.Models
{
    using System.Collections.Generic;

    public class Board
    {
        public int BoardId { get; set; }

        public int BoardStatusId { get; set; }

        public int UserId { get; set; }

        public string ImagePath { get; set; }

        public bool WasPayed { get; set; }

        public byte[] ImageArray { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImagePath))
                {
                    return "noimage_board";
                }

                return string.Format(
                    "http://russiaapi.azurewebsites.net{0}",
                    ImagePath.Substring(1));
            }
        }

        public BoardStatus BoardStatus { get; set; }

        public User User { get; set; }

        public List<Prediction> Predictions { get; set; }
    }
}
