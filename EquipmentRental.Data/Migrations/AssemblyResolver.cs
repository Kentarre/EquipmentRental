using System.Reflection;

namespace EquipmentRental.Data.Migrations;

public class AssemblyResolver
{
    public static readonly Assembly Migrator = typeof(AssemblyResolver).Assembly;

}