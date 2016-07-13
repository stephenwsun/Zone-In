namespace ZoneInApp.Controllers {

    export class InboxController {

        public messages;

        constructor(private inboxService: ZoneInApp.Services.InboxService) {

            this.getUserMessages();
        }

        getUserMessages() {

            this.messages = this.inboxService.getUserMessages();
        }
    }

    export class InboxDetailsController {

        public message;
        public messageId;

        constructor(private inboxService: ZoneInApp.Services.InboxService, private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {

            this.messageId = $stateParams['id'];
            this.getMessage();
        }

        getMessage() {

            this.inboxService.getMessage(this.messageId).then((data) => {
                //console.log(data);
                this.message = data;
            });
        }
    }
}