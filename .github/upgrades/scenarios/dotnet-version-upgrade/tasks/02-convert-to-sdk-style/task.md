# 02-convert-to-sdk-style: Convert Projects to SDK-Style Format

Convert all three projects from legacy (non-SDK) to SDK-style format while staying on .NET Framework 4.8.

All projects currently use classic ToolsVersion csproj format. SDK-style conversion is a structural change that must be done **before** TFM upgrade, allowing the project system and tooling to align. This separation ensures conversion issues are isolated and fixed independently from API compatibility work.

Assessment notes: All projects are non-SDK-style (Sdk Style = False).

**Issues to watch**: 
- packages.config file management during conversion (if present)
- Preserve all project properties and references
- Verify no post-build events or custom imports are broken

**Done when**:
- All three projects (Wonde.NET.csproj, Tests.csproj, TestWondeConsole.csproj) are converted to SDK-style format
- Projects still target net48
- Solution builds and all existing tests pass
- No breaking changes to project structure or references
