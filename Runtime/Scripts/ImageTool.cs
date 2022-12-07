using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Sxer.Tool
{
    public static partial class ImageTool
    {
        public const string Head2Byte_PNG = "13780";
        public const string Head2Byte_JPG = "255216";
        public const string Head2Byte_BMP = "6677";
        public const string Head2Byte_GIF = "7173";


        /// <summary>
        /// 检测当前图片文件格式
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static ImageFileExtension CheckImageFileExtension(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            string fileType = string.Empty;
            try
            {
                byte data = br.ReadByte();
                fileType += data.ToString();
                data = br.ReadByte();
                fileType += data.ToString();
              
                return GetImageType(fileType);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    br.Close();
                    fs.Close();
                }
            }
        }

        public static ImageFileExtension CheckImageFileExtension(byte[] data)
        {
            string fileType = string.Empty;
            try
            {
                fileType = data[0].ToString() + data[1].ToString();

                return GetImageType(fileType);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        static ImageFileExtension GetImageType(string headbyte)
        {
            switch (headbyte)
            {
                case Head2Byte_PNG:
                    return ImageFileExtension.PNG;
                case Head2Byte_JPG:
                    return ImageFileExtension.JPG;
                case Head2Byte_BMP:
                    return ImageFileExtension.BMP;
                case Head2Byte_GIF:
                    return ImageFileExtension.GIF;
            }
            return ImageFileExtension.VALIDFILE;
        }


    }


   



    public enum ImageFileExtension
    {
        BMP = 6677,
        JPG = 255216,
        PNG = 13780,
        GIF = 7173,
        VALIDFILE = 9999999
        //SWF = 6787,
        //RAR = 8297,
        //ZIP = 8075,
        //_7Z = 55122,

        // 255216 jpg; 

        // 7173 gif; 

        // 6677 bmp, 

        // 13780 png; 

        // 6787 swf 

        // 7790 exe dll, 

        // 8297 rar 

        // 8075 zip 

        // 55122 7z 

        // 6063 xml 

        // 6033 html 

        // 239187 aspx 

        // 117115 cs 

        // 119105 js 

        // 102100 txt 

        // 255254 sql  

    }

}


