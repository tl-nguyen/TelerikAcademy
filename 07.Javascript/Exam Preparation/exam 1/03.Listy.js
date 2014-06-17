function Solve(params) {
    var lines = fillLines();

    function fillLines() {
        var lines = [],
            i, len;

        for (i = 0, len = params.length; i < len; i += 1) {
            lines.push(commandLine(params[i]));
        }

        return lines;
    }

    function calculate() {
        var calculator = {
            sum: function (val) {
                var sum = 0;
                for (var i = 0; i < val.length; i += 1) {
                    sum += val[i];
                }

                return sum;
            },
            min: function (val) {
                return Math.min.apply(null, val);
            },
            max: function (val) {
                return Math.max.apply(null, val);
            },
            avg: function (val) {
                var sum = 0;

                for (var i = 0; i < val.length; i += 1) {
                    sum += val[i];
                }

                return Math.floor(sum / val.length);
            }
        };

        for (var i = 0, len = lines.length; i < len; i += 1) {
            lines[i] = calculateLine((lines[i]));
        }

        function calculateLine (line) {
            var newValue = [];
            for (var i = 0; i < line.value.length; i += 1) {
                if (!isFinite(line.value[i])) {
                    var temp = findValueByName(line.value[i]);
                    if (typeof temp === 'object') {
                        for (var j = 0; j < temp.length; j +=1) {
                            newValue.push(temp[j]);
                        }
                    } else {
                        newValue.push(temp);
                    }
                } else {
                    newValue.push(line.value[i]);
                }
            }

            line.value = newValue;

            if (line.operation === 'sum' || line.operation === 'min' ||
                    line.operation === 'max' || line.operation === 'avg') {
                line.value = calculator[line.operation](line.value);
            }

            return line;
        }

        function findValueByName (name) {
            var linename = '';
            for (var i = 0; i < lines.length - 1; i+=1) {
                linename = lines[i].name;
                if (name === lines[i].name) {

                    return lines[i].value;
                }
            }
        }

        var result = lines[lines.length - 1].value;

        if (typeof result === 'object') {
            return result.pop();
        }

        return result;
    }

    return calculate();

    function commandLine(line) {
        var name,
            operation,
            value,
            temp;

        line = line.trim();
        if (line.indexOf('def') === 0) {
            line = line.slice(3).trim();
        }

        temp = line.split('[');

        if (temp[0].indexOf(' ') > 0) {
            name = temp[0].slice(0, temp[0].indexOf(' ')).trim();
            operation = temp[0].slice(temp[0].indexOf(' '), temp[0].length).trim();
        }
        else {
            if (temp[0].trim() !== 'sum' && temp[0].trim() !== 'min' && temp[0].trim() !== 'max' && temp[0].trim() !== 'avg') {
                name = temp[0].trim();
            } else {
                operation = temp[0].trim();
            }
        }

        value = temp[1].trim().slice(0, -1).split(',').map(function (item) {
            if (isFinite(item)) {
                return parseInt(item);
            } else {
                return item.trim();
            }
        });

        return {
            name: name,
            operation: operation,
            value: value
        }
    }
}

var test1 = [
    'def     func      sum[5, 3, 7, 2, 6, 3]',
    'def func2 [5, 3, 7, 2, 6, 3]',
    'def func3 min[func2]',
    'def func4 max[5, 3, 7, 2, 6, 3]',
    'def func5 avg[5, 3, 7, 2, 6, 3]',
    'def func6 sum[func2, func3, func4 ]',
    'sum[func6, func4]'
],
    test2 = [
    'def func sum[1, 2, 3, -6]',
    'def newList [func, 10, 1]',
    'def newFunc sum[func, 100, newList]',
    '[newFunc]'
];

console.log(Solve(test1));