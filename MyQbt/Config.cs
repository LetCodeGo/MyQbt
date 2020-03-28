using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyQbt
{
    [XmlRoot("Config")]
    public class Config
    {
        [XmlRoot("Connect")]
        public class Connect
        {
            [XmlAttribute("Url")]
            public string Url;
            [XmlAttribute("User")]
            public string User;
            [XmlAttribute("Password")]
            public string Password;
        }

        [XmlRoot("DomainCategory")]
        public class DomainCategory
        {
            [XmlAttribute("Domain")]
            public string Domain;
            [XmlAttribute("Category")]
            public string Category;
        }

        public enum SystemType
        {
            [XmlEnum("Windows")]
            Windows,
            [XmlEnum("Linux")]
            Linux
        }

        public enum BTClient
        {
            [XmlEnum("qBittorrent")]
            qBittorrent,
            [XmlEnum("Transmission")]
            Transmission
        }
        [XmlAttribute("BTClientType")]
        public BTClient BTClientType;
        [XmlAttribute("QbtSystemType")]
        public SystemType QbtSystemType;
        [XmlAttribute("IsPathMap")]
        public bool IsPathMap;
        [XmlAttribute("LastUseUrl")]
        public string LastUseUrl;
        [XmlArray("ConnectList")]
        public List<Connect> ConnectList;

        [XmlAttribute("LastUseCategory")]
        public string LastUseCategory;
        [XmlArray("CategoryList")]
        public List<string> CategoryList;

        [XmlArray("DomainCategoryList")]
        public List<DomainCategory> DomainCategoryList;

        [XmlArray("SaveFolderList")]
        public List<string> SaveFolderList;

        [XmlElement("PathMapString")]
        public string PathMapString;

        [XmlArray("TrackerFindList")]
        public List<string> TrackerFindList;

        [XmlArray("TrackerReplaceList")]
        public List<string> TrackerReplaceList;

        [XmlArray("SavePathFindList")]
        public List<string> SavePathFindList;

        [XmlArray("SavePathReplaceList")]
        public List<string> SavePathReplaceList;
    }
}
