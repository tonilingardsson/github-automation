using System;
using System.Linq;
using WeatherAPI.Controllers;
using Xunit;

namespace WeatherAPI.Tests
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void Get_ReturnsFiveForecasts_WithExpectedShapes()
        {
            // Arrange
            var controller = new WeatherForecastController();

            // Act
            var result = controller.Get().ToArray();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Length);

            var baseDate = DateOnly.FromDateTime(DateTime.Now);
            for (int i = 0; i < result.Length; i++)
            {
                var item = result[i];
                var expectedDate = baseDate.AddDays(i + 1);
                Assert.Equal(expectedDate, item.Date);
                Assert.InRange(item.TemperatureC, -20, 54);
                Assert.False(string.IsNullOrWhiteSpace(item.Summary));
            }
        }
    }
}
