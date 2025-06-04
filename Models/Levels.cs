using System.ComponentModel.DataAnnotations;
namespace MvcGame.Models
{
    public class Levels
    {
        public int Id { get; set; }
        public string? Mode { get; set; }
        public string? Role { get; set; }
    }
}
