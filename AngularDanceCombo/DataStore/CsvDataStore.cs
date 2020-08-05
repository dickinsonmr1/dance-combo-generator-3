using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AngularDanceCombo.Models;
using CsvHelper;

namespace AngularDanceCombo.DataStore
{
    public class CsvDataStore : IDataStore
    {
        //private List<Move> allMoves;
        public List<Move> GetAllMoves()
        {
            using var reader = new StreamReader("DataStore\\Balboa moves - 2.csv");
            using var csv = new CsvReader(reader);
            
            return csv.GetRecords<Move>().ToList();
        }

        public List<Move> GenerateCombo(int numMoves, int difficulty)
        {
            var allMoves = GetAllMoves();
            //var length = new Random().Next(10);
            return allMoves
                .Where(x => x.DifficultyLevel.HasValue && x.DifficultyLevel.Value <= difficulty)
                .OrderBy(x => Guid.NewGuid())
                .Take(numMoves)
                .ToList();
        }
    }
}
