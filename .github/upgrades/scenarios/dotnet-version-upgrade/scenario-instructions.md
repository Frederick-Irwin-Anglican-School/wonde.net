# .NET Version Upgrade Scenario

Upgrade Wonde.NET from .NET Framework 4.8 to .NET 10.0 (LTS)

## Preferences
- **Flow Mode**: Automatic
- **Target Framework**: net10.0 (LTS, support until Nov 2028)

## Source Control
- **Source Branch**: master
- **Working Branch**: upgrade-dotnet-10
- **Commit Strategy**: After Each Task
- **Branch Sync**: Auto (Merge)

## Upgrade Options
- **Upgrade Strategy**: Bottom-Up (required for .NET Framework → modern .NET transition)
- **Project Approach**: In-place
- **Package Management**: Per-project PackageReference
- **Breaking API Changes**: Manual Review
- **Configuration Migration**: System.Configuration.ConfigurationManager bridge
- **System.Web Compatibility**: System.Web.Adapters evaluation

## Build Tool Decisions
- **Wonde.NET.csproj**: `dotnet build` (SDK-style, net48→net10.0, no special requirements)
- **TestWondeConsole.csproj**: `dotnet build` (SDK-style, net48→net10.0, no special requirements)
- **Tests.csproj**: `dotnet build` (SDK-style, net48→net10.0, MSTest via NuGet)
