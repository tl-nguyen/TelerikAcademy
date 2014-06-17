(function () {

    createDivs(10);

    function createDivs(numberOfDivs) {
        var fragment = document.createDocumentFragment(),
            divElement = document.createElement('div');

        for (var i = 0; i < numberOfDivs; i += 1) {
            divElement.style.width = generateRandomNumber(100, 20) + 'px';
            divElement.style.height = generateRandomNumber(100, 20) + 'px';
            divElement.style.backgroundColor = 'rgb(' +
                generateRandomNumber(255) + ', ' +
                generateRandomNumber(255) + ', ' +
                generateRandomNumber(255) + ')';
            divElement.style.color = 'rgb(' +
                generateRandomNumber(255) + ', ' +
                generateRandomNumber(255) + ', ' +
                generateRandomNumber(255) + ')';
            divElement.style.position = 'absolute';
            divElement.style.top = generateRandomNumber(window.innerHeight) + 'px';
            divElement.style.left = generateRandomNumber(window.innerWidth) + 'px';
            divElement.innerHTML = '<strong>DIV</strong>';
            divElement.style.borderRadius = generateRandomNumber(20) + 'px';
            divElement.style.borderColor = 'rgb(' +
                generateRandomNumber(255) + ', ' +
                generateRandomNumber(255) + ', ' +
                generateRandomNumber(255) + ')';
            divElement.style.borderWidth = generateRandomNumber(20, 1) + 'px';

            fragment.appendChild(divElement.cloneNode(true));
        }

        document.body.appendChild(fragment);
    }


    function generateRandomNumber(max, min) {
        min = min || 0;

        return (Math.random() * max | 0) + min + 1;
    }
}());