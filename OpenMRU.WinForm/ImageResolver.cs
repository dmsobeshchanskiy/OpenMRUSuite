using OpenMRU.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
                }
            }
            catch (Exception)
            {
                itemImage = Properties.Resources.icons8_file_64;
            }
            return itemImage;
        }

        private static Image GetImageFromFile(MRUItem item)
        {
            Icon iconForFile = Icon.ExtractAssociatedIcon(item.FilePath);
            return iconForFile.ToBitmap();
        }
    }
}
