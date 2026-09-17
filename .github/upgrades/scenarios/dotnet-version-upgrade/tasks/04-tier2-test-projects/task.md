# 04-tier2-test-projects: Upgrade Tests.csproj and TestWondeConsole.csproj to .NET 10.0

Upgrade both test projects and the console app from .NET Framework 4.8 to .NET 10.0.

Tests.csproj (14 issues) and TestWondeConsole.csproj (4 issues) are Tier 2 projects, depending entirely on the upgraded Wonde.NET.csproj. Together they have 18 API issues:
- All source incompatible
- All related to legacy Configuration system (ConfigurationManager references, app.config usage)
- No binary incompatible issues

**Scope**: 
- Tests.csproj: Update TFM to net10.0, resolve configuration-related compilation errors
- TestWondeConsole.csproj: Update TFM to net10.0, resolve configuration-related compilation errors

**Dependencies**: Requires Wonde.NET.csproj (Tier 1) to be upgraded to net10.0 first.

**Done when**:
- Both Tests.csproj and TestWondeConsole.csproj target net10.0
- All compilation errors resolved
- Solution builds without warnings or errors
- Full test suite (both unit and integration tests) passes
- No build-time or runtime issues detected
