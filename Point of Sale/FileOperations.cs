
using Point_of_Sale.ErrorLogging;

/*
namespace Point_of_Sale
{
    internal class FileOperations
    {
        //Save Product Data to File
        public static void SaveProductsToFile(string path)
        {            
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (Product product in Product.Products)
                    {
                        string textLine = product.Name + "|" + product.Category + "|" + product.Description + "|" + product.Price;
                        sw.WriteLine(textLine);

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
        }


        //Read Products from file and save to Object
        public static void ReadProductsFromFile(string path)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                Product.Products.Clear();

                using (StreamReader sr = new StreamReader(path))
                {

                    while (sr.Peek() != -1)
                    {
                        string textLine = sr.ReadLine();
                        string[] details = textLine.Split('|');
                        if (details.Length == 4)
                        {
                            double price = double.Parse(details[3]);
                            Product product = new Product(details[0], details[1], details[2], price);
                            Product.Products.Add(product);
                        }
                        else
                        {
                            Logger.LogError($"Couldn't Add Product: {textLine}");            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}*/
