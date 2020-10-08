
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StockAnalyzer.Data
{
    public class FileOperations
    {
        public List<StockPrice> GetAllStocks(UnitOfWork unitOfWork)
        {
            List<StockPrice> resultSet = new List<StockPrice>();
            string[] files = Directory.GetFiles(@"E:\stocks");
            if(files != null && files.Length > 0)
            {
                foreach (string filePath in files)
                {
                    var fileText = ReadFile(filePath);
                    var stocks = GetStockPrices(filePath,fileText);
                    unitOfWork.StockPrices.InsertAll(stocks);
                    unitOfWork.Commit();
                }
            }
            files = Directory.GetFiles(@"E:\etfs");
            if (files != null && files.Length > 0)
            {
                foreach (string filePath in files)
                {
                    var fileText = ReadFile(filePath);
                    var stocks = GetStockPrices(filePath, fileText);
                    unitOfWork.StockPrices.InsertAll(stocks);
                    unitOfWork.Commit();
                }
            }
            return resultSet;
        }
        public List<Company> GetCompanies(string [] fileText)
        {
            char separator = ',';
            List<Company> companies = new List<Company>();
            foreach (string item in fileText.Skip(1))
            {
                string [] properties = item.Split(separator);
                if(properties != null)
                {
                    Company company = new Company();
                    company.Symbol = properties[0];
                    company.CompanyName = properties[1];
                    company.Exchange = properties[2];
                    company.Industry = properties[3];
                    company.Website = properties[4];
                    company.Description = properties[5];
                    company.CEO = properties[6];
                    company.IssueType = properties[7];
                    company.Sector = properties[8];
                    companies.Add(company);
                }
            }
            return companies;
        }
        public List<StockPrice> GetStockPrices(string[] fileText)
        {
            char[] separators = new char []{ ',' };
            List<StockPrice> stockPrices = new List<StockPrice>();
            foreach (string line in fileText.Skip(1))
            {
                string [] properties = line.Split(separators);
                if(properties != null)
                {
                    StockPrice stockPrice = new StockPrice();
                    stockPrice.Ticker = properties[0];
                    if (DateTime.TryParse(properties[1], out DateTime tradeDate))
                    {
                        stockPrice.TradeDate = tradeDate;
                    }
                    if(decimal.TryParse(properties[2], out decimal open))
                    {
                        stockPrice.Open = open;
                    }
                    if (decimal.TryParse(properties[3], out decimal high))
                    {
                        stockPrice.High = high;
                    }
                    if (decimal.TryParse(properties[4], out decimal low))
                    {
                        stockPrice.Low = low;
                    }
                    if (decimal.TryParse(properties[5], out decimal close))
                    {
                        stockPrice.Close = close;
                    }
                    if(int.TryParse(properties[6], out int volume))
                    {
                        stockPrice.Volume = volume;
                    }
                    //if(decimal.TryParse(properties[7], out decimal change))
                    //{
                    //    stockPrice.Change = change;
                    //}
                    //if(decimal.TryParse(properties[8], out decimal changePercent))
                    //{
                    //    stockPrice.ChangePercent = changePercent;
                    //}
                    stockPrices.Add(stockPrice);
                }
            }
            return stockPrices;
        }
        public List<StockPrice> GetStockPrices(string filename, string[] fileText)
        {
            char[] separators = new char[] { ',' };
            List<StockPrice> stockPrices = new List<StockPrice>();
            foreach (string line in fileText.Skip(1))
            {
                string[] properties = line.Split(separators);
                if (properties != null)
                {
                    StockPrice stockPrice = new StockPrice();
                    stockPrice.Ticker = GetFilename(filename);
                    if (DateTime.TryParse(properties[0], out DateTime tradeDate))
                    {
                        stockPrice.TradeDate = tradeDate;
                    }
                    if (decimal.TryParse(properties[1], out decimal open))
                    {
                        stockPrice.Open = open;
                    }
                    if (decimal.TryParse(properties[2], out decimal high))
                    {
                        stockPrice.High = high;
                    }
                    if (decimal.TryParse(properties[3], out decimal low))
                    {
                        stockPrice.Low = low;
                    }
                    if (decimal.TryParse(properties[4], out decimal close))
                    {
                        stockPrice.Close = close;
                    }
                    if (decimal.TryParse(properties[5], out decimal adjclose))
                    {
                        stockPrice.AdjClose = adjclose;
                    }
                    if (int.TryParse(properties[6], out int volume))
                    {
                        stockPrice.Volume = volume;
                    }                    
                    stockPrices.Add(stockPrice);
                }
            }
            return stockPrices;
        }
        public string[] ReadFile(string filepath)
        {
            Console.WriteLine(filepath);
            return File.ReadAllLines(filepath);            
        }
        public string GetFilename(string filePath)
        {
            var backslashSplits = filePath.Split('\\');
            int numberOfSplits = backslashSplits.Length;
            string filenameSplit = backslashSplits[numberOfSplits - 1];
            return filenameSplit.Split('.')[0];
        }
    }
}
