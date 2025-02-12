
namespace ReportGenerator
{
    class QuarterlyIncomeReport
    {
        static void Main(string[] args)
        {
            // create a new instance of the class
            QuarterlyIncomeReport report = new QuarterlyIncomeReport();

            // call the GenerateSalesData method
            SalesData[] salesData = GenerateSalesData();

            // call the QuarterlySalesReport method
            report.QuarterlySalesReport(salesData);

        }

        public void QuarterlySalesReport(SalesData[] salesData)
        {
            // create a dictionary to store the quarterly sales data
            Dictionary<string, double> quarterlySales = new Dictionary<string, double>();

            // iterate through the sales data
            foreach (SalesData data in salesData)
            {
                // calculate the total sales for each quarter
                string quarter = GetQuarter(data.DateSold.Month);
                double totalSales = data.QuantitySold * data.UnitPrice;

                if (quarterlySales.ContainsKey(quarter))
                {
                    quarterlySales[quarter] += totalSales;
                }
                else
                {
                    quarterlySales.Add(quarter, totalSales);
                }
            }

            // display the quarterly sales report
            Console.WriteLine("Quarterly Sales Report");
            Console.WriteLine("----------------------");
            foreach (KeyValuePair<string, double> quarter in quarterlySales)
            {
                Console.WriteLine(quarter.Key + ": $" + quarter.Value);
            }
        }

        public string GetQuarter(int month)
        {
            if (month >= 1 && month <= 3)
            {
                return "Q1";
            }
            else if (month >= 4 && month <= 6)
            {
                return "Q2";
            }
            else if (month >= 7 && month <= 9)
            {
                return "Q3";
            }
            else
            {
                return "Q4";
            }
        }

        // public struct SalesData. Include the following fields: date sold, department name, product ID, quantity sold, unit price
        public struct SalesData
        {
            public DateOnly DateSold;
            public string DepartmentName;
            public int ProductID;
            public int QuantitySold;
            public double UnitPrice;
        }

        /* the GenerateSalesData method returns 1000 SalesData records. It assigns random values to each field of the data structure */
        public static SalesData[] GenerateSalesData()
        {
            SalesData[] salesData = new SalesData[1000];
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                salesData[i].DateSold = new DateOnly(2023, random.Next(1, 13), random.Next(1, 29));
                salesData[i].DepartmentName = "Department " + random.Next(1, 10);
                salesData[i].ProductID = random.Next(1, 100);
                salesData[i].QuantitySold = random.Next(1, 100);
                salesData[i].UnitPrice = random.Next(1, 1000);
            }
            return salesData;
        }
    }
}