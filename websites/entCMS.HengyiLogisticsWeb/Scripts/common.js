/// <reference path="jquery-1.4.1-vsdoc.js" />
// JavaScript Document
$(document).ready(function () {
    $(".one").hover(function () { //Hover over event on list item
        $(".menudd", this).show(); //Show the subnav
        $("dt a", this).addClass("hover");

    }, function () { //on hover out...
        $("dd", this).hide(); //Hide the subnav
        $("dt a", this).removeClass("hover");
    });
    $(function () {
        var left = 10;
        var width = $('#mainmenu').width();
        var ddnum = $("#nav .one").length;
        for (var i = 1; i <= ddnum; i++) {
            var pos = $("#nav .one:nth-child(" + i + ")").position();
            var ulnum = $("#nav .one:nth-child(" + i + ") ul").length;
            if (ulnum > 5) {
                ulnum = 5;
                left = (width - 135 * ulnum) / 2;
                if (left > pos.left) left = (pos.left - 10);
            } else {
                left = 10;
            }
            $("#nav .one:nth-child(" + i + ") dd").css("left", -1 * left);
            $("#nav .one:nth-child(" + i + ") dd").css("width", 135 * ulnum);
        };
    });
}); 

//sidebar menu
function highlight(parm1, parm2, parm3, parm4) {
    $(".panel").hide();
    $("a.flip").removeClass("on");
    $("#panel_" + parm1).show();
    $("#flip_" + parm1).toggleClass("on");
    $("#flip_" + parm4).addClass("active");
    $(".panel_" + parm2).addClass("active");
    $("#panel_" + parm1).css({ "background": "#8bbfe0" });
    $(".panelsub_" + parm3).addClass("active");
    $(".mappoint").hide();
    $(".mappoint_" + parm1).show();
};
function panelsub(parm1, parm2) {
    $(".panelsubmenu").hide();
    $("#panelsubmenu_" + parm1 + parm2).show();
};
//End sidebar menu