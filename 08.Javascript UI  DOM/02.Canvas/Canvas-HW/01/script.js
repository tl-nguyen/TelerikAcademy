(function (doc) {
    var canvas = doc.getElementById('the-canvas'),
        ctx = canvas.getContext('2d'),
        fillstyle, strokestyle;

    // draw person head:
    //head
    strokestyle = 'green';
    fillstyle = 'yellow';
    drawEllipse(ctx, 130, 180, 60, 50, strokestyle, fillstyle); // head
    drawEllipse(ctx, 95, 160, 12, 8, strokestyle, fillstyle); // left eye
    drawEllipse(ctx, 92, 160, 4, 7, strokestyle, strokestyle);
    drawEllipse(ctx, 140, 160, 12, 8, strokestyle, fillstyle); // right eye
    drawEllipse(ctx, 137, 160, 4, 7, strokestyle, strokestyle);
    drawNose(ctx, 115, 160, 15, 25, strokestyle, fillstyle); // nose
    drawEllipse(ctx, 150, 180, 25, 8, strokestyle, fillstyle, 10); // mouth
    //hat
    strokestyle = 'black';
    fillstyle = 'blue';
    drawEllipse(ctx, 130, 130, 60, 10, strokestyle, fillstyle);
    drawEllipse(ctx, 130, 120, 30, 10, strokestyle, fillstyle);
    drawHatBody(ctx, 100, 120, 60, 80, strokestyle, fillstyle);
    drawEllipse(ctx, 130, 40, 30, 10, strokestyle, fillstyle);

    // draw bicycle:
    // tires
    strokestyle = 'black';
    fillstyle = 'purple';
    drawEllipse(ctx, 100, 450, 60, 60, strokestyle, fillstyle);
    drawEllipse(ctx, 350, 450, 60, 60, strokestyle, fillstyle);
    // body
    drawBicycleBody(ctx, 100, 450, 350, 450, strokestyle);

    // draw house:
    // body
    strokestyle = 'black';
    fillstyle = 'pink';
    drawHouseBody(ctx, 600, 300, strokestyle, fillstyle);
    drawChimney(ctx, 850, 250, strokestyle, fillstyle);
    // door
    drawDoor(ctx, 650, 600, strokestyle, fillstyle);

    // windows
    strokestyle = 'black';
    fillstyle = 'black';
    drawWindows(ctx, 640, 340, 100, 60, strokestyle, fillstyle);
    drawWindows(ctx, 800, 340, 100, 60, strokestyle, fillstyle);
    drawWindows(ctx, 800, 440, 100, 60, strokestyle, fillstyle);

    // draw functions:

    function drawEllipse(ctx, cx, cy, rx, ry, strokestyle, fillstyle, rotate) {
        if (ctx.ellipse) {
            ctx.save();
            ctx.beginPath();

            if (rotate) {
                ctx.rotate(rotate * Math.PI / 180);
            }

            ctx.ellipse(cx, cy, rx, ry, 0, 0, Math.PI * 2);
            ctx.strokeStyle = strokestyle || 'black';
            ctx.fillStyle = fillstyle || 'white';
            ctx.fill();
            ctx.stroke();
            ctx.restore();
        } else {
            console.log('function ellipse() is not supported in your browser')
        }
    }

    function drawHatBody(ctx, cx, cy, width, height, strokestyle, fillstyle) {
        ctx.save();
        ctx.beginPath();
        ctx.moveTo(cx, cy);
        ctx.lineTo(cx, cy - height);
        ctx.lineTo(cx + width, cy - height);
        ctx.lineTo(cx + width, cy);
        ctx.strokeStyle = strokestyle || 'black';
        ctx.fillStyle = fillstyle || 'white';
        ctx.fill();
        ctx.stroke();
        ctx.restore();
    }

    function drawDoorBody(ctx, cx, cy, width, height, strokestyle, fillstyle) {
        ctx.save();
        ctx.beginPath();
        ctx.moveTo(cx, cy);
        ctx.lineTo(cx, cy + height);
        ctx.lineTo(cx + width, cy + height);
        ctx.lineTo(cx + width, cy);
        ctx.strokeStyle = strokestyle || 'black';
        ctx.fillStyle = fillstyle || 'white';
        ctx.fill();
        ctx.stroke();
        ctx.restore();
    }

    function drawBicycleBody(ctx, startX, startY, endX, endY, strokestyle) {
        ctx.save();
        ctx.beginPath();
        ctx.moveTo(startX + 80, startY - 40);
        ctx.lineTo(startX + 140, startY + 40);
        ctx.stroke();
        drawEllipse(ctx, startX + 110, startY, 20, 20, strokestyle);
        ctx.moveTo(startX + 50, startY - 100);
        ctx.lineTo(startX + 90, startY - 100);
        ctx.moveTo(endX - 15, endY - 110);
        ctx.lineTo(endX, endY);
        ctx.moveTo(endX - 55, endY - 100);
        ctx.lineTo(endX - 15, endY - 110);
        ctx.lineTo(endX + 20, endY - 140);
        ctx.moveTo(startX, startY);
        ctx.lineTo(startX + 80, startY  - 80);
        ctx.lineTo(endX - 10, endY - 80);
        ctx.lineTo(endX - 140, endY);
        ctx.lineTo(startX, startY);
        ctx.moveTo(startX + 70, startY - 100);
        ctx.lineTo(startX + 110, startY);
        ctx.strokeStyle = strokestyle || 'black';
        ctx.stroke();
        ctx.restore();
    }

    function drawNose(ctx, cx, cy, width, height, strokestyle, fillstyle) {
        ctx.save();
        ctx.beginPath();
        ctx.moveTo(cx, cy);
        ctx.lineTo(cx - width, cy  + height);
        ctx.lineTo(cx, cy + height);
        ctx.strokeStyle = strokestyle || 'black';
        ctx.fillStyle = fillstyle || 'white';
        ctx.fill();
        ctx.stroke();
        ctx.restore();
    }

    function drawHouseBody(ctx, cx, cy, strokestyle, fillstyle) {
        drawRect(ctx, cx, cy, 350, 300, strokestyle, fillstyle);
        ctx.save();
        ctx.beginPath();
        ctx.moveTo(cx, cy);
        ctx.lineTo(cx + 175, cy - 200);
        ctx.lineTo(cx + 350, cy);
        ctx.strokeStyle = strokestyle || 'black';
        ctx.fillStyle = fillstyle || 'white';
        ctx.fill();
        ctx.stroke();
        ctx.restore();
    }

    function drawChimney(ctx, cx, cy, strokestyle, fillstyle) {
        drawHatBody(ctx, cx, cy, 30, 100, strokestyle, fillstyle);
        drawEllipse(ctx, cx + 15, cy - 100, 15, 5, strokestyle, fillstyle);
    }

    function drawDoor(ctx, cx, cy, strokestyle, fillstyle) {
        drawEllipse(ctx, cx + 40, cy - 110, 40, 20, strokestyle, fillstyle);
        drawDoorBody(ctx, cx, cy - 110, 80, 110, strokestyle, fillstyle);
        ctx.save();
        ctx.beginPath();
        ctx.moveTo(cx + 40, cy);
        ctx.lineTo(cx + 40, cy - 130);
        ctx.strokeStyle = strokestyle || 'black';
        ctx.fillStyle = fillstyle || 'white';
        ctx.fill();
        ctx.stroke();
        ctx.restore();
        drawEllipse(ctx, cx + 30, cy - 60, 5, 5, strokestyle, fillstyle);
        drawEllipse(ctx, cx + 50, cy - 60, 5, 5, strokestyle, fillstyle);
    }

    function drawWindows(ctx, cx, cy, width, height, strokestyle, fillstyle) {
        drawRect(ctx, cx, cy, width / 2 - 2, height / 2 - 2, strokestyle, fillstyle);
        drawRect(ctx, cx + width / 2 + 2, cy, width / 2 - 2, height / 2 - 2, strokestyle, fillstyle);
        drawRect(ctx, cx + width / 2 + 2, cy + height / 2 + 2, width / 2 - 2, height / 2 - 2, strokestyle, fillstyle);
        drawRect(ctx, cx, cy + height / 2 + 2, width / 2 - 2, height / 2 - 2, strokestyle, fillstyle);
    }

    function drawRect(ctx, cx, cy, width, heigh, strokestyle, fillstyle) {
        if (ctx.rect) {
            ctx.save();
            ctx.beginPath();
            ctx.rect(cx, cy, width, heigh);
            ctx.strokeStyle = strokestyle || 'black';
            ctx.fillStyle = fillstyle || 'white';
            ctx.fill();
            ctx.stroke();
            ctx.restore();
        } else {
            console.log('function rect() is not supported in your browser')
        }
    }
}(document));