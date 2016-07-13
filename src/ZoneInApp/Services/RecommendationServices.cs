using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoneInApp.Models;
using ZoneInApp.Repositories;

namespace ZoneInApp.Services
{
    public class RecommendationServices : IRecommendationServices
    {
        private IGenericRepository _repo;

        public RecommendationServices(IGenericRepository repo)
        {
            _repo = repo;
        }


        /// <summary>
        /// Returns all recommended businesses in the logged in user's neighborhood
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Recommendation> GetRecommendations(string userId)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == userId).FirstOrDefault();
            var recommendations = _repo.Query<Recommendation>().Where(r => r.User.NeighborhoodName == user.NeighborhoodName).ToList();
            return recommendations;
        }


        /// <summary>
        /// Returns all recommendations - Admin Use
        /// </summary>
        /// <returns></returns>
        public List<Recommendation> GetAllRecommendations()
        {
            var recommendations = _repo.Query<Recommendation>().ToList();
            return recommendations;
        }


        /// <summary>
        /// Returns a single recommended business with the matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Recommendation GetRecommendation(int id)
        {
            var recommendation = _repo.Query<Recommendation>().Where(r => r.Id == id).FirstOrDefault();
            return recommendation;
        }


        /// <summary>
        /// Creates a new business if id is zero
        /// Edits a recommended business's information if business is already created
        /// </summary>
        /// <param name="id"></param>
        /// <param name="recommendation"></param>
        public void SaveRecommendation(int id, Recommendation recommendation)
        {
            if (recommendation.Id == 0)
            {
                _repo.Add(recommendation);
                _repo.SaveChanges();
            }

            else
            {
                var recommendationEdit = _repo.Query<Recommendation>().Where(r => r.Id == recommendation.Id).FirstOrDefault();
                recommendationEdit.BusinessName = recommendation.BusinessName;
                recommendationEdit.BusAddr = recommendation.BusAddr;
                recommendationEdit.BusPhone = recommendation.BusPhone;
                recommendationEdit.Url = recommendation.Url;

                _repo.SaveChanges();
            }
        }


        public void SaveRecommendations(int id, int recommendationValue)
        {
            var recommendation = _repo.Query<Recommendation>().Where(p => p.Id == id).FirstOrDefault();

            if (recommendationValue == 1)
            {
                recommendation.NumRecos++;
            }

            _repo.SaveChanges();
        }

        /// <summary>
        /// Deletes recommended business with matching id - Admin Use
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRecommendation(int id)
        {
            var recommendationDelete = _repo.Query<Recommendation>().Where(r => r.Id == id).FirstOrDefault();

            _repo.Delete(recommendationDelete);
        }
    }
}