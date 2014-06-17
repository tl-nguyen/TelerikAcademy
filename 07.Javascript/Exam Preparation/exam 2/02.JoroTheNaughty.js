function Solve(params) {
    var rowColJump = toNum(params),
        startPos = toNum(params),
        currentPos = [startPos[0], startPos[1]],
        matrix = initMatrix(rowColJump[0], rowColJump[1]),
        countNums = 0,
        countJumps = 0,
        escaped = false,
        jumpIndex = 0,
        temp;

    function toNum(param) {
        return param.shift().split(' ').map(Number);
    }

    while (true) {
        if (currentPos[0] < 0 || currentPos[0] >= rowColJump[0]
                || currentPos[1] < 0 || currentPos[1] >= rowColJump[1]) {
            escaped = true;
            break;
        }

        if (matrix[currentPos[0]][currentPos[1]] === 'X') {
            escaped = false;
            break;
        }

        countNums += matrix[currentPos[0]][currentPos[1]];
        countJumps += 1;
        matrix[currentPos[0]][currentPos[1]] = 'X';

        temp = params[jumpIndex].split(' ').map(Number);
        currentPos[0] += temp[0];
        currentPos[1] += temp[1];

        jumpIndex += 1;

        if (jumpIndex >= rowColJump[2]) {
            jumpIndex = 0;
        }
    }

    function initMatrix (row, col) {
        var matrix = [],
            counter = 1;

        for (var i = 0; i < row; i += 1) {
            matrix[i] = [];
            for (var j = 0; j < col; j += 1) {
                matrix[i][j] = counter;
                counter +=1;
            }
        }

        return matrix;
    }

    return escaped ? 'escaped ' + countNums : 'caught ' + countJumps;
}


var test1 = [
    '6 7 3',
    '0 0',
    '2 2',
    '-2 2',
    '3 -1'
];

console.log(Solve(test1));