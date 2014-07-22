define(['underscore'], function (_) {
    var inputNum = document.getElementById('number'),
        checkBtn = document.getElementById('check'),
        info = document.getElementById('info'),
        current = document.getElementById('current'),
        top = document.getElementById('top'),
        newGameBtn = document.getElementById('newGame');

    var setInfo = function (text) {
        info.innerText = text;
    };

    var appendCurrent = function (text) {
        current.innerHTML += '<p>' + text + '</p>';
    };

    var clearCurrent = function () {
        current.innerHTML = '';
    };

    var isValidNum = function (num) {
        var validDigitsCount;

        validDigitsCount = _.chain(num)
                            .filter(function (digit, index) {
                                return isValidDigit(digit, index);
                            })
                            .value().length;

        return (validDigitsCount === 4);
    };

    var getUserName = function () {
        return prompt("Congratulation, You won :-D. Please enter your name", "Harry Potter");
    };

    var addToLeaderBoard = function (value, key) {
        top.innerHTML += '<p>' + key + ' : ' + value + '</p>';
    };

    function isValidDigit(digit, index) {
        if (index === 0) {
            return (digit >= 1 && digit <= 9);
        } else {
            return (digit >= 0 && digit <= 9);
        }
    }

    return {
        inputNum: inputNum,
        checkBtn: checkBtn,
        newGameBtn: newGameBtn,
        isValidNum: isValidNum,
        setInfo: setInfo,
        appendCurrent: appendCurrent,
        clearCurrent: clearCurrent,
        getUserName: getUserName,
        addToLeaderBoard: addToLeaderBoard
    };

});