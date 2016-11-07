ajaxServices =
    {
        getURL: function () {
            return '/';
        },

        get: function (webMethod, successMethod, failureMethod) {
            var _url = this.getURL() + webMethod;

            $.ajax
                ({
                    url: _url,
                    dataType: 'json',
                    // headers: { "user": getCurrentUserId() },
                    beforeSend: function () {
                        //   showLoader();
                    },
                    complete: function () {
                        // hideLoader();
                    },
                    success: function (json) {
                        successMethod(json);
                    },
                    error: function (error) {
                        failureMethod(error);
                    }
                });
        },

        post: function (webMethod, postData, successMethod, failureMethod) {
            var _url = webMethod;
            $.ajax
                ({
                    url: _url,
                    type: 'POST',
                    dataType: 'json',
                    contentType: "application/json; charset=utf-8",
                    data: this.serialize(postData),
                    // headers: { "user": getCurrentUserId() },
                    beforeSend: function () {
                        // showLoader();
                    },
                    complete: function () {
                        //hideLoader();
                    },
                    success: function (json) {
                        successMethod(json);
                    },
                    error: function (error) {
                        failureMethod(error);
                    }
                });
        },


        serialize: function (jsonObject) {
            var stringfy = JSON.stringify(jsonObject);
            return stringfy;
        }

    };

