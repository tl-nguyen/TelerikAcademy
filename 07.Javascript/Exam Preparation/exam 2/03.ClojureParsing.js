function Solve(params) {
    var lines = [],
        command = {
            '+' : function (val) {
                if (val.length === 1) {
                    return val[0];
                }

                var sum = 0;

                for (var i = 0; i < val.length; i += 1) {
                    sum += val[i];
                }

                return sum;
            },
            '-' : function (val) {
                if (val.length === 1) {
                    return val[0];
                }

                var sub = val[0];

                for (var i = 1; i < val.length; i += 1) {
                    sub -= val[i];
                }

                return sub;
            },
            '*' : function (val) {
                if (val.length === 1) {
                    return val[0];
                }

                var sub = val[0];

                for (var i = 1; i < val.length; i += 1) {
                    sub *= val[i];
                }

                return sub;
            },
            '/' : function (val) {
                if (val.length === 1) {
                    return val[0];
                }

                var sub = val[0];

                for (var i = 1; i < val.length; i += 1) {
                    if (val[i] === 0) return 'err';
                    sub /= val[i];
                }

                return sub;
            }
        };

    fillLines();
    calculate();

    console.log(lines);

    function calculate() {
        for (var i = 0; i < lines.length; i += 0) {
            lines[i] = calculateLine(lines[i]);
        }

        function calculateLine(line) {
            var newValue = [];

            for (var i =0; i < line.value.length; i += 1) {
                if (!isFinite(line.value[i])) {
                    var temp = findValueByName(line.value[i]);
                    for (var j = 0; j < temp.length; j += 1) {
                        newValue.push(temp[j]);
                    }
                }
                else {
                    newValue.push(line.value[i]);
                }
            }
            if (line.operation) {
                line.value = command[line.operation](newValue);
            } else {
                line.value = newValue;
            }

        }

        function findValueByName(name) {
            for (var i = 0; i < lines.length; i += 1) {
                if (lines[i].name === name) {
                    return lines[i].value;
                }
            }
        }
    }

    function fillLines() {
        for (var i = 0; i < params.length; i += 1) {
            lines.push(convertLine(params[i], i + 1));
        }
    }

    function convertLine(line, lineNum) {
        var name,
            operation,
            value,
            temp;

        line = line.trim().slice(1, -1).trim(); // get lost of outter ()

        if (line.indexOf('def') === 0) {
            line = line.slice(line.indexOf('def') + 3).trim();
        }

        if (line.indexOf('(') >= 0) {
            temp = line.split('(');
            name = temp[0].trim();
            operation = temp[1].trim().slice(0,1).trim();
            temp = temp[1].trim().slice(1, -1).trim().split(' ');
            value = [];
            for (var i = 0; i < temp.length; i += 1) {
                if (temp[i] === '') {
                    continue;
                }
                value.push(temp[i]);
            }

            value = value.map(function (item) {
                if (isFinite(item)) {
                    return parseInt(item);
                }
                return item.trim();
            })

        } else {
            if (line[0] === '+' || line[0] === '-' || line[0] === '*' || line[0] === '/') {
                operation = line.slice(0, line.indexOf(' ')).trim();
            } else {
                name = line.slice(0, line.indexOf(' ')).trim();
            }
            value = [parseInt(line.slice(line.indexOf(' ')).trim())];
        }

        return {
            name: name,
            operation: operation,
            value: value,
            line: lineNum
        }
    }

}


var test1 = [
    '(def func 10)',
    '(def newFunc (+  func          2))',
    '(def sumFunc (+ func func newFunc 0 0 0))',
    '(* sumFunc 2)'
],
    test2 = [
    '(def func (+ 5 2))',
    '(def func2 (/  func 5 2 1 0))',
    '(def func3 (/ func 2))',
    '(+ func3 func)'
];

Solve(test1);