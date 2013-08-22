
var timerId = null;
var dataLoading = true;
//显示加载条 add by wxg 080806
function showProgress() {
    dataLoading = true;
    GetMsg();
}
function hideProgress() {
    dataLoading = false;
}
function GetMsg() {
    var msg = document.getElementById("divShowLoading");
    var divWidth = msg.style.width;
    var divHeight = msg.style.height;
    msg.style.position = "absolute";
    msg.style.top = "50%";
    msg.style.left = "50%";
    msg.style.margin = "-" + (divHeight / 2) + "px 0 0 -" + (divWidth / 2 + 150) + "px";
    msg.style.top = window.screen.height / 3 - 120;
    //调整样式等待进度条 始终处于窗口可见位置  shizy 20090915
    //msg.style.left = (document.body.clientWidth - 220) / 2;
    //msg.style.top = window.screen.height / 3 - 120;

    if (window.document.readyState != null && window.document.readyState != 'complete' && dataLoading) {
        msg.style.display = "block";
    }
    else {
        msg.style.display = "none";
        window.clearTimeout(timerId);
        dataLoading = false;
        return;
    }
    timerId = window.setTimeout('GetMsg()', 100);
}
document.write('<div id="divShowLoading" style="position:absolute; display:none; background:#ffffff; padding:10px; border:1px solid  #cccccc;">');
document.write('<img id="imgProgress" src="/manage/images/loadingBar.gif" style="border-width:0px;" /><br/>数据正在加载......</div>');
showProgress();