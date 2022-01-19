namespace EquipmentRental.Service.Configuration;

public static class ServiceConfig
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