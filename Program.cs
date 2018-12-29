using System;
using Newtonsoft.Json;

namespace Toprakkaya
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain coin = new Blockchain();  
            coin.AddBlock(new Block(DateTime.Now, "{from:John,to:Alice,amount:50}"));  
            coin.AddBlock(new Block(DateTime.Now, "{from:Alice,to:John,amount:25}"));  
            coin.AddBlock(new Block(DateTime.Now, "{from:Alice,to:John,amount:25}"));  
            
            Console.WriteLine(JsonConvert.SerializeObject(coin, Formatting.Indented));  
            Console.WriteLine($"Is Chain Valid: {coin.IsValid()}");

            Console.WriteLine($"Update amount to 100 for the first block");
            coin.chain[1].data = "{from:John,to:Alice,amount:100}";
            Console.WriteLine($"Is Chain Valid: {coin.IsValid()}");

            Console.WriteLine($"Update hash for the first block");
            coin.chain[1].hash = coin.chain[1].CalculateHash();
            Console.WriteLine($"Is Chain Valid: {coin.IsValid()}");
        }
    }
}
