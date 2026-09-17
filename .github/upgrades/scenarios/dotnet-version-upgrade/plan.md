# Upgrade Plan

Target: Wonde.NET from .NET Framework 4.8 → .NET 10.0 (LTS)

## Strategy

### Selected Strategy

**Bottom-Up (Dependency-First)** — Upgrade projects from leaf nodes upward through the dependency chain, tier by tier.

**Rationale**: 3 projects with 2-tier dependency structure. Framework→Core boundary requires different upgrade mechanics per tier.

## Dependency Graph

```
Tier 2 (Root Applications)
┌─────────────────────────────┐
│ Tests.csproj                │
│ TestWondeConsole.csproj     │
└─────────────┬───────────────┘
			  │
			  ↓
Tier 1 (Foundation Library)
┌─────────────────────────────┐
│ Wonde.NET.csproj (net48)    │
│ - 23 API issues (binary+src)│
│ - System.Web (8 issues)     │
│ - Config (9 issues)         │
└─────────────────────────────┘
```

## Tier Overview

### Tier 1: Foundation Library
**Project**: Wonde.NET.csproj (ClassLibrary, net48)
- 2,638 LOC, 55 files
- 23 API issues: 8 binary incompatible, 15 source incompatible
- Key technologies: System.Web (8 issues, binary incompatible), Configuration System (9 issues, source incompatible)
- Dependents: Tests.csproj, TestWondeConsole.csproj

### Tier 2: Test & Console Projects
**Projects**: Tests.csproj (ClassLibrary, net48), TestWondeConsole.csproj (Console App, net48)
- Tests: 479 LOC, 4 files, 14 API issues (all source incompatible, configuration-related)
- Console: 78 LOC, 2 files, 4 API issues (all source incompatible, configuration-related)
- Both depend on Wonde.NET.csproj for core functionality

---

## Tasks

### 01-prerequisites: Environment Setup & Validation

Establish the foundation for the upgrade by validating tooling, framework installation, and solution structure.

All three projects are using non-SDK-style (legacy) csproj format and targeting .NET Framework 4.8. Before any code changes, ensure:
- .NET 10 SDK is installed and accessible
- Visual Studio can load projects on the new framework
- No project file encoding or syntax conflicts with SDK-style format
- Verify global.json compatibility (if present)

**Done when**: 
- .NET 10.0 SDK validates successfully
- Solution loads in Visual Studio without errors
- No blocking tooling or framework compatibility issues identified

---

### 02-convert-to-sdk-style: Convert Projects to SDK-Style Format

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

---

### 03-tier1-wonde-net: Upgrade Wonde.NET.csproj to .NET 10.0

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

---

### 04-tier2-test-projects: Upgrade Tests.csproj and TestWondeConsole.csproj to .NET 10.0

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

---

### 05-validation: Final Solution Validation & Documentation

Perform comprehensive testing and validation across the entire upgraded solution to ensure all functionality is preserved and all targets are correctly updated.

After all projects are upgraded, perform final checks:
- Full solution build with all warnings resolved
- All unit and integration tests pass
- Verify all projects are targeting net10.0
- Document any deferred recommendations from the assessment (e.g., modern config migration, nullable reference types)
- Verify no broken dependencies or circular references
- Clean up any temporary workarounds or compatibility layers if not needed

**Assessment recommendations for future modernization** (post-upgrade):
- **Configuration System**: Consider migrating from System.Configuration.ConfigurationManager to Microsoft.Extensions.Configuration with JSON/environment variables
- **System.Web Adapters**: Evaluate whether remaining adapters can be removed for full modern .NET compliance
- **Nullable Reference Types**: Consider enabling NRTs in C# 11+ for compile-time null safety
- **API patterns**: Review any API compatibility workarounds for long-term refactoring opportunities

**Done when**:
- Entire solution builds successfully without errors or warnings
- All tests pass (unit, integration)
- All project files confirm net10.0 target framework
- Assessment recommendations are documented in code comments or a follow-up document
