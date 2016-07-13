namespace ZoneInApp.Services {

    export class InboxService {

        private messageResource;

        constructor($resource: angular.resource.IResourceService) {

            this.messageResource = $resource('/api/inbox/:id', null, {

                getUserMessages: {

                    method: 'GET',
                    url: '/api/inbox/getusermessages',
                    isArray: true
                }
            });
        }

        // Sends a GET request to the server-side and returns user's messages
        getUserMessages() {

            return this.messageResource.getUserMessages();
        }

        // Sends a GET request with messageId to the server-side and returns a message with matching id
        getMessage(messageId) {

            return this.messageResource.get({ id: messageId }).$promise;
        }

        // Sends a POST request to the server-side to create/edit a message
        saveUser(message) {

            return this.messageResource.save(message).$promise;
        }

        // Sends a DELETE request to the server-side to delete a message
        deleteUser(messageId) {

            return this.messageResource.delete({ id: messageId }).$promise;
        }
    }

    angular.module('ZoneInApp').service('inboxService', InboxService);
}