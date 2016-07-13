namespace ZoneInApp.Services {

    export class UserService {

        private userResource;

        constructor($resource: angular.resource.IResourceService) {

            this.userResource = $resource('/api/user/:id', null, {

                getActiveUsers: {

                    method: 'GET',
                    url: '/api/user/getactiveusers',
                    isArray: true
                }
            });
        }

        // Sends a GET request to the server-side and returns active users
        getActiveUsers() {

            return this.userResource.getActiveUsers().$promise;
        }

        // Sends a GET request with userId to the server-side and returns a user with matching id
        getUser(userId) {

            return this.userResource.get({ id: userId });
        }

        // Sends a GET request to the server-side and returns logged in user's information
        getLoginUser() {

            return this.userResource.get();
        }

        // Sends a POST request to the server-side to edit a user details
        saveUser(user) {

            return this.userResource.save(user).$promise;
        }

        // Sends a DELETE request to the server-side to delete a user
        deleteUser(userId) {

            return this.userResource.delete({ id: userId }).$promise;
        }
    }

    angular.module('ZoneInApp').service('userService', UserService);
}