(function () {

    var Book = (function (){
        function Book(name, author) {
            this.name = name;
            this.author = author;
        }

        Book.prototype.toString = function () {
            return this.name + ' by ' + this.author + '\n';
        };

        return Book;
    }());

    var books = [
            new Book('Horror 1','Gosho'),
            new Book('Romance 1','Pesho'),
            new Book('Romance','Maria'),
            new Book('Fiction 1','Gosho'),
            new Book('Fiction 2','Gosho'),
            new Book('Horror 2','Ivan'),
            new Book('Horror','Gosho'),
            new Book('Fiction 3','Gosho'),
            new Book('Romance 2','Pesho'),
            new Book('Horror 3','Maria'),
            new Book('Fiction 4','Pesho'),
            new Book('Fiction 5','Gosho'),
            new Book('Horror 4','Pesho'),
            new Book('Fiction 6','Ivan'),
            new Book('Horror 5','Ivan'),
            new Book('Fiction 7','Pesho'),
            new Book('Romance 3','Maria'),
            new Book('Horror 6','Maria')
        ],
        bestAuthor;

    console.log('---------- Task 06 -----------');

    bestAuthor = _.chain(books)
        .groupBy('author')
        .sortBy(function (books) {
            return books.length * (-1);
        })
        .first()
        .map(function (book) {
            return book.author;
        })
        .first()
        .value()

    console.log('best author : ' + bestAuthor);
}());