app.factory('player', function($rootScope) {
    var service = this;
    this.Name = "";
    this.Id = "";
       
    return {
            getName: function () {
                return this.Name;
            },
            setName: function(value) {
                this.Name = value;
            },
            getId: function() {
                return this.Id;
            },
            setId: function(value) {
                this.Id = value
            }
        };
});