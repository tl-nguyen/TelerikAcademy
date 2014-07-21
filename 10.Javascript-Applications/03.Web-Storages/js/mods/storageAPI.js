define(['gameUI', 'underscore'], function (gameUI, _) {
    var saveUser = function (name, score) {
        localStorage.setItem(name, score);
        gameUI.addToLeaderBoard(score, name);
    };

    var loadLeaderBoard = function () {
        _.each(localStorage, function(value, key) {
            if (value) {
                gameUI.addToLeaderBoard(value, key);
            }
        });
    };

    return {
        saveUser: saveUser,
        loadLeaderBoard: loadLeaderBoard
    }
});