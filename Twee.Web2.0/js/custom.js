/* Write here your custom javascript codes */
$(document).ready(function () {
  // Customs tree menu script
 
    $(".dropdown-tree-a").click(function () { //use a class, since your ID gets mangled
        $(this).parent('.dropdown-tree').toggleClass("open-tree active"); //add the class to the clicked element
    });
}); // end Ready