using System.ComponentModel.DataAnnotations;

namespace Correctif_API_Game.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pseudo { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class MemberRegForm
    {
        [Required]
        public string Pseudo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Pwd), ErrorMessage = "Les deux mdp doivent correspondre")]
        public string PwdRepeat { get; set; }
    }

    public class MemberLoginForm
    {
        [Required]
        public string Pseudo { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }
    }

    public class MemberProfilView : Member
    {
        public IEnumerable<Game> FavoriteList { get; set; }
    }
}
