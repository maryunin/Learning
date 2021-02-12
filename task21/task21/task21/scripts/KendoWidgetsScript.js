﻿function createGrid() {
    var dataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "http://task21/gridData.json",
                dataType: "json"
            }
        },
        schema: {
            data: "items"
        },
        pageSize: 10
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
                    url: "http://task21/chartData.json",
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
                field: "Items",
                categoryField: "Category",
                name: "Items"
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
$(document).ready(createGrid);
$(document).ready(createChart);
$(document).bind("kendo:skinChange", createChart);