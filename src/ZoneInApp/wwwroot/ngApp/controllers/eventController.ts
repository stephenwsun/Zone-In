namespace ZoneInApp.Controllers {

    // Declare variable for Instagram feed
    declare var Instafeed: any;

    // Controller in charge of getting all active events and displaying Instagram feed
    export class EventController {

        public events;
        public event;
        public user;

        constructor(private eventService: ZoneInApp.Services.EventService, private userService: ZoneInApp.Services.UserService, private $state: angular.ui.IStateService) {

            this.getLoginUser();
            this.getEvents();
            this.instafeed();
        }

        getLoginUser() {

            this.user = this.userService.getLoginUser();
        }

        getEvents() {

            this.events = this.eventService.getEvents();
        }

        instafeed() {

            var userFeed = new Instafeed({
                get: 'user',
                userId: '445932006',
                accessToken: '445932006.1677ed0.61e74d38b3094243b36f3bd3d4801018'
            });

            userFeed.run();
        }

        saveEvent() {

            this.eventService.saveEvent(this.event).then(() => {
                this.getEvents();
            });
        }

        close() {

            (<any>$("#event-modal")).modal('hide');
            this.getEvents();
        }

        dateTimePicker() {
            
            (<any>$('#datetimepicker6')).datetimepicker();
            (<any>$('#datetimepicker7')).datetimepicker({
                useCurrent: false 
            });
            (<any>$("#datetimepicker6")).on("dp.change", function (e) {
                $('#datetimepicker7').data("DateTimePicker").minDate(e.date);
            });
            (<any>$("#datetimepicker7")).on("dp.change", function (e) {
                $('#datetimepicker6').data("DateTimePicker").maxDate(e.date);
            });
        }

        dateTimePicker2() {

            (<any>$('#datetimepicker1')).datetimepicker();
            console.log("working");
        }
    }

    // Controller in charge of getting eventId and event with matching eventId
    export class EventDetailsController {

        public event;
        public eventId;
        public user;

        constructor(private eventService: ZoneInApp.Services.EventService, private userService: ZoneInApp.Services.UserService, private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {

            this.getLoginUser();
            this.eventId = $stateParams['id'];
            this.getEvent();
        }

        going() {

            this.eventService.eventStatus(this.eventId, 1);
            this.getEvent();
            let element: any = document.getElementById("going");
            this.getEvent();
        }

        maybe() {

            this.eventService.eventStatus(this.eventId, 2);
            this.getEvent();
            let element: any = document.getElementById("maybe");
            this.getEvent();
        }

        decline() {

            this.eventService.eventStatus(this.eventId, 3);
            this.getEvent();
            let element: any = document.getElementById("decline");
            this.getEvent();
        }

        getLoginUser() {
            
            this.user = this.userService.getLoginUser();
        }

        getEvent() {

            this.event = this.eventService.getEvent(this.eventId);
        }

        saveEvent() {

            this.eventService.saveEvent(this.event).then(() => {
                this.$state.go('events');
            });
        }

        cancel() {

            this.$state.go('events');
        }
    }

    // Controller in charge of creating a new event
    export class EventCreateController {

        public event;

        constructor(private eventService: ZoneInApp.Services.EventService,
            private $state: angular.ui.IStateService) {

        }

        saveEvent() {
            this.eventService.saveEvent(this.event).then(() => {
                this.$state.go('events');
            });
        }

        cancel() {
            this.$state.go('events');
        }
    }

    // Controller in charge of editing existing events
    export class EventEditController {

        public event;
        public eventId;

        constructor(private eventService: ZoneInApp.Services.EventService,
            private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {

            this.eventId = $stateParams['id'];
            this.getEvent();
        }

        getEvent() {

            this.event = this.eventService.getEvent(this.eventId);
        }

        saveEvent() {
            this.eventService.saveEvent(this.event).then(() => {
                this.$state.go('events');
            });
        }

        cancel() {
            this.$state.go('events');
        }
    }

    // Controller in charge of deleting event with matching id
    export class EventDeleteController {

        public event;
        public eventId;

        constructor(private eventService: ZoneInApp.Services.EventService,
            private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {

            this.eventId = $stateParams['id'];
            this.getEvent();
        }

        getEvent() {
            this.event = this.eventService.getEvent(this.eventId);
        }

        deleteEvent() {
            this.eventService.deleteEvent(this.eventId).then(() => {
                this.$state.go('events');
            });
        }

        cancel() {
            this.$state.go('events');
        }
    }
}