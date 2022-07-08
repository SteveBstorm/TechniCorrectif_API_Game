using Demo_ASP_MVC_Modele.BLL.Entities;
using Demo_ASP_MVC_Modele.BLL.Interfaces;

namespace Correctif_API_Game.Models.Mappers
{
    public static class MemberMapper
    {
        public static MemberModel ToBll(this MemberRegForm form)
        {
            return new MemberModel
            {
                Email = form.Email,
                Pwd = form.Pwd,
                Pseudo = form.Pseudo
            };
        }

        public static Member ToWeb(this MemberModel m)
        {
            return new Member
            {
                Id = m.Id,
                Email = m.Email,
                Pseudo = m.Pseudo,
                IsAdmin = m.IsAdmin
            };
        }

        public static MemberProfilView ToView(this Member m, IGameService gameService)
        {
            return new MemberProfilView
            {
                Id = m.Id,
                Email = m.Email,
                Pseudo = m.Pseudo,
                IsAdmin = m.IsAdmin,
                FavoriteList = gameService.GetByMemberId(m.Id).Select(x => x.ToViewModel())
            };
        }
    }
}
