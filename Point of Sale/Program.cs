using Point_of_Sale;

Console.WriteLine("Here are the available products:");
Console.WriteLine(Product.DisplayAllProducts());

Console.WriteLine("Which product would you like to purchase? Enter 1-12");
int userInput = int.Parse(Console.ReadLine());
string userChoice = Product.DisplayProduct(userInput - 1);
Console.WriteLine(userChoice);


