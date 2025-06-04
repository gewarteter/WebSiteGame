using System.ComponentModel.DataAnnotations;
namespace MvcGame.Models
{
    public class Players
    {
        public int Id { get; set; }
        public string? Nickname { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Gender { get; set; }
    }
}
