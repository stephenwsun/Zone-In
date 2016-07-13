namespace ZoneInApp {

    angular.module('ZoneInApp', ['ui.router', 'ngResource', 'ui.bootstrap', 'ngMap', 'ngMaterial', 'ngtimeago', 'ngtweet']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            // landing page
            .state('welcome', {
                url: '/',
                templateUrl: '/ngApp/views/zonein.html',
                controller: ZoneInApp.Controllers.WelcomeController,
                controllerAs: 'controller'
            })
            // home
            .state('newsfeed', {
                url: '/newsfeed',
                templateUrl: '/ngApp/views/home.html',
                controller: ZoneInApp.Controllers.PostController,
                controllerAs: 'controller'
            })
            // posts
            .state('postCreate', {
                url: '/post/create',
                templateUrl: '/ngApp/views/postCreate.html',
                controller: ZoneInApp.Controllers.PostCreateController,
                controllerAs: 'controller'
            })
            .state('postDetails', {
                url: '/post/details/:id',
                templateUrl: '/ngApp/views/postDetails.html',
                controller: ZoneInApp.Controllers.PostDetailsController,
                controllerAs: 'controller'
            })
            .state('postEdit', {
                url: '/post/edit/:id',
                templateUrl: '/ngApp/views/postEdit.html',
                controller: ZoneInApp.Controllers.PostEditController,
                controllerAs: 'controller'
            })
            .state('postDelete', {
                url: '/post/delete:id',
                templateUrl: '/ngApp/views/postDelete.html',
                controller: ZoneInApp.Controllers.PostDeleteController,
                controllerAs: 'controller'
            })
            // inbox
            .state('inbox', {
                url: '/inbox',
                templateUrl: '/ngApp/views/inbox.html',
                controller: ZoneInApp.Controllers.InboxController,
                controllerAs: 'controller'
            })
            // neighbors
            .state('users', {
                url: '/users',
                templateUrl: '/ngApp/views/users.html',
                controller: ZoneInApp.Controllers.UserController,
                controllerAs: 'controller'
            })
            .state('userDetails', {
                url: '/user/details/:id',
                templateUrl: '/ngApp/views/userDetails.html',
                controller: ZoneInApp.Controllers.UserDetailsController,
                controllerAs: 'controller'
            })
            .state('userEdit', {
                url: '/user/edit/:id',
                templateUrl: '/ngApp/views/userEdit.html',
                controller: ZoneInApp.Controllers.UserEditController,
                controllerAs: 'controller'
            })
            .state('userDelete', {
                url: '/user/delete/:id',
                templateUrl: '/ngApp/views/userDelete.html',
                controller: ZoneInApp.Controllers.UserDeleteController,
                controllerAs: 'controller'
            })
            // map
            .state('map', {
                url: '/map',
                templateUrl: '/ngApp/views/map.html',
                controller: ZoneInApp.Controllers.MapController,
                controllerAs: 'controller'
            })
            //categories
            .state('categories', {
                url: '/categories',
                templateUrl: '/ngApp/views/categories.html',
                controller: ZoneInApp.Controllers.CategoryController,
                controllerAs: 'controller'
            })
            .state('categoryDetails', {
                url: '/category/details/:id',
                templateUrl: '/ngApp/views/categoryDetails.html',
                controller: ZoneInApp.Controllers.CategoryDetailController,
                controllerAs: 'controller'
            })
            .state('categoryCreate', {
                url: '/category/create',
                templateUrl: '/ngApp/views/categoryCreate.html',
                controller: ZoneInApp.Controllers.CategoryCreateController,
                controllerAs: 'controller'
            })
            .state('categoryEdit', {
                url: '/category/edit/:id',
                templateUrl: '/ngApp/views/categoryEdit.html',
                controller: ZoneInApp.Controllers.CategoryEditController,
                controllerAs: 'controller'
            })
            .state('categoryDelete', {
                url: '/category/delete/:id',
                templateUrl: '/ngApp/views/categoryDelete.html',
                controller: ZoneInApp.Controllers.CategoryDeleteController,
                controllerAs: 'controller'
            })
            // recommendations
            .state('recommendationDetails', {
                url: '/recommendation/details/:id',
                templateUrl: '/ngApp/views/recommendationDetails.html',
                controller: ZoneInApp.Controllers.RecommendationDetailsController,
                controllerAs: 'controller'
            })
            .state('recommendationCreate', {
                url: '/recommendation/create',
                templateUrl: '/ngApp/views/recommendationCreate.html',
                controller: ZoneInApp.Controllers.RecommendationCreateController,
                controllerAs: 'controller'
            })
            // events
            .state('events', {
                url: '/events',
                templateUrl: '/ngApp/views/events.html',
                controller: ZoneInApp.Controllers.EventController,
                controllerAs: 'controller'
            })
            .state('eventDetails', {
                url: '/event/details/:id',
                templateUrl: '/ngApp/views/eventDetails.html',
                controller: ZoneInApp.Controllers.EventDetailsController,
                controllerAs: 'controller'
            })
            .state('eventCreate', {
                url: '/events/create',
                templateUrl: '/ngApp/views/eventCreate.html',
                controller: ZoneInApp.Controllers.EventCreateController,
                controllerAs: 'controller'
            })
            .state('eventEdit', {
                url: '/event/edit/:id',
                templateUrl: '/ngApp/views/eventEdit.html',
                controller: ZoneInApp.Controllers.EventEditController,
                controllerAs: 'controller'
            })
            .state('eventDelete', {
                url: '/event/delete/:id',
                templateUrl: '/ngApp/views/eventDelete.html',
                controller: ZoneInApp.Controllers.EventDeleteController,
                controllerAs: 'controller'
            })
            // not used
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: ZoneInApp.Controllers.AboutController,
                controllerAs: 'controller'
            })
            // admin
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: ZoneInApp.Controllers.SecretController,
                controllerAs: 'controller'
            })
            // login
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: ZoneInApp.Controllers.LoginController,
                controllerAs: 'controller'
            })
            //register
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: ZoneInApp.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: ZoneInApp.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            })             
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('ZoneInApp').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('ZoneInApp').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
