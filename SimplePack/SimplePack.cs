using System.Collections;
using Base58Check;

namespace simplepack
{

    public class SimplePack
    {
        private string head;
        private string foot;
        public SimplePack(string header, string footer){
            head = header;
            foot = footer;
            if (header.Length == 0 | footer.Length == 0){
                throw new InvalidSimplePackHeader();
            }
        }

        public byte[] decode(string data){
            if (! data.Contains(head) | ! data.Contains(foot)){ throw new InvalidSimplePackHeader();}

            string base58Data = "";
            for (int i = head.Length; i < data.Length - foot.Length; i++){
                base58Data += data[i];
            }
            return Base58CheckEncoding.Decode(base58Data);
        }

        public string encode(byte[] data){
            // OutOfMemoryException may be thrown for large payloads
            return head + Base58CheckEncoding.Encode(data) + foot;
        }

    }
}
