$(document).ready(function () { getMy(); })
function getMy() {   
    //读取菜单
    $.ajax({ type: "POST", dateType: "html", url: "../Manage/getmeaun.aspx?id=" + Math.random().toString(), data: { wnType: 2 }, success: function (msg) {
       
        $("#dvM").html(msg);
        $("#dvM").accordion();
        $(function () {
            tabCloseEven();
            $('.cs-navi-tab').click(function () {
                var $this = $(this);
                var href = $this.attr('src');
                // var title = $this.text();
                var title = $this.attr("title");
                // alert(title);
                addTab(title, href);
            });
        });
    }
    });

}
function loginOut() {
    if (confirm('确定退出吗？')) { document.location.href = 'adminLogin.htm' }
}



