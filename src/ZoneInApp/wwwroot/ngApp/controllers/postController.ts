namespace ZoneInApp.Controllers {

    // controller in charge of getting all active posts
    export class PostController {

        public posts;
        public post;
        public user;

        constructor(private postService: ZoneInApp.Services.PostService, private userService: ZoneInApp.Services.UserService, private $state: angular.ui.IStateService) {

            this.getLoginUser();
            this.getNeighborhoodPosts();
        }

        getLoginUser() {

            this.user = this.userService.getLoginUser();
        }

        getActivePosts() {

            this.posts = this.postService.getActivePosts();
        }

        getNeighborhoodPosts() {

            this.posts = this.postService.getNeighborhoodPosts();
        }

        savePost() {

            this.postService.savePost(this.post).then(() => {

                this.getNeighborhoodPosts();
            });
        }

        close() {

            (<any>$("#post-modal")).modal('hide');
            this.getNeighborhoodPosts();
        }

        cancel() {

            this.getNeighborhoodPosts();
        }
    }

    // Controller in charge of getting postId and post with matching postId
    export class PostDetailsController {

        public post;
        public postId;
        public reply;

        constructor(private postService: ZoneInApp.Services.PostService, private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {

            this.postId = $stateParams['id'];
            this.getPost();
        }

        thankPost() {

            this.postService.thankPost(this.postId, 1);
            this.getPost();
            let element: any = document.getElementById("thank");
            this.getPost();
        }

        getPost() {

            this.post = this.postService.getPost(this.postId);
        }

        saveReply() {

            this.postService.saveReply(this.postId, this.reply).then(() => {

                this.getPost();
                let element: any = document.getElementById("replyForm");
                element.reset();
            });
        }

        cancel() {

            this.$state.go('newsfeed');
        }
    }

    // Controller in charge of creating a new post
    export class PostCreateController {

        public post;

        constructor(private postService: ZoneInApp.Services.PostService, private $state: angular.ui.IStateService) {

        }

        savePost() {

            this.postService.savePost(this.post).then(() => {

                this.$state.go('newsfeed');
            });
        }

        cancel() {

            this.$state.go('newsfeed');
        }
    }

    // Controller in charge of editing existing posts
    export class PostEditController {

        public post;
        public postId;

        constructor(private postService: ZoneInApp.Services.PostService, private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {

            this.postId = $stateParams['id'];
            this.getPost();
        }

        getPost() {

            this.post = this.postService.getPost(this.postId);
        }

        savePost() {

            this.postService.savePost(this.post).then(() => {

                this.$state.go('newsfeed');
            });
        }

        cancel() {

            this.$state.go('newsfeed');
        }
    }

    // Controller in charge of deleting post with matching id
    export class PostDeleteController {

        public post;
        public postId;

        constructor(private postService: ZoneInApp.Services.PostService, private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {

            this.postId = $stateParams['id'];
            this.getPost();
        }

        getPost() {

            this.post = this.postService.getPost(this.postId);
        }

        deletePost() {

            this.postService.deletePost(this.postId).then(() => {

                this.$state.go('newsfeed');
            });
        }

        cancel() {

            this.$state.go('newsfeed');
        }
    }
}