var gradifybase = 'http://gradify.kimerran.com/';
(function () {
    'use strict';
    angular.module('gradify',
    [
        'gradify.controllers',
        'gradify.services'
    ]);
    angular.module('gradify.controllers', []);
    angular.module('gradify.services', ['ngResource']);
})();

(function () {
    'use strict';
    angular.module('gradify.controllers')
        .controller('gradeController', [
            '$scope', 'gradeSvc',
            function ($scope, gradeSvc) {
                $scope.error = {};
                $scope.new = {};
                $scope.add = function() {

                    if ($scope.new.passcode != undefined && $scope.new.passcode != "") {
                        $scope.new.isPrivate = true;
                    }
                    gradeSvc.post($scope.new, function (res) {
                        $scope.new = {};
                        $scope.new.shortUrl = gradifybase + 'g/' + res.shortUrl;
                    });
                }
            }
        ])
        .controller('privateController', [
            '$scope', 'gradeSvc',
        function ($scope, gradeSvc) {
            $scope.cur = {};
            $scope.loaded = {};

            $scope.load = function () {
                $scope.cur.id = gradify_secret_id || 0;
                $scope.cur.isVerified = false;

                gradeSvc.get({ Id: $scope.cur.id }, function (res) {
                    $scope.loaded = res;
                });
            }

            $scope.verify = function () {
                if ($scope.cur.passcode == $scope.loaded.passcode) {
                    $scope.cur.isVerified = true;
                }
            }

            $scope.load();
        }]);
})();
(function () {
    'use strict';
    angular.module('gradify.services')
        .factory('gradeSvc',
            function ($resource) {
                return $resource(gradifybase + 'api/grade/:Id', { Id: '@Id' }, {
                    get: { method: 'GET' },
                    post: { method: 'POST' }
                });
            });
})();
