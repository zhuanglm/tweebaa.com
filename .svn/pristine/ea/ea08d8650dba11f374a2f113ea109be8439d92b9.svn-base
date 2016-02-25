var FormSliders = function () {

    return {

        //Form Sliders
        initFormSliders: function () {
            // Regular slider
            $('#slider1').slider({
                min: 0,
                max: 500,
                slide: function (event, ui) {
                    $('#slider1-value').text(ui.value);
                }
            });

            // Range slider
            $('#slider2').slider({
                min: 0,
                max: 500,
                range: true,
                values: [75, 300],
                slide: function (event, ui) {
                    $('#slider2-value1').text(ui.values[0]);
                    $('#slider2-value2').text(ui.values[1]);
                }
            });

            // Step slider
            $('#slider3').slider({
                min: 0,
                max: 500,
                step: 1,
                values: 250,
                slide: function (event, ui) {
                    $('#slider3-value').text(ui.value);
                }
            });

            // Rounded Regular slider
            $('#slider1-rounded').slider({
                min: 0,
                max: 500,
                step: 10,
                value:250,
                slide: function (event, ui) {
                    //$('#slider1-value-rounded').text(ui.value);
                    //console.log("aaaaa=" + ui.value);
                    //Í¼Æ¬·Å´ó/ËõĞ¡
                    var prevVal = $("#amount").val();
                    var newVal = ui.value;
                    if (prevVal > newVal) {
                        zoomOut();
                    } else {
                        zoomIn();
                    }

                    $("#amount").val(ui.value);
                }
            });

            // Rounded Range slider
            $('#slider2-rounded').slider({
                min: 0,
                max: 500,
                range: true,
                values: [75, 300],
                slide: function (event, ui) {
                    $('#slider2-value1-rounded').text(ui.values[0]);
                    $('#slider2-value2-rounded').text(ui.values[1]);
                }
            });

            // Rounded Step slider
            $('#slider3-rounded').slider({
                min: 0,
                max: 500,
                step: 100,
                slide: function (event, ui) {
                    $('#slider3-value-rounded').text(ui.value);
                }
            });
        }

    };

} ();