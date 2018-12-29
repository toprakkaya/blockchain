using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Toprakkaya
{
    public class Block
    {
        public int index { set;  get; }
        public DateTime timeStamp { set;  get; }
        public string data { set;  get; }
        public string previousHash { set;  get; }
        public string hash { set;  get; }

        public Block(DateTime timeStamp, string data)  
        {  
            this.timeStamp = timeStamp;  
            this.data = data;
        }  
  
        public string CalculateHash()
        {  
            SHA256 sha256 = SHA256.Create();  
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{timeStamp}-{previousHash ?? ""}-{data}");  
            byte[] outputBytes = sha256.ComputeHash(inputBytes);  
            return Convert.ToBase64String(outputBytes);  
        } 

    }
}