# .NET 9.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that a .NET 9.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 9.0 upgrade.
3. Upgrade MvcMovie.csproj to .NET 9.0
4. Upgrade WpfMovie.csproj to .NET 9.0  
5. Upgrade WpfMovie.Tests.csproj to .NET 9.0
6. Upgrade MvcMovie.Tests.csproj to .NET 9.0
7. Upgrade RazorMovie.csproj to .NET 9.0
8. Upgrade RazorMovie.Tests.csproj to .NET 9.0
9. Run unit tests to validate upgrade in the test projects: WpfMovie.Tests.csproj, MvcMovie.Tests.csproj, RazorMovie.Tests.csproj

## Settings

This section contains settings and data used by execution steps.

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                                        | Current Version           | New Version | Description                         |
|:----------------------------------------------------|:-------------------------:|:-----------:|:------------------------------------|
| HtmlSanitizer                                       | 7.1.542                   | 9.0.886     | Security vulnerability              |
| Microsoft.Data.SqlClient                           | 4.0.5                     | 6.1.1       | Deprecated version                  |
| Microsoft.EntityFrameworkCore.Design               | 6.0.0-rtm.21467.1         | 9.0.8       | Recommended for .NET 9.0           |
| Microsoft.EntityFrameworkCore.SqlServer            | 6.0.0-rc.1.21452.10       | 9.0.8       | Recommended for .NET 9.0           |
| Microsoft.EntityFrameworkCore.Tools                | 6.0.0-rc.1.21452.10       | 9.0.8       | Recommended for .NET 9.0           |
| Microsoft.VisualStudio.Web.CodeGeneration.Design   | 6.0.0-rc.1.21464.1        | 9.0.0       | Recommended for .NET 9.0           |

### Project upgrade details
This section contains details about each project upgrade and modifications that need to be done in the project.

#### MvcMovie modifications

Project properties changes:
- Target framework should be changed from `net6.0` to `net9.0`

NuGet packages changes:
- Microsoft.EntityFrameworkCore.Design should be updated from `6.0.0-rtm.21467.1` to `9.0.8` (*recommended for .NET 9.0*)
- Microsoft.EntityFrameworkCore.SqlServer should be updated from `6.0.0-rc.1.21452.10` to `9.0.8` (*recommended for .NET 9.0*)
- Microsoft.EntityFrameworkCore.Tools should be updated from `6.0.0-rc.1.21452.10` to `9.0.8` (*recommended for .NET 9.0*)
- Microsoft.VisualStudio.Web.CodeGeneration.Design should be updated from `6.0.0-rc.1.21464.1` to `9.0.0` (*recommended for .NET 9.0*)
- Microsoft.Data.SqlClient should be updated from `4.0.5` to `6.1.1` (*deprecated version*)

#### WpfMovie modifications

Project properties changes:
- Target framework should be changed from `net6.0-windows` to `net9.0-windows`

#### WpfMovie.Tests modifications

Project properties changes:
- Target framework should be changed from `net6.0-windows` to `net9.0-windows`

#### MvcMovie.Tests modifications

Project properties changes:
- Target framework should be changed from `net6.0` to `net9.0`

#### RazorMovie modifications

Project properties changes:
- Target framework should be changed from `net6.0` to `net9.0`

NuGet packages changes:
- HtmlSanitizer should be updated from `7.1.542` to `9.0.886` (*security vulnerability*)

#### RazorMovie.Tests modifications

Project properties changes:
- Target framework should be changed from `net6.0` to `net9.0`