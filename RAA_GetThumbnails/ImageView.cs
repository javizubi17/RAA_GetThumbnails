using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace RAA_GetThumbnails
{
	internal class ImageView
	{
		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObject);
		public static List<ImageEntity> GetAllImagesData(List<string> listFamilyFiles)
		{

            //// this is a variable for the Revit application
            //UIApplication uiapp = commandData.Application;
            //// this is a variable for the current Revit model
            //Document doc = uiapp.ActiveUIDocument.Document;

            try
			{
				// return images data
				//int THUMB_SIZE = 256;
				int THUMB_SIZE = 200;
				List<ImageEntity> list = new List<ImageEntity>();
				foreach (string familyFile in listFamilyFiles)
				{
					ImageEntity ie = new ImageEntity();
					ie.ImagePath = familyFile;
					ie.FileName = Path.GetFileNameWithoutExtension(familyFile);

                    //Bitmap thumbnail = WindowsThumbnailProvider.GetThumbnail(familyFile, THUMB_SIZE, THUMB_SIZE, ThumbnailOptions.None);

                    //FilteredElementCollector collector = new FilteredElementCollector(doc);

                    //collector.OfClass(typeof(FamilyInstance));

                    using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(THUMB_SIZE, THUMB_SIZE))
                    {
                        IntPtr hBitmap = WindowsThumbnailProvider.GetThumbnail(familyFile, THUMB_SIZE, THUMB_SIZE, ThumbnailOptions.None);

						try
						{
							ie.ImageBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
								hBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
						}
						//try
						//{
						//                      foreach (FamilyInstance fi in collector)
						//                      {
						//                          Debug.Assert(null != fi.Category, "expected family instance to have a valid category");
						//                          ElementId typeId = fi.GetTypeId();

						//                          ElementType type = doc.GetElement(typeId) as ElementType;

						//                          System.Drawing.Size imgSize = new System.Drawing.Size(200, 200);

						//                          Bitmap image = type.GetPreviewImage(imgSize);

						//                          var codeBitmap = new Bitmap(image);
						//                          System.Drawing.Image _image = (System.Drawing.Image)codeBitmap;

						//                          ie.ImageBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, 
						//                              IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

						//                      }
						//                  }
						finally
                        {
                            DeleteObject(hBitmap);
                        }
                    }

                    list.Add(ie);
				}
				return list;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}

    public class ImageEntity
	{
		public string ImagePath { get; set; }
		public string FileName { get; set; }
		public System.Windows.Media.ImageSource ImageBitmap { get; set; }
        public virtual Bitmap elementTypeBitmap { get; set; }
    }
}
