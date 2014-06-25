$.fn.gridView = function (data) {
    var $this = $(this);
    var container = $("<table>");
    var row = $("<tr>");
    var headerCol = $("<th>");
    var normalCol = $("<td>");
    var addRowBtn = $("<button>");
    var addColBtn = $("<button>");
    var headerColVal = $("<input>");


    //style
    container.css("border", "1px solid black");
    row.css("border", "1px solid black");
    headerCol.css("border", "1px solid black");
    headerCol.css("width", "100px");
    normalCol.css("border", "1px solid black");
    normalCol.css("height", "20px");

    makeHeader();

    //buttons
    addRowBtn.text("Add Row");
    addRowBtn.on('click', makeDataRow);


    headerCol.attr("type", "text");
    addColBtn.text("Add Col");
    addColBtn.on('click', makeCol);

    function makeCol() {
        var allRows = container.find('tr');

        headerCol.text(headerColVal.val());

        $(allRows[0]).append(headerCol.clone());

        for (var i = 1, len = allRows.length; i < len; i += 1) {
            $(allRows[i]).append(normalCol.clone());
        }
    }

    function makeDataRow() {
        row.empty();

        var headerCount = $(container.find('th'));

        for (var i = 0, len = headerCount.length; i < len; i += 1) {
            row.append(normalCol.clone());
        }
        container.append(row.clone());
    }

    function makeHeader() {
        row.empty();

        for (var i = 0, len = data.length; i < len; i += 1) {
            headerCol.text(data[i]);
            row.append(headerCol.clone());
        }

        container.append(row.clone());
    }

    $this.append(container);
    $this.append(addRowBtn);
    $this.append(headerColVal);
    $this.append(addColBtn);
};