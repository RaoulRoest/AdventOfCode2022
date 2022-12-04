using AdventCalendar.Console.Configurations;
using AdventCalendar.Console.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdventCalendar.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddQuestions();
            var serviceProvider = services.BuildServiceProvider();

            var adventQuestionGuru = serviceProvider.GetRequiredService<IGuru>();
            await adventQuestionGuru.Go(4);
        }
    }
}