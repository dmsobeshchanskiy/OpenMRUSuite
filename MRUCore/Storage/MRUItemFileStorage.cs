using MRUCore;
using MRUCore.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MRUCore.Storage
{
    /// <summary>
    /// MRU items storage that uses .xml file  
    /// </summary>
    public class MRUItemFileStorage : IMRUItemStorage
    {
        /// <summary>
        /// Read MRU items from xml file
        /// </summary>
        /// <returns>List of MRU items</returns>
        public IEnumerable<MRUItem> ReadMRUItems()
        {
            Stream deseralizationStream = null;
            try
            {
                deseralizationStream = File.OpenRead(storageFilePath);
                XmlSerializer serializer = new XmlSerializer(typeof(MRUItemsHolder));
                MRUItemsHolder holder = serializer.Deserialize(deseralizationStream) as MRUItemsHolder;
                return holder.Items;
            }
            catch (Exception ex)
            {
                if (deseralizationStream != null)
                {
                    deseralizationStream.Close();
                }
                throw new Exception(string.Format("MRUItemFileStorage: Fail to read object from storage!\r\n{0}", ex.Message));
            }
            finally
            {
                if (deseralizationStream != null)
                {
                    deseralizationStream.Close();
                }
            }
        }

        /// <summary>
        /// Save MRU items to xml file
        /// </summary>
        /// <param name="items">MRU items to save</param>
        public void SaveMRUItems(IEnumerable<MRUItem> items)
        {
            Stream seralizationStream = null;
            try
            {
                seralizationStream = File.Create(storageFilePath);
                XmlSerializer serializer = new XmlSerializer(typeof(MRUItemsHolder));
                MRUItemsHolder holder = new MRUItemsHolder
                {
                    Items = items as List<MRUItem>
                };
                serializer.Serialize(seralizationStream, holder);
            }
            catch (Exception ex)
            {
                if (seralizationStream != null)
                {
                    seralizationStream.Close();
                }
                throw new Exception(string.Format("MRUItemFileStorage: Fail to save object to storage!\r\n{0}", ex.Message));
            }
            finally
            {
                if (seralizationStream != null)
                {
                    seralizationStream.Close();
                }
            }
        }


        private readonly string storageFilePath = "";

        /// <summary>
        /// Create new MRUItemFileStorage instance
        /// </summary>
        /// <param name="StorageFilePath">full path to xml file that will be used for storage</param>
        public MRUItemFileStorage (string StorageFilePath)
        {
            storageFilePath = StorageFilePath;
            InitializeStorage();
        }

        private void InitializeStorage()
        {
            if (String.IsNullOrEmpty(storageFilePath))
            {
                throw new ArgumentException("MRUItemFileStorage: not valid path for file storage");
            }
            FileInfo fi = new FileInfo(storageFilePath);
            if (fi.Extension != ".xml")
            {
                throw new ArgumentException("MRUItemFileStorage: not supported extension for file storage. Should be '.xml'");
            }
            if (!fi.Exists)
            {
                Stream stream = File.Create(fi.FullName);
                stream.Close();
            }
            try
            {
                // file has correct information about MRU.
                IEnumerable<MRUItem> items = ReadMRUItems();
            }
            catch
            {
                // File is new or contain corrupted information - re-create it
                SaveMRUItems(new List<MRUItem>());
            }
        }

    }

    public class MRUItemsHolder
    {
        public List<MRUItem> Items { get; set; }
    }
}


