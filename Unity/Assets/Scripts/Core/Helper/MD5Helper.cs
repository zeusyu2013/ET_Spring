using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ET
{
	public static class MD5Helper
	{
		public static string FileMD5(string filePath)
		{
			byte[] retVal;
            using (FileStream file = new FileStream(filePath, FileMode.Open))
            {
	            MD5 md5 = MD5.Create();
				retVal = md5.ComputeHash(file);
			}
			return retVal.ToHex("x2");
		}

		public static string SigntureMD5(string signture)
		{
			MD5 md5 = MD5.Create();
			byte[] retVal = md5.ComputeHash(Encoding.UTF8.GetBytes(signture));
			return retVal.ToHex("x2");
		}
	}
}
