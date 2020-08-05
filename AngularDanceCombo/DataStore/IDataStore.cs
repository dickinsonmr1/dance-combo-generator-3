using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDanceCombo.Models;

namespace AngularDanceCombo.DataStore
{
    public interface IDataStore
    {
        List<Move> GetAllMoves();
        List<Move> GenerateCombo(int numMoves, int difficulty);
    }
}
