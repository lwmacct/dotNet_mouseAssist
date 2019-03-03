using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System;
using System.IO;
namespace Lwm.Md5 {
	public class Md5 {
		/// <summary>
		/// 取 Image md5
		/// </summary>
		/// <param name="image"></param>
		/// <returns></returns>
		public static string Get_imageMd5(Image image) {

			MD5 md5 = MD5.Create();
			byte[] retVal = md5.ComputeHash( ImageToByte( image ) );
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < retVal.Length; i++) {
				sb.Append( retVal[i].ToString( "x2" ) );
			}
			return sb.ToString();
		}
		/// <summary>
		/// 将Image转换成流数据，并保存为byte[] 
		/// </summary>
		/// <param name="imgPhoto"></param>
		/// <returns></returns>
		public static byte[] ImageToByte(System.Drawing.Image imgPhoto) {
			MemoryStream mstream = new MemoryStream();
			imgPhoto.Save( mstream, System.Drawing.Imaging.ImageFormat.Bmp );
			byte[] byData = new Byte[mstream.Length];
			mstream.Position = 0;
			mstream.Read( byData, 0, byData.Length ); mstream.Close();
			return byData;
		}
	}

}

