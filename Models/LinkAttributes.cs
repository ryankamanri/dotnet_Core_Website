using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public static class LinkAttributes
    {
        public static string ThisURL = "http://47.108.205.96:5000";
        public static string IISURL = "http://47.108.205.96:5002";
        public static string PhysicalLocation = "G:\\ftpShare";
        public static string PublicPhysicalLocation = PhysicalLocation + "\\Public\\View";
        public static string PrivatePhysicalLocation = PhysicalLocation + "\\Private";
        public static string PublicVirtualLocation = IISURL + "/View";
        public static string FilesPageLocation = ThisURL + "/Files";
        public static string UploadPageLocation = ThisURL + "/Upload";
        public static string StoreLocation = IISURL;
    }
}
