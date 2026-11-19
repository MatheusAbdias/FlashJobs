<#
.SYNOPSIS
Runs common FlashJobs development commands.

.EXAMPLE
./scripts/dev.ps1 migration AddJobPriority

.EXAMPLE
./scripts/dev.ps1 update

.EXAMPLE
./scripts/dev.ps1 scaffold JobPosts
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory, Position = 0)]
    [ValidateSet("migration", "remove-migration", "update", "list", "scaffold", "build", "run")]
    [string] $Command,

    [Parameter(Position = 1)]
    [string] $Name
)

$ErrorActionPreference = "Stop"
$ProjectRoot = Split-Path -Parent $PSScriptRoot
Push-Location $ProjectRoot

try {
    switch ($Command) {
        "migration" {
            if ([string]::IsNullOrWhiteSpace($Name)) {
                throw "Command 'migration' requires a name."
            }

            dotnet ef migrations add $Name
        }
        "remove-migration" {
            dotnet ef migrations remove
        }
        "update" {
            dotnet ef database update $Name
        }
        "list" {
            dotnet ef migrations list
        }
        "scaffold" {
            if ([string]::IsNullOrWhiteSpace($Name)) {
                throw "Command 'scaffold' requires a model name."
            }

            dotnet tool restore
            dotnet aspnet-codegenerator controller `
                -name "${Name}Controller" `
                -m $Name `
                -dc AppDBContext `
                -outDir Controllers `
                -scripts `
                -udl
        }
        "build" {
            dotnet build
        }
        "run" {
            dotnet run
        }
    }

    if ($LASTEXITCODE -ne 0) {
        throw "Command '$Command' failed with exit code $LASTEXITCODE."
    }
}
finally {
    Pop-Location
}
