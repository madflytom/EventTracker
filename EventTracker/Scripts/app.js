var app = angular.module('eventScheduler', ['ui.router']);

app.factory('events', ['$http', function($http) {
    var o = {
        dataCollection: []
    };

    //o.getData = function (link) {
    //    return $http.get(link).success(function (data) {
    //        angular.copy(data, o.dataCollection);
    //    });
    //};

    o.getAllData = function () {
        return $http.get('api/Events').success(function (data) {
            angular.copy(data, o.dataCollection);
        });
    };

    o.saveEvent = function (event) {
        //TODO: find "post" for angular
        alert(event.Title);
        return $http.post('api/Events', event).success(function (data) {
            redirectPage('/index.html');
        });
    };

    o.deleteEvent = function (id) {
        alert(id);
        return $http.delete('api/Events/' + id).success(function (data) {
            redirectPage('/index.html');
        });
    };
    o.updateEvent = function (id, event) {
        //alert(id);
        return $http.put('api/Events/' + id, event).success(function (data) {
            alert("Update Successful");
        });

    };

    return o;
}]);

app.factory('dataFactory', ['$http', function($http){
    var urlBase = '/api/Events/';
    var dataFactory = {};

    dataFactory.getOneEvent = function(id) {
        return $http.get(urlBase + id);
        alert("done")
    };

    return dataFactory;
}]);

app.config([
    '$stateProvider',
    '$urlRouterProvider',
    function ($stateProvider, $urlRouterProvider) {

        $stateProvider
    		.state('home', {
    		    url: '/home',
    		    templateUrl: '/home.html',
    		    controller: 'MainCtrl'
    		})
            .state('edit', {
                url: '/edit',
                templateUrl: '/edit.html',
                controller: 'EditCtrl'
            })
    		.state('signUp', {
    		    url: '/signUp/{id}',
    		    templateUrl: '/signUp.html',
    		    controller: 'SingUpCtrl'
    		})
            .state('createEvent', {
                url: '/createEvent',
                templateUrl: '/create.html',
                controller: 'CreateEventCtrl'
            });

        $urlRouterProvider.otherwise('home');
    }]);


app.controller('SingUpCtrl', [
	'$scope',
    'dataFactory',
	function ($scope, dataFactory) {
	    $scope.event;
	    getOneEvent();
	    alert();
	    
	    function getOneEvent() {
            //TODO: figure out how to get the event number to pass through here.
	        dataFactory.getOneEvent(21)
            .success(function (event) {
                $scope.event = event;
                alert(event.Title)
            }).error(function (error) {
                $scope.status = 'Unable to load event data: ' + error.message;
            });
	    }

        var slots = 
	    $scope.slots = ["03/02/2015 08:00", "03/02/2015 08:10", "03/02/2015 08:20"];

	}]);

app.controller('CreateEventCtrl', [
	'$scope',
    'events',
	function ($scope, events) {
	    $scope.title = "";
	    $scope.summary = "";
	    $scope.location = "";
	    $scope.startDate = "";
	    $scope.endDate = "";
	    $scope.slotDuration = "";
	    $scope.seats = "";
       
	    $scope.saveEvent = function () {
            alert($scope.title)
	        var event = {
	            Title: $scope.title,
	            Description: $scope.summary,
	            Location: $scope.location,
	            OwnerENT: "tstahl",
	            Seats: $scope.seats,
	            BlockDuration: $scope.slotDuration,
	            StartDateTime: $scope.startDate,
	            EndDateTime: $scope.endDate
	        };
	        alert(event.Title);
	        events.saveEvent(event);
	    }

	}]);

app.controller('MainCtrl', [
	'$scope',
    'events',
	function ($scope, events) {
	    events.getAllData();
	    $scope.events = events.dataCollection;
	    $scope.deleteEvent = function (id) {
	        events.deleteEvent(id);
	    };
	    //$scope.updateEvent = function (id) {
	    //    events.updateEvent(id, events.dataCollection);
	    //    //events.updateEvent(event.EventId, event);
	    //};

	    $scope.save = function (event) {
	        //alert("Edit");
	        //var frien = this.event;
	       // alert(event.EventId);
	        //alert(event);
	        events.updateEvent(event.EventId, event);
	    };
	}
]);

app.controller('EditCtrl', [
	'$scope',
    'events',
	function ($scope, events) {
	    events.getAllData();
	    $scope.events = events.dataCollection;
	    $scope.deleteEvent = function (id) {
	        events.deleteEvent(id);
	    };
	    //$scope.updateEvent = function (id) {
	    //    events.updateEvent(id, events.dataCollection);
	    //    //events.updateEvent(event.EventId, event);
	    //};

	    $scope.save = function (event) {
	        //alert("Edit");
	        //var frien = this.event;
	        // alert(event.EventId);
	        //alert(event);
	        events.updateEvent(event.EventId, event);
	    };
	}
]);

function redirectPage(url) {
    alert("Post Successful");
    window.location.assign(url);
}

