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

app.controller('GameController', [ '$scope', '$http', '$log', function($scope, $http, $log) {
    var controller = this;
    this.games = [];
    this.playerName = "";
    this.GameId = "";
    this.PlayerId = "";
    
    this.connect = function() {
        $log.debug("server.connect");
        var ws = new WebSocket("ws://localhost:8181");
        this.ws = ws;
            
        this.ws.onopen = function () {
            $log.log("Connection established");
            controller.showGames();
        };

        this.ws.onmessage = function (evt) {
            var data = JSON.parse(evt.data);
            $log.log(evt.data);
            
            switch(data.MessageType) {
                case "ShowGames":
                    controller.games = data.Games;
                    $scope.$apply();
                    break;
                case "GameJoined":
                    $log.log("GameJoined")
                    controller.GameId = data.GameId;
                    controller.PlayerId = data.PlayerId;
                    $scope.$apply();
                    break;
                 case "GameCreated": 
                    $log.log("GameCreated");
                    controller.showGames();
            }
        };
        
        this.ws.onclose = function () {
            $log.log("Connection is closed...");
        };
    }
    
    this.showGames = function() {
        $log.debug("showGames");
        this.ws.send("{ 'MessageType': 'ShowGames' }");
    }
        
    this.createGame = function() {
        $log.debug("createGame");
        this.ws.send("{ 'MessageType' : 'CreateGame' }");
    }

    this.joinGame = function() {
        $log.debug("joinGame");
        this.ws.send("{ 'MessageType' : 'JoinGame', GameId : '" + this.GameId  + "', PlayerName: '" + this.playerName  + "' }");
    }
    
    this.selectGame = function(id) {
        $log.debug("selectGame " + id);
        this.GameId = id;
    }
    
    this.isGameSelected = function(game) {
        return game.GameId === this.GameId;
    }
    
    this.connect();
}]);