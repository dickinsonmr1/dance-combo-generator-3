using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using AngularDanceCombo.DataStore;
using AngularDanceCombo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularDanceCombo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateComboController : ControllerBase
    {
        // https://www.infoq.com/articles/Angular-Core-3/
        // https://dev.to/dileno/build-an-angular-8-app-with-rest-api-and-asp-net-core-2-2-part-2-46ap
        // https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/angular?view=aspnetcore-3.1&tabs=visual-studio
        // https://localhost:44357/api/generate?numMoves=8&difficulty=3

        [HttpGet]
        public IEnumerable<Move> Get()//int numMoves, int difficulty)
        {
            var numMoves = 4;
            var difficulty = 3;
            //return "value";

            var dataStore = new CsvDataStore();
            //var moves = dataStore.GenerateCombo(numMoves, difficulty);
            var moves = dataStore.GetAllMoves();
            //model = new RandomModel { Moves = moves };

            return moves.ToArray();
        }
    }
}
