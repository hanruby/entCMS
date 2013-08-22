//固定方式
(function ($) {
    jQuery.fn.PositionFixed = function (options) {
        var defaults = {
            css: '',
            x: 0,
            y: 0
        };
        var o = jQuery.extend(defaults, options);
        var isIe6 = false;
        if (browser.msie && parseInt(browser.version) == 6) isIe6 = true;
        var html = $('html');
        if (isIe6 && html.css('backgroundAttachment') !== 'fixed') {
            html.css('backgroundAttachment', 'fixed')
        };
        return this.each(function () {
            var domThis = $(this)[0];
            var objThis = $(this);
            if (isIe6) {
                var left = parseInt(o.x) - html.scrollLeft(),
				top = parseInt(o.y) - html.scrollTop();
                objThis.css('position', 'absolute');
                domThis.style.setExpression('left', 'eval((document.documentElement).scrollLeft + ' + o.x + ') + "px"');
                domThis.style.setExpression('top', 'eval((document.documentElement).scrollTop + ' + o.y + ') + "px"');
            } else {
                objThis.css('position', 'fixed').css('top', o.y).css('left', o.x);
            }
        });
    };
})(jQuery)

Array.prototype.del = function (n) {//n表示第几项，从0开始算起。
    //prototype为对象原型，注意这里为对象增加自定义方法的方法。
    if (n < 0)//如果n<0，则不进行任何操作。
        return this;
    else
        return this.slice(0, n).concat(this.slice(n + 1, this.length));
    /*
　　　concat方法：返回一个新数组，这个新数组是由两个或更多数组组合而成的。
　　　　　　　　　这里就是返回this.slice(0,n)/this.slice(n+1,this.length)
　　 　　　　　　组成的新数组，这中间，刚好少了第n项。
　　　slice方法： 返回一个数组的一段，两个参数，分别指定开始和结束的位置。
　　*/
}

//滚动方式
var Floaters = {
    delta: 0.08,
    queue: null,
    collection: {},
    items: [],
    addItem: function (Obj, left, top, ani) {
        Obj.style['top'] = top + 'px';
        Obj.style['left'] = left + 'px';
        var newItem = { object: Obj, oLeft: left, oTop: top };
        this.items[this.items.length] = newItem;
        this.delta = ani ? ani : this.delta;
    },
    removeItem: function (idx) {
        this.items.del(idx);
    },
    removeLastItem: function () {
        this.items.del(this.items.length - 1);
    },
    sPlay: function () {
        this.collection = this.items; this.queue = setInterval('play()', 10);
    },
    sStop: function () {
        clearInterval(this.queue);
    }
}
function checkStandard() {
    var scrollY;
    if (document.documentElement && document.documentElement.scrollTop) {
        scrollY = document.documentElement.scrollTop;
    } else if (document.body) {
        scrollY = document.body.scrollTop;
    }
    return scrollY;
}
function play() {
    var diffY = checkStandard();
    for (var i in Floaters.collection) {
        if (isNaN(i)) continue; // 排除del方法
        var obj = Floaters.collection[i].object;
        var obj_x = Floaters.collection[i].oLeft;
        var obj_y = Floaters.collection[i].oTop;
        var total = diffY + obj_y;
        if (obj.offsetTop != total) {
            var oy = (total - obj.offsetTop) * Floaters.delta;
            oy = (oy > 0 ? 1 : -1) * Math.ceil(Math.abs(oy));
            obj.style['top'] = obj.offsetTop + oy + 'px';
        } else {
            clearInterval(Floaters.queue);
            Floaters.queue = setInterval('play()', 10);
        }
    }
}
function textWrap(my) {
    var text = '', txt = my.text();
    txt = txt.split("");
    for (var i = 0; i < txt.length; i++) {
        text += txt[i] + '<br/>';
    }
    my.html(text);
}
//在线交流部分
function onlineclose() {
    $('#onlinebox').hide();
    return false;
}
function olne_domx(type, onlinex) {
    var w = $('#onlinebox').width();
    var maxr = document.body.offsetWidth - w;
    if (type >= 3) {
        w = 130;
        onlinex = document.body.scrollWidth - w - onlinex;
    }
    if (onlinex < 0) onlinex = 0;
    if (onlinex > maxr) {
        onlinex = maxr;
        if (browser.msie && parseInt(browser.version) == 6) onlinex = maxr - 18;
    }
    return onlinex;
}
function olne_dd_wd(d) {
    var w = 0;
    d.each(function () {
        w = w > $(this).outerWidth(true) ? w : $(this).outerWidth(true);
    });
    return w;
}
function olne_mouse_on(t, my, nex, type) {
    if (t == 1) {
        my.hide();
        nex.show();
        var dmk = $('div.onlinebox-conbox .online-tbox').size() ? $('div.onlinebox-conbox .online-tbox').outerWidth(true) : 0;
        var dt = olne_dd_wd($('div.onlinebox-conbox dd'));
        dt = dt > dmk ? dt : $('div.onlinebox-conbox .online-tbox').outerWidth(true);
        if (dt <= 0) dt = 100;
        var wd = type < 3 ? 0 : my.width() - dt + 4;
        nex.css({
            'position': 'absolute',
            'left': wd + 'px',
            'width': dt + 'px'
        });
    } else {
        nex.css({
            'position': 'absolute',
            'left': '0px'
        });
        nex.hide();
        my.show();
    }
}
function olne_mouse(dom, type) {
    var nex = dom.next('div.onlinebox-conbox');
    if ($('.onlinebox_2').size() > 0) {
        dom.click(function () { olne_mouse_on(1, $(this), nex, type); });
    } else {
        dom.hover(function () { olne_mouse_on(1, $(this), nex, type); }, function () { });
    }
    $('#onlinebox .onlinebox-top').click(function () { if (!nex.is(':hidden')) olne_mouse_on(0, dom, nex, type); });
    textWrap($(".onlinebox-showbox span"));
}
function olne_app(msg, type, x, y) {
    $('body').remove('#onlinebox');
    // jquery代码链实现延时执行代码的较优雅办法
    // http://www.cnblogs.com/think/archive/2012/10/08/jquery_queue_for_delay_code.html
    // http://mrthink.net/jqueryapi-queue-dequeue/
    // 使用延时执行主要解决 $('#onlinebox').width()不能正确获取的问题
    $('body').append(msg);
    $('#onlinebox').delay(100).queue(function () {
        var mx = Number(olne_domx(type, x));
        var my = Number(y);
        if (type == 2 || type == 4) {//1固左2滚左3固右4滚右0关闭
            var floatDivr = document.getElementById('onlinebox');
            Floaters.addItem(floatDivr, mx, my);
            Floaters.sPlay();
        } else {
            $('#onlinebox').PositionFixed({ x: mx, y: my });
        }
        $('#onlinebox').show();
        if ($('div.onlinebox-showbox').size() > 0) {
            olne_mouse($('div.onlinebox-showbox'), type);
        }
    }).dequeue();
    $(window).resize(function () {
        $('#onlinebox').hide();
        var mx = Number(olne_domx(type, x));
        var my = Number(y);
        if (type == 2 || type == 4) {//1固左2滚左3固右4滚右0关闭
            var floatDivr = document.getElementById('onlinebox');
            Floaters.sStop();
            Floaters.removeLastItem();
            Floaters.addItem(floatDivr, mx, my);
            Floaters.sPlay();
        } else {
            $('#onlinebox').PositionFixed({ x: mx, y: my });
        }
        $('#onlinebox').show();
    });
}
function olne_para(y) {
    var d = $('#online_param').attr('href');
    d = d.split('?');
    d = d[1]; 
    d = d.split('&');
    var t = d[y]; t = t.split('='); t = t[1];
    return t;
}
function metonline() {
    var t = parseInt(olne_para(0)); u = olne_para(1); x = olne_para(2); y = olne_para(3); lang = olne_para(4);
    if (t != 0) {
        $('head').append($('<link rel="stylesheet" type="text/css" id="onlinecss" />'));
        $('#onlinecss').attr('href', u + 'Manage/Css/online.css');
        if (u.indexOf('http://') != -1) {
            $.getJSON(u + 'Manage/System/Ajax.ashx?Action=ServicerCode&navurl=' + u + '&lang=' + lang + '&jsoncallback=?', function (json) {
                if (json.metcms != '') {
                    olne_app(json.metcms, t, x, y);
                }
            });
        } else {
            $.ajax({
                type: "POST",
                url: u + "Manage/System/Ajax.ashx?Action=ServicerCode&navurl=" + u + "&lang=" + lang,
                success: function (json) {
                    if (json) {
                        olne_app(json, t, x, y);
                    }
                }
            });
        }
    }
}
metonline();