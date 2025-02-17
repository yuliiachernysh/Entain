# General description

Automation solution is built with Playwright and C#

## Installation

The next packages were used in solution:

```bash
Microsoft.Extensions.Configuration 8.0.0
Microsoft.Extensions.Configuration.Abstructions 8.0.0
Microsoft.Extensions.Configuration.Binder 8.0.2
Microsoft.Extensions.Configuration.Json 8.0.2
Microsoft.Net.Test.Sdk 17.8.0
Microsoft.Playwright 1.49.0
NUnit 3.14.0
NUnit.Analyzers 3.9.0
NUnit3TestAdapter 4.5.0
```

```
Also you have to install .net 8.0 SDK locally to run this test
```

## Solution composition:

```
Folder Configuration
# Folder Contains class ConfigReader that allows us to manipulate with config data
that locate in appsettings.json
FYI: appsettings.json file contains 'Device' property that allows us to switch between 
'Mobile' and 'Desktop' mode in test run

# Folder ObjectRepositories contains pages locators

# Folder Pages contains methods that allow us to interact with page`s elements that
were descripted in ObjectRepositories files
Than approach implement Page Object pattern. 

# Folder Test contains test suite. Test were separated by page logic and business needs 
```

## Test run
```
To run this tests locally you can use:
# Visual Studio ->> Test explorer 
# with bash script 
dotnet test --filter "LiveBettingTestSuit"
```

## NOTE: 
```
I want to emphasize that now some of provided tests could be flake. It's happening because UI env is not stable. As example, functionality for Betslip that was able on Saturday disappeared laterly.
On my point of view it`s not a good practice to invest time to automate currently changable functionality. Also the most locators are hard-detected (without static id or other unique components). 
It makes test creation a bit time-consuming. On my point of view it could be discussed and optimize on development side.

Provided solution is my vision how to setup UI test solution with Playwrite framework and page-object pattern.
```
