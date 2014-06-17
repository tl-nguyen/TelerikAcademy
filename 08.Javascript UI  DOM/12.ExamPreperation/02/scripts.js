$.fn.tabs = function () {
    var $this = $(this);
    var tabItems = $this.children();

    $this.addClass('tabs-container');

    hideTabs();
    clickHandler();

    function hideTabs () {
        var content;

        for (var i = 0, len = tabItems.length; i < len; i += 1) {
            content = $(tabItems[i]).children()[1];

            if ($(tabItems[i]).attr('class').indexOf('current') < 0) {
                $(content).hide();
            } else {
                $(content).show();
            }
        }
    }

    function clickHandler () {
        for (var i = 0, len = tabItems.length; i < len; i += 1) {
            $(tabItems[i]).on('click', function () {
                // remove all the current classes
                $this.children('.current').removeClass('current');

                $(this).addClass('current');

                hideTabs();
            });
        }
    }

};