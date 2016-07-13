using System.Collections.Generic;
using ZoneInApp.Models;

namespace ZoneInApp.Services
{
    public interface IRecommendationServices
    {
        List<Recommendation> GetRecommendations(string userId);
        List<Recommendation> GetAllRecommendations();
        Recommendation GetRecommendation(int id);
        void DeleteRecommendation(int id);
        void SaveRecommendation(int id, Recommendation recommendation);
        void SaveRecommendations(int id, int recommendationValue);
    }
}