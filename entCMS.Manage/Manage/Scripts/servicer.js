function onlineposition(onlineid, lng) {    
    $('#onlineleft' + lng).hide();
    $('#onlineright' + lng).hide();
    if (onlineid == 1 || onlineid==2) {
        $('#onlineleft' + lng).show();
    } else if (onlineid == 3 || onlineid==4) {
        $('#onlineright' + lng).show();
    }
}
function closediv(dom) {
    $('#cmsboard').remove();
    $('#' + dom).hide();
}
function cmsboard() {
    $('#cmsboard').remove();
    $('body').append('<div id="cmsboard"></div>');
    $('#cmsboard').height($(window).height());
    $('#cmsboard').css({
        'opacity': 0.1,
        'position': 'absolute',
        'left': '0px',
        'top': '0px',
        'z-index': 99,
        'width': '100%',
        'background': '#000'
    });
}
function divshow(dom) {
    var dom = $('#' + dom);
    cmsboard();
    var pinx = (820 - 600) / 2;
    var piny = ($(window).height() - dom.height()) / 3;
    if (piny < 0) piny = 0;
    if (pinx < 0) pinx = 0;
    dom.css('left', pinx + 'px');
    dom.css('top', piny + 'px');
    dom.show();
}
function okonlineicon(type) {
    var hz = type == 'msn' || type == 'skype' ? '.gif' : '.jpg';
    $('#met' + type + 'img').attr('src', '../images/' + type + '/' + type + '_' + $("input[name='met_" + type + "_type']:checked").val() + hz);
    type = 'online_box_' + type;
    closediv(type);
}