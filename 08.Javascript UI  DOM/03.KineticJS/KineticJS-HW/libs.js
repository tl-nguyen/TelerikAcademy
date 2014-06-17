    var vizEngine = {
        stage: new Kinetic.Stage({
            container: 'container',
            width: 1800,
            height: 3000
        }),

        layer: new Kinetic.Layer(),

        produceFemaleNode: function (name, cx, cy, width, height) {
            width = width || 300;
            height = height || 50;
            var femaleNode = {
                body: new Kinetic.Rect({
                    x: cx,
                    y: cy,
                    width: width,
                    height: height,
                    stroke: 'green',
                    strokeWidth: 3,
                    cornerRadius: 25
                }),
                text: new Kinetic.Text({
                    x: cx,
                    y: cy + 10,
                    text: name,
                    fontSize: 30,
                    fill: 'black',
                    width: width,
                    align: 'center'
                }),
                type: 'female',
                name: name
            };

            this.add([femaleNode.body, femaleNode.text]);

            return femaleNode;
        },

        produceMaleNode: function (name, cx, cy, width, height) {
            width = width || 300;
            height = height || 50;

            var maleNode = {
                body: new Kinetic.Rect({
                    x: cx,
                    y: cy,
                    width: width,
                    height: height,
                    stroke: 'green',
                    strokeWidth: 3,
                    cornerRadius: 10
                }),
                text: new Kinetic.Text({
                    x: cx,
                    y: cy + 10,
                    text: name,
                    fontSize: 30,
                    fill: 'black',
                    width: width,
                    align: 'center'
                }),
                type: 'male',
                name: name
            };

            this.add([maleNode.body, maleNode.text]);

            return maleNode;
        },

        makeLink: function (parentNode, childNode) {
            var x1 = parentNode.body.x() + parentNode.body.width()/2,
                y1 = parentNode.body.y() + parentNode.body.height(),
                x2 = childNode.body.x() + parentNode.body.width()/2,
                y2 = childNode.body.y();

            var newLink = new Kinetic.Line({
                points: [x1, y1, x2, y2],
                stroke: 'black'
            });

            this.add([newLink]);

            return newLink;
        },

        add: function (elements) {
            for (var i = 0, len = elements.length; i < len; i += 1) {
                this.layer.add(elements[i]);
            }
        },

        render: function () {
            this.stage.add(this.layer);
        }
    };

    var dataEngine = {
        data: [],

        findAllMales: function () {
            var males = [];
            for (var i = 0, len = this.data.length; i < len; i += 1) {
                males.push(this.data[i].father);
            }

            return males;
        },

        findAllFemales: function () {
            var males = [];
            for (var i = 0, len = this.data.length; i < len; i += 1) {
                males.push(this.data[i].mother);
            }

            return males;
        },

        findAllChildren: function () {
            var children = [];
            for (var i = 0, len = this.data.length; i < len; i += 1) {
                for (var j = 0, len2 = this.data[i].children.length; j < len2; j += 1) {
                    children.push(this.data[i].children[j]);
                }
            }

            return children;
        },

        isMale: function (name, maleList) {
            var isMale = false;

            for (var i = 0, len = maleList.length; i < len; i += 1) {
                if (name === maleList[i]) isMale = true;
            }

            if (isMale === false && name[name.length - 1] !== 'a') isMale = true;

            return isMale;
        },

        hasParent: function (name, childrenList) {
            for (var i = 0, len = childrenList.length; i < len; i += 1) {
                if (name === childrenList[i]) return true;
            }

            return false;
        },

        isTheOriginCouple: function (male, female, childrenList) {
            return (!this.hasParent(male, childrenList) &&
                !this.hasParent(female, childrenList));
        },

        findPartner: function (name) {
            for (var i = 0; i < this.data.length; i += 1) {
                if (name === this.data[i].father) {
                    return this.data[i].mother;
                } else if (name === this.data[i].mother) {
                    return this.data[i].father;
                }
            }

            return -1;
        },

        findChildren: function(father, mother) {
            for (var i = 0, len = this.data.length; i < len; i += 1) {
                if (father === this.data[i].father && mother === this.data[i].mother) {
                    return this.data[i].children;
                }
            }
        },

        getAllNames: function (males, females, children) {
            var all = males.concat(females);

            for (var i = 0; i < children.length; i += 1) {
                if (!this.alreadyIn(children[i], all)) all.push(children[i]);
            }

            return all;
        },

        alreadyIn: function (name, all) {
            for (var j = 0; j < all.length; j += 1) {
                if (name === all[j]) {
                    return true;
                }
            }

            return false;
        }

    };