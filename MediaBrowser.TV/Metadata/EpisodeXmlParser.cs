﻿using System.IO;
using System.Xml;
using MediaBrowser.Controller.Xml;
using MediaBrowser.TV.Entities;

namespace MediaBrowser.TV.Metadata
{
    public class EpisodeXmlParser : BaseItemXmlParser<Episode>
    {
        protected override void FetchDataFromXmlNode(XmlReader reader, Episode item)
        {
            switch (reader.Name)
            {
                case "filename":
                    {
                        string filename = reader.ReadString();

                        if (!string.IsNullOrWhiteSpace(filename))
                        {
                            string seasonFolder = Path.GetDirectoryName(item.Path);
                            item.PrimaryImagePath = Path.Combine(seasonFolder, "metadata", filename);
                        }
                        break;
                    }
                case "EpisodeNumber":
                    string number = reader.ReadString();

                    if (!string.IsNullOrWhiteSpace(number))
                    {
                        item.IndexNumber = int.Parse(number);
                    }
                    break;

                case "EpisodeName":
                    item.Name = reader.ReadString();
                    break;

                default:
                    base.FetchDataFromXmlNode(reader, item);
                    break;
            }
        }
    }
}
