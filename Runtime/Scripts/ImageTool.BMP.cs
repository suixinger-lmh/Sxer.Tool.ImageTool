using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEngine;

namespace Sxer.Tool
{
    public static partial class ImageTool
    {
        public static byte[] BMP2PNG(byte[] bmpdata)
        {
            using (MemoryStream stream = new MemoryStream(bmpdata))
            {
                Bitmap bitmap;
                bitmap = new Bitmap(stream);
                return Bitmap2Byte(bitmap, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
        public static byte[] BMP2JPG(byte[] bmpdata)
        {
            using (MemoryStream stream = new MemoryStream(bmpdata))
            {
                Bitmap bitmap;
                bitmap = new Bitmap(stream);
                return Bitmap2Byte(bitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private static byte[] Bitmap2Byte(Bitmap bitmap, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // 将bitmap 以png格式保存到流中
                bitmap.Save(stream, imageFormat);
                // 创建一个字节数组，长度为流的长度
                byte[] data = new byte[stream.Length];
                // 重置指针
                stream.Seek(0, SeekOrigin.Begin);
                // 从流读取字节块存入data中
                stream.Read(data, 0, System.Convert.ToInt32(stream.Length));
                return data;
            }
        }



    }
}

