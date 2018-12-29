using System;
using System.Collections.Generic;
using System.Text;

namespace Toprakkaya
{
    public class Blockchain  
    {  
        public IList<Block> chain { set;  get; }  
    
        public Blockchain()  
        {  
            InitializeChain();  
            AddGenesisBlock();  
        }  
    
        public void InitializeChain()  
        {  
            chain = new List<Block>();  
        }  
    
        public Block CreateGenesisBlock()  
        {  
            return new Block(DateTime.Now, "{}");  
        }  
    
        public void AddGenesisBlock()  
        {  
            chain.Add(CreateGenesisBlock());  
        }  
        
        public Block GetLatestBlock()  
        {  
            return chain[chain.Count - 1];  
        }  
    
        public void AddBlock(Block block)  
        {  
            Block latestBlock = GetLatestBlock();  
            block.index = latestBlock.index + 1;  
            block.previousHash = latestBlock.hash;  
            block.hash = block.CalculateHash();  
            chain.Add(block);  
        }  

        public bool IsValid()
        {
            for (int i = 1; i < chain.Count; i++)
            {
                Block currentBlock = chain[i];
                Block previousBlock = chain[i - 1];
                if (currentBlock.hash != currentBlock.CalculateHash() ||
                    currentBlock.previousHash != previousBlock.hash)
                {
                    return false;
                }
            } 
            return true;
        }

    } 
}