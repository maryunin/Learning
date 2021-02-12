angular.module("umbraco").controller("CustomDashboardController", function ($scope,userService) {
    var vm = this;
    vm.UserName = "guest";

    var user = userService.getCurrentUser().then(function(user) {
        console.log(user);
        vm.UserName = user.name;
    });
});