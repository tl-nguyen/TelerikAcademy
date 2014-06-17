$.fn.gallery = function (colsPerRow) {
    colsPerRow = colsPerRow || 4;
    var IMG_WIDTH = 250;
    var galleryWidth = (colsPerRow * IMG_WIDTH + colsPerRow * 10) + 'px';

    var $this = $(this);
    var allImages = $this.find('.image-container');
    var $galleryList = $($this.children('.gallery-list')[0]);
    var $selectedList = $($this.children('.selected')[0]);
    var $prevImg = $($selectedList.find('#previous-image')[0]);
    var $currentImg = $($selectedList.find('#current-image')[0]);
    var $nextImg = $($selectedList.find('#next-image')[0]);

    resetAll();
    selectImgEventSetup();
    selectedImgEventSetup();

    function resetAll() {
        $this.addClass('gallery');
        $this.css("width", galleryWidth);

        $prevImg.hide();
        $currentImg.hide();
        $nextImg.hide();

        for (var i = 0, len = allImages.length; i < len; i += 1) {
            $(allImages[i]).css("width", IMG_WIDTH + 'px');
        }
    }

    function selectImgEventSetup() {
        for (var i = 0, len = allImages.length; i < len; i += 1) {
            $($(allImages[i]).children('img')[0]).on('click', onClickImg);
        }
    }

    function selectedImgEventSetup() {
        $currentImg.on('click', onSelectedImg);
        $prevImg.on('click', onClickImg);
        $nextImg.on('click', onClickImg);
    }

    function onSelectedImg() {
        $prevImg.hide();
        $currentImg.hide();
        $nextImg.hide();
        $galleryList.removeClass('blurred');
        enableImagesBehind();
    }

    function onClickImg() {
        var currentIndex = findSelectedIndex($(this));
        var prevIndex = currentIndex - 1;
        var nextIndex = currentIndex + 1;

        if (prevIndex < 0) {
            prevIndex = allImages.length - 1;
        }

        if (nextIndex >= allImages.length) {
            nextIndex = 0;
        }

        $currentImg.attr('src', $(this).attr('src'));
        $prevImg.attr('src', $($(allImages[prevIndex]).children('img')[0]).attr('src'));
        $nextImg.attr('src', $($(allImages[nextIndex]).children('img')[0]).attr('src'));

        $galleryList.addClass('blurred');
        $currentImg.show();
        $prevImg.show();
        $nextImg.show();
        disableImagesBehind();
    }

    function findSelectedIndex(img) {
        for (var i = 0, len = allImages.length; i < len; i += 1) {
            if ($($(allImages[i]).children('img')[0]).attr('src') === img.attr('src')) {
                return i;
            }
        }
    }

    function disableImagesBehind() {
        for (var i = 0; i < allImages.length; i += 1) {
            $($(allImages[i]).children('img')[0]).off('click');
        }
    }

    function enableImagesBehind() {
        for (var i = 0; i < allImages.length; i += 1) {
            $($(allImages[i]).children('img')[0]).on('click',onClickImg);
        }
    }
};