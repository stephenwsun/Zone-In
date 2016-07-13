namespace ZoneInApp.Controllers {

    //Displays all users who have an active account
    export class UserController {

        public users;

        constructor(private userService: ZoneInApp.Services.UserService) {

            this.getActiveUsers();
        }

        getActiveUsers() {

            this.users = this.userService.getActiveUsers().then((data) => {

                this.users = data;
            });
        }
    }

    //Includes Detail Edit Delete methods
    export class UserDetailsController {

        public user;
        public userId;
        
        constructor(private userService: ZoneInApp.Services.UserService, private $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService) {

            this.userId = $stateParams['id'];
            this.getUser();            
        }

        getUser() {

            this.user = this.userService.getUser(this.userId);
        }
        
        saveUser() {

            this.userService.saveUser(this.user).then(() => {

                this.$state.go('users');
            });
        }

        cancel() {

            this.$state.go('users');
        }
    }

    export class UserEditController {

        public user;
        public userId;

        constructor(private userService: ZoneInApp.Services.UserService, private $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService) {

            this.userId = $stateParams['id'];
            this.getLoginUser();
        }

        getLoginUser() {

            this.user = this.userService.getLoginUser();
        }

        saveUser() {

            this.userService.saveUser(this.user).then(() => {

                this.getLoginUser();
            });
        }

        cancel() {
            this.$state.go('users');
        }
    }

    angular.module('ZoneInApp').controller('UserEditController', UserEditController);

    export class UserDeleteController {

        public user;
        public userId;

        constructor(private userService: ZoneInApp.Services.UserService, private $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService) {

            this.userId = $stateParams['id'];
            this.getUser();

        }

        getUser() {
            this.user = this.userService.getUser(this.userId);
        }

        deleteUser() {
            this.userService.deleteUser(this.userId).then(() => {
                this.$state.go('users');
            });
        }

        cancel() {
            this.$state.go('users');
        }
    }
}