Feature: Rainfall Measurements


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

