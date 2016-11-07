var $lnkGetTinyURL = $('#lnkGetTinyURL');
var $txtLongURL = $('#txtLongURL');
var $lblTinyUrl = $('#lblTinyUrl');
var $lblError = $('#lblError');
$(document).ready(function () {
    $lblError.hide();
    if ($lnkGetTinyURL !== undefined) {
        $lnkGetTinyURL.click(function (e) {
            getTinyURL();
        });
    }

    getTinyURL = function () {
        if ($txtLongURL !== undefined) {
            if ($txtLongURL.val() !== '') {
                if ($txtLongURL.val().indexOf('mydeal.com.au') > 0) {
                    var longURL = $txtLongURL.val();
                    var model = getURLMappedModel(longURL);
                    tinyUrlService.getTinyURL(model, function (result) {
                        var shortUrl = window.location.origin + "/Home/MyTinyUrl/" + result.PayLoad;
                        $lblTinyUrl.val(shortUrl);
                    });
                }
                else {
                    $lblError.show();
                    $lblError.text('Url Entered should be domain or subdomain from deal.com.au');
                }
            }
            else {
                $lblError.show();
                $lblError.text('Please enter the long url to be shortened.');
            }
        }
    }

    getURLMappedModel = function (longUrl) {
        var requestModel = {
            PayLoad: longUrl
        };
        return requestModel;
    }
});