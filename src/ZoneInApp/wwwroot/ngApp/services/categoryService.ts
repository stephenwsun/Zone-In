namespace ZoneInApp.Services {

    export class CategoryService {

        private categoryResource;
        private recommendationResource;

        constructor($resource: ng.resource.IResourceService) {

            this.categoryResource = $resource('/api/category/:id', null, {

                getCategoryRecommendations: {

                    method: 'GET',
                    url: '/api/category/getcategoryrecommendations',
                    isArray: true
                }
            });

            this.recommendationResource = $resource('/api/recommendation/:id', null, {

                recommend: {

                    method: 'PUT'
                },

                getRecommendations: {

                    method: 'GET',
                    url: '/api/recommendation/getrecommendations',
                    isArray: true
                }
            });
        }

        // Recommend Functionality
        recommend(recoId, recommendationValue) {

            return this.recommendationResource.recommend({ id: recoId }, recommendationValue);
        }

        // Sends a GET request to the server-side and returns all business categories
        getCategories() {

            return this.categoryResource.query();
        }

        // Sends a GET request with categoryId to the server-side and returns recommendations that match the category and the logged in user's neighborhood
        getCategoryRecommendations(categoryId) {

            return this.categoryResource.getCategoryRecommendations({ id: categoryId }).$promise;
        }

        // Sends a POST request to the server-side to add/edit a category - Admin Only
        saveCategory(category) {

            return this.categoryResource.save(category).$promise;
        }

        // Sends a DELETE request with postId to the server-side - Admin Only
        deleteCategory(categoryId) {

            return this.categoryResource.delete({ id: categoryId }).$promise;
        }

        // get all recommendations. For Admin
        getAllRecommendations() {

            return this.recommendationResource.query();
        }

        // get all recommendations pertaining to the logged in user's neighborhood
        getRecommendations() {

            return this.recommendationResource.getRecommendations();
        }

        //get details about a specific business Ex: details about ABC Plumbing
        getRecommendation(recoId) {

            return this.recommendationResource.get({ id: recoId });
        }

        //add or edit a business
        saveRecommendation(categoryId, recommendation) {
            
            return this.recommendationResource.save({ id: categoryId }, recommendation).$promise;
        }
    }

    angular.module('ZoneInApp').service('categoryService', CategoryService);
}