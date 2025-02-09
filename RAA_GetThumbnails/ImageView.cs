﻿//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Runtime.InteropServices;

//namespace RAA_GetThumbnails
//{
//	internal class ImageView
//	{
//		[DllImport("gdi32.dll")]
//		public static extern bool DeleteObject(IntPtr hObject);
//		public static List<ImageEntity> GetAllImagesData(List<string> listFamilyFiles)
//		{
//			try
//			{
//				// return images data
//				//int THUMB_SIZE = 256;
//				int THUMB_SIZE = 200;
//				List<ImageEntity> list = new List<ImageEntity>();
//				foreach (string familyFile in listFamilyFiles)
//				{
//					ImageEntity ie = new ImageEntity();
//					ie.ImagePath = familyFile;
//					ie.FileName = Path.GetFileNameWithoutExtension(familyFile);

//					//Bitmap thumbnail = WindowsThumbnailProvider.GetThumbnail(familyFile, THUMB_SIZE, THUMB_SIZE, ThumbnailOptions.None);

//					using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(THUMB_SIZE, THUMB_SIZE))
//					{
//						IntPtr hBitmap = WindowsThumbnailProvider.GetThumbnail(familyFile, THUMB_SIZE, THUMB_SIZE, ThumbnailOptions.None);

//						try
//						{
//							ie.ImageBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
//								hBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
//						}
//						finally
//						{
//							DeleteObject(hBitmap);
//						}
//					}

//					list.Add(ie);
//				}
//				return list;
//			}
//			catch (Exception ex)
//			{
//				throw new Exception(ex.Message);
//			}
//		}
//	}
//	public class ImageEntity
//	{
//		public string ImagePath { get; set; }
//		public string FileName { get; set; }
//		public System.Windows.Media.ImageSource ImageBitmap { get; set; }
//	}
//}
