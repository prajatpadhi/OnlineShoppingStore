$(function () {
    var AsyncSearch = function () {
        var $form = $(this);
        var options = {
            url: $form.attr("action"),
            method: $form.attr("action"),
            data: $form.serialize
        };

        $.ajax(options).done(function (data) {
            var target = $($form.attr("data-prajat-target"));
            target.replaceWith(data);
        }
    };
    $(form["data-prajat-ajax=true"]).submit(AsyncSearch)

}    
 );