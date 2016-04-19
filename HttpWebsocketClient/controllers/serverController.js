var server = app.controller('ServerController', [ '$scope', '$log', 'websocket', function($scope, $log, websocket) {
    var controller = this;
    this.games = [];
    this.playerName = "";
    this.GameId = "";
    this.PlayerId = "";
       
    this.showGames = function() {
        $log.debug("showGames");
        websocket.send({ MessageType: 'ShowGames' });
    }
        
    this.createGame = function() {
        $log.debug("createGame");
        websocket.send({ MessageType : 'CreateGame' });
    }

    this.joinGame = function() {
        $log.debug("joinGame");
        websocket.send({ MessageType : 'JoinGame', GameId : this.GameId, PlayerName: this.playerName });
    }
    
    this.deleteGame = function(game) {
        $log.debug("deleteGame");
        websocket.send({ MessageType: 'DeleteGame', GameId : game.GameId });
    }
    
    this.selectGame = function(id) {
        $log.debug("selectGame " + id);
        this.GameId = id;
    }
    
    this.isGameSelected = function(game) {
        return game.GameId === this.GameId;
    }
    
    this.inGame = function() {
        if (this.GameId) {
            if (this.PlayerId) {
                return true;
            }
        }
        
        return false;
    }
    
    this.canJoin = function() {
        if (this.GameId) {
            if (this.playerName) {
                if (!this.PlayerId) {
                    return true;
                }
            }
        }
        
        return false;
    }
    
    $scope.$on('websocketReady', function() {
        controller.showGames();
    });
    
    $scope.$on('websocketMessage', function() {
        var data = websocket.data;
        
        switch(data.MessageType) {
                case "ShowGames":
                    controller.games = data.Games;
                    $scope.$apply();
                    break;
                case "GameJoined":
                    $log.log("GameJoined")
                    controller.GameId = data.GameId;
                    controller.PlayerId = data.PlayerId;
                    controller.showGames();
                    websocket.send({ MessageType: "GameStatus", GameId: controller.GameId });
                    break;
                 case "GameCreated": 
                    $log.log("GameCreated");
                    controller.showGames();
                    break;
                 case "GameDeleted": 
                    $log.log("GameDeleted");
                    controller.showGames();
                    break;
        }
    })
    
    return this;
}]);

server.$inject = ['$scope', '$log', 'websocket'];