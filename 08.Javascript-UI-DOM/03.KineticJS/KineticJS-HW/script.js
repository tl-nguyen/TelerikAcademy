(function (vizEngine, dataEngine) {

    var data = [{
        mother: 'Maria Petrova',
        father: 'Georgi Petrov',
        children: ['Teodora Petrova',
            'Peter Petrov']
    }, {
        mother: 'Petra Stamatova',
        father: 'Todor Stamatov',
        children: ['Maria Petrova']
    }],
        currentCouples = [{
           mother: '',
           father: '',
           children: []
        }],

        cx = 100,
        cy = 100,
        offsetX = 400,
        offsetY = 100;

    dataEngine.data = data;


    var males = dataEngine.findAllMales(),
        females = dataEngine.findAllFemales(),
        children = dataEngine.findAllChildren(),
        all = dataEngine.getAllNames(males, females, children);
        sorted = [];

    for (var i = 0, len = data.length; i < len; i += 1) {

        if (dataEngine.isTheOriginCouple(data[i].father, data[i].mother, children)) {

            currentCouples.push({
                father: vizEngine.produceMaleNode(data[i].father, cx, cy),
                mother: vizEngine.produceFemaleNode(data[i].mother, cx + offsetX, cy),
                children: data[i].children
            });

            addToSorted(data[i].father);
            addToSorted(data[i].mother);
            cy += offsetY;

            break;
        }
    }

    while (sorted.length < all.length) {
        var temp = currentCouples;
        currentCouples = [];

        for(i = 0, len = temp.length; i < len; i += 1) {
            var couplesCounts = 1, singleCounts = 0;
            for (var j = 0; j < temp[i].children.length; j += 1) {
                var partner = dataEngine.findPartner(temp[i].children[j]);
                var child;

                if (dataEngine.isMale(temp[i].children[j], males)) {
                    child = vizEngine.produceMaleNode(temp[i].children[j], cx * couplesCounts, cy);

                    if (partner != -1 ) {
                        partner = vizEngine.produceFemaleNode(partner, cx * couplesCounts + offsetX * couplesCounts, cy);

                        currentCouples.push({
                            father: child,
                            mother: partner,
                            children: dataEngine.findChildren(child.name, partner.name)
                        });

                        addToSorted(partner.name);
                        couplesCounts += 1;

                    } else {
                        child.body.x(cx + offsetX * singleCounts);
                        child.text.x(cx + offsetX * singleCounts);
                        singleCounts += 1;
                    }

                } else {
                    child = vizEngine.produceFemaleNode(temp[i].children[j], cx * couplesCounts, cy);

                    if (partner != -1 ) {
                        partner = vizEngine.produceMaleNode(partner, cx * couplesCounts + offsetX * couplesCounts, cy);

                        currentCouples.push({
                            father: partner,
                            mother: child,
                            children: dataEngine.findChildren(partner.name, child.name)
                        });

                        addToSorted(partner.name);
                        couplesCounts += 1;

                    } else {
                        child.body.x(cx + offsetX * singleCounts);
                        child.text.x(cx + offsetX * singleCounts);
                        singleCounts += 1;
                    }

                }

                addToSorted(child.name);

                vizEngine.makeLink(temp[i].father, child);
                vizEngine.makeLink(temp[i].mother, child);
            }

            cy += offsetY;
        }
    }

    function addToSorted(name) {
        var alreadyIn = false;
        for (var i = 0; i < sorted.length; i += 1) {
            if (name === sorted[i]) {
                alreadyIn = true;
                break;
            }
        }

        if (!alreadyIn) sorted.push(name);
    }

    vizEngine.render();

}(vizEngine, dataEngine));



