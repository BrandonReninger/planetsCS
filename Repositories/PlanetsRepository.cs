using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using planetsCSapi.Models;

namespace planetsCSapi.Repositories
{
    public class PlanetsRepository
    {
        private readonly IDbConnection _db;

        public PlanetsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Planet> GetAll()
        {
            string sql = "SELECT * FROM planets";
            return _db.Query<Planet>(sql);
        }

        internal Planet Create(Planet newPlanet)
        {
            string sql = @"
            INSERT INTO planets
            (title, category, habitable, distance)
            VALUES
            (@title, @category, @habitable, @distance);
            SELECT LAST_INSERT_ID()";
            newPlanet.Id = _db.ExecuteScalar<int>(sql, newPlanet);
            return newPlanet;
        }

        internal Planet GetById(int id)
        {
            string sql = "SELECT * FROM planets WHERE id = @Id";
            return _db.QueryFirstOrDefault<Planet>(sql, new { id });
        }

        internal bool Delete(int id)
        {
            string sql = "DELETE FROM planets WHERE id = @Id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }

        internal bool Edit(int id)
        {
            //ANCHOR finish this 
            string sql = @"UPDATE FROM planets
            SET 
            ";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }
    }
}