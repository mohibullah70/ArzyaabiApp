// Apply global config
Highcharts.setOptions({
    chart: {
        events: {
            load: function () {
                this.credits.element.onclick = function (e) {
                    //window.open('http://www.example.com', '_blank');
                    e.preventDefault();
                }
            }
        },
        borderWidth: 1,
        borderColor:"#f68b1f",
    },
    credits: {
        text: 'EZKAR, Ministry of Economy'
    },
});