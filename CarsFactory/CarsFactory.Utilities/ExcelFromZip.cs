using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.IO.Compression;

using CarsFactory.Models;
using CarsFactory.Models.Enums;

namespace CarsFactory.Utilities
{
    // TODO: Refactor class
    public class ExcelFromZip
    {
        private const string TempExcelFile = "TempExcelFile.xls";

        public static IReadOnlyCollection<ZipArchiveEntry> GetFileEntries(ZipArchive zip)
        {
            return zip.Entries;
        }

        public static IReadOnlyCollection<ZipArchiveEntry> GetCurrentEntries(IReadOnlyCollection<ZipArchiveEntry> entries, string endPathFile)
        {
            var currentEntries = new List<ZipArchiveEntry>();
            foreach (var entry in entries)
            {
                if (entry.FullName.EndsWith(endPathFile))
                {

                    switch (endPathFile)
                    {
                        case "Towns.xls":
                            currentEntries.Add(entry);
                            break;
                        case "Platforms.xls":
                            currentEntries.Add(entry);
                            break;
                        case "Engines.xls":
                            currentEntries.Add(entry);
                            break;
                        case "Models.xls":
                            currentEntries.Add(entry);
                            break;
                        case "Cars.xls":
                            currentEntries.Add(entry);
                            break;
                    }
                }
            }

            return currentEntries;
        }

        public static ICollection<Town> GetAllTowns(ICollection<Town> dealershipTowns, IReadOnlyCollection<ZipArchiveEntry> townEntries)
        {

            foreach (var entry in townEntries)
            {
                var fileName = GetFileName(entry);

                using (var ms = new MemoryStream())
                {
                    var file = File.Create(TempExcelFile);
                    using (file)
                    {
                        CopyStream(entry.Open(), ms);
                        ms.WriteTo(file);
                    }
                }

                var connection = new OleDbConnection();
                OleDbConnectionStringBuilder connectionString = SetUpConnectionString();

                connection.ConnectionString = connectionString.ToString();

                using (connection)
                {
                    connection.Open();

                    var excelSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

                    var oleDbCommand = new OleDbCommand("SELECT * FROM [" + sheetName + "]", connection);

                    using (var adapter = new OleDbDataAdapter(oleDbCommand))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        using (var reader = dataSet.CreateDataReader())
                        {
                            while (reader.Read())
                            {
                                var town = new Town()
                                {
                                    Name = reader["Name"].ToString(),
                                };
                                Console.WriteLine(town.Name);
                                dealershipTowns.Add(town);
                            }
                        }
                    }
                }
            }
            File.Delete(TempExcelFile);

            return dealershipTowns;
        }

        public static ICollection<Platform> GetAllPlatforms(ICollection<Platform> dealershipPlatforms, IReadOnlyCollection<ZipArchiveEntry> platformEntries)
        {
            foreach (var entry in platformEntries)
            {

                var connection = new OleDbConnection();
                OleDbConnectionStringBuilder connectionString = SetUpConnectionString();

                connection.ConnectionString = connectionString.ToString();

                var fileName = GetFileName(entry);

                using (var ms = new MemoryStream())
                {
                    var file = File.Create(TempExcelFile);
                    using (file)
                    {
                        CopyStream(entry.Open(), ms);
                        ms.WriteTo(file);
                    }
                }

                using (connection)
                {
                    connection.Open();


                    var excelSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

                    var oleDbCommand = new OleDbCommand("SELECT * FROM [" + sheetName + "]", connection);

                    using (var adapter = new OleDbDataAdapter(oleDbCommand))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        using (var reader = dataSet.CreateDataReader())
                        {
                            while (reader.Read())
                            {
                                var platform = new Platform()
                                {
                                    PlatformType = (PlatformType)Enum.Parse(typeof(PlatformType), reader["PlatformType"].ToString()),
                                    NumberOfDoors = int.Parse(reader["NumberOfDoors"].ToString())
                                };
                                Console.WriteLine(platform.NumberOfDoors);
                                dealershipPlatforms.Add(platform);
                            }
                        }
                    }
                }
            }
            File.Delete(TempExcelFile);

            return dealershipPlatforms;
        }

        public static ICollection<Engine> GetAllEngines(ICollection<Engine> dealershipEngines, IReadOnlyCollection<ZipArchiveEntry> engineEntries)
        {

            foreach (var entry in engineEntries)
            {
                var fileName = GetFileName(entry);

                using (var ms = new MemoryStream())
                {
                    var file = File.Create(TempExcelFile);
                    using (file)
                    {
                        CopyStream(entry.Open(), ms);
                        ms.WriteTo(file);
                    }
                }

                var connection = new OleDbConnection();
                OleDbConnectionStringBuilder connectionString = SetUpConnectionString();

                connection.ConnectionString = connectionString.ToString();

                using (connection)
                {
                    connection.Open();

                    var excelSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

                    var oleDbCommand = new OleDbCommand("SELECT * FROM [" + sheetName + "]", connection);

                    using (var adapter = new OleDbDataAdapter(oleDbCommand))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        using (var reader = dataSet.CreateDataReader())
                        {
                            while (reader.Read())
                            {
                                var engine = new Engine()
                                {
                                    Fuel = (FuelType)Enum.Parse(typeof(FuelType), reader["Fuel"].ToString()),
                                    HorsePower = int.Parse(reader["HorsePower"].ToString())
                                };
                                Console.WriteLine(engine.HorsePower);
                                dealershipEngines.Add(engine);
                            }
                        }
                    }
                }
            }
            File.Delete(TempExcelFile);

            return dealershipEngines;
        }

        public static ICollection<Model> GetAllModels(ICollection<Model> dealershipModels, IReadOnlyCollection<ZipArchiveEntry> modelEntries)
        {

            foreach (var entry in modelEntries)
            {
                var fileName = GetFileName(entry);

                using (var ms = new MemoryStream())
                {
                    var file = File.Create(TempExcelFile);
                    using (file)
                    {
                        CopyStream(entry.Open(), ms);
                        ms.WriteTo(file);
                    }
                }

                var connection = new OleDbConnection();
                OleDbConnectionStringBuilder connectionString = SetUpConnectionString();

                connection.ConnectionString = connectionString.ToString();

                using (connection)
                {
                    connection.Open();

                    var excelSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

                    var oleDbCommand = new OleDbCommand("SELECT * FROM [" + sheetName + "]", connection);

                    using (var adapter = new OleDbDataAdapter(oleDbCommand))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        using (var reader = dataSet.CreateDataReader())
                        {
                            while (reader.Read())
                            {
                                var model = new Model()
                                {
                                    Name = reader["Name"].ToString(),
                                    Year = DateTime.Parse(reader["Year"].ToString()),
                                    Engine =
                                    new Engine()
                                    {
                                        Fuel = (FuelType)Enum.Parse(typeof(FuelType), reader["Fuel"].ToString()),
                                        HorsePower = int.Parse(reader["HorsePower"].ToString())
                                    },
                                    Manufacturer = new Manufacturer()
                                    {
                                        Name = reader["Manufacturer"].ToString()
                                    },
                                    Platform = new Platform()
                                    {
                                        PlatformType = (PlatformType)Enum.Parse(typeof(PlatformType), reader["PlatformType"].ToString()),
                                        NumberOfDoors = 4,
                                    }
                                };
                                Console.WriteLine(model.Name);
                                dealershipModels.Add(model);
                            }
                        }
                    }
                }
            }
            File.Delete(TempExcelFile);

            return dealershipModels;
        }

        public static ICollection<Car> GetAllCars(ICollection<Car> dealershipCars, IReadOnlyCollection<ZipArchiveEntry> carEntries)
        {

            foreach (var entry in carEntries)
            {
                var fileName = GetFileName(entry);

                using (var ms = new MemoryStream())
                {
                    var file = File.Create(TempExcelFile);
                    using (file)
                    {
                        CopyStream(entry.Open(), ms);
                        ms.WriteTo(file);
                    }
                }

                var connection = new OleDbConnection();
                OleDbConnectionStringBuilder connectionString = SetUpConnectionString();

                connection.ConnectionString = connectionString.ToString();

                using (connection)
                {
                    connection.Open();

                    var excelSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

                    var oleDbCommand = new OleDbCommand("SELECT * FROM [" + sheetName + "]", connection);

                    using (var adapter = new OleDbDataAdapter(oleDbCommand))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        using (var reader = dataSet.CreateDataReader())
                        {
                            while (reader.Read())
                            {
                                var car = new Car()
                                {
                                    Model = new Model()
                                    {
                                    Name = reader["Model"].ToString(),
                                    Engine = new Engine()
                                    {
                                        Fuel = (FuelType)Enum.Parse(typeof(FuelType), reader["Fuel"].ToString()),
                                        HorsePower = int.Parse(reader["HorsePower"].ToString())
                                    },
                                    Manufacturer = new Manufacturer()
                                    {
                                        Name = "mobile.bg"
                                    },
                                    Platform = new Platform()
                                    {
                                        PlatformType = (PlatformType)Enum.Parse(typeof(PlatformType), reader["PlatformType"].ToString())
                                    }
                                    },
                                    Year = DateTime.Parse(reader["Year"].ToString()),
                                    Dealer =
                                    new Dealer()
                                    {
                                        Name = reader["Dealer"].ToString(),
                                        Town = new Town()
                                        {
                                            Name = reader["DealerTown"].ToString()
                                        }
                                    },
                                    Order = new Order()
                                    {
                                        OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), reader["OrderStatus"].ToString()),
                                        Date = DateTime.Now
                                    },
                                    Price = decimal.Parse(reader["Price"].ToString())
                                };
                                Console.WriteLine(car.Model.Name);
                                dealershipCars.Add(car);
                            }
                        }
                    }
                }
            }
            File.Delete(TempExcelFile);

            return dealershipCars;
        }

        private static OleDbConnectionStringBuilder SetUpConnectionString()
        {
            return new OleDbConnectionStringBuilder
                    {
                        { "Provider", "Microsoft.ACE.OLEDB.12.0" },
                        { "Extended Properties", "Excel 12.0 XML" },
                        { "Data Source", TempExcelFile }
                    };
        }

        private static string GetFileName(ZipArchiveEntry entry)
        {
            var entryParts = entry.FullName.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var fileName = entry.FullName;
            if (entryParts.Length > 1)
            {
                fileName = entryParts[entryParts.Length - 1];
            }

            return fileName;
        }

        private static void CopyStream(Stream input, Stream output)
        {
            var buffer = new byte[2048];
            var read = input.Read(buffer, 0, buffer.Length);
            while (read > 0)
            {
                output.Write(buffer, 0, read);
                read = input.Read(buffer, 0, buffer.Length);
            }
        }
    }
}
