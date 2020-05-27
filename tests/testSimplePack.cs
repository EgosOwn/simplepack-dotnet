using NUnit.Framework;
using System.Text;
using Base58Check;
using simplepack;


namespace tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRequireHeader(){
            string header = "";
            string footer = " test-footer";
            byte[] expected_result = UTF8Encoding.UTF8.GetBytes("hello world");
            string encoded = header + Base58CheckEncoding.Encode(expected_result) + footer;
            try{
                SimplePack packer = new SimplePack(header, footer);
            }
            catch(InvalidSimplePackHeader){
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void TestRequireFooter(){
            string header = "test-header";
            string footer = "";
            byte[] expected_result = UTF8Encoding.UTF8.GetBytes("hello world");
            string encoded = header + Base58CheckEncoding.Encode(expected_result) + footer;
            try{
                SimplePack packer = new SimplePack(header, footer);
            }
            catch(InvalidSimplePackHeader){
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void TestInvalidChecksum(){
            byte[] expected_result = UTF8Encoding.UTF8.GetBytes("hello world");
            string header = "header-part ";
            string footer = " footer part.";
            string encoded = header + Base58CheckEncoding.EncodePlain(expected_result) + footer;
            SimplePack packer = new SimplePack(header, footer);
            try{
                packer.decode(encoded);
            }
            catch(System.FormatException){return;}
            Assert.Fail(); // Did not catch no checksum, fail

        }

        [Test]
        public void TestDecode()
        {
            byte[] expected_result = UTF8Encoding.UTF8.GetBytes("hello world");
            string header = "header-part ";
            string footer = " footer part.";
            string encoded = header + Base58CheckEncoding.Encode(expected_result) + footer;
            SimplePack packer = new SimplePack(header, footer);
            Assert.AreEqual(packer.decode(encoded),
                            expected_result);
        }

        [Test]
        public void TestEncode()
        {
            byte[] message = UTF8Encoding.UTF8.GetBytes("hello world");
            string expected_header = "header-part ";
            string expected_footer = " footer part.";
            string expected_result = expected_header + Base58CheckEncoding.Encode(message) + expected_footer;
            SimplePack packer = new SimplePack(expected_header, expected_footer);
            string actual_result = packer.encode(message);
            Assert.AreEqual(actual_result, expected_result);
        }
    }
}