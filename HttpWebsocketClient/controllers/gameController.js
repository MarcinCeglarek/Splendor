app.directive("gameBoard", function() {
    return {
        restrict: 'E',
        templateUrl: './templates/gameBoard.html'
    }
});

app.controller('ServerController', [ '$scope', '$log', 'websocket', function($scope, $log, websocket) {
    var controller = this;
    this.game = {};
    
    
    
}]);