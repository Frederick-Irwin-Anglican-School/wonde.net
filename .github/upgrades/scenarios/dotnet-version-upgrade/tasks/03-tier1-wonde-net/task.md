# 03-tier1-wonde-net: Upgrade Wonde.NET.csproj to .NET 10.0

Upgrade the foundation library (Wonde.NET.csproj) from .NET Framework 4.8 to .NET 10.0, addressing API compatibility issues and modernizing dependencies.

This is Tier 1 (leaf node) of the dependency graph. The main library has 23 API issues:
- **8 binary incompatible**: System.Web.Script.Serialization (JavaScriptSerializer, MaxJsonLength property)
- **15 source incompatible**: Configuration system (ConfigurationManager, AppSettings), System.Net.WebRequest

Key technologies:
- **System.Web** (8 issues): JavaScriptSerializer references from System.Web.Script.Serialization
- **Legacy Configuration** (9 issues): ConfigurationManager.AppSettings usage
- **Serialization** (14 issues): Exception constructor with SerializationInfo/StreamingContext parameters

**Research starting points**: 
- Inventory all System.Web.Script.Serialization usages; consider migrating to System.Text.Json or using System.Web.Adapters
- Check all ConfigurationManager usages; consider System.Configuration.ConfigurationManager NuGet package as interim bridge
- Review Exception constructor calls with SerializationInfo/StreamingContext (binary serialization support)

**Done when**:
- Wonde.NET.csproj targets net10.0
- All compilation errors from API changes are resolved
- Solution builds without warnings or errors
- Unit tests for Wonde.NET.csproj pass
- Higher-tier projects (Tests, TestWondeConsole) still build on net48
