# 02-convert-to-sdk-style: Convert Projects to SDK-Style Format

Convert all three projects from legacy (non-SDK) to SDK-style format while staying on .NET Framework 4.8.

All projects currently use classic ToolsVersion csproj format. SDK-style conversion is a structural change that must be done **before** TFM upgrade, allowing the project system and tooling to align. This separation ensures conversion issues are isolated and fixed independently from API compatibility work.

Assessment notes: All projects are non-SDK-style (Sdk Style = False).

## Research Findings

### Project Topological Order (dependency-first)
1. **Wonde.NET.csproj** — Main library (root dependency)
2. **TestWondeConsole.csproj** — Console app (depends on Wonde.NET)
3. **Tests.csproj** — Test library (depends on Wonde.NET)

### Project Analysis
| Project | Type | Path | Format | Dependencies |
|---------|------|------|--------|--------------|
| Wonde.NET.csproj | ClassLibrary | `DotNetClient/Wonde.NET.csproj` | Legacy | System frameworks only |
| TestWondeConsole.csproj | ConsoleApp | `TestWondeClient/TestWondeConsole.csproj` | Legacy | Wonde.NET, System.Xml-related |
| Tests.csproj | ClassLibrary | `Tests/Tests.csproj` | Legacy | Wonde.NET |

### Dependency Details
**Wonde.NET.csproj** assembly references (all .NET Framework built-ins):
- System, System.Core, System.Data, System.Xml, System.Xml.Linq
- System.Web, System.Web.Extensions (legacy compatibility)
- System.Net.Http, Microsoft.CSharp
- System.Data.DataSetExtensions

**No packages.config files detected** — All dependencies are direct assembly references (no NuGet packages to migrate)

### Build Tool Decision
- **Tool**: `dotnet build` (after conversion to SDK-style)
- **Rationale**: Projects are SDK-style (after conversion), target net48 only (no multi-target yet), no .resx with images, no WPF/WinForms, no COM references
- **Alternative**: If `dotnet build` fails on net48, fallback to `msbuild.exe` (requires Microsoft.NETFramework.ReferenceAssemblies package)

**Done when**: 
- All three projects (Wonde.NET.csproj, Tests.csproj, TestWondeConsole.csproj) are converted to SDK-style format
- Projects still target net48
- Solution builds and all existing tests pass
- No breaking changes to project structure or references
