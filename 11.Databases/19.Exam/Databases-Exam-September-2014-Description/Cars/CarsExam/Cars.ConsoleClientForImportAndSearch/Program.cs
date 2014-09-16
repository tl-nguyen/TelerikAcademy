namespace Cars.ConsoleClientForImportAndSearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Text;
    using System.IO;

    using Newtonsoft.Json;

    using Cars.Data;
    using Cars.Models;

    class Program
    {
        private static CarsDbContext db;

        static void Main(string[] args)
        {
            db = new CarsDbContext();

            //Import();

            Search();
        }

        private static void Search()
        {
            var xmlQueries = XElement.Load(@"..\..\..\..\Queries.xml").Elements();

            foreach (var xmlQuery in xmlQueries)
            {
                var result = new XElement("Cars");

                var queryInCars = db.Cars.AsQueryable();
                var outputFileName = xmlQuery.Attribute("OutputFileName").Value;

                var whereClauses = xmlQuery.Element("WhereClauses");

                foreach (var whereClause in whereClauses.Elements("WhereClause"))
                {
                    var propertyName = whereClause.Attribute("PropertyName").Value;
                    var type = whereClause.Attribute("Type").Value;

                    if (propertyName == "City")
                    {
                        var cityName = whereClause.Value;
                        queryInCars = queryInCars
                                        .Where(c => c.Dealer.Cities.Select(ct => ct.Name)
                                                        .Where(ctName => ctName == cityName)
                                                        .FirstOrDefault() == cityName);
                    }
                    else if (propertyName == "Year")
                    {
                        var year = int.Parse(whereClause.Value);

                        if (type == "Equals")
                        {
                            queryInCars = queryInCars.Where(c => c.Year == year);
                        }
                        else if (type == "GreaterThan")
                        {
                            queryInCars = queryInCars.Where(c => c.Year > year);
                        }
                        else if (type == "LessThan")
                        {
                            queryInCars = queryInCars.Where(c => c.Year < year);
                        }
                    }
                    else if (propertyName == "Price")
                    {
                        var price = decimal.Parse(whereClause.Value);


                        if (type == "Equals")
                        {
                            queryInCars = queryInCars.Where(c => c.Price == price);
                        }
                        else if (type == "GreaterThan")
                        {
                            queryInCars = queryInCars.Where(c => c.Price > price);
                        }
                        else if (type == "LessThan")
                        {
                            queryInCars = queryInCars.Where(c => c.Price < price);
                        }
                    }
                    else if (propertyName == "Id")
                    {
                        var id = int.Parse(whereClause.Value);

                        if (type == "Equals")
                        {
                            queryInCars = queryInCars.Where(c => c.Id == id);
                        }
                        else if (type == "GreaterThan")
                        {
                            queryInCars = queryInCars.Where(c => c.Id > id);
                        }
                        else if (type == "LessThan")
                        {
                            queryInCars = queryInCars.Where(c => c.Id < id);
                        }
                    }
                    else if (propertyName == "Model")
                    {
                        var model = whereClause.Value;

                        if (type == "Equals")
                        {
                            queryInCars = queryInCars.Where(c => c.Model == model);
                        }
                        else if (type == "Contains")
                        {
                            queryInCars = queryInCars.Where(c => c.Model.Contains(model));
                        }
                    }
                    else if (propertyName == "Manufacturer")
                    {
                        var manufacturer = whereClause.Value;

                        if (type == "Equals")
                        {
                            queryInCars = queryInCars.Where(c => c.Manufacturer.Name == manufacturer);
                        }
                        else if (type == "Contains")
                        {
                            queryInCars = queryInCars.Where(c => c.Manufacturer.Name.Contains(manufacturer));
                        }
                    }
                    else if (propertyName == "Dealer")
                    {
                        var dealer = whereClause.Value;

                        if (type == "Equals")
                        {
                            queryInCars = queryInCars.Where(c => c.Dealer.Name == dealer);
                        }
                        else if (type == "Contains")
                        {
                            queryInCars = queryInCars.Where(c => c.Dealer.Name.Contains(dealer));
                        }
                    }
                }

                var orderBy = xmlQuery.Element("OrderBy").Value;

                if (orderBy == "Id")
                {
                    queryInCars = queryInCars.OrderBy(c => c.Id);
                }
                else if (orderBy == "Year")
                {
                    queryInCars = queryInCars.OrderBy(c => c.Year);
                }

                else if (orderBy == "Model")
                {
                    queryInCars = queryInCars.OrderBy(c => c.Model);
                }

                else if (orderBy == "Price")
                {
                    queryInCars = queryInCars.OrderBy(c => c.Price);
                }

                else if (orderBy == "Manufacturer")
                {
                    queryInCars = queryInCars.OrderBy(c => c.Manufacturer);
                }

                var carsSet = queryInCars.ToList();

                foreach (var carInSet in carsSet)
                {
                    var xmlCarSet = new XElement("Car");
                    var xmlManufacturerAttribute = new XAttribute("Manufacturer", carInSet.Manufacturer.Name);
                    var xmlModelAttribute = new XAttribute("Model", carInSet.Model);
                    var xmlYearAttribute = new XAttribute("Year", carInSet.Year.ToString());
                    var xmlPriceAttribute = new XAttribute("Price", carInSet.Price.ToString());

                    xmlCarSet.Add(xmlManufacturerAttribute);
                    xmlCarSet.Add(xmlModelAttribute);
                    xmlCarSet.Add(xmlYearAttribute);
                    xmlCarSet.Add(xmlPriceAttribute);

                    var xmlTransmissionType = new XElement("TransmissionType");
                    xmlTransmissionType.Value = carInSet.TransmissionType.ToString();

                    //Add transmission type
                    xmlCarSet.Add(xmlTransmissionType);

                    var xmlDealer = new XElement("Dealer");
                    var xmlNameAttribute = new XAttribute("Name", carInSet.Dealer.Name);
                    xmlDealer.Add(xmlNameAttribute);

                    var xmlCities = new XElement("Cities");
                    var recentDealerCities = carInSet.Dealer.Cities;

                    foreach (var recentDealerCity in recentDealerCities)
                    {
                        var xmlDealerCity = new XElement("City");
                        xmlDealerCity.Value = recentDealerCity.Name;

                        xmlCities.Add(xmlDealerCity);
                    }

                    // Add Dealer
                    xmlDealer.Add(xmlCities);
                    xmlCarSet.Add(xmlDealer);

                    result.Add(xmlCarSet);
                }
                result.Save(@"..\..\..\..\QueryResults\" + outputFileName + ".xml");
            }
        }

        private static void Import()
        {
            var unpackDirectory = @"..\..\..\..\Data.Json.Files";

            var cars = new List<CarJsonModel>();

            foreach (string file in Directory.GetFiles(unpackDirectory))
            {
                if (file.EndsWith(".json"))
                {
                    var currentJsonDoc = RetrieveFromJsonFile(file);
                    cars.AddRange(currentJsonDoc);
                }
            }

            var index = 0;

            foreach (var car in cars)
            {
                var newCar = new Car
                {
                    Model = car.Model,
                    Year = car.Year,
                    Price = car.Price,
                    TransmissionType = car.TransmissionType
                };

                var manufacturer = GetManufacturer(car.ManufacturerName);

                newCar.Manufacturer = manufacturer;

                var dealer = GetDealer(car.Dealer.Name);

                var city = GetCity(car.Dealer.City);

                dealer.Cities.Add(city);

                newCar.Dealer = dealer;

                db.Cars.Add(newCar);

                index++;

                Console.Write(".");
                db.SaveChanges();
            }
            Console.WriteLine("\n Import Done");
        }

        private static City GetCity(string cityName)
        {
            var city = db.Cities.Where(c => c.Name == cityName).FirstOrDefault();

            if (city == null)
            {
                city = new City
                {
                    Name = cityName
                };
            }

            return city;
        }

        private static Dealer GetDealer(string dealerName)
        {
            var dealer = db.Dealers.Where(d => d.Name == dealerName).FirstOrDefault();

            if (dealer == null)
            {
                dealer = new Dealer
                {
                    Name = dealerName
                };
            }

            return dealer;
        }

        private static Manufacturer GetManufacturer(string manuFacturerName)
        {
            var manufacturer = db.Manufacturers.Where(m => m.Name == manuFacturerName).FirstOrDefault();

            if (manufacturer == null)
            {
                manufacturer = new Manufacturer
                {
                    Name = manuFacturerName
                };
            }

            return manufacturer;
        }

        private static List<CarJsonModel> RetrieveFromJsonFile(string file)
        {
            StreamReader re = new StreamReader(file);
            JsonTextReader reader = new JsonTextReader(re);

            JsonSerializer se = new JsonSerializer();
            List<CarJsonModel> parsedCars = se.Deserialize<List<CarJsonModel>>(reader);

            return parsedCars;
        }
    }
}
