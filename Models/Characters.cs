using System.ComponentModel.DataAnnotations;
namespace MvcGame.Models
{
    public class Characters
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Attribute { get; set; }
        public string? Complexity { get; set; }
    }
}
