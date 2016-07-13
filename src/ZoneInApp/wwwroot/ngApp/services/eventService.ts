namespace ZoneInApp.Services {

    export class EventService {

        private eventResource;

        constructor($resource: ng.resource.IResourceService) {

            this.eventResource = $resource('/api/event/:id', null, {

                eventStatus: {

                    method: 'PUT'
                },

                getActiveEvents: {

                    method: 'GET',
                    url: '/api/event/getactiveevents',
                    isArray: true
                },

                getEvents: {

                    method: 'GET',
                    url: 'api/event/getevents',
                    isArray: true
                }
            });
        }

        // Event Status Functionality
        eventStatus(eventId, eventValue) {

            return this.eventResource.eventStatus({ id: eventId }, eventValue);
        }

        // Sends a GET request to the server-side and returns active events. For Admin
        getActiveEvents() {

            return this.eventResource.getActiveEvents();
        }

        // Sends a GET request to the server-side and returns all events pertaining to the logged in user's neighborhood
        getEvents() {

            return this.eventResource.getEvents();
        }

        // Sends a GET request with eventId to the server-side and returns event with matching id
        getEvent(eventId) {

            return this.eventResource.get({ id: eventId });
        }

        // Sends a POST request to the server-side to add/edit an event
        saveEvent(ev) {

            return this.eventResource.save(ev).$promise;
        }

        // Sends a DELETE request with eventId to the server-side
        deleteEvent(eventId) {

            return this.eventResource.delete({ id: eventId }).$promise;
        }
    }

    angular.module('ZoneInApp').service('eventService', EventService);
}