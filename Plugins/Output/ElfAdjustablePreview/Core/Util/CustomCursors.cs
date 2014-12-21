﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ElfAdjustablePreview.Core.Controllers;

namespace ElfAdjustablePreview.Core.Util
{
	public class CustomCursors
	{
		#region [ Declares ]

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

		[DllImport("user32.dll")]
		private static extern IntPtr CreateIconIndirect(ref IconInfo icon);

		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr handle);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		extern static bool DestroyIcon(IntPtr handle);

		#endregion [ Declares ]

		#region [ Static Variables ]

		public static IntPtr ʃCreatedCursorPtr = IntPtr.Zero;
		public static Cursor ʃMemoryCursor = null;

		#endregion [ Static Variables ]

		/// <summary>
		/// Create a cursor from a bitmap
		/// </summary>
		/// <param name="bmp">Bitmap used to create the cursor.</param>
		/// <param name="xHotSpot">X position of the hotspot</param>
		/// <param name="yHotSpot">Y position of the hotspot</param>
		public static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
		{
			if (bmp == null)
				return null;

			IntPtr ptr = bmp.GetHicon();
			IconInfo tmp = new IconInfo();
			GetIconInfo(ptr, ref tmp);
			tmp.xHotspot = xHotSpot;
			tmp.yHotspot = yHotSpot;
			tmp.fIcon = false;

			ʃCreatedCursorPtr = CreateIconIndirect(ref tmp);

			if (tmp.hbmColor != IntPtr.Zero)
				DeleteObject(tmp.hbmColor);
			if (tmp.hbmMask != IntPtr.Zero)
				DeleteObject(tmp.hbmMask);

			return new Cursor(ʃCreatedCursorPtr);
		}

		/// <summary>
		/// Destroys a Cursor created with the CreateIconIndirect call
		/// </summary>
		/// <param name="handle">Object Handle</param>
		public static void DestroyCreatedCursor(IntPtr handle)
		{
			if (handle != IntPtr.Zero)
				DestroyIcon(handle);
		}

		/// <summary>
		/// Destroys a Cursor created with the CreateIconIndirect call
		/// </summary>
		/// <param name="cursor">Object to destroy.</param>
		public static void DestroyCreatedCursor(Cursor cursor)
		{
			try
			{
				if (cursor == null)
					return;
				if (cursor.Handle != IntPtr.Zero)
					DestroyIcon(cursor.Handle);
			}
			catch (ObjectDisposedException)
			{ }
		}

		/// <summary>
		/// Create a cursor from a cursor file in the program resources.
		/// </summary>
		/// <param name="cursorBytes">Byte array of the cursor</param>
		/// <returns></returns>
		public static Cursor MemoryCursor(byte[] cursorBytes)
		{
			using (var memoryStream = new MemoryStream(cursorBytes))
			{
				ʃMemoryCursor = new Cursor(memoryStream);
				return ʃMemoryCursor;
			}
		}

		/// <summary>
		/// Cursor that is round or square, radius defined by the nibSize and elements within Workshop
		/// </summary>
		public static Cursor NibCursor(float nibSize, bool isRound)
		{
			float Diameter = 1;

			Diameter = nibSize * Workshop.Instance.Profile.Scaling.CellScaleF;

			int Size = Convert.ToInt32(Math.Ceiling(Diameter + 2));
			Bitmap CursorBmp = new Bitmap(Size, Size);
			Graphics g = Graphics.FromImage(CursorBmp);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.Clear(Color.Transparent);
			Pen CursorPen = null;

			if (isRound)
			{
				CursorPen = new Pen(Color.AntiqueWhite, 1.8f);
				g.DrawEllipse(CursorPen, 1, 1, Diameter, Diameter);
			}
			else
			{
				CursorPen = new Pen(Color.AntiqueWhite, 1f);
				g.DrawRectangle(CursorPen, 1, 1, Diameter, Diameter);
			}

			CursorPen.Dispose();
			g.Dispose();

			Diameter /= 2;
			Size = Convert.ToInt32(Math.Ceiling(Diameter)) + 1;
			return CreateCursor(CursorBmp, Size, Size);
		}

		struct IconInfo
		{
			public bool fIcon;
			public int xHotspot;
			public int yHotspot;
			public IntPtr hbmMask;
			public IntPtr hbmColor;
		}
	}
}
