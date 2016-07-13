namespace ZoneInApp.Controllers {

    // Controller in charge of getting all business categories
    export class CategoryController {

        public categories;

        constructor(private categoryService: ZoneInApp.Services.CategoryService) {

            this.getCategories();
        }

        getCategories() {

            this.categories = this.categoryService.getCategories();
        }
    }

    // Controller in charge of getting categoryId and category with matching categoryId
    export class CategoryDetailController {

        public category;
        public categoryId;
        public recommendation;
        public recommendations;

        constructor(private categoryService: ZoneInApp.Services.CategoryService, private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {

            this.categoryId = $stateParams['id'];
            this.getCategoryRecommendations();
        }

        getCategoryRecommendations() {

            this.categoryService.getCategoryRecommendations(this.categoryId).then((data) => {
                console.log(data);
                this.recommendations = data;
            });
        }

        saveRecommendation() {

            this.categoryService.saveRecommendation(this.categoryId, this.recommendation).then(() => {

                this.getCategoryRecommendations();
            });
        }

        close() {

            (<any>$("#post-modal")).modal('hide');
            this.getCategoryRecommendations();
        }

        cancel() {

            this.$state.go('categories');
        }
    }

    // Controller in charge of creating a new business category - Admin Only
    export class CategoryCreateController {

        public category;

        constructor(private categoryService: ZoneInApp.Services.CategoryService, private $state: angular.ui.IStateService) {

        }

        saveCategory() {

            this.categoryService.saveCategory(this.category).then(() => {

                this.$state.go('categories');
            });
        }

        cancel() {

            this.$state.go('categories');
        }
    }

    // Controller in charge of editing existing business categories - Admin Only
    export class CategoryEditController {

        public category;
        public categoryId;

        constructor(private categoryService: ZoneInApp.Services.CategoryService,
            private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {

            this.categoryId = $stateParams['id'];
            this.getCategory();
        }

        getCategory() {

            this.category = this.categoryService.getCategoryRecommendations(this.categoryId);
        }

        saveCategory() {

            this.categoryService.saveCategory(this.category).then(() => {
                this.$state.go('categories');
            });
        }

        cancel() {

            this.$state.go('categories');
        }
    }

    // Controller in charge of deleting business category with matching id
    export class CategoryDeleteController {

        public category;
        public categoryId;

        constructor(private categoryService: ZoneInApp.Services.CategoryService,
            private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {

            this.categoryId = $stateParams['id'];
            this.getCategory();
        }

        getCategory() {

            this.category = this.categoryService.getCategoryRecommendations(this.categoryId);
        }

        deleteCategory() {

            this.categoryService.deleteCategory(this.categoryId).then(() => {
                this.$state.go('categories');
            });
        }

        cancel() {

            this.$state.go('categories');
        }
    }

    export class RecommendationDetailsController {

        public recommendation;
        public recommendationId;

        constructor(private categoryService: ZoneInApp.Services.CategoryService, private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {

            this.recommendationId = $stateParams['id'];
            this.getRecommendation();
        }

        recommend() {

            this.categoryService.recommend(this.recommendationId, 1);
            this.getRecommendation();
            let element: any = document.getElementById("recommend");
            this.getRecommendation();
        }

        //get details about a specific business
        getRecommendation() {

            this.recommendation = this.categoryService.getRecommendation(this.recommendationId);
        }
    }

    export class RecommendationCreateController {

        public recommendation;
        public categoryId;

        constructor(private categoryService: ZoneInApp.Services.CategoryService,
            private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {

            this.categoryId = $stateParams['id'];
            this.saveRecommendation();
        }

        saveRecommendation() {

            this.categoryService.saveRecommendation(this.categoryId, this.recommendation).then(() => {
                this.$state.go('categoryDetails');
            });
        }

        cancelReco() {

            this.$state.go('categoryDetails');
        }
    }
}