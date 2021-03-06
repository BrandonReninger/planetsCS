using System;
// using System.Collections;
using System.Collections.Generic;
using planetsCSapi.Models;
using planetsCSapi.Repositories;

namespace planetsCSapi.Services
{
    public class PlanetsService
    {
        private readonly PlanetsRepository _repo;

        public PlanetsService(PlanetsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Planet> GetAll()
        {
            return _repo.GetAll();
        }

        internal Planet Create(Planet newPlanet)
        {
            Planet createdPlanet = _repo.Create(newPlanet);
            return createdPlanet;
        }

        internal Planet GetById(int id)
        {
            Planet foundPlanet = _repo.GetById(id);
            if (foundPlanet == null)
            {
                throw new Exception("invalid id!");
            }
            return foundPlanet;
        }

        internal Planet Delete(int id)
        {
            Planet foundPlanet = GetById(id);
            if (_repo.Delete(id))
            {
                return foundPlanet;
            }
            throw new Exception("Something is fishy here.");
        }

        internal Planet Edit(int id, Planet updatePlanet)
        {
            Planet editPlanet = GetById(id);
            editPlanet.Title = updatePlanet.Title;
            editPlanet.Category = updatePlanet.Category;
            editPlanet.Habitable = updatePlanet.Habitable;
            editPlanet.Distance = updatePlanet.Distance;
            return _repo.Edit(editPlanet);
        }
    }
}