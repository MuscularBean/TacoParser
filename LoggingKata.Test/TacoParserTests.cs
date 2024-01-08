using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.569202, -84.540661, Taco Bell Union Cit...", -84.540661)]
        [InlineData("32.524115, -86.20775, Taco Bell Wetumpk...", -86.20775)]
        [InlineData("30.427835, -84.220516, Taco Bell Tallahassee...", -84.220516)]
        [InlineData("32.48032, -85.030559, Taco Bell Phenix Cit...", -85.030559)]
        [InlineData("32.637154,-85.41445,Taco Bell Opelik...", -85.41445)]
        

       
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        
        [Theory]
        [InlineData("33.375958,-84.569057,Taco Bell Peachtree Cit...", 33.375958)]
        [InlineData("32.359559,-86.2172,Taco Bell Montgomery...", 32.359559)]
        [InlineData("33.696915,-86.67977,Taco Bell Pinso...", 33.696915)]
        [InlineData("33.569202,-84.540661,Taco Bell Union Cit...", 33.569202)]
        [InlineData("34.8709,-85.519289,Taco Bell Trenton...", 34.8709)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse(line);

            Assert.Equal(expected, actual.Location.Latitude);
        }

    }
}
