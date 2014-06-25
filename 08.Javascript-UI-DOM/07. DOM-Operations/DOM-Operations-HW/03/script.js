(function () {

    var textArea = document.createElement('textarea'),
        input1 = document.createElement('input'),
        input2 = document.createElement('input');

    textArea.style.rows = 5;
    textArea.style.cols = 100;

    input1.setAttribute('type', 'text');
    input2.setAttribute('type', 'text');

    input1.addEventListener('change', function () {
        textArea.style.color = this.value;
    });

    input2.addEventListener('change', function () {
        textArea.style.backgroundColor = this.value;
    });

    document.body.appendChild(textArea);
    document.body.appendChild(input1);
    document.body.appendChild(input2);
}());