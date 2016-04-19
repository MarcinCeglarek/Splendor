var game = app.controller('GameController', [ '$scope', '$log', 'websocket', function($scope, $log, websocket) {
    var controller = this;
    this.game = {};
    
    $scope.$on('websocketMessage', function() {
        var data = websocket.data;
        
        switch(data.MessageType) {
            case "GameStatus":
                controller.game = data;
                $scope.$apply();
                break;
        }
    })
    
    return this;
}]);

game.$inject = ['$scope', '$log', 'websocket'];