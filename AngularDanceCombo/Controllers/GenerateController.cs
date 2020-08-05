using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDanceCombo.DataStore;
using AngularDanceCombo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularDanceCombo.Controllers
{
    [Route("[controller]")]
    public class GenerateController : ControllerBase
    {
        // https://www.infoq.com/articles/Angular-Core-3/
        // https://dev.to/dileno/build-an-angular-8-app-with-rest-api-and-asp-net-core-2-2-part-2-46ap
        // https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/angular?view=aspnetcore-3.1&tabs=visual-studio
        // https://localhost:44357/api/generate?numMoves=8&difficulty=3

        [HttpGet]
        public IEnumerable<Move> GenerateCombo(int numMoves, int difficulty)
        {
            //return "value";

            var dataStore = new CsvDataStore();
            var moves = dataStore.GenerateCombo(numMoves, difficulty);
            //model = new RandomModel { Moves = moves };

            return moves.ToArray();
        }
    }
}
