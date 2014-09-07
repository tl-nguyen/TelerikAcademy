namespace BookStore.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using BookStore.Data;
    using BookStore.Models;
    using System.Text;

    public class Program
    {
        private static BookStoreDbContext db;
        public static void Main()
        {
            db = new BookStoreDbContext();

            Import();

            Search();
        }

        public static void Search()
        {
            var xmlQueries = XElement.Load(@"..\..\..\..\reviews-queries.xml").Elements();
            var result = new XElement("search-results");

            foreach (var xmlQuery in xmlQueries)
            {
                var queryInReviews = db.Reviews.AsQueryable();

                if (xmlQuery.Attribute("type").Value == "by-period")
                {
                    var startDate = DateTime.Parse(xmlQuery.Element("start-date").Value);
                    var endDate = DateTime.Parse(xmlQuery.Element("end-date").Value);

                   queryInReviews = queryInReviews.Where(r => (startDate <= r.CreateOn) && (r.CreateOn <= endDate));
                }
                else if (xmlQuery.Attribute("type").Value == "by-author")
                {
                    var authorName = xmlQuery.Element("author-name").Value;

                    queryInReviews = queryInReviews.Where(r => r.Author.Name == authorName);
                }

                var resultSet = queryInReviews
                                    .OrderBy(r => r.CreateOn)
                                    .ThenBy(r => r.Content)
                                    .Select(r => new
                                    {
                                        Date = r.CreateOn,
                                        Content = r.Content,
                                        Book = new
                                        {
                                            Title = r.Book.Title,
                                            Authors = r.Book.Authors
                                                            .OrderBy(a => a.Name)
                                                            .Select(a => a.Name),
                                            Isbn = r.Book.Isbn,
                                            Url = r.Book.Website
                                        }
                                    })
                                    .ToList();

                var xmlResultSet = new XElement("result-set");

                foreach (var reviewInResult in resultSet)
                {
                    var foundedReview = new XElement("review");
                    
                    var date = new XElement("date");

                    date.Value = reviewInResult.Date.ToString("d-MMM-yyyy");
                    foundedReview.Add(date);

                    var content = new XElement("content");
                    content.Value = reviewInResult.Content;
                    foundedReview.Add(content);

                    var book = new XElement("book");

                    var title = new XElement("title");
                    title.Value = reviewInResult.Book.Title;
                    book.Add(title);

                    if (reviewInResult.Book.Isbn != null)
                    {
                        var isbn = new XElement("isbn");
                        isbn.Value = reviewInResult.Book.Isbn;
                        book.Add(isbn);
                    }

                    var reviewsCount = reviewInResult.Book.Authors.Count();
                    if (reviewsCount > 0)
                    {
                        var authors = new XElement("authors");
                        StringBuilder authorsNames = new StringBuilder();

                        for (var i = 0; i < reviewsCount; i++ )
                        {
                            if (i == reviewsCount - 1)
                            {
                                authorsNames.Append(reviewInResult.Book.Authors.ElementAt(i));
                            }
                            else
                            {
                                authorsNames.Append(reviewInResult.Book.Authors.ElementAt(i) + ", ");
                            }
                        }

                        authors.Value = authorsNames.ToString();

                        book.Add(authors);
                    }
                    
                    foundedReview.Add(book);

                    xmlResultSet.Add(foundedReview);
                }

                result.Add(xmlResultSet);
            }

            result.Save(@"..\..\..\..\reviews-search-results.xml");
        }

        public static void Import()
        {
            var xmlLoader = XElement.Load(@"..\..\..\..\complex-books.xml");

            var xmlBooks = xmlLoader.Elements();

            foreach (var xmlBook in xmlBooks)
            {
                var currentBook = new Book();

                currentBook.Title = xmlBook.Element("title").Value;

                var authorsLoader = xmlBook.Element("authors");

                if (authorsLoader != null)
                {
                    var xmlAuthors = authorsLoader.Elements("author");

                    foreach (var xmlAuthor in xmlAuthors)
                    {
                        var authorName = xmlAuthor.Value;

                        var author = getAuthor(authorName);

                        currentBook.Authors.Add(author);
                    }
                }

                var website = xmlBook.Element("web-site");

                if (website != null)
                {
                    currentBook.Website = website.Value;
                }

                var reviewsLoader = xmlBook.Element("reviews");

                if (reviewsLoader != null)
                {
                    var xmlReviews = reviewsLoader.Elements();

                    foreach (var xmlReview in xmlReviews)
                    {
                        var author = xmlReview.Attribute("author");
                        var createOnDate = xmlReview.Attribute("date");

                        var currentReview = new Review
                        {
                            Content = xmlReview.Value,
                            CreateOn = createOnDate == null ? DateTime.Now : DateTime.Parse(createOnDate.Value),
                            Author = author == null ? null : getAuthor(author.Value)
                        };

                        currentBook.Reviews.Add(currentReview);
                    }
                }

                var isbn = xmlBook.Element("isbn");

                if (isbn != null)
                {
                    var bookExist = db.Books.Any(b => b.Isbn == isbn.Value);

                    if (bookExist)
                    {
                        throw new ArgumentException("book already exists");
                    }

                    currentBook.Isbn = isbn.Value;
                }

                var price = xmlBook.Element("price");
                if (price != null)
                {
                    currentBook.Price = decimal.Parse(price.Value);
                }

                db.Books.Add(currentBook);
                db.SaveChanges();
            }
        }

        public static Author getAuthor(string authorName)
        {
            var author = db.Authors.Where(a => a.Name == authorName).FirstOrDefault();

            if (author == null)
            {
                author = new Author
                {
                    Name = authorName
                };
            }

            return author;
        }
    }
}
