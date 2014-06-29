var DOMQuery = (function () {
    var buffer = [];

    function appendChild(element, parentSelector) {
        var parent = document.querySelector(parentSelector);

        if (parent) {
            parent.appendChild(element);
        }
    }

    function removeChild(parentSelector, childSelector) {
        var parent = document.querySelector(parentSelector),
            child;

        if (parent) {
            child = parent.querySelector(childSelector);

            if (child) {
                parent.removeChild(child);
            }
        }
    }

    function addHandler(elementsSelector, eventType, callback) {
        var elements = document.querySelectorAll(elementsSelector);

        if (elements) {
            for (var i = 0, len = elements.length; i < len; i += 1) {
                elements[i].addEventListener(eventType, callback);
            }
        }
    }

    function appendToBuffer(containerSelector, element) {
        var container = document.querySelector(containerSelector),
            docFrag = document.createDocumentFragment();

        if (buffer[containerSelector]) {

            buffer[containerSelector].push(element);

            if (buffer[containerSelector].length === 100) {
                for (var i = 0, len = buffer[containerSelector].length; i < len; i += 1) {
                    docFrag.appendChild(buffer[containerSelector][i]);
                }

                container.appendChild(docFrag);
                buffer[containerSelector] = [];
            }
        } else {
            buffer[containerSelector] = [];
            buffer[containerSelector].push(element);
        }
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer
    }
}());