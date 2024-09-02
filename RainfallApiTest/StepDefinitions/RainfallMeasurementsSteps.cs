using FluentAssertions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;
using RainfallApiTest.Models;

namespace RainfallApiTest.Steps
{
    [Binding]
    public class RainfallMeasurementsSteps
    {
        private readonly HttpClient _httpClient;
        private HttpResponseMessage _response;
        private ScenarioContext _scenarioContext;

        public RainfallMeasurementsSteps(ScenarioContext scenarioContext)
        {
            _httpClient = new HttpClient();
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have a valid endpoint for rainfall measurements with a limit parameter")]
        public void GivenIHaveAValidEndpointForRainfallMeasurementsWithALimitParameter()
        {
            // Endpoint is predefined, no action needed here
        }

        [When(@"I send a GET request to the API with a limit of (.*)")]
        public async Task WhenISendAGETRequestToTheAPIWithALimitOf(int limit)
        {
            var url = $"https://environment.data.gov.uk/flood-monitoring/id/measures?&parameter=rainfall&_limit={limit}";
            _response = await _httpClient.GetAsync(url);
            _scenarioContext.Add("response", _response);
        }

        [Then(@"the API should return (.*) or fewer rainfall measurements")]
        public async Task ThenTheAPIShouldReturnOrFewerRainfallMeasurements(int expectedLimit)
        {
            _response = _scenarioContext.Get<HttpResponseMessage>("response");
            Assert.True(((int) _response.StatusCode).Equals(200));
            var content = await _response.Content.ReadFromJsonAsync<ApiResponse>();
            content.Items.Should().HaveCountLessOrEqualTo(expectedLimit);
        }

        [Given(@"I have a valid endpoint for rainfall measurements with a specific date")]
        public void GivenIHaveAValidEndpointForRainfallMeasurementsWithASpecificDate()
        {
            // Endpoint is predefined, no action needed here
        }

        [When(@"I send a GET request to the API for the date ""(.*)""")]
        public async Task WhenISendAGETRequestToTheAPIForTheDate(string day)
        {
            var date = DateUtils.GetDate(day);
            _scenarioContext.Add("RequestDate", date);
            var url = $"https://environment.data.gov.uk/flood-monitoring/id/measures?date={date}&parameter=rainfall";
            _response = await _httpClient.GetAsync(url);
        }

        [Then(@"the API should return rainfall measurements for that specific date")]
        public async Task ThenTheAPIShouldReturnRainfallMeasurementsForThatSpecificDate()
        {
            _response.EnsureSuccessStatusCode();
           var requestDate =  _scenarioContext.Get<string>("RequestDate");
            var content = await _response.Content.ReadFromJsonAsync<ApiResponse>();
            foreach (var item in content.Items)
            {
                item.LatestReading.Date.Should().Be(requestDate);
            }
        }
    }
}
