# Task 04: Tier 2 Test Projects Upgrade — Progress Details

## Summary
Successfully retargeted `Tests.csproj` and `TestWondeConsole.csproj` to target `net10.0`, resolved the `System.Web.Script.Serialization` compatibility blocker in the foundation library, cleaned up legacy framework assembly references, and achieved a **build-successful solution with 0 errors**.

## Changes Made

### Project Target Framework Upgrades
- **Tests.csproj**: `net48` → `net10.0`
- **TestWondeConsole.csproj**: `net48` → `net10.0`

### Wonde.NET.csproj Compatibility Fixes
1. **Serialization Migration**: Replaced `System.Web.Script.Serialization` (JavaScriptSerializer) with `System.Text.Json` in two files:
   - **Wonde/Helpers/JsonSerializeHelper.cs**: Updated `getJsonAsDictionary()` and `formatObjectAsJson()` methods to use `JsonSerializer.Deserialize<T>()` and `JsonSerializer.Serialize()`
   - **Wonde/EndPoints/BootstrapEndpoint.cs**: Removed the using statement for `System.Web.Script.Serialization`

2. **Configuration Migration**: Added `System.Configuration.ConfigurationManager` NuGet package (v8.0.0) to all three projects to provide `ConfigurationManager` in net10.0

3. **Frame Assembly Reference Cleanup**: Removed obsolete .NET Framework-specific assembly references from all project files:
   - Removed: `System.Web`, `System.Web.Extensions`, `System.Data.DataSetExtensions`, `Microsoft.CSharp`, `System.Net.Http`
   - These had been generating MSB3245/MSB3243 warnings and conflicts in net10.0

### Packages Added
All three projects now have `System.Configuration.ConfigurationManager v8.0.0` to support ConfigurationManager APIs in net10.0.

## Build Validation

### Final Build Status
```
Wonde.NET.csproj:      ✅ Build succeeded, 8 Warnings, 0 Errors
Tests.csproj:          ✅ Build succeeded, 0 Warnings, 0 Errors
TestWondeConsole.csproj: ✅ Build succeeded, 0 Warnings, 0 Errors
```

### Remaining Warnings (Not Errors)
- **SYSLIB0014** (2 occurrences): `WebRequest.Create()` is obsolete, recommends `HttpClient`
- **SYSLIB0051** (6 occurrences): `Exception(SerializationInfo, StreamingContext)` is obsolete, relates to BinaryFormatter serialization

These are informative obsolescence warnings from using older patterns that are deprecated but still functional in net10.0. They do not block the build or cause compilation failures. Future enhancement work can address WebRequest → HttpClient migration and exception serialization patterns if needed.

## Files Modified
- `src/DotNetClient/Tests/Tests.csproj` (target framework, package references)
- `src/DotNetClient/TestWondeClient/TestWondeConsole.csproj` (target framework, package references)
- `src/DotNetClient/DotNetClient/Wonde.NET.csproj` (target framework, package references, assembly references)
- `src/DotNetClient/DotNetClient/Wonde/Helpers/JsonSerializeHelper.cs` (serialization code migration)
- `src/DotNetClient/DotNetClient/Wonde/EndPoints/BootstrapEndpoint.cs` (using statement cleanup)

## Compatibility Observations
- **System.Web.Script.Serialization** does not exist in net10.0; `System.Text.Json` is the modern replacement
- **System.Configuration.ConfigurationManager** requires explicit NuGet package in net10.0
- Legacy framework assembly references conflict with SDK-provided versions and should be removed for clean builds
- Exception serialization constructors (BinaryFormatter-based) are deprecated but can remain for backward compatibility if needed

## Done-When Checklist
- [x] Retarget Tests.csproj to net10.0
- [x] Retarget TestWondeConsole.csproj to net10.0
- [x] Add System.Configuration.ConfigurationManager to all projects requiring ConfigurationManager
- [x] Resolve System.Web.Script.Serialization incompatibility
- [x] Clean up framework assembly references
- [x] Achieve solution-wide build success with 0 errors
- [x] Document all changes and rationale

## Next Steps
Task 05 (Final Validation) should perform end-to-end validation, run unit tests, verify all projects compile clean, and commit the upgrade.
