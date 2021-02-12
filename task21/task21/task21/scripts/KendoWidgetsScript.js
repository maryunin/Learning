function createGrid() {
    let dataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "http://task21/large-file.json",
                dataType: "json"
            }
        },
        //schema: {
        //    data: "items"
        //},
        pageSize: 5
    });
    $("#grid").kendoGrid({
        dataSource: dataSource,
        editable: true,
        filterable: true,
        groupable: true,
        sortable: true,
        pageable: true,
        save: function (e) {
            $("#alert").kendoAlert({
                title: "Sorry",
                content: "changes can't be saved yet",
                messages: {
                    okText: "OK"
                }
            }).data("kendoAlert").open();
        }
    });
}

function createChart() {
    $("#chart").kendoChart({
        dataSource: {
            transport: {
                read: {
                    url: "http://task21/chartData3.json",
                    dataType: "json"
                }
            },
            schema: {
                data: "items"
            },
            sort: {
                field: "Category",
                dir: "asc"
            }
        },
        title: {
            text: "Items in categories"
        },
        legend: {
            position: "top"
        },
        seriesDefaults: {
            type: "column"
        },
        series:
            [{
                field: "Items1",
                categoryField: "Category",
                name: "Items1"
            },
            {
                field: "Items2",
                categoryField: "Category",
                name: "Items2"
            },
            {
                field: "Items3",
                categoryField: "Category",
                name: "Items3"
            }],
        categoryAxis: {
            labels: {
                rotation: 0
            },
            majorGridLines: {
                visible: false
            }
        },
        valueAxis: {
            labels: {
                format: "N0"
            },
            majorUnit: 1,
            line: {
                visible: false
            }
        },
        tooltip: {
            visible: true,
            format: "N0"
        }
    });
}

$(document).ready(function () {
    createGrid();
    createChart();
});
$(document).bind("kendo:skinChange", createChart);