using System;
using Xunit;
using Toprakkaya;

namespace test
{
    public class BlockchainTests
    {
        private Blockchain coin;

        public BlockchainTests() {
            initTestData();
        }

        private void initTestData() {
            coin = new Blockchain();  
            coin.AddBlock(new Block(DateTime.Now, "{from:John,to:Alice,amount:50}"));  
            coin.AddBlock(new Block(DateTime.Now, "{from:Alice,to:John,amount:25}"));  
            coin.AddBlock(new Block(DateTime.Now, "{from:Alice,to:John,amount:25}"));
        }

        [Fact]
        public void ChainValid()
        {
            Assert.True(coin.IsValid());
        }

        [Fact]
        public void ChainNotValidAfterChangingData()
        {
            coin.chain[1].data = "{from:John,to:Alice,amount:100}";
            Assert.False(coin.IsValid());
        }

        [Fact]
        public void ChainNotValidAfterChangingHash()
        {
            coin.chain[1].hash = coin.chain[0].hash;
            Assert.False(coin.IsValid());
        }
    }
}