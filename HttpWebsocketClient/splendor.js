var app = angular.module('splendorApp', [])
app.controller('GameController', function() {
    this.games = [];
    this.playerName = "";
    this.SelectedGameId = "";
    
    this.connect = function() {
        console.log("server.connect");
        var ws = new WebSocket("ws://localhost:8181");
        this.ws = ws;
            
        ws.onopen = function () {
            console.log("Connection established");
        };

        ws.onmessage = function (evt) {
            var received_msg = evt.data;
            console.log("Message received = "+received_msg);
        };
        
        ws.onclose = function () {
            console.log("Connection is closed...");
        };
    }
    
    this.showGames = function() {
        console.log("ShowGames");
        ws.send("{ 'MessageType': 'ShowGames' }");
    }
        
    this.createGame = function() {
        console.log("CreateGame");
        ws.send("{ 'MessageType' : 'CreateGame' }")
    }

    this.joinGame = function() {
        console.log("JoinGame");
        ws.send("{ 'MessageType' : 'JoinGame', PlayerName: '" + this.playerName + "' }")
    }
    
    this.connect();
  });