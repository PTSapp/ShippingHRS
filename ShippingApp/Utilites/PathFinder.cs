using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ShippingApp.Utilites
{
    public static class PathFinder
    {
        public static readonly string resourcesPath = ResolveAppPath() + @"\Resources";

        public static string FetchPathForResource(string resourceName)
        {
            Console.WriteLine(resourceName);
            if (resourceName.Contains("."))
            {
                int dotIndex = resourceName.IndexOf('.');
                resourceName = resourceName.Substring(0, resourceName.Length - 1 - dotIndex);
            }
            Console.WriteLine(resourceName);

            DirectoryInfo resourcesFolderInfo = new DirectoryInfo(resourcesPath);
            FileInfo foundFileInfo = resourcesFolderInfo.GetFiles().ToList().Where(f => f.Name.Equals(resourceName)).FirstOrDefault();
            if (foundFileInfo == null)
            {
                return null;
            }

            return foundFileInfo.FullName;
        }

        private static string ResolveAppPath()
        {
            string assemblyPathNode = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string binPathNode = Directory.GetParent(assemblyPathNode).FullName;
            return Directory.GetParent(binPathNode).FullName;
        }
    }
}
