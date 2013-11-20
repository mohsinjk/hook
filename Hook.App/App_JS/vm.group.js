define('vm.group', ['ko', 'hookData', 'model', 'dataservice'],
    function (ko, hookData, model, dataservice) {

        var vmGroup = {
            //group: ko.observableArray([]),
            //groupToAdd: ko.observable(""),
            
            //// loading the observable array 
            //load: function () {
            //    vmGroup.group = ko.mapping.fromJS(hookData.group);
            //}
        };

        return {
            group: vmGroup
        };
    });
