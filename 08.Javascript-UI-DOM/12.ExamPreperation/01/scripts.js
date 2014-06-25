function createCalendar(element, data) {
    var container = document.querySelector(element),
        calendar = [],
        calendarHTML = [];

    generateCalendar();
    makeDayNodes();
    populateEvents();
    eventHandlingSetup();

    function eventHandlingSetup() {
        var titles = document.getElementsByClassName('title');

        for (var i = 0, len = titles.length; i < len; i += 1) {

            if (titles[i].className.indexOf('current') >= 0) {
                continue;
            }

            titles[i].addEventListener('mouseover', mouseOver);
            titles[i].addEventListener('mouseout', mouseOut);
            titles[i].addEventListener('click', mouseClicked)
        }

        function mouseOver() {
            this.style.backgroundColor = '#ddd';
        }

        function mouseOut() {
            this.style.backgroundColor = '#ccc';
        }

        function mouseClicked() {
            clearCurrentClass();

            this.className += ' current';
            this.style.backgroundColor = '#fff';

            this.removeEventListener('mouseout', mouseOut);
            this.removeEventListener('mouseover', mouseOver);
        }

        function clearCurrentClass() {
            var currentSelectedTitle = container.querySelector('.current');

            if (currentSelectedTitle) {
                currentSelectedTitle.className = 'title';
                currentSelectedTitle.style.backgroundColor = '#ccc';
                currentSelectedTitle.addEventListener('mouseover', mouseOver);
                currentSelectedTitle.addEventListener('mouseout', mouseOut);
            }
        }
    }

    function populateEvents() {

        for (var i = 0, len = data.length; i < len; i += 1) {
            calendarHTML[data[i].date - 1].childNodes[1].innerText = data[i].hour + ' ' + data[i].duration + ' ' + data[i].title;
        }
    }

    function makeDayNodes() {
        var dayContainer = document.createElement("div"),
            title = document.createElement("p"),
            event = document.createElement("div"),
            currentDay;

        //styles
        dayContainer.style.width = '150px';
        dayContainer.style.height = '150px';
        dayContainer.style.border = '1px solid black';
        dayContainer.style.borderRadius = '3px';
        dayContainer.style.float = 'left';
        dayContainer.style.margin = '0';

        title.style.backgroundColor = '#ccc';
        title.style.textAlign = 'center';
        title.style.margin = '0';
        title.style.borderBottom = '1px solid black';
        title.className = 'title';

        event.style.margin = '0';

        dayContainer.appendChild(title);
        dayContainer.appendChild(event);

        for (var i = 0, len = calendar.length; i < len; i += 1) {
            title.innerHTML = '<strong>' + calendar[i].day + ' ' + calendar[i].date + ' June 2014' + '</strong>';

            currentDay = dayContainer.cloneNode(true);
            container.appendChild(currentDay);
            calendarHTML.push(currentDay);
        }
    }

    function generateCalendar() {
        var days = ["Sun", "Mon", "Tue", "Wen", "Thu", "Fri", "Sat"],
            date = {};

        for (var i = 1, j = 0; i < 31; i += 1, j += 1) {
            if (j === 7) {
                j = 0;
            }

            date = {
                date: i,
                day: days[j]
            };

            calendar.push(date);
        }
    }
}