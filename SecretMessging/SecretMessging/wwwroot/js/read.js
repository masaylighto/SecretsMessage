function decrypt() {
    document.getElementById("decypted").style.visibility="hidden"
    var message = document.getElementById("message");
    if (message =="No Message Has Been Found On This Link") {
        alert(message);
        location.href = "/";
    }
    var messagecontent = document.getElementsByClassName("messagecontent")[0];
    messagecontent.style.visibility = "visible";
    var key = document.getElementById("Key").value;
    message.value = CryptoJS.AES.decrypt(message.value, key).toString(CryptoJS.enc.Utf8);

}
