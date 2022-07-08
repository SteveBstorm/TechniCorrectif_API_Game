using Demo_ASP_MVC_Modele.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Correctif_API_Game.Models.Mappers;
using Correctif_API_Game.Models;
using Microsoft.AspNetCore.Authorization;

namespace Correctif_API_Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_gameService.GetAll().Select(x => x.ToViewModel()));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_gameService.GetById(id).ToViewModel());
        }

        [Authorize("Admin")]
        [HttpPost]
        public IActionResult Create(GameForm form)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                _gameService.Insert(form.ToModel());
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize("Admin")]

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _gameService.Delete(id);
            return Ok();
        }
        [Authorize("Admin")]

        [HttpPut]
        public IActionResult Update([FromBody]GameForm form)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if(_gameService.Update(form.ToModel())) return Ok();
                return Forbid();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize("Auth")]

        [HttpPost("favorite/{idg}/member/{idm}")]
        public IActionResult AddFavorite(int idg, int idm)
        {
            _gameService.AddFavoriteGame(idm, idg);
            return Ok();
        }



    }
}
