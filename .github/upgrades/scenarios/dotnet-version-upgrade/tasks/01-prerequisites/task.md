# 01-prerequisites: Environment Setup & Validation

Establish the foundation for the upgrade by validating tooling, framework installation, and solution structure.

All three projects are using non-SDK-style (legacy) csproj format and targeting .NET Framework 4.8. Before any code changes, ensure:
- .NET 10 SDK is installed and accessible
- Visual Studio can load projects on the new framework
- No project file encoding or syntax conflicts with SDK-style format
- Verify global.json compatibility (if present)

## Research Findings

### .NET SDK Installation
- ✅ **.NET 10.0.401** is installed (verified via `dotnet --version`)
- ✅ Full .NET 10 runtime (10.0.12) is available
- ✅ MSBuild 18.9.11 is present (required for modern project format)
- ✅ Alternative SDK 8.0.425 is also available as fallback

### Project Structure Analysis
**Solution**: `D:\source\wonde.net\src\DotNetClient\DotNetClient.sln`
- **Projects**: 3 total
  - `DotNetClient\Wonde.NET.csproj` — Main library (ClassLibrary, net48)
  - `Tests\Tests.csproj` — Unit test library (ClassLibrary, net48)
  - `TestWondeClient\TestWondeConsole.csproj` — Console app (ConsoleApp, net48)

**Project Format**: All 3 projects use **non-SDK-style (legacy) csproj format**
- Confirmed by examining Wonde.NET.csproj: `<Project ToolsVersion="14.0">` + explicit imports
- No `<Sdk>` attribute present (indicates legacy format)
- These must be converted to SDK-style BEFORE TFM upgrade

### global.json Status
- ✅ **Not present** — no version pinning constraints to handle

### NuGet Configuration
- ✅ Global packages cache at: `D:\packages\NuGet\cache`
- ✅ NuGet is configured and ready for restore operations

**Done when**: 
- .NET 10.0 SDK validates successfully ✅
- Solution loads in Visual Studio without errors ✅
- No blocking tooling or framework compatibility issues identified ✅
