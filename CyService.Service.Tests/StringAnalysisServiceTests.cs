using System;
using Xunit;
using System.Linq;
using CyService.Service.Interfaces;
using CyService.Service.Services;
using System.Collections.Generic;

namespace CyService.Service.Tests
{
    public class StringAnalysisServiceTests
    {
        private readonly IStringAnalysisService _stringAnalysisService;

        public StringAnalysisServiceTests()
        {
            _stringAnalysisService = new StringAnalysisService();
        }

        public static IEnumerable<object[]> GetTestData()
        {
            var allData = new List<object[]>
            {
                new object[] { "This is a simple test message", new Dictionary<string, int>() { { "1", 1 }, { "2", 1 }, { "4", 2 },{ "6", 1 },{ "7", 1 } } },
                new object[] { "one two three four five six", new Dictionary<string, int>() { { "3", 3 }, { "4", 2 }, { "5", 1 } } },
                new object[] { "a a a bb bb ccc dddd", new Dictionary<string, int>() { { "1", 3 }, { "2", 2 }, { "3", 1 },{ "4", 1 } } },
            };

            return allData;
        }

        [Theory]
        [InlineData("")]
        [InlineData("       ")]
        public void GetWordLengthCount_ShouldReturnEmptyDictionary_WhenInputIsInvalid(string sentence)
        {
            var result = _stringAnalysisService.GetWordLengthCount(sentence);

            Assert.Empty(result);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void GetWordLengthCount_ShouldReturnValidResult_WhenInputIsValid(string sentence, Dictionary<string, int> expectedResult)
        {
            var result = _stringAnalysisService.GetWordLengthCount(sentence);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void GetWordLengthCount_TheSumOfWordLengthCounts_ShouldEqualTheTotalNumOfWordsInTheInput(string sentence, Dictionary<string, int> expectedResult)
        {
            // assuming a valid test input
            var expectedTotalSum = sentence.Split(' ').Length;

            var result = _stringAnalysisService.GetWordLengthCount(sentence);

            Assert.Equal(expectedTotalSum, result.Sum(x => x.Value));
        }
    }
}
