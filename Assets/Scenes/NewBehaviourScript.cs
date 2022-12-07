using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sxer.Tool;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{
    Texture2D tex;
    int len;
    int nowlen = 0;
    byte[] pngbyte;
    byte[] gifByte;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(
        ImageTool.CheckImageFileExtension(@"C: \Users\DS\Desktop\郊庙歌辞 晋昭德成\郊庙歌辞 晋昭德成.jpg")
        );

        Debug.Log(
        ImageTool.CheckImageFileExtension(@"C:\Users\DS\Desktop\6.4.png")
        );

        pngbyte = ImageTool.BMP2JPG(File.ReadAllBytes(@"C: \Users\DS\Desktop\郊庙歌辞 晋昭德成\郊庙歌辞 晋昭德成.jpg"));
        Debug.Log(ImageTool.CheckImageFileExtension(pngbyte));


        //Debug.Log(ImageTool.CheckImageFileExtension(@"C: \Users\DS\Desktop\182c8cf2525_b48.gif"));
        //gifByte = File.ReadAllBytes(@"C: \Users\DS\Desktop\182c8cf2525_b48.gif");
        //len = ImageTool.GetGifLength(gifByte);

        //pngbyte = ImageTool.GetGifFrameIndex_JPG(gifByte, nowlen);




        tex = new Texture2D(512, 512);
        tex.LoadImage(pngbyte);




        ImageTool.ScaleTexture(tex,10,10);
       // ImageTool.ScaleTexture()


    }


    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(200, 200, 200, 200), tex);
    }

    // Update is called once per frame
    void Update()
    {
        //nowlen++;
        //if (nowlen >= len)
        //{
        //    nowlen = 0;
        //}
        //pngbyte = ImageTool.GetGifFrameIndex_JPG(gifByte, nowlen);
        //tex.LoadImage(pngbyte);
    }
}
