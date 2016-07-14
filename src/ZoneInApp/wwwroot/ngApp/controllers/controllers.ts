namespace ZoneInApp.Controllers {

    export class HomeController {

        constructor() {

        }
    }

    export class SecretController {

        public secrets;
        public posts;
        public user;
        public events;
        public recommendations;

        constructor($http: ng.IHttpService, private postService: ZoneInApp.Services.PostService, private userService: ZoneInApp.Services.UserService, private eventService: ZoneInApp.Services.EventService, private categoryService: ZoneInApp.Services.CategoryService) {

            this.getLoginUser();
            this.getActivePosts();
            this.getActiveEvents();
            this.getAllRecommendations();
        }

        getLoginUser() {

            this.user = this.userService.getLoginUser();
        }

        getActivePosts() {

            this.posts = this.postService.getActivePosts();
        }

        getActiveEvents() {

            this.events = this.eventService.getActiveEvents();
        }

        getAllRecommendations() {

            this.recommendations = this.categoryService.getAllRecommendations();
        }
    }


    export class AboutController {

    }

}
