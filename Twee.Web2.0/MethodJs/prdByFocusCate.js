﻿function LoadByFocusCate() {
    //var byFocus =["Twee-Tech Products (Electronics & Gadgets)", "Aha! Products (Daily Problem Solvers)", "Novel-twee (Unique products to evoke smiles)", "Un-Breathable (Prices that take your breath away)"];
    //var byFocusHtml=""
    //for (var i=0; i<byFocus.length; i++) {
    //     byFocusHtml = byFocusHtml +
    //       '<label><input type="checkbox" name="optByFocus[]" value="' + i.toString() + '" />' + byFocus[i] + '</label>' + '\n';
    //    $("div.multiselect").html(byFocusHtml);
    //}
    $("#ulByFocus").html();


    $.ajax({
        type: "Post",
        url: "/AjaxPages/prdReviewAjax.aspx",
        data: "{'action':'getFocusCate'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            var obj = eval("(" + resu + ")");
            var byFocusHtml = "";
            for (var i = 0; i < obj.length; i++) {
                var focusCate = obj[i];
                var focusCateID = focusCate.focusCateID;
                var focusCateName = focusCate.name;
                var focusCateNote = focusCate.note;
                //byFocusHtml = byFocusHtml +
                //     '<label>&nbsp;<input type="checkbox" name="optByFocus" onclick="serch();" value="' + focusCateID.toString() + '" />&nbsp;' + focusCateName + " " + focusCateNote + '</label>' + '\n';

                byFocusHtml = byFocusHtml +
                              '<li>' +
                              '   <label class="checkbox">' +
                              '   <input type="checkbox" name="option[]" value="' + focusCateID.toString() + '" onclick="DoSearch()" /><i>' +
                              '      </i>' + focusCateName + " " + focusCateNote + '<small><a href="#"></a></small>' +
                              '   </label>' +
                              '</li>';
            }
            $("#ulByFocus").html(byFocusHtml);
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });

}