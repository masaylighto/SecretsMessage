function Send()
{
    var message = document.getElementById("message").value;
    var key = document.getElementById("Key").value;
    if (document.getElementById("Encypted").checked) {
        var data = CryptoJS.AES.encrypt(message, key);
        Ajax("Content=" + data + "&Crypted=true", "/Msg/send_action", get);
        return;
    }
   
    Ajax("Content=" + message +"&Crypted=false", "/Msg/send_action", get);
}
function get(str) {
    var url = document.getElementById("url");
   
    url.innerText =  document.location.origin +"/Msg/Reads_view?url="+str;
}