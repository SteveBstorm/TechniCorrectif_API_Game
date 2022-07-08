using Correctif_API_Game.Infrastructure;
using Correctif_API_Game.Models;
using Correctif_API_Game.Models.Mappers;
using Demo_ASP_MVC_Modele.BLL.Interfaces;
using Demo_ASP_MVC_Modele.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Correctif_API_Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberService _memberService;
        private TokenManager _tokenManager;
        private IGameService _gameService;

        public MemberController(IMemberService memberService, TokenManager manager, IGameService gameService)
        {
            _memberService = memberService;
            _tokenManager = manager;
            _gameService = gameService;
        }

        [HttpPost]
        public IActionResult Register(MemberRegForm form)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                _memberService.Register(form.ToBll());
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(MemberLoginForm form)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                Member currentUser = _memberService.Login(form.Pseudo, form.Pwd).ToWeb();

                currentUser.Token = _tokenManager.GenerateToken(currentUser);

                return Ok(currentUser.Token);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [Authorize("Auth")]
        [HttpGet("{id}")]
        public IActionResult Profil(int id)
        {
            MemberProfilView m = _memberService.GetById(id).ToWeb().ToView(_gameService);
            return Ok(m);
        }

        [Authorize("Admin")]
        [HttpPut("{id}")]
        public IActionResult SetAdmin(int id)
        {
            if (!_memberService.SetAdmin(id)) return BadRequest();
            return Ok();
        }
    }
}
