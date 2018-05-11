namespace RussiaX.Models
{
    using System.Collections.Generic;

    public class BoardStatus
    {
        public int BoardStatusId { get; set; }

        public string Name { get; set; }

        public List<Board> Boards { get; set; }
    }
}
