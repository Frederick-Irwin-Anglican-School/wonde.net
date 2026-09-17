# Project overview

**Wonde.NET** is a comprehensive .NET Framework 4.8 helper library for seamless integration with the Wonde MIS (Management Information System) API. Wonde is a modern cloud-based solution designed for educational institutions to manage student information, attendance, behavior, assessments, and more. This library provides strongly-typed, object-oriented access to Wonde's RESTful API endpoints, with support for data retrieval via cursor-based pagination and write-back operations for pushing data back to the Wonde system. The library abstracts away HTTP complexity and JSON serialization, allowing developers to focus on business logic while working with familiar .NET classes and methods.

## Code generation

- Always use the latest version C# supported by the target.
- Write clear and concise comments for each function.

## README generation

- Include a README.md file with clear instructions for using the library.
- Use markdown formatting for code snippets, tables, and headings.
- Include a one-line description of the application under the heading.
- include emoji for headings.
- If a docs folder exists, create a link to the index.md page in the /docs directory to allow the user to easily view more extensive documentation.
- Include a table of referenced top-level NuGet packages.
- Add badges underneath the description.
  - .net framework version (including the .net icon)
  - Licence
    - Uses the EOIUL (Extended Organisation Internal Use License) license, which is a custom closed-source license.
    - Create a static badge that just displays the text without trying to link to a non-existent license page.
    - The link should point to the LICENSE file in the repository.
- Include the following sections:
  - Overview
  - Features
  - Requirements
  - Installation
  - Quick Start
  - Domain Models documentation (if any)
  - Error Handling
  - Dependencies
  - Development
- When adding tables, ensure that columns are aligned to make the content more user-friendly.

## General Instructions

- Make only high confidence suggestions when reviewing code changes.
- Write code with good maintainability practices, including comments on why certain design decisions were made.
- Handle edge cases and write clear exception handling.
- For libraries or external dependencies, mention their usage and purpose in comments.

## Naming Conventions

- Follow PascalCase for component names, method names, and public members.
- Use camelCase for private fields and local variables.
- Prefix interface names with "I" (e.g., IUserService).

## Formatting

- Prefer file-scoped namespace declarations and single-line using directives.
- Insert a newline before the opening curly brace of any code block (e.g., after `if`, `for`, `while`, `foreach`, `using`, `try`, etc.).
- Ensure that the final return statement of a method is on its own line.
- Use pattern matching and switch expressions wherever possible.
- Use `nameof` instead of string literals when referring to member names.
- Ensure that XML doc comments are created for any public APIs. When applicable, include `<example>` and `<code>` documentation in the comments.
- Use collection expressions where possible.

## Nullable Reference Types

- Declare variables non-nullable, and check for `null` at entry points.
- Always use `is null` or `is not null` instead of `== null` or `!= null`.
- Trust the C# null annotations and don't add null checks when the type system says a value cannot be null.

## Testing

- Always include test cases for public methods, and for any private methods that contain complex logic.
- Guide users through creating unit tests.
- Copy existing style in nearby files for test method names and capitalization.
- Use xUnit for unit testing, and follow the Arrange-Act-Assert pattern in test methods.
- Use Shouldly assertions for test assertions, and follow the Arrange-Act-Assert pattern in test methods.
- Add the Shouldly nuget package if required.

## Commit messages

The first line should be a single-line summary starting with an emoji character and a length of no more than 50 characters.
The second line should be blank.
The body (if any) should start on the third line.
Wrap code, class names, and method names in code blocks.
The body should be a bulleted list.
Include emoji for each non-empty line.
Ensure the emoji is relevant to the current line.
Use the following emojis:

- ⚡ for improved performance
- 🔥 for removed code or files
- 🐛 for bug fixes
- ✨ for new features
- 📝 for added or updated documentation
- 💄 for updated UI and styles
- 🧪 for unit tests
- 🔒 for fixed security or privacy issues
- 🔖 for release/version tags
- ✏️ for typos
- 🧵 for multithreading or async operations
- 🎨 for code style changes
- ♻️ for refactoring
- 🧩 for .ntp files
- 🤡 for mocking objects
- 🔧 for new or updated configuration files
- 🚚 for moved or renamed resources
- 🎉 for the start of a new project
- 🔊 for added or updated logging
- 🔇 for removed logging
- 💥 for breaking changes
- 🚨 for fixing compiler/linter warnings
- ⬇️ for downgraded dependencies or packages
- ⬆️ for upgraded dependencies or packages
- ➕ for new dependencies or packages
- ➖ for removed dependencies or packages
- ⏪️ for internationalization and localization
- ♿️ for improved accessibility
- 💡 for added or updated comments
- 🗃️ for database changes
- 🏗️ for architectural changes
- 📱 for responsive design changes
- 🙈 for ignoring items
- 💚 for CI/CD updates
