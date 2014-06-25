$(document).ready(function () {

    $.fn.dropdown = function () {
        var $this = $(this),
            data = extractData(),
            newContainer = $("<div>"),
            newListOptions = $("<ul>"),
            newOption = $("<li>");

        $this.css("display", "none");

        newContainer.addClass("dropdown-list-container");
        newListOptions.addClass("dropdown-list-options");
        newContainer.append(newListOptions);

        for (var i = 0, len = data.length; i < len; i += 1) {
            newOption.addClass("dropdown-list-option");
            newOption.attr("data-value", data[i].value);
            newOption.text(data[i].text);

            if (data[i].selected) {
                newOption.addClass("selected-item");
            }

            newListOptions.append(newOption.clone());
        }

        attachClicks();

        newContainer.insertAfter($this);

        // help functions

        function attachClicks () {
            var allLists = newListOptions.children();

            for (var i = 0, len = allLists.length; i < len; i += 1) {

                $(allLists[i]).on('click', function () {
                    var $self = $(this);

                    $(".dropdown-list-options")
                        .children('.selected-item')
                        .removeClass('selected-item');

                    $this.children(':selected')
                        .removeAttr('selected');

                    $self.addClass('selected-item');

                    $this.children('option[value="' + $self.attr("data-value") + '"]')
                        .attr('selected', 'selected');
                });
            }
        }

        function extractData () {
            var options = $this.children(),
                data = [];

            for (var i = 0, len = options.length; i < len; i += 1) {
                data.push({
                    text: $(options[i]).text(),
                    value: $(options[i]).val(),
                    selected: $(options[i]).attr("selected")
                });
            }

            return data;
        }

        return $this;
    };
});