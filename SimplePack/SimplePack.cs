using Base58Check;

namespace simplepack
{

    public class SimplePack
    {
        private string head;
        private string foot;
        public SimplePack(string header, string footer){
            // Specify human meaningful header/footer string
            head = header;
            foot = footer;
            // header footer need to be >= 1 len
            if (header.Length == 0 | footer.Length == 0){
                throw new InvalidSimplePackHeader();
            }
        }

        public byte[] decode(string data){
            // Not valid if it doesn't have head/foot
            if (! data.Contains(head) | ! data.Contains(foot)){ throw new InvalidSimplePackHeader();}
            string base58Data = "";

            // Extract the encoded part without header/footer
            for (int i = head.Length; i < data.Length - foot.Length; i++){
                base58Data += data[i];
            }
            // Will raise System.FormatException if checksum is not valid (or invalid footer/header)
            return Base58CheckEncoding.Decode(base58Data);
        }

        public string encode(byte[] data){
            // OutOfMemoryException may be thrown for large payloads
            return head + Base58CheckEncoding.Encode(data) + foot;
        }

    }
}
