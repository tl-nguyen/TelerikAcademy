(function (doc) {
    var coolColor = doc.getElementById('cool-color');

    coolColor.addEventListener('change', function () {
        document.body.style.background = coolColor.value;
    }, false);

}(document));