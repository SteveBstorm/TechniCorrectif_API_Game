using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Correctif_API_Game.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NbPlayerMin { get; set; }
        public int NbPlayerMax { get; set; }
        public int? Age { get; set; }
        public bool IsCoop { get; set; }
    }

    public class GameForm
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? NbPlayerMin { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? NbPlayerMax { get; set; }

        [Range(0, 150)]
        public int? Age { get; set; }

        [Required]
        public bool IsCoop { get; set; }
    }

    public class FavoriteForm
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
    }
    
}
