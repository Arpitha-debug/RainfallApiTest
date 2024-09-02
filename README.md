# Rainfall Measurements API Automation Framework

## Overview

This automation framework is created to test the Rainfall Measurements API using SpecFlow, xUnit, and FluentAssertions. The framework supports testing various functionalities of the API, including:
- Retrieving rainfall measurements with a limit parameter.
- Retrieving rainfall measurements for a specific date.

The framework includes:
- SpecFlow: For behavior-driven development (BDD) scenarios and write in a simple english
- xUnit: For unit testing and test execution.
- FluentAssertions: For expressive and readable assertions.

## Setup

### Prerequisites
Ensure the following are installed on your machine:
- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or later recommended)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (or any compatible IDE)
- [SpecFlow](https://specflow.org/) Visual Studio extension
- [xUnit](https://xunit.net/) Test Framework

### Clone the Repository
git clone <repository url>

### Restore NuGet Packages
Open the solution file (`.sln`) in Visual Studio and restore the NuGet packages by right-clicking on the solution and selecting `Restore NuGet Packages`. Alternatively, you can run:

## Configuration

### API Endpoints
The endpoints used in the tests are:

- Get Rainfall Measurements with Limit Parameter

  https://environment.data.gov.uk/flood-monitoring/id/measures?&parameter=rainfall&_limit={limit}
- Get Rainfall Measurements for a Specific Date
  https://environment.data.gov.uk/flood-monitoring/id/measures?date={date}&parameter=rainfall

## Running the Tests
1. Open the solution in Visual Studio.
2. Build the solution.
3. Open the Test Explorer (`Test` -> `Test Explorer`).
4. Run the tests by clicking `Run All` or selecting specific tests.

## Test Scenarios
   Scenario Outline: Get Rainfall Measurements with Limit Parameter
    Given I have a valid endpoint for rainfall measurements with a limit parameter
    When I send a GET request to the API with a limit of <limit>
    Then the API should return <limit> or fewer rainfall measurements

Examples: 

| limit |
| 50    |
| 5     |
| 10    |

  Scenario Outline: Get Rainfall Measurements for a Specific Date
    Given I have a valid endpoint for rainfall measurements with a specific date
    When I send a GET request to the API for the date "<requestDate>"
    Then the API should return rainfall measurements for that specific date
Examples: 
| requestDate |
| Yesterday   |
| today       |
| 31-08-2024  |

## Error Handling
The framework includes error handling for:
- Invalid responses
- Unexpected status codes
- Parsing errors

The `GetDate` method in `DateUtils` handles various date inputs, including "Yesterday", "Today", and specific dates in "dd-MM-yyyy" format.

