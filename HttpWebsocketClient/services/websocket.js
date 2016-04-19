app.factory('websocket', function($rootScope) {
    var service = this;
    this.ws = {};
    this.data = {};
    
    this.connect = function() {
        var ws = new WebSocket("ws://localhost:8181");
        this.ws = ws;
        
        this.ws.onopen = function () {
            Materialize.toast("Connected", 5000)
            $rootScope.$boradcast('websocketReady')
        };

        this.ws.onmessage = function (evt) {
            service.data = data = JSON.parse(evt.data);
            $rootScope.$broadcast('websocketMessage');
        };
        
        this.ws.onclose = function (event) {
            Materialize.toast("Connection closed: " + event.data, 5000, 'red')
        };
        
        this.ws.onerror = function(event) {
            Materialize.toast("There was an error during connection: " + event.data, 5000, 'red');
        }
    }

    this.send = function(request) {
        this.ws.send(request);
    }
    
    this.connect();
});