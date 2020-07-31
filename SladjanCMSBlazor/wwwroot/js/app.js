
populateChart = (sensorData) => {
    let dataset = []

    let jsonObj = JSON.parse(sensorData)

    jsonObj.forEach(item => {
        dataset.push({ aaxis: item.temperature, baxis: item.humidity, caxis: item.timestamp*1000 })
    })

    new Morris.Line({
        // ID of the element in which to draw the chart.
        element: 'linechart',
        // Chart data records -- each entry in this array corresponds to a point on
        // the chart.
        data: dataset,
        // The name of the data record attribute that contains x-values.
        xkey: 'caxis',
        // A list of names of data record attributes that contain y-values.
        ykeys: ['aaxis', 'baxis'],
        // Labels for the ykeys -- will be displayed when you hover over the
        // chart.
        labels: ['Temperature', 'Humidity'],
        lineColors: ['rgb(139, 27, 248)', 'rgb(241, 73, 27)']
    })

}
