using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Models;
using AdventCalendar.Console.Questions;
using AdventCalendar.Console.Services.Factories;
using AdventCalendar.Console.Services.FileReaders;
using AdventCalendar.Console.Services.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace AdventCalendar.Console.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQuestions(this IServiceCollection services)
        {
            services.AddTransient<ICalculatorFactory, CalculatorFactory>();

            services.AddTransient<IStringMultiMapper<int>, StringToIntListMapper>();
            services.AddTransient<IGameMapper, StringToGameMapper>();
            services.AddTransient<IGameMapper, StringToGameMapperStateBased>();
            services.AddTransient<ICharMapper<int>, CharToIntMapper>();
            services.AddTransient<IStringMultiMapper<BackpackModel>, StringToBackpackMapper>();
            services.AddTransient<IStringMapper<ElfCleaningDuoModel>, StringToElfCleaningModelMapper>();

            services.AddTransient<IGameMapperFactory, GameMapperFactory>();
            services.AddTransient<IFileReaderFactory, FileReaderFactory>();

            services.AddTransient<IAsyncFileReader<string>, TextFileLineReaderAsync>();
            services.AddTransient<IAsyncFileReader<List<string>>, EmptyStringCollectionReader>();

            services.AddTransient<IAdventQuestion, AdventQuestionOne>();
            services.AddTransient<IAdventQuestion, AdventQuestionTwo>();
            services.AddTransient<IAdventQuestion, AdventQuestionThree>();
            services.AddTransient<IAdventQuestion, AdventQuestionFour>();

            services.AddTransient<IAdventQuestionFactory, AdventQuestionFactory>();
            services.AddSingleton<IGuru, AdventQuestionGuru>();

            return services;
        }
    }
}
