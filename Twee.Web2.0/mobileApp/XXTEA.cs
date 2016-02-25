using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace TweebaaWebApp2.mobileApp
{
    public enum XXTEAMode
    {
        Encrypt,
        Decrypt
    }

    public class XXTEA
    {
        public static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }

        public static string DecodeString(string sEncrypt)
        {
           // byte[] bytBase64 = FromHex(sEncrypt);
            //byte[] base64EncodedBytes = System.Convert.FromBase64String(bytBase64.ToString());
            //replace all space to +
            string[] s1 = sEncrypt.Split(' ');
            sEncrypt = "";
            for (int i = 0; i < s1.Length; i++)
            {
                sEncrypt = sEncrypt + s1[i] + "+";
            }
            //remove last one
            sEncrypt = sEncrypt.Substring(0, sEncrypt.Length - 1);

            //string decodedString = Encoding.GetEncoding("ISO-8859-1").GetString(bytBase64, 0, bytBase64.Length);
            //Encoding e = Encoding.GetEncoding("ISO-8859-1");
            string key="2012@tweebaa!2015*&%^";
            //Byte[] b = _Decrypt(e.GetBytes(sEncrypt), e.GetBytes(key));

            string decodedString = Decrypt(sEncrypt, key);
            decodedString = decodedString.Substring(10, decodedString.Length - 10);
            return decodedString;
        }
        #region 算法实现

        private static Byte[] _Encrypt(Byte[] Data, Byte[] Key)
        {
            if (Data.Length == 0)
            {
                return Data;
            }

            return _ToByteArray(_Encrypt(_ToUInt32Array(Data, true), _ToUInt32Array(Key, false)), false);
        }

        private static Byte[] _Decrypt(Byte[] Data, Byte[] Key)
        {
            if (Data.Length == 0)
            {
                return Data;
            }

            return _ToByteArray(_Decrypt(_ToUInt32Array(Data, false), _ToUInt32Array(Key, false)), true);
        }

        private static UInt32[] _Encrypt(UInt32[] v, UInt32[] k)
        {
            Int32 n = v.Length - 1;
            if (n < 1)
            {
                return v;
            }

            if (k.Length < 4)
            {
                UInt32[] Key = new UInt32[4];
                k.CopyTo(Key, 0);
                k = Key;
            }

            UInt32 z = v[n], y = v[0], delta = 0x9E3779B9, sum = 0, e;
            Int32 p, q = 6 + 52 / (n + 1);

            while (q-- > 0)
            {
                sum = unchecked(sum + delta);
                e = sum >> 2 & 3;
                for (p = 0; p < n; p++)
                {
                    y = v[p + 1];
                    z = unchecked(v[p] += (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z));
                }
                y = v[0];
                z = unchecked(v[n] += (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z));
            }

            return v;
        }

        private static UInt32[] _Decrypt(UInt32[] v, UInt32[] k)
        {
            Int32 n = v.Length - 1;

            if (n < 1)
            {
                return v;
            }

            if (k.Length < 4)
            {
                UInt32[] Key = new UInt32[4];
                k.CopyTo(Key, 0);
                k = Key;
            }

            UInt32 z = v[n], y = v[0], delta = 0x9E3779B9, sum, e;
            Int32 p, q = 6 + 52 / (n + 1);
            sum = unchecked((UInt32)(q * delta));

            while (sum != 0)
            {
                e = sum >> 2 & 3;
                for (p = n; p > 0; p--)
                {
                    z = v[p - 1];
                    y = unchecked(v[p] -= (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z));
                }
                z = v[n];
                y = unchecked(v[0] -= (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z));
                sum = unchecked(sum - delta);
            }

            return v;
        }

        private static UInt32[] _ToUInt32Array(Byte[] Data, Boolean IncludeLength)
        {
            Int32 n = (((Data.Length & 3) == 0) ? (Data.Length >> 2) : ((Data.Length >> 2) + 1));
            UInt32[] Result;

            if (IncludeLength)
            {
                Result = new UInt32[n + 1];
                Result[n] = (UInt32)Data.Length;
            }
            else
            {
                Result = new UInt32[n];
            }

            n = Data.Length;
            for (Int32 i = 0; i < n; i++)
            {
                Result[i >> 2] |= (UInt32)Data[i] << ((i & 3) << 3);
            }

            return Result;
        }

        private static Byte[] _ToByteArray(UInt32[] Data, Boolean IncludeLength)
        {
            Int32 n;

            if (IncludeLength)
            {
                n = (Int32)Data[Data.Length - 1];
            }
            else
            {
                n = Data.Length << 2;
            }

            Byte[] Result = new Byte[n];
            for (Int32 i = 0; i < n; i++)
            {
                Result[i] = (Byte)(Data[i >> 2] >> ((i & 3) << 3));
            }

            return Result;
        }

        #endregion

        #region 使用方法

        /// <summary> 
        /// Description：加密字符串
        /// Author：小笨蛋
        /// </summary>
        /// <param name=\"str\">传入的明文</param>
        /// <param name=\"key\">密钥仅对对称算法有效</param>
        /// <returns>返回密文</returns>
        public static string Encrypt(string str, string key = "sandglass")
        {
            Encoding e = Encoding.UTF8;
            Byte[] b = _Encrypt(e.GetBytes(str), e.GetBytes(key));
            return Convert.ToBase64String(b);
        }

        /// <summary> 
        /// Description：解密字符串
        /// Author：小笨蛋
        /// </summary>
        /// <param name=\"str\">传入的加密字符串</param>
        /// <param name=\"key\">密钥仅对对称算法有效</param>
        /// <returns>返回明文</returns>
        public static string Decrypt(string str, string key = "sandglass")
        {
            var encoding = Encoding.GetEncoding("ISO-8859-1");
            var strDecrypt = string.Empty;

            try
            {
                strDecrypt = encoding.GetString(_Decrypt(Convert.FromBase64String(str), encoding.GetBytes(key)));
            }
            catch
            {
                return string.Empty;
            }
            return strDecrypt;
        }

        #endregion
    }
    
}