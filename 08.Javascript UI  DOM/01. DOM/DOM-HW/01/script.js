(function() {

    var innerDivsQS = getInnerDivsByQS(),
        innerDivsGEBTN = getInnerDivsByGEBTN();

    console.log('querySelectorAll:');
    displayResult(innerDivsQS);
    console.log('====================');
    console.log('getElementsByTagName:');
    displayResult(innerDivsGEBTN);

    function getInnerDivsByQS() {
        var innerDivs = document.querySelectorAll('div > div');

        return innerDivs;
    }

    function getInnerDivsByGEBTN() {
        var divs = document.getElementsByTagName('div'),
            innerDivs = [];

        for (var i = 0, len = divs.length; i < len; i += 1) {
            innerDivs.push(divs[i].getElementsByTagName('div'));
        }

        return innerDivs;
    }

    function displayResult(innerDivs) {
        for (var i = 0, len = innerDivs.length; i < len; i += 1) {
            console.log(innerDivs[i]);
        }
    }
}());