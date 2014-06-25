function createImagesPreviewer(selector, items) {
    var RIGHTBOX_WIDTH = 300;
    var RIGHT_ELS_WIDTH = 200;
    var LEFTBOX_WIDTH = 600;
    var LEFT_ELS_WIDTH = 500;
    var BOX_HEIGHT = 500;

    var filteredItems = items;
    var container = document.querySelector(selector);
    var fragment = document.createDocumentFragment();
    var leftbox = document.createElement('div');
    var rightbox = document.createElement('div');
    var filterContainer = document.createElement('div');
    var filterTitle = document.createElement('p');
    var filterInput = document.createElement('input');
    var imagesContainer = document.createElement('div');
    var imgContainer = document.createElement('div');
    var imgTitle = document.createElement('strong');
    var img = document.createElement('img');
    var leftImgContainer = document.createElement('div');
    var leftImgTitle = document.createElement('strong');
    var leftImg = document.createElement('img');
    var selected = null;

    // rightbox styles
    rightbox.style.width = RIGHTBOX_WIDTH + 'px';
    rightbox.style.height = BOX_HEIGHT + 'px';
    rightbox.style.overflowY = "scroll";

    filterContainer.style.textAlign = 'center';
    filterTitle.innerText = 'Filter';
    filterTitle.style.margin = '0';
    filterInput.style.width = RIGHT_ELS_WIDTH + 'px';
    filterInput.style.textAlign = 'center';

    imgContainer.style.textAlign = 'center';
    imgTitle.style.display = 'block';
    img.style.width = RIGHT_ELS_WIDTH + 'px';
    img.style.borderRadius = '10px';

    filterContainer.appendChild(filterTitle);
    filterContainer.appendChild(filterInput);

    imgContainer.appendChild(imgTitle);
    imgContainer.appendChild(img);

    // leftbox styles
    leftbox.style.float = 'left';
    leftbox.style.width = LEFTBOX_WIDTH + 'px';
    leftbox.style.height = BOX_HEIGHT + 'px';
    leftbox.style.textAlign = 'center';

    leftImgContainer.style.width = LEFT_ELS_WIDTH + 'px';
    leftImgContainer.style.margin = '0 auto';
    leftImgTitle.style.fontSize = '50px';
    leftImg.style.width = '100%';
    leftImg.style.margin = '30px 0';
    leftImg.style.borderRadius = '20px';

    populateRightBox();
    populateLeftBox();

    function populateLeftBox() {
        leftImg.src = items[0].url;
        leftImgTitle.innerText = items[0].title;

        leftImgContainer.appendChild(leftImgTitle);
        leftImgContainer.appendChild(leftImg);
        leftbox.appendChild(leftImgContainer);
    }

    function populateRightBox() {
        filterInput.addEventListener('keyup', onFilter);

        // this method populate imagesContainer variable,
        // where contains all the right box images
        populateRightBoxImages();

        rightbox.appendChild(filterContainer);
        rightbox.appendChild(imagesContainer);
    }

    function populateRightBoxImages() {
        var currentContainer;

        for (var i = 0, len = filteredItems.length; i < len; i += 1) {
            imgTitle.innerText = filteredItems[i].title;
            img.src = filteredItems[i].url;

            currentContainer = imgContainer.cloneNode(true);

            currentContainer.addEventListener('click', onClickedImg);
            currentContainer.addEventListener('mouseover', onMouseOverImg);
            currentContainer.addEventListener('mouseout', onMouseOutImg);

            imagesContainer.appendChild(currentContainer);
        }
    }

    function onFilter() {
        var filteredText = this.value;
        filteredItems = [];

        for (var i = 0, len = items.length; i < len; i += 1) {
            if (items[i].title.toLowerCase().indexOf(filteredText.toLowerCase()) >= 0) {
                filteredItems.push(items[i]);
            }
        }

        removeAllChildren(imagesContainer);

        populateRightBoxImages();

        filterInput.focus();
    }

    function removeAllChildren(parentElement) {
        while( parentElement.hasChildNodes() ){
            parentElement.removeChild(parentElement.lastChild);
        }
    }

    function onMouseOverImg() {
        if (selected !== this) {
            this.style.backgroundColor = '#ccc';
        }
    }

    function onMouseOutImg() {
        if (selected !== this) {
            this.style.backgroundColor = '';
        }
    }

    function onClickedImg() {
        if (selected != null) {
            selected.style.backgroundColor = '';
        }

        if (selected === this) {
            selected = null;
        } else {
            var currentTitle = this.getElementsByTagName('strong')[0].innerText;
            var currentImg = this.getElementsByTagName('img')[0].src;

            this.style.backgroundColor = '#ccc';
            leftImgTitle.innerText = currentTitle;
            leftImg.src = currentImg;

            selected = this;
        }
    }

    //adding all to container
    fragment.appendChild(leftbox);
    fragment.appendChild(rightbox);
    container.appendChild(fragment);
}