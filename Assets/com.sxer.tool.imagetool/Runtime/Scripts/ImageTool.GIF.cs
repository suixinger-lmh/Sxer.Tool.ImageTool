using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using UnityEngine;

namespace Sxer.Tool
{
    public static partial class ImageTool
    {
        public static int GetGifLength(byte[] gifdata)
        {
            using (MemoryStream stream = new MemoryStream(gifdata))
            {
                using (Image gifImage = Image.FromStream(stream))
                {
                    FrameDimension frame = new System.Drawing.Imaging.FrameDimension(gifImage.FrameDimensionsList[0]);
                    Debug.Log("gif帧数:" + gifImage.GetFrameCount(frame));
                    return gifImage.GetFrameCount(frame);
                }
            }
        }


        public static byte[] GetGifFrameIndex_PNG(byte[] gifdata,int frameIndex)
        {
            using (MemoryStream stream = new MemoryStream(gifdata))
            {
                using (Image gifImage = Image.FromStream(stream))
                {
                    FrameDimension frame = new System.Drawing.Imaging.FrameDimension(gifImage.FrameDimensionsList[0]);
                    if (frameIndex < gifImage.GetFrameCount(frame))
                    {
                        gifImage.SelectActiveFrame(frame, frameIndex);
                        Bitmap framBitmap = new Bitmap(gifImage.Width, gifImage.Height);
                        using (System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(framBitmap))
                        {
                            graphic.DrawImage(gifImage, System.Drawing.Point.Empty);
                        }

                        byte[] useByte = Bitmap2Byte(framBitmap, ImageFormat.Png);

                        frame = null;
                        framBitmap.Dispose();
                        framBitmap = null;

                        return useByte;
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// 获取gif的第几帧的图像
        /// </summary>
        /// <param name="gifdata">gif图片数据</param>
        /// <param name="frameIndex">帧数</param>
        /// <returns>jpg数据</returns>
        public static byte[] GetGifFrameIndex_JPG(byte[] gifdata, int frameIndex)
        {
            using (MemoryStream stream = new MemoryStream(gifdata))
            {
                using (Image gifImage = Image.FromStream(stream))
                {
                    FrameDimension frame = new System.Drawing.Imaging.FrameDimension(gifImage.FrameDimensionsList[0]);
                    if (frameIndex < gifImage.GetFrameCount(frame))
                    {
                        gifImage.SelectActiveFrame(frame, frameIndex);
                        Bitmap framBitmap = new Bitmap(gifImage.Width, gifImage.Height);
                        using (System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(framBitmap))
                        {
                            graphic.DrawImage(gifImage, System.Drawing.Point.Empty);
                        }

                        byte[] useByte = Bitmap2Byte(framBitmap, ImageFormat.Jpeg);

                        frame = null;
                        framBitmap.Dispose();
                        framBitmap = null;

                        return useByte;
                    }
                    return null;
                }
            }
        }


    }
}

