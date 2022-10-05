using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3_wbwright.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string ImdbHyperLink { get; set; }
        public byte[]? Photo { get; set; }

        [ForeignKey("Movie")]
        public int? MovieId { get; set; }
        public Actor? Movie { get; set; }
    }
}
