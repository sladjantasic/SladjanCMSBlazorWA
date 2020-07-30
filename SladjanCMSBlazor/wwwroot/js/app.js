
populateChart = () => {
    $(new Morris.Line({
        // ID of the element in which to draw the chart.
        element: 'linechart',
        // Chart data records -- each entry in this array corresponds to a point on
        // the chart.
        data: [
            { year: '2008', value1: 20, value2: 34 },
            { year: '2009', value1: 10, value2: 44 },
            { year: '2010', value1: 5, value2: 44 },
            { year: '2011', value1: 5, value2: 46 },
            { year: '2012', value1: 20, value2: 65 }
        ],
        // The name of the data record attribute that contains x-values.
        xkey: 'year',
        // A list of names of data record attributes that contain y-values.
        ykeys: ['value1', 'value2'],
        // Labels for the ykeys -- will be displayed when you hover over the
        // chart.
        labels: ['Value1', 'Value2'],
        lineColors: ['rgb(139, 27, 248)', 'rgb(241, 73, 27)']
    }));
}