// 淇冮攢 鍔ㄧ敾
(function ($) {
    $.fn.apic = function (options) {
        var defaults = {
            pic: "li",//鍥剧墖鎵€鍦ㄧ殑
            dian: ".dian",//
            leftBtn: ".leftBtn",
            rightBtn: ".rightBtn",
            showtime: 5000,//鏃堕棿闂撮殧
            speedtime: 500,//鍔ㄧ敾鏃堕棿
            addclass: "active"
        }
        var options = $.extend(defaults, options);

        this.each(function () {
            var THIS = this
            var obj1 = $(this).find(options.pic)
            var obj2 = $(this).find(options.dian)
            var leftBtn = $(this).find(options.leftBtn)
            var rightBtn = $(this).find(options.rightBtn)
            var speed = options.speedtime;
            var active = options.addclass;
            var isnow = 0

            THIS.timer = setInterval(func, options.showtime)
            //娣诲姞鐐�
            $(options.dian).html("")
            for (var i = 0; i < obj1.length; i++) {
                obj2.append('<span>' + (i + 1) + '</span>')
            };
            function func() {
                isnow++
                if (isnow >= obj1.length) {
                    isnow = 0
                };
                objMove(isnow)
            }
            function objMove(isNow) {
                obj1.eq(isNow).stop().animate({ opacity: "1", "z-index": "5" }, speed).siblings(options.pic).animate({ opacity: "0", "z-index": "1" }, speed)
                obj2.find('span').eq(isNow).addClass(active).siblings('span').removeClass(active)

            }
            objMove(0)
            obj2.find('span').css('cursor', 'pointer');
            obj2.find('span').mouseenter(function (event) {
                isnow = $(this).index()
                clearInterval(THIS.timer)
                objMove(isnow)
            }).mouseleave(function (event) {
                clearInterval(THIS.timer)
                THIS.timer = setInterval(func, options.showtime)
            });

            rightBtn.click(function () {
                clearInterval(THIS.timer)
                func();
                console.log(isnow)
                THIS.timer = setInterval(func, options.showtime)
            });
            leftBtn.click(function () {
                clearInterval(THIS.timer)
                isnow--
                if (isnow < 0) {
                    isnow = obj1.length - 1
                };
                objMove(isnow)
                console.log(isnow)
                THIS.timer = setInterval(func, options.showtime)
            })
            obj1.parent().mouseenter(function (event) {
                clearInterval(THIS.timer)
            }).mouseleave(function (event) {
                THIS.timer = setInterval(func, options.showtime)
            });




        });
    }
})(jQuery)
