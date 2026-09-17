# 03-tier1-wonde-net: Upgrade Wonde.NET.csproj to .NET 10.0

Upgrade the foundation library (Wonde.NET.csproj) from .NET Framework 4.8 to .NET 10.0, addressing API compatibility issues and modernizing dependencies.

This is Tier 1 (leaf node) of the dependency graph.

## Research & Changes Applied

### Target Framework Upgrade
- **Updated**: TargetFramework from net48 → net10.0 in Wonde.NET.csproj

### System.Web Compatibility
- **Added**: System.Web.Adapters 0.2.4 package
- **Reason**: Provides compatibility for System.Web.Script.Serialization used in BootstrapEndpoint.cs and JsonSerializeHelper.cs

### Key Code Locations Requiring Updates
- **BootstrapEndpoint.cs** (line 11): Uses `System.Web.Script.Serialization.JavaScriptSerializer`
- **JsonSerializeHelper.cs** (line 6): Uses `System.Web.Script.Serialization.JavaScriptSerializer`

**Done when**: 
- Wonde.NET.csproj targets net10.0 ✅
- All compilation errors from API changes are resolved
- Solution builds without warnings or errors
- Unit tests for Wonde.NET.csproj pass
- Higher-tier projects (Tests, TestWondeConsole) still loadable
