using System;
using System.Collections.Generic;
using System.Drawing;
using ZXing;
using ZXing.QrCode;

namespace V2ray_Config_Pool.UI
{
    public  class QrCodeReader
    {
        public Bitmap Read_QrCode(string _QrPath)
        {

            QrCodeEncodingOptions options = new QrCodeEncodingOptions()
            {
                CharacterSet = "UTF-8",
                DisableECI = true,
                Width = 240,
                Height = 240
            };

     
            BarcodeWriter writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = options
            };

      
            return writer.Write(_QrPath);
        }
    }
}
