using OpenMRU.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMRU.WinForm
{
    /// <summary>
    /// Resolver for MRU item image
    /// </summary>
    public static class ImageResolver
    {
        [DllImport("shell32.dll", EntryPoint = "FindExecutable")]
        private static extern long FindExecutableA(string lpFile, string lpDirectory, StringBuilder lpResult);
        /// <summary>
        /// Returns image for given MRU item
        /// </summary>
        /// <param name="item">MRU item</param>
        /// <param name="imagePath">path to image for to use with given MRU item</param>
        /// <returns>If path to image specified, than image from this path will be returned, otherwise method will try to get image from file itself.
        /// If all above fail - than image from resource file will be used</returns>
        public static Image GetImageForItem (MRUItem item, string imagePath)
        {
            Image itemImage;
            try
            {
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    itemImage = Image.FromFile(imagePath);
                } else
                {
                    itemImage = GetImageFromFile(item);
                    if (itemImage == null)
                    {
                        itemImage = GetAssociatedImage(item);
                    }
                }
            }
            catch (Exception)
            {
                itemImage = Properties.Resources.icons8_file_64;
            }
            return itemImage;
        }

        private static Image GetAssociatedImage(MRUItem item)
        {
            string executable = FindExecutable(item.FilePath);
            Icon iconForFile = Icon.ExtractAssociatedIcon(executable);
            return iconForFile.ToBitmap();
        }

        private static string FindExecutable(string fileName)
        {
            string executable = string.Empty;
            StringBuilder objResultBuffer = new StringBuilder(1024);
            long lngResult = FindExecutableA(fileName, string.Empty, objResultBuffer);
            if (lngResult >= 32)
            {
                executable = objResultBuffer.ToString();
            }
            return executable;
        }

        private static Image GetImageFromFile(MRUItem item)
        {
            Image image;
            try
            {
                Icon iconForFile = Icon.ExtractAssociatedIcon(item.FilePath);
                image = iconForFile.ToBitmap();
            }
            catch(Exception)
            {
                image = null;
            }
            return image;
        }
    }
}
