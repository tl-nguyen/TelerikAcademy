$(document).ready(function () {

    $.fn.messageBox = function () {
        var $this = $(this),
            successMsg = $("<span>"),
            errorMsg = $("<span>");

        var success = function (msg) {
            clearBox();
            successMsg.text(msg);

            $this.css("opacity", 0);
            $this.html(successMsg);

            fadeInFadeOut();
        };

        var error = function (msg) {
            clearBox();
            errorMsg.text(msg);

            $this.css("opacity", 0);
            $this.html(errorMsg);

            fadeInFadeOut();
        };

        function clearBox () {
            $this.html('');
        }

        function fadeInFadeOut() {
            var currentOpacity = parseFloat($this.css("opacity"));

            if ( currentOpacity < 1) {
                currentOpacity += 0.01;

                $this.css("opacity", currentOpacity);

                setTimeout(fadeInFadeOut, 1);
            } else {
                setTimeout(function () {
                    $this.css("opacity", 0);
                }, 3000);
            }
        }

        return {
            success: success,
            error: error
        };
    };
});