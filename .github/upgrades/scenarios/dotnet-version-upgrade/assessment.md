# Projects and dependencies analysis

This document provides a comprehensive overview of the projects and their dependencies in the context of upgrading to .NETCoreApp,Version=v10.0.

## Table of Contents

- [Executive Summary](#executive-Summary)
  - [Highlevel Metrics](#highlevel-metrics)
  - [Projects Compatibility](#projects-compatibility)
  - [Package Compatibility](#package-compatibility)
  - [API Compatibility](#api-compatibility)
  - [Binding Redirect Configuration](#binding-redirect-configuration)
- [Aggregate NuGet packages details](#aggregate-nuget-packages-details)
- [Top API Migration Challenges](#top-api-migration-challenges)
  - [Technologies and Features](#technologies-and-features)
  - [Most Frequent API Issues](#most-frequent-api-issues)
- [Projects Relationship Graph](#projects-relationship-graph)
- [Project Details](#project-details)

  - [DotNetClient\Wonde.NET.csproj](#dotnetclientwondenetcsproj)
  - [Tests\Tests.csproj](#teststestscsproj)
  - [TestWondeClient\TestWondeConsole.csproj](#testwondeclienttestwondeconsolecsproj)


## Executive Summary

### Highlevel Metrics

| Metric | Count | Status |
| :--- | :---: | :--- |
| Total Projects | 3 | All require upgrade |
| Total NuGet Packages | 0 | All compatible |
| Total Code Files | 61 |  |
| Total Code Files with Incidents | 16 |  |
| Total Lines of Code | 3195 |  |
| Total Number of Issues | 47 |  |
| Estimated LOC to modify | 41+ | at least 1.3% of codebase |

### Projects Compatibility

| Project | Target Framework | Difficulty | Package Issues | API Issues | Binding Issues | Est. LOC Impact | Description |
| :--- | :---: | :---: | :---: | :---: | :---: | :---: | :--- |
| [DotNetClient\Wonde.NET.csproj](#dotnetclientwondenetcsproj) | net48 | 🟢 Low | 0 | 23 | 0 | 23+ | ClassicClassLibrary, Sdk Style = False |
| [Tests\Tests.csproj](#teststestscsproj) | net48 | 🟢 Low | 0 | 14 | 0 | 14+ | ClassicClassLibrary, Sdk Style = False |
| [TestWondeClient\TestWondeConsole.csproj](#testwondeclienttestwondeconsolecsproj) | net48 | 🟢 Low | 0 | 4 | 0 | 4+ | ClassicDotNetApp, Sdk Style = False |

### Package Compatibility

| Status | Count | Percentage |
| :--- | :---: | :---: |
| ✅ Compatible | 0 | 0.0% |
| ⚠️ Incompatible | 0 | 0.0% |
| 🔄 Upgrade Recommended | 0 | 0.0% |
| ***Total NuGet Packages*** | ***0*** | ***100%*** |

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 8 | High - Require code changes |
| 🟡 Source Incompatible | 33 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 2906 |  |
| ***Total APIs Analyzed*** | ***2947*** |  |

## Aggregate NuGet packages details

| Package | Current Version | Suggested Version | Projects | Description |
| :--- | :---: | :---: | :--- | :--- |

## Top API Migration Challenges

### Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |
| Legacy Configuration System | 18 | 43.9% | Legacy XML-based configuration system (app.config/web.config) that has been replaced by a more flexible configuration model in .NET Core. The old system was rigid and XML-based. Migrate to Microsoft.Extensions.Configuration with JSON/environment variables; use System.Configuration.ConfigurationManager NuGet package as interim bridge if needed. |
| ASP.NET Framework (System.Web) | 8 | 19.5% | Legacy ASP.NET Framework APIs for web applications (System.Web.*) that don't exist in ASP.NET Core due to architectural differences. ASP.NET Core represents a complete redesign of the web framework. Migrate to ASP.NET Core equivalents or consider System.Web.Adapters package for compatibility. |

### Most Frequent API Issues

| API | Count | Percentage | Category |
| :--- | :---: | :---: | :--- |
| M:System.Exception.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext) | 14 | 34.1% | Source Incompatible |
| T:System.Configuration.ConfigurationManager | 9 | 22.0% | Source Incompatible |
| P:System.Configuration.ConfigurationManager.AppSettings | 9 | 22.0% | Source Incompatible |
| P:System.Web.Script.Serialization.JavaScriptSerializer.MaxJsonLength | 2 | 4.9% | Binary Incompatible |
| T:System.Web.Script.Serialization.JavaScriptSerializer | 2 | 4.9% | Binary Incompatible |
| M:System.Web.Script.Serialization.JavaScriptSerializer.#ctor | 2 | 4.9% | Binary Incompatible |
| M:System.Net.WebRequest.Create(System.String) | 1 | 2.4% | Source Incompatible |
| M:System.Web.Script.Serialization.JavaScriptSerializer.Serialize(System.Object) | 1 | 2.4% | Binary Incompatible |
| M:System.Web.Script.Serialization.JavaScriptSerializer.Deserialize''1(System.String) | 1 | 2.4% | Binary Incompatible |

## Projects Relationship Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart LR
    P1["<b>⚙️&nbsp;Wonde.NET.csproj</b><br/><small>net48</small>"]
    P2["<b>⚙️&nbsp;Tests.csproj</b><br/><small>net48</small>"]
    P3["<b>⚙️&nbsp;TestWondeConsole.csproj</b><br/><small>net48</small>"]
    P2 --> P1
    P3 --> P1
    click P1 "#dotnetclientwondenetcsproj"
    click P2 "#teststestscsproj"
    click P3 "#testwondeclienttestwondeconsolecsproj"

```

## Project Details

<a id="dotnetclientwondenetcsproj"></a>
### DotNetClient\Wonde.NET.csproj

#### Project Info

- **Current Target Framework:** net48
- **Proposed Target Framework:** net10.0
- **SDK-style**: False
- **Project Kind:** ClassicClassLibrary
- **Dependencies**: 0
- **Dependants**: 2
- **Number of Files**: 55
- **Number of Files with Incidents**: 10
- **Lines of Code**: 2638
- **Estimated LOC to modify**: 23+ (at least 0.9% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph upstream["Dependants (2)"]
        P2["<b>⚙️&nbsp;Tests.csproj</b><br/><small>net48</small>"]
        P3["<b>⚙️&nbsp;TestWondeConsole.csproj</b><br/><small>net48</small>"]
        click P2 "#teststestscsproj"
        click P3 "#testwondeclienttestwondeconsolecsproj"
    end
    subgraph current["Wonde.NET.csproj"]
        MAIN["<b>⚙️&nbsp;Wonde.NET.csproj</b><br/><small>net48</small>"]
        click MAIN "#dotnetclientwondenetcsproj"
    end
    P2 --> MAIN
    P3 --> MAIN

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 8 | High - Require code changes |
| 🟡 Source Incompatible | 15 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 2188 |  |
| ***Total APIs Analyzed*** | ***2211*** |  |

#### Project Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |
| ASP.NET Framework (System.Web) | 8 | 34.8% | Legacy ASP.NET Framework APIs for web applications (System.Web.*) that don't exist in ASP.NET Core due to architectural differences. ASP.NET Core represents a complete redesign of the web framework. Migrate to ASP.NET Core equivalents or consider System.Web.Adapters package for compatibility. |

<a id="teststestscsproj"></a>
### Tests\Tests.csproj

#### Project Info

- **Current Target Framework:** net48
- **Proposed Target Framework:** net10.0
- **SDK-style**: False
- **Project Kind:** ClassicClassLibrary
- **Dependencies**: 1
- **Dependants**: 0
- **Number of Files**: 4
- **Number of Files with Incidents**: 4
- **Lines of Code**: 479
- **Estimated LOC to modify**: 14+ (at least 2.9% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["Tests.csproj"]
        MAIN["<b>⚙️&nbsp;Tests.csproj</b><br/><small>net48</small>"]
        click MAIN "#teststestscsproj"
    end
    subgraph downstream["Dependencies (1"]
        P1["<b>⚙️&nbsp;Wonde.NET.csproj</b><br/><small>net48</small>"]
        click P1 "#dotnetclientwondenetcsproj"
    end
    MAIN --> P1

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 14 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 687 |  |
| ***Total APIs Analyzed*** | ***701*** |  |

#### Project Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |
| Legacy Configuration System | 14 | 100.0% | Legacy XML-based configuration system (app.config/web.config) that has been replaced by a more flexible configuration model in .NET Core. The old system was rigid and XML-based. Migrate to Microsoft.Extensions.Configuration with JSON/environment variables; use System.Configuration.ConfigurationManager NuGet package as interim bridge if needed. |

<a id="testwondeclienttestwondeconsolecsproj"></a>
### TestWondeClient\TestWondeConsole.csproj

#### Project Info

- **Current Target Framework:** net48
- **Proposed Target Framework:** net10.0
- **SDK-style**: False
- **Project Kind:** ClassicDotNetApp
- **Dependencies**: 1
- **Dependants**: 0
- **Number of Files**: 2
- **Number of Files with Incidents**: 2
- **Lines of Code**: 78
- **Estimated LOC to modify**: 4+ (at least 5.1% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["TestWondeConsole.csproj"]
        MAIN["<b>⚙️&nbsp;TestWondeConsole.csproj</b><br/><small>net48</small>"]
        click MAIN "#testwondeclienttestwondeconsolecsproj"
    end
    subgraph downstream["Dependencies (1"]
        P1["<b>⚙️&nbsp;Wonde.NET.csproj</b><br/><small>net48</small>"]
        click P1 "#dotnetclientwondenetcsproj"
    end
    MAIN --> P1

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 4 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 31 |  |
| ***Total APIs Analyzed*** | ***35*** |  |

#### Project Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |
| Legacy Configuration System | 4 | 100.0% | Legacy XML-based configuration system (app.config/web.config) that has been replaced by a more flexible configuration model in .NET Core. The old system was rigid and XML-based. Migrate to Microsoft.Extensions.Configuration with JSON/environment variables; use System.Configuration.ConfigurationManager NuGet package as interim bridge if needed. |

