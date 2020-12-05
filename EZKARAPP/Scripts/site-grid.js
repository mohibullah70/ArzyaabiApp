$(document).ready(function () {
    [].forEach.call(document.getElementsByClassName('mvc-grid'), function (element) {
        new MvcGrid(element);
    });
    //$(".globalSearch").blur(function () {
    //    search($(this));
    //});
    $('.grid-global-search-term').change(function (e) {
        $(".grid-global-search-button").click();
    });
    $(".grid-global-search-value").keyup(function (e) {
        if (e.keyCode === 13) {
            $(".grid-global-search-button").click();
        }
    });
    $(".grid-global-search-button").click(function () {
       
        var termElement = $('.grid-global-search-term[data-name="' + $(this).attr('data-name') + '"]');
        var valueElement = $('.grid-global-search-value[data-name="' + $(this).attr('data-name') + '"]');
        search(termElement,valueElement);
    });




});
function search(termElement, valueElement) {
    var grid = new MvcGrid(document.querySelector('#' + termElement.attr('data-name')));
    grid.query.set('searchTerm', termElement.val());
    grid.query.set('searchValue', valueElement.val());
    grid.reload();
};
document.addEventListener('reloadend', function (e) {
    $(".grid-footer").addClass("d-none");
});
document.addEventListener('reloadfail', function (e) {
    $(".grid-footer").removeClass("d-none").html("Failed to load data, please referesh the page.");
});