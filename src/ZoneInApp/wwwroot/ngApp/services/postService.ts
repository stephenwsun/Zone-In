namespace ZoneInApp.Services {

    export class PostService {

        private postResource;
        private replyResource;

        constructor($resource: angular.resource.IResourceService) {

            this.postResource = $resource('/api/post/:id', null, {

                thank: {

                    method: 'PUT'
                },

                getActivePosts: {

                    method: 'GET',
                    url: '/api/post/getactiveposts',
                    isArray: true
                },

                getNeighborhoodPosts: {

                    method: 'GET',
                    url: '/api/post/getneighborhoodposts',
                    isArray: true
                }
            });

            this.replyResource = $resource('/api/reply/:id');
        }

        // Thank Functionality
        thankPost(postId, thankValue) {

            return this.postResource.thank({ id: postId }, thankValue);
        }
        
        // Sends a GET request to the server-side and returns active posts
        getActivePosts() {

            return this.postResource.getActivePosts();
        }

        // Sends a GET request to the server-side and returns all posts belonging to that neighborhood
        getNeighborhoodPosts() {

            return this.postResource.getNeighborhoodPosts();
        }

        // Sends a GET request with postId to the server-side and returns post with matching id
        getPost(postId) {

            return this.postResource.get({ id: postId });
        }

        // Sends a POST request to the server-side to add/edit a post
        savePost(post) {

            return this.postResource.save(post).$promise;
        }

        // Sends a POST request to the server-side to add/edit a reply
        saveReply(postId, reply) {

            return this.replyResource.save({ id: postId }, reply).$promise;
        }

        // Sends a DELETE request with postId to the server-side
        deletePost(postId) {

            return this.postResource.delete({ id: postId }).$promise;
        }
    }

    angular.module('ZoneInApp').service('postService', PostService);
}