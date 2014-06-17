function Solve(params) {
    var countOfNum,
        answer = 1;
    params = params.map(Number);
    countOfNum = params.shift();

    for (var i = 0; i < countOfNum - 1; i += 1) {
        if (params[i] > params[i+1]) {
            answer += 1;
        }
    }

    return answer;
}


var test1 = [
    '9',
    '1',
    '8',
    '8',
    '7',
    '6',
    '5',
    '7',
    '7',
    '6'
];

Solve(test1);