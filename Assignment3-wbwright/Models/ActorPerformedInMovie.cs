using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3_wbwright.Models
{
    public class ActorPerformedInMovie
    {
        public int Id { get; set; }

        [ForeignKey("Movie")]
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }

        [ForeignKey("Actor")]
        public int? ActorId { get; set; }
        public Actor? Actor { get; set; }
    }
}
