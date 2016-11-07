tinyUrlService = {
    failure: function (error) {
        if (typeof (error) == "string") {
            alert(error);
        }
        else {
            alert('Error Occurred.');
        }
    },
    getTinyURL: function (request, successMethod) {
        var innerFailure = this.failure;
        var webApiURL = 'http://localhost:51656/Api/TinyURL/';
        ajaxServices.post(webApiURL + 'GetTinyUrl', request, function (result) {
            if (result.Status == true) {
                successMethod(result);
            }
            else {
                innerFailure(result.ErrorMessage);
            }
        }, this.failure);
    },
}