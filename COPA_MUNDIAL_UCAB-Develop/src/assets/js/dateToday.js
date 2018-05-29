var headline = angular.module('headline', []);
headline.controller('datCtrl', function($scope) {
    $scope.today = new Date();
});