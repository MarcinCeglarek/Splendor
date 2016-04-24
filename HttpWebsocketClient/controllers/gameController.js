var game = app.controller('GameController', [ '$scope', '$log', 'websocket', 'player', function($scope, $log, websocket, player) {
    var controller = this;
    this.player = player;
    this.game = {};
    this.ChipsToTake = { "White": 0, "Blue" : 0, "Green":0, "Red": 0, "Black": 0, "Gold": 0 };
    
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
    
    this.getPlayerName = function() {
        return player.getName();
    }
    
    this.getPlayerId = function() {
        return player.getId();
    }
    
    this.refreshGame = function() {
        if (controller.game.GameId) {
            websocket.send({ MessageType: "GameStatus", GameId: controller.game.GameId });
        }
        
    }
    
    this.startGame = function() {
        if (controller.game.GameId) {
            websocket.send({ MessageType: "GameStarted", GameId: controller.game.GameId });
        }
    }
    
    this.takeChip = function(color) {
        if (this.game && this.game.Bank[color] > 0) {
            debugger;
            this.game.Bank[color]--;
            this.ChipsToTake[color]++;
        }
    }
        
    this.untakeChip = function(color) {
        if (this.game && this.ChipsToTake[color] > 0) {
            debugger;
            this.ChipsToTake[color]--;
            this.game.Bank[color]++;
        }
    }
    
    this.takeChips = function() {
        
    }
    
    return this;
}]);

game.$inject = ['$scope', '$log', 'websocket'];