var interceptorAutenticacion = ["$q", "$location", function ($q, $location) {
    return {
        response: function (response) {
            if (response.status == 401) {
                console.log("Error 401");
            }
            return response || $q.when(response);
        },
        responseError: function (rejection) {
            if (rejection.status === 401) {
                console.log("Response Error 401", rejection);
                var returnUrl = $location.path();
                $location.path('/Login').search('returnUrl', returnUrl);
            }
            return $q.reject(rejection);
        },
    }
}];