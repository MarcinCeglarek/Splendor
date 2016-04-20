var game = app.controller('GameController', [ '$scope', '$log', 'websocket', function($scope, $log, websocket) {
    var controller = this;
    this.game = {};
    
    $scope.$on('websocketMessage', function() {
        var data = websocket.data;
        
        switch(data.MessageType) {
            case "GameStatus":
                controller.game = data;
                console.log(data);
                $scope.$apply();
                break;
                
            case "PlayerJoined":
                controller.refreshGame();
                break;
            
            case "PlayerLeft":
                controller.refreshGame();
                break;
                
            case "GameStarted":
                controller.refreshGame();
                break;
        }
    })
    
    this.refreshGame = function() {
        if (controller.game.GameId) {
            websocket.send({ MessageType: "GameStatus", GameId: controller.game.GameId });
        }
        
    }
    
    this.startGame = function() {
        debugger;
        if (controller.game.GameId) {
            websocket.send({ MessageType: "GameStarted", GameId: controller.game.GameId });
        }
    }
    
    return this;
}]);

game.$inject = ['$scope', '$log', 'websocket'];