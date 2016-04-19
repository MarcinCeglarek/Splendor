var app = angular.module('splendorApp', [])

app.directive("gamesList", function() {
    return {
        restrict: 'E',
        templateUrl: './templates/gamesList.html'
    }
})

app.directive("gameMenu", function() {
    return {
        restrict: 'E',
        templateUrl: './templates/gameMenu.html'
    }
})

app.directive("gameBoard", function() {
    return {
        restrict: 'E',
        templateUrl: './templates/gameBoard.html'
    }
});


