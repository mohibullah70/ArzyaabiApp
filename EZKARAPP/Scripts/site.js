function createTemplate(defaultTemplate) {
    var time = Date.now();
    var template = $(defaultTemplate.replace(/_0/gm, "_" + time).replace(/\[0\]/gm, '[' + time + ']').replace(/\{0\}/gm, time));
    template.find("input[type='hidden'].index").val(time);
    template.find(".datepicker").datepicker({
        autoclose: true,
        clearBtn: true,
        todayBtn: "linked",
        todayHighlight: true,

    });
    template.find(".select").select2();
    template.find(".bootstrap4-toggle").bootstrapToggle();
    return template;
};

function initSelect(element) {
    //if (element != "") {
    //    $(".select").not("[multiple]").select2({
    //        allowClear: true,
    //        placeholder: 'select an option',
    //        dropdownParent:$(element)
    //    }).trigger('change');
    //    $(".select[multiple]").select2({
    //        allowClear: false,
    //        placeholder: 'select an option',
    //        dropdownParent: $(element)
    //    });
    //} else {
        $(".select").not("[multiple]").select2({
            allowClear: true,
            placeholder: 'select an option'
        }).trigger('change');
        $(".select[multiple]").select2({
            allowClear: false,
            placeholder: 'select an option'
        });
    //}
    
};

$(function () {
    $('[data-toggle="popover"]').popover()
})
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
}); 


$(document).ready(function () {

    //$(".modal").on('shown.bs.modal', function () {
    //    initSelect($(this));
    //});

    //select2 hack for modal, search input was not working
    $.fn.modal.Constructor.prototype._enforceFocus = function () { };

    $.fn.select2.defaults.set('placeholder', 'select an option');
    $.fn.select2.defaults.set('allowClear', true);
    //$.fn.select2.defaults.set("theme", "bootstrap4");
    $(".select").not("[multiple]").select2({
        allowClear: true,
        placeholder: 'select an option'
    }).trigger('change');
    $(".select[multiple]").select2({
        allowClear: false,
        placeholder: 'select an option'
    });
    //$('.select').on("select2:select", function (e) {
    //    $("form").validate().element($(this));
    //});
    //$(".select").on("select2:close", function (e) {
    //    $(this).valid();
    //});

   // $.fn.datepicker.defaults.format = "dd-mm-yyyy";
    $(".datepicker").datepicker({
        autoclose: true,
        clearBtn: true,
        todayBtn: "linked",
        todayHighlight: true,

    });


    //jquery validator customization
    if ($.validator) {
        (function ($) {
            var defaultOptions = {
                validClass: 'is-valid',
                errorClass: 'is-invalid',
                highlight: function (element, errorClass, validClass) {
                    //$(element).closest(".form-group")
                    $(element)
                        .removeClass(validClass)
                        .addClass(errorClass);
                },
                unhighlight: function (element, errorClass, validClass) {
                    //$(element).closest(".form-group")
                    $(element)
                        .removeClass(errorClass)
                        .addClass(validClass);
                }
            };
            if (typeof $.validator === 'undefined') {
                console.log('validator is undefined');
            } else {
                $.validator.setDefaults(defaultOptions);

                $.validator.unobtrusive.options = {
                    errorClass: defaultOptions.errorClass,
                    validClass: defaultOptions.validClass,
                };
            }
        })(jQuery);
    }
    //(function ($) {
    //    if ($.validator && $.validator.unobtrusive) {
    //        var defaultOptions = {
    //            validClass: 'is-valid',
    //            errorClass: 'is-invalid',
    //            highlight: function (element, errorClass, validClass) {
    //                $(element)
    //                    .removeClass(validClass)
    //                    .addClass(errorClass);
    //            },
    //            unhighlight: function (element, errorClass, validClass) {
    //                $(element)
    //                    .removeClass(errorClass)
    //                    .addClass(validClass);
    //            }
    //        };

    //        $.validator.setDefaults(defaultOptions);

    //        $.validator.unobtrusive.options = {
    //            errorClass: defaultOptions.errorClass,
    //            validClass: defaultOptions.validClass,
    //            errorElement: 'div',
    //            errorPlacement: function (error, element) {
    //                error.addClass('invalid-feedback');

    //                if (element.next().is(".input-group-append")) {
    //                    error.insertAfter(element.next());
    //                } else {
    //                    error.insertAfter(element);
    //                }
    //            }
    //        };
    //    }
    //    else {
    //        console.warn('$.validator is not defined. Please load this library **after** loading jquery.validate.js and jquery.validate.unobtrusive.js');
    //    }
    //})(jQuery);

});