var myApp = angular.module("myApp", [ "ui.router", "ngResource" ]);
myApp.controller("MainController", MainController);
myApp.controller("CategoryController", CategoryController);
myApp.controller("CategoriesController", CategoriesController);
// myApp.controller("EmployeeController", EmployeeController);
// myApp.service("$employeeService", EmployeeService);
myApp.controller("EditAdController", EditAdController);
myApp.controller("AddAdController", AddAdController);
myApp.controller("AdDetailsController", AdDetailsController);
myApp.service("$adService", AdService);
myApp.service("$categoryService", CategoryService);


myApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider
        .state("home", {
            url: "/",
            templateUrl: "/ngApp/views/main.html",
            controller: CategoriesController,
            controllerAs: "controller"
        }).state("category", {
            url: "/category/:id",
            templateUrl: "/ngApp/views/category.html",
            controller: CategoryController,
            controllerAs: "controller"                
        }).state("editAd", {
            url: "/editAd/:id",
            templateUrl: "/ngApp/views/editAd.html",
            controller: EditAdController,
            controllerAs: "controller"
        }).state("addAd", {
            url: "/addAd",
            templateUrl: "/ngApp/views/addAd.html",
            controller: AddAdController,
            controllerAs: "controller"
        }).state("adDetails", {
            url: "/adDetails/:id",
            templateUrl: "/ngApp/views/adDetails.html",
            controller: AdDetailsController,
            controllerAs: "controller"
        });

    // Handle request for non-existent route
    $urlRouterProvider.otherwise("/notFound");

    // Enable HTML5 navigation
    $locationProvider.html5Mode(true);
});
