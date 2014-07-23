define(['gameUI', 'storageAPI', 'underscore'], function (gameUI, storageAPI, _) {
    var GuessGame,
        generatedNumber,
        inputNum,
        score;

    GuessGame = (function () {
        function GuessGame() { }

        GuessGame.prototype.init = function () {
            inputNum = gameUI.inputNum;
            generatedNumber =  makeGuessNumber();
            score = 100;
            gameUI.clearCurrent();
            storageAPI.loadLeaderBoard();
            this.eventHandlerSetup();
        };

        GuessGame.prototype.eventHandlerSetup = function () {
            var self = this;
            gameUI.checkBtn.addEventListener('click', checkInput);
            gameUI.newGameBtn.addEventListener('click', function () {
                self.init();
            });
        };

        var makeRandomDigit = function (isFirstDigit) {
            return String(Math.floor(Math.random() * 9 + (isFirstDigit ? 1: 0)));
        };

        var makeGuessNumber = function () {
            var digits = [],
                resultNumber = '',
                currentDigit,
                i;

            for (i = 0; i < 4; i += 1) {
                do {
                    currentDigit = (i === 0) ? makeRandomDigit(true) : makeRandomDigit();
                } while (_.contains(digits, currentDigit));

                digits[i] = currentDigit;
            }

            _.each(digits, function (digit) {
                resultNumber += digit;
            });

            return resultNumber;
        };

        var disableCheckBtn = function () {
            gameUI.checkBtn.removeEventListener('click', checkInput);
        };

        var checkInput = function () {
            var rams = 0,
                sheeps = 0;

            if (gameUI.isValidNum(inputNum.value)) {
                gameUI.setInfo('');

                rams = ramsCount(generatedNumber, inputNum.value);
                sheeps = sheepsCount(generatedNumber, inputNum.value);

                if (rams === 4) {
                    gameWon();
                } else {
                    gameUI.appendCurrent('entered: ' + inputNum.value + ', rams: ' + rams + ', sheeps: ' + sheeps);
                    score -= 2;
                }
            } else {
                gameUI.setInfo('invalid number, please enter again');
            }
        };

        var gameWon = function () {
            var username = gameUI.getUserName();

            storageAPI.saveUser(username, score);
            disableCheckBtn();
        };

        var ramsCount = function (generatedNumber, inputNumber) {
            var rams = 0;

            _.each(generatedNumber, function (digit, index) {
                if (digit === inputNumber[index]) {
                    rams += 1;
                }
            });

            return rams;
        };

        var sheepsCount = function (generatedNumber, inputNumber) {
            var sheeps = 0;

            _.each(generatedNumber, function (digit, index) {
                for (var i = 0; i < 4; i += 1) {
                    if (digit === inputNumber[i] && index !== i) {
                        sheeps += 1;
                        break;
                    }
                }
            });

            return sheeps;
        };

        return GuessGame;
    }());

    return GuessGame;

});