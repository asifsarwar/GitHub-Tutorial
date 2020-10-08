using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockAnalyzer.Data;
using Newtonsoft.Json;

namespace SaveDataToSQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SaveToSql();
            //ReadDataFromSQL();
            Console.ReadLine();
        }
        public static void ReadDataFromSQL()
        {
            try
            {
                StockAnalyzerDbContext context = new StockAnalyzerDbContext();
                UnitOfWork UnitOfWork = new UnitOfWork(context);
                IEnumerable<Company> companies = UnitOfWork.Companies.GetAll();
                foreach (var item in companies)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                }
                
                UnitOfWork.Commit();
                Console.WriteLine("Exiting program");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void SaveToSql()
        {
            try
            {
                StockAnalyzerDbContext context = new StockAnalyzerDbContext();
                UnitOfWork UnitOfWork = new UnitOfWork(context);
                FileOperations operation = new FileOperations();
                var resultset =  operation.GetAllStocks(UnitOfWork);
                //UnitOfWork.StockPrices.InsertAll(resultset);
                //string filepath = @"E:\CompanyData.csv";
                //var data = operation.ReadFile(filepath);
                //List<Company> companies = operation.GetCompanies(data);
                //UnitOfWork.Companies.InsertAll(companies);
                //filepath = @"E:\StockPrices_Small.csv";
                //data = operation.ReadFile(filepath);
                //List<StockPrice> stockPrices = operation.GetStockPrices(data);
                //UnitOfWork.StockPrices.InsertAll(stockPrices);
                

                //UnitOfWork.Commit();
                Console.WriteLine("Exiting program");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
       
    }
}
