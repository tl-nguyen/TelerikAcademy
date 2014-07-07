define([], function () {
    'use strict';

    var Item;

    Item = (function (){

        var types = {
            "accessory": "accessory",
            "smart-phone": "smart-phone",
            "notebook": "notebook",
            "pc": "pc",
            "tablet": "tablet"
        };

        function Item(type, name, price) {
            if (!types.hasOwnProperty(type)) {
                throw new Error("The type is invalid");
            }

            if (name.length < 6 || name.length > 40) {
                throw new Error("name must be 6-40 characters long");
            }

            if (isNaN(price)) {
                throw new Error("price must be float number");
            }

            this.type = type;
            this.name = name;
            this.price = price;
        }

        return Item;
    }());

    return Item;
});