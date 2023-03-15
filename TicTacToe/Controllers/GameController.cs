using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Numerics;
using System.Reflection.PortableExecutable;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class GameController : Controller
    {
        private static Dictionary<int, Game> games = new Dictionary<int, Game>();
        private static int nextId = 1;

        [HttpGet]
        public IActionResult Index() 
        { 
            return View(games.Values); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string player1, string player2)
        {
            Game game = new Game();
            game.Id = nextId++;
            game.Player1 = player1;
            game.Player2 = player2;
            games.Add(game.Id, game);
            return RedirectToAction("Play", new { id = game.Id });
        }

        [HttpGet]
        public IActionResult Play(int id)
        {
            Game game = games[id];
            return View(game);
        }

        [HttpGet]
        public IActionResult Move(int id, string player, int row, int column)
        {
            Game game = games[id];
            game.MakeMove(player, row, column);
            return View("Play", game);
        }

        [HttpGet]
        public ActionResult Reset(int id)
        {
            Game game = games[id];
            game.ResetBoard();
            games[id] = game;
            return RedirectToAction("Play", new { id = id });
        }
    }
}
