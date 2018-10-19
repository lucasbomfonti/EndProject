using System;
using System.Collections.Generic;
using EndProject.Domain.Arguments.Player;
using EndProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EndProject.API.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IServicePlayer _servicePlayer;

        public PlayerController(IServicePlayer servicePlayer)
        {
            _servicePlayer = servicePlayer;
        }

        [HttpGet]
        public IEnumerable<PlayerResponse> Get()
        {
            try
            {
               var response = _servicePlayer.PlayerList();
                return  response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddPlayerRequest player)
        {
            try
            {
              _servicePlayer.AddPlayer(player);
                return new NoContentResult();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}