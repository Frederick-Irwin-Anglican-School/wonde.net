# Upgrade Options — Wonde.NET

Assessment: 3 projects (all net48 → net10.0), 3K LOC, key issues: Configuration System (18), System.Web (8), API compatibility (39 source, 8 binary incompatible)

## Upgrade Strategy

| Value | Description | Status |
|-------|-------------|--------|
| **Bottom-Up** | Start with leaf-node library (Wonde.NET.csproj), then upgrade test projects. Each tier validated independently before moving up. Essential for .NET Framework→modern .NET transition. | **Selected** (required for Framework→Core) |

---

## Project Approach

| Value | Description | Status |
|-------|-------------|--------|
| **In-place** | Upgrade projects directly in their current locations; no new projects created. | **Selected** (recommended) |

---

## Package Management

| Value | Description | Status |
|-------|-------------|--------|
| **Per-project PackageReference** | Keep package references in individual project files; no centralized package management file. | **Selected** (default for heterogeneous solutions) |

---

## Breaking API Changes

| Value | Description | Status |
|-------|-------------|--------|
| **Manual Review** | Address API incompatibilities (binary and source) with careful code review and targeted fixes during upgrade. | **Selected** (39 source incompatible, 8 binary incompatible detected) |

---

## Configuration Migration

| Value | Description | Status |
|-------|-------------|--------|
| **System.Configuration.ConfigurationManager bridge** | Use ConfigurationManager NuGet package as interim compatibility bridge for app.config references; migrate to modern config later if needed. | **Selected** (18 config-related issues detected) |

---

## System.Web Compatibility

| Value | Description | Status |
|-------|-------------|--------|
| **System.Web.Adapters evaluation** | Assess System.Web references (8 detected) for compatibility; use adapters package if needed or refactor to ASP.NET Core equivalents. | **Selected** (8 System.Web issues in main library) |
