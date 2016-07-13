namespace ZoneInApp.Controllers {

    export class MapController {

        public user;
        public neighbors;

        constructor(private userService: ZoneInApp.Services.UserService) {

            this.getUserLocation();
            this.getActiveNeighbors();
        }

        getUserLocation() {

            this.user = this.userService.getLoginUser();
        }

        getActiveNeighbors() {

            this.userService.getActiveUsers().then((data) => {
                console.log(data);
                this.neighbors = data;
            });
        }

        showNeighbor() {

            (<any>$("#myModal")).modal('show');
        }

        
    }
}