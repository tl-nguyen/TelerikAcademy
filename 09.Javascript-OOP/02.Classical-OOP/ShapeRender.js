var ShapeRender = function (canvasId) {
    this.canvas = document.getElementById(canvasId);
    this.ctx = this.canvas.getContext('2d');
    this.ctx.lineWidth = '2';
    this.ctx.strokeStyle = 'black';
};

ShapeRender.prototype = {
    drawRect: function (x, y, width , height) {
        this.ctx.beginPath();
        this.ctx.rect(x, y, width , height);
        this.ctx.stroke();
    },

    drawCircle: function (x, y, radius) {
        this.ctx.beginPath();
        this.ctx.arc(x, y, radius, 0, 2 * Math.PI);
        this.ctx.stroke();
    },

    drawLine: function (x1, y1, x2, y2) {
        this.ctx.beginPath();
        this.ctx.moveTo(x1, y1);
        this.ctx.lineTo(x2, y2);
        this.ctx.stroke();
    }
};