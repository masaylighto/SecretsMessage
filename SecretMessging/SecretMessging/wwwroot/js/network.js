function Ajax(data, url, fn = function () { }) {

    var http = new XMLHttpRequest();
    http.open("POST", url, true);
    http.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    http.send(data);

    http.onreadystatechange = function () {
        if (http.readyState == 4 && http.status == 200) {
            if (http.responseText != "Breaks") {
                fn(http.responseText);
            }
            else {
                location.href = "/";
            }

        }
    };

}
