var specialConsole = (function () {

    function writeLine() {
        console.log(formatRender(arguments));
    }

    function writeError() {
        console.error(formatRender(arguments));
    }

    function writeWarning() {
        console.warn(formatRender(arguments));
    }

    function formatRender(args) {
        var message = args[0],
            currentIndex, i, len;

        for (i = 1, len = args.length; i < len; i += 1) {
            currentIndex = message.indexOf('{' + (i - 1) + '}');

            if (currentIndex !== -1) {
                message = message.replace('{' + (i - 1) + '}', args[i]);
            }
        }

        return message;
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    }
}());