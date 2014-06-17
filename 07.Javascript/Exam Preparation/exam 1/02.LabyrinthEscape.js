function Solve(params) {
    var rowCol = params[0].split(' ').map(Number),
        startPos = params[1].split(' ').map(Number),
        lab = params.slice(2),
        nums = initNums(),
        sumOfNums = 0,
        numsOfCells = 0,
        currentPos = {
            row: startPos[0],
            col: startPos[1]
        },
        direction = {
            'l': {
                row: 0,
                col: -1
            },
            'r': {
                row: 0,
                col: 1
            },
            'u': {
                row: -1,
                col: 0
            },
            'd': {
                row: 1,
                col: 0
            }
        },
        currentDir;

    while (true) {
        if (currentPos.row < 0 || currentPos.row >= rowCol[0] ||
                currentPos.col < 0 || currentPos.col >= rowCol[1]) {
            return 'out ' + sumOfNums;
        }

        if (nums[currentPos.row][currentPos.col] === 'X') {
            return 'lost ' + numsOfCells;
        }

        sumOfNums += nums[currentPos.row][currentPos.col];
        numsOfCells += 1;

        nums[currentPos.row][currentPos.col] = 'X';

        currentDir = lab[currentPos.row][currentPos.col];
        currentPos.row += direction[currentDir].row;
        currentPos.col += direction[currentDir].col;
    }


    function initNums () {
        var nums = [],
            counter = 1;

        for (var i = 0; i < rowCol[0]; i += 1) {
            nums[i] = [];
            for (var j = 0; j < rowCol[1]; j += 1) {
                nums[i][j] = counter;
                counter += 1;
            }
        }

        return nums;
    }
}

var test1 =[
    "3 4",
    "1 3",
    "lrrd",
    "dlll",
    "rddd"
];

var test2 =[
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "durlddud",
    "urrrldud",
    "ulllllll"
];

var test3 =[
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "lurlddud",
    "urrrldud",
    "ulllllll"
];

console.log(Solve(test1));