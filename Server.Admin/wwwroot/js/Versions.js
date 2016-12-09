var app = angular.module("app", ["xeditable"]);

app.run(function (editableOptions) {
    editableOptions.theme = 'bs3';
});

app.controller('Ctrl', function ($scope, $filter, $http) {
    $scope.versions = [];

    $http.get('/version/versions').success(function (data) {
        $scope.versions = data;
    });



    $scope.states = [
    { value: 1, text: 'Production' },
    { value: 2, text: 'Dev' },
    { value: 3, text: 'Test' }
    ];

    $scope.saveVersion = function (data, id) {
        //$scope.user not updated yet
        angular.extend(data, { id: id });
        $http.post(window.location.protocol + '//' + window.location.host + '/Version/SaveVersion', data).then(function () { });
    };


    $scope.removeVersion = function (data, index) {
        $scope.versions.splice(index, 1);
        $http.post(window.location.protocol + '//' + window.location.host + '/Version/DeleteVersion', data).then(function () { });
    };


    $scope.addVersion = function () {
        $scope.inserted = {
            id:{},
            vers: "0.0.0.0",
            startedTime: new Date(),
            state: "Dev",
            isActual: false
        };
        $scope.versions.push($scope.inserted);
    };
});

//ngMockE2E
//// --------------- mock $http requests ----------------------
//app.run(function ($httpBackend) {
//    $httpBackend.whenGET('/groups').respond([
//      { id: 1, text: 'user' },
//      { id: 2, text: 'customer' },
//      { id: 3, text: 'vip' },
//      { id: 4, text: 'admin' }
//    ]);

//    $httpBackend.whenPOST(/\/saveUser/).respond(function (method, url, data) {
//        data = angular.fromJson(data);
//        return [200, { status: 'ok' }];
//    });
//});