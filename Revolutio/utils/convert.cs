#region Namespace Inclusions
using System;
using System.Linq;
using System.Text;
#endregion

namespace convert_all
{

    public class convert
    {


        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        public static byte[] HexStringToByteArray(string s)
        {
            
                s = s.Replace(" ", "");
                byte[] buffer = new byte[s.Length / 2];
                for (int i = 0; i < s.Length; i += 2)
                    buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
                return buffer;
            
        }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }

        public static string ConvertStringToHex(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        }

        public static string ConvertHexToString(string HexValue)
        {
            //string StrValue = "";
            //while (HexValue.Length > 0)
            //{
            //    StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
            //    HexValue = HexValue.Substring(2, HexValue.Length - 2);
            //}
            //return StrValue;
            
            if (HexValue == null)
                throw new ArgumentNullException("hexString");
            if (HexValue.Length % 2 != 0)
                throw new ArgumentException("hexString must have an even length", "hexString");
            var bytes = new byte[HexValue.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                string currentHex = HexValue.Substring(i * 2, 2);
                bytes[i] = Convert.ToByte(currentHex, 16);
            }
           
            return System.Text.Encoding.ASCII.GetString(bytes);

        }

        //convert from two byte unicode [page number, char on page].
        public static string ConvertFromUnicode(string str)

        {
            char c = ' ';
            string rtstr = "";

            for (int i = 0; i < str.Length; i += 4)
            {
                string str1 = str.Substring(i, 4);
                c = (char)Int16.Parse(str1, System.Globalization.NumberStyles.HexNumber);
                rtstr += c;
            }
            return rtstr;

        }

        public static string ConverttoUnicode(string str)
        {

            char c = ' ';
            
            return ((int)c).ToString("X4");
        }


        public static string ConvertStringToUnicode(char[] characters, int end_null)

        {
            string rtstr = "";

            for (int i = 0; i < characters.Length; i += 1)
            {
                rtstr += ((int)characters[i]).ToString("X4");
            }

            if (end_null == 1)
            {
                return rtstr + "0000"; //NULL terminated strings
            }
            else
            {
                return rtstr;
            }
            

        }

        

        public static string convert_ASCII_to_unicode(string input)
        {
            //------------------------------------------------------------------------
            // Convert to 2 byte Unicode
            // The return is always 2 bytes.
            //-----------------------------------------------------------------------


            StringBuilder ubuilder = new StringBuilder();

            char[] stringChars = Encoding.Unicode.GetChars(Encoding.Unicode.GetBytes(input));

            Array.ForEach(stringChars, c => ubuilder.AppendFormat("{0:x4} ", (int)c));

            return ubuilder.ToString();
        }


        public static string convert_ASCII_to_utf8(string input)
        {
            //------------------------------------------------------------------------
            // Convert to UTF8
            // The return will be either 1 byte, 2 bytes or 3 bytes.
            //-----------------------------------------------------------------------

            UTF8Encoding utf8 = new UTF8Encoding();
            StringBuilder builder = new StringBuilder();

            for (int text_index = 0; text_index < input.Length; text_index++) //do one char at a time

            {
                byte[] encodedBytes = utf8.GetBytes(input.Substring(text_index, 1));

                for (int index = 0; index < encodedBytes.Length; index++)

                {
                    builder.AppendFormat("{0}", Convert.ToString(encodedBytes[index], 16).PadLeft(2, '0'));
                }
            }

            return builder.ToString();
        }

        public static string convert_UTF8_to_ASCII(string input)
        {
            //split into 2 char chunks, then into bytes, then into string.
            Encoding utf8 = Encoding.UTF8;
            string utext = input.Replace(" ", ""); //get string and remove spaces.
            return Encoding.UTF8.GetString(
                    Enumerable.Range(0, utext.Length / 2)
                        .Select(i => Convert.ToByte(utext.Substring(i * 2, 2), 16))
                        .ToArray());
        }

        public static string convert_Unicode_to_ASCII(string input)
        {
            String utext = input.Replace(" ", ""); //get string and remove spaces.

            char c = ' ';

            string rtstr = "";
            for (int i = 0; i < utext.Length; i += 4)
            {
                string str1 = utext.Substring(i, 4);
                c = (char)Int16.Parse(str1, System.Globalization.NumberStyles.HexNumber);
                rtstr += c;
            }

            return rtstr;
        }

        public static string dectohex(string data)
        {

            float val = float.Parse(data);

            byte[] b = BitConverter.GetBytes(val);

            Array.Reverse(b);

            StringBuilder sb = new StringBuilder();

            foreach (byte by in b)
                sb.Append(by.ToString("X2"));

            return sb.ToString();

        }


        public static string hextodec(string data)
        {
            uint num = uint.Parse(data, System.Globalization.NumberStyles.AllowHexSpecifier);

            byte[] floatVals = BitConverter.GetBytes(num);
            float f = BitConverter.ToSingle(floatVals, 0);

            return f.ToString();
        }
         
    }
}
          