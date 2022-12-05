using AdventCalendar.Console.Configurations;
using AdventCalendar.Console.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdventCalendar.IntegrationTests
{
    public class TestAnswers
    {
        public IServiceProvider ServiceProvider { get; set; }
        public IAdventQuestionFactory AdventQuestionFactory
            => ServiceProvider.GetRequiredService<IAdventQuestionFactory>();

        public TestAnswers()
        {
            var services = new ServiceCollection();
            services.AddQuestions();

            ServiceProvider = services.BuildServiceProvider();
        }

        [Theory]
        [InlineData(1, 69912, 208180)]
        [InlineData(2, 14264, 12382)]
        [InlineData(3, 7793, 2499)]
        [InlineData(4, 651, 956)]
        [InlineData(5, "QNHWJVJZW", "BPCZJLFJW")]
        public async void Test1(int day, object firstExpected, object secondExpected)
        {
            // Arrange
            var question = AdventQuestionFactory.CreateQuestion(day);

            // Act
            var result_1 = await question.GetFirstAnswer();
            var result_2 = await question.GetSecondAnswer();

            // Assert
            result_1.Should().Be(firstExpected);
            result_2.Should().Be(secondExpected);
        }
    }
}