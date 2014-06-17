function Solve(params) {
    var numbers = params.slice(1).map(Number);
    var maxSum = numbers[0];

    for (var i = 0; i < numbers.length; i += 1) {
        var currentSum = 0;
        for (var j = i; j < numbers.length; j += 1) {
            currentSum += numbers[j];
            if (currentSum > maxSum) {
                maxSum = currentSum;
            }
        }
    }

    return maxSum;
}

var test1 = [
    '9',
    '-9',
    '-8',
    '-8',
    '-7',
    '-6',
    '-5',
    '-1',
    '-7',
    '-6'
]

console.log(Solve(test1));