(function (doc) {
    var coolText = doc.getElementById('cool-text'),
        coolResult = doc.getElementById('cool-result');

    coolText.addEventListener('keyup', function () {
        coolResult.innerText = coolText.value;
    }, false);

}(document));