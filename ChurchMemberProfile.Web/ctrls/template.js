angular.module('vpApp').controller('TemplateCtrl', ['$scope', '$modal',
    function ($scope, $modal) {
        
        $scope.openModal = function () {
            var modalInstance = $modal.open({
                animation: true,
                templateUrl: 'createTemplateModal.html',
                controller: 'CreateTemplateModalInstanceCtrl',
                size: 'md',
                resolve: {
                    
                }
            });

            modalInstance.result.then(function (result) {

            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };


    }
]);


angular.module('vpApp').controller('CreateTemplateModalInstanceCtrl', function ($scope, $modalInstance) {

    $scope.cancel = function () {
        $modalInstance.dismiss();
    };

    $scope.load = function () {
        
    };

    $scope.load();
});
