var app = angular.module('splendorApp', [])
app.controller('GameController', function($scope) {
    var controller = this;
    this.games = [];
    this.playerName = "";
    this.GameId = "";
    this.PlayerId = "";
    
    this.connect = function() {
        console.log("server.connect");
        var ws = new WebSocket("ws://localhost:8181");
        this.ws = ws;
            
        this.ws.onopen = function () {
            console.log("Connection established");
        };

        this.ws.onmessage = function (evt) {
            var data = JSON.parse(evt.data);
            console.log("Message received = " + evt.data);
            
            switch(data.MessageType) {
                case "ShowGames":
                    controller.games = data.Games;
                    $scope.$apply();
                    break;
                case "GameJoined":
                    controller.GameId = data.GameId;
                    controller.PlayerId = data.PlayerId;
                    controller.$apply();
                    break;
            }
        };
        
        this.ws.onclose = function () {
            console.log("Connection is closed...");
        };
    }
    
    this.showGames = function() {
        console.log("ShowGames");
        this.ws.send("{ 'MessageType': 'ShowGames' }");
    }
        
    this.createGame = function() {
        console.log("CreateGame");
        this.ws.send("{ 'MessageType' : 'CreateGame' }")
    }

    this.joinGame = function() {
        console.log("JoinGame");
        this.ws.send("{ 'MessageType' : 'JoinGame', GameId : '" + this.GameId +  "', PlayerName: '" + this.playerName + "' }")
    }
    
    this.selectGame = function(id) {
        console.log("selectGame:" + id);
        this.GameId = id;
    }
    
    this.connect();
  });