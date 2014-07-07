define(['tech-store-models/item'], function (Item) {
    'use strict';

    var Store;

    Store = (function (){
        function Store(name) {
            if (name.length < 6 || name.length > 30) {
                throw new Error("name must be 6-30 characters long");
            }

            this.name = name;
            this.items = [];
        }

        var sortByName = function (items) {
            items.sort(compare);

            function compare(item1, item2) {
                if (item1.name < item2.name) {
                    return -1;
                }
                if (item1.name > item2.name) {
                    return 1;
                }
                return 0;
            }

            return items;
        };

        var sortByPrice = function (items) {
            items.sort(compare);

            function compare(item1, item2) {
                return item1.price - item2.price;
            }

            return items;
        };

        var extractByType = function (types) {
            var itemsByTypes = [],
                i, len;

            for (i = 0, len = this.items.length; i < len; i += 1) {
                if (types.hasOwnProperty(this.items[i].type)) {
                    itemsByTypes.push(this.items[i]);
                }
            }

            return itemsByTypes;
        };

        Store.prototype.addItem = function (item) {
            if (!(item instanceof Item)) {
                throw new Error("the item must be instance of Item");
            }

            this.items.push(item);

            return this;
        };

        Store.prototype.getAll = function () {
            return sortByName.call(this, this.items);
        };

        Store.prototype.getSmartPhones = function () {
            var smartPhones = extractByType.call(this, {
                'smart-phone':'smart-phone'
            });

            sortByName(smartPhones);

            return smartPhones;
        };

        Store.prototype.getMobiles = function () {
            var mobiles = extractByType.call(this, {
                'smart-phone': 'smart-phone',
                'tablet': 'tablet'
            });

            sortByName(mobiles);

            return mobiles;
        };

        Store.prototype.getComputers = function () {
            var computers = extractByType.call(this, {
                'pc': 'pc',
                'notebook': 'notebook'
            });

            sortByName(computers);

            return computers;
        };

        Store.prototype.filterItemsByType = function (filterType) {
            var filteredItems = [],
                i, len;

            for (i = 0, len = this.items.length; i < len; i += 1) {
                if (this.items[i].type === filterType) {
                    filteredItems.push(this.items[i]);
                }
            }

            sortByName(filteredItems);

            return filteredItems;
        };

        Store.prototype.filterItemsByPrice = function (options) {
            var filteredItems = [],
                i, len;

            options = options || {};
            options.min = options.min || 0;
            options.max = options.max || (options.min - 1);

            for (i = 0, len = this.items.length; i < len; i += 1) {
                if (options.max >= options.min) {
                    if (this.items[i].price >= options.min &&
                            this.items[i].price <= options.max) {
                        filteredItems.push(this.items[i]);
                    }
                } else {
                    if (this.items[i].price >= options.min) {
                        filteredItems.push(this.items[i]);
                    }
                }
            }

            sortByPrice(filteredItems);

            return filteredItems;
        };

        Store.prototype.filterItemsByName = function (partOfName) {
            var filteredItems = [],
                currentName, i, len;

            partOfName = partOfName.toLowerCase();

            for (i = 0, len = this.items.length; i < len; i += 1) {
                currentName = this.items[i].name.toLowerCase();

                if (currentName.indexOf(partOfName) >= 0) {
                    filteredItems.push(this.items[i]);
                }
            }

            sortByName(filteredItems);

            return filteredItems;
        };

        Store.prototype.countItemsByType = function () {
            var itemsCounts = {
                    "accessory": 0,
                    "smart-phone": 0,
                    "notebook": 0,
                    "pc": 0,
                    "tablet": 0
                }, i, len;

            for (i = 0, len = this.items.length; i < len; i += 1) {
                if (itemsCounts.hasOwnProperty(this.items[i].type)) {
                    itemsCounts[this.items[i].type] += 1;
                }
            }

            return itemsCounts;
        };

        return Store;
    }());

    return Store;
});