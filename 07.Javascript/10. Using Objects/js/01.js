(function () {
	'use strict';
	
	var Point = function (x, y) {
		this.x = x || 0;
		this.y = y || 0;
	}
	
	var Line = function (p1, p2) {
		this.p1 = p1 || 0;
		this.p2 = p2 || 0;
	}
	
	Point.distanceOfPoints = function (p1, p2) {
		return Math.sqrt(Math.pow(p1.x - p2.x, 2) + Math.pow(p1.y - p2.y, 2));
	}
	
	Line.prototype.getLength = function () {
		return Point.distanceOfPoints(this.p1, this.p2);
	}
	
	Line.isATriangle = function (l1, l2, l3) {
		return (l1.getLength() < l2.getLength() + l3.getLength() &&
              l2.getLength() < l1.getLength() + l3.getLength() &&
              l3.getLength() < l1.getLength() + l2.getLength());
	}
	
	var newLine = new Line(new Point(1,2), new Point(2,3));
	var newLine2 = new Line(new Point(3,1), new Point(2,3));
	var newLine3 = new Line(new Point(3,2), new Point(3,3));
	
	myConsole.appendToConsole('Task 01:', [
		'would it form a triangle ? ' + Line.isATriangle(newLine, newLine2, newLine3)
	]);
}());