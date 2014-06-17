(function () {
    var tags = ["cms", "javascript", "js",
        "ASP.NET MVC", ".net", ".net", "css",
        "wordpress", "xaml", "js", "http", "web",
        "asp.net", "asp.net MVC", "ASP.NET MVC",
        "wp", "javascript", "js", "cms", "html",
        "javascript", "http", "http", "CMS"];


    var tagCloud = generateTagCloud(tags,17,42);

    document.body.appendChild(tagCloud);

    function generateTagCloud(tags, minSize, maxSize) {
        var container = document.createElement('div'),
            textSpan = document.createElement('span'),
            tagsContainer = buildTags(tags),
            maxTagCount = maxTagNumber(tagsContainer),
            minTagCount = minTagNumber(tagsContainer);

        container.style.border = '1px solid black';
        container.style.width = '550px';
        container.style.height = '100px';
        container.style.padding = '5px';

        textSpan.style.margin = '5px';

        for (var tag in tagsContainer) {
            textSpan.innerText = tag;
            textSpan.style.fontSize = calculateFontSize(tagsContainer[tag].size,
                                                            minTagCount,
                                                            maxTagCount,
                                                            minSize,
                                                            maxSize) + 'px';


            container.appendChild(textSpan.cloneNode(true));
        }

        return container;
    }

    function calculateFontSize (count, minCount, maxCount, min, max) {
        if (count === minCount) return min;
        if (count === maxCount) return max;

        return ( (count - minCount) / (maxCount - minCount) ) * (max - min) + min;
    }

    function maxTagNumber (tagsContainer) {
        var max = 0;
        for (var tag in tagsContainer) {
            if (tagsContainer[tag].size > max) {
                max = tagsContainer[tag].size;
            }
        }

        return max;
    }

    function minTagNumber (tagsContainer) {
        var min = 100000;
        for (var tag in tagsContainer) {
            if (tagsContainer[tag].size < min) {
                min = tagsContainer[tag].size;
            }
        }

        return min;
    }

    function buildTags(tags) {
        var tagsContainer = {},
            tagName;

        var Tag = function () {
            this.size = 1;
        };

        for (var i = 0, len = tags.length; i < len; i += 1) {
            tagName = tags[i].toLowerCase();

            if (tagsContainer[tagName]) {
                tagsContainer[tagName].size += 1;
            } else {
                tagsContainer[tagName] = new Tag();
            }
        }

        return tagsContainer;
    }

}());