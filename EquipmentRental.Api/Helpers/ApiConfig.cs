using System;
using System.IO;

namespace EquipmentRental.Helpers;

public static class ApiConfig
{
    public static string DbPath
    {
        get
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            return Path.Join(path, "rental.db");
        }
    }
}