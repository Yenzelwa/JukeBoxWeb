
var app = angular.module("App", ['toaster', 'ngAutocomplete', 'ngTouch', 'angucomplete-alt']);

app.directive('dateTimePicker', function () {
    return {
        restrict: 'A',
        require: '?ngModel',
        link: function (scope, element, attrs, ngModel) {

            if (!ngModel) {
                return;
            }

            element.datetimepicker({
                weekStart: 0,
                autoclose: 1,
                todayHighlight: 0,
                startView: 2,
                forceParse: 0,
                showMeridian: 0,
                minuteStep: 1,
                pickerPosition: 'bottom-left'
                //format: 'dd MM yyyy HH:mm'
                
            });

            element.bind('change', function () {
                scope.$apply(read);
            });

            if (ngModel != null) {
                ngModel.$render = function () {
                    var dt = new Date(ngModel.$viewValue);
                    element.datetimepicker("setDate", dt);
                    return ngModel.$viewValue;
                };
            }

            function read() {
                ngModel.$setViewValue(element.val());
            }
        }
    }
});


app.directive('datePicker', function () {
    return {
        restrict: 'A',
        require: '?ngModel',
        link: function (scope, element, attrs, ngModel) {

            if (!ngModel) {
                return;
            }

            element.datetimepicker({
                weekStart: 0,
                autoclose: 1,
                todayHighlight: 0,
                startView: 2,
                forceParse: 0,
                showMeridian: 0,
                minuteStep: 1,
                pickerPosition: 'bottom-left',
                format: 'dd MM yyyy',
                minView: 2
            });

            element.bind('change', function () {
                scope.$apply(read);
            });

            if (ngModel != null) {
                ngModel.$render = function () {
                    var dt = new Date(ngModel.$viewValue);
                    element.datetimepicker("setDate", dt);
                    return ngModel.$viewValue;
                };
            }

            function read() {
                ngModel.$setViewValue(element.val());
            }
        }
    }
});


app.directive("passwordVerify", function () {
    return {
        require: "ngModel",
        scope: {
            passwordVerify: '='
        },
        link: function (scope, element, attrs, ctrl) {
            scope.$watch(function () {
                var combined;

                if (scope.passwordVerify || ctrl.$viewValue) {
                    combined = scope.passwordVerify + '_' + ctrl.$viewValue;
                }
                return combined;
            }, function (value) {
                if (value) {
                    ctrl.$parsers.unshift(function (viewValue) {
                        var origin = scope.passwordVerify;
                        if (origin !== viewValue) {
                            ctrl.$setValidity("passwordVerify", false);
                            return undefined;
                        } else {
                            ctrl.$setValidity("passwordVerify", true);
                            return viewValue;
                        }
                    });
                }
            });
        }
    };
});

app.directive('openDialogBox', function () {

   
    var openDialog = {
        link: function (scope, element) {
            function openDialog() {
                var element = angular.element('#myModal');
                element.modal('show');
            }
            element.bind('click', openDialog);
        }
    }
    return openDialog;
});

app.directive('openRejectReasonDialogBox', function () {


    var openDialog = {
        link: function (scope, element) {
            function openDialog() {
                var element = angular.element('#RejectReason');
                element.modal('show');
            }
            element.bind('click', openDialog);
        }
    }
    return openDialog;
});


app.directive('ngIf', function () {
    return {
        link: function (scope, element, attrs) {
            if (scope.$eval(attrs.ngIf)) {
                // remove '<div ng-if...></div>'
                element.replaceWith(element.children())
            } else {
                element.replaceWith(' ')
            }
        }
    }
});


app.directive('bsTabs', function ($parse, $compile, $timeout) {
    
    var template = '<div class="tabs">' +
    '<ul class="nav nav-tabs">' +
      '<li ng-repeat="pane in panes" ng-class="{active:pane.active}">' +
        '<a data-target="#{{pane.id}}" data-index="{{$index}}" data-toggle="tab">{{pane.title}}</a>' +
      '</li>' +
    '</ul>' +
    '<div class="tab-content" ng-transclude>' +
      // '<div ng-repeat="pane in panes" ng-class="{active:pane.selected}">{{pane.content}}</div>' +
    '</div>';

    return {
        restrict: 'A',
        require: '?ngModel',
        priority: 0,
        scope: true,
        template: template,//'<div class="tabs"><ul class="nav nav-tabs"></ul><div class="tab-content"></div></div>',
        replace: true,
        transclude: true,
        compile: function compile(tElement, tAttrs, transclude) {

            return function postLink(scope, iElement, iAttrs, controller) {

                var getter = $parse(iAttrs.bsTabs),
                    setter = getter.assign,
                    value = getter(scope);

                scope.panes = [];
                var $tabs = iElement.find('ul.nav-tabs');
                var $panes = iElement.find('div.tab-content');


                var activeTab = 0, id, title, active;
                $timeout(function () {

                    $panes.find('[data-title], [data-tab]').each(function (index) {
                        var $this = angular.element(this);

                        id = 'tab-' + scope.$id + '-' + index;
                        title = $this.data('title') || $this.data('tab');
                        active = !active && $this.hasClass('active');

                        $this.attr('id', id).addClass('tab-pane');
                        if (iAttrs.fade) $this.addClass('fade');

                        scope.panes.push({
                            id: id,
                            title: title,
                            content: this.innerHTML,
                            active: active
                        });

                    });

                    if (scope.panes.length && !active) {
                        $panes.find('.tab-pane:first-child').addClass('active' + (iAttrs.fade ? ' in' : ''));
                        scope.panes[0].active = true;
                    }

                });

                // If we have a controller (i.e. ngModelController) then wire it up
                if (controller) {

                    iElement.on('show', function (ev) {
                        var $target = $(ev.target);
                        scope.$apply(function () {
                            controller.$setViewValue($target.data('index'));
                        });
                    });

                    // Watch ngModel for changes
                    scope.$watch(iAttrs.ngModel, function (newValue, oldValue) {
                        if (angular.isUndefined(newValue)) return;
                        activeTab = newValue; // update starting activeTab before first build
                        scope.tabChanged();
                        setTimeout(function () {
                            var $next = $($tabs[0].querySelectorAll('li')[newValue * 1]);
                            if (!$next.hasClass('active')) {
                                $next.children('a').tab('show');                                
                            }
                        });
                    });

                }

            };

        }

    };

});

app.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}]);

app.service('fileUpload', ['$http', function ($http) {
    this.uploadFileToUrl = function (file, uploadUrl) {
        var fd = new FormData();
        fd.append('file', file);

        $http.post(uploadUrl, fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })

        .success(function () {
        })

        .error(function () {
        });
    }
}]);




