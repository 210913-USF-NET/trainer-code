using System;
using Xunit;
using Models;

namespace Tests
{
    public class ModelTests
    {
        [Fact]
        public void RestaurantShouldCreate()
        {
            //Arrange & Act
            Restaurant test = new Restaurant();

            Assert.NotNull(test);
        }

        [Fact]
        public void RestaurantsShouldSetValidData()
        {
            //Arrange
            Restaurant test = new Restaurant();
            string testName = "test restaurant";

            //Act
            test.Name = testName;

            //Assert
            Assert.Equal(testName, test.Name);
        }


        [Theory]
        [InlineData("")]
        [InlineData("%$@^^")]
        public void RestaurantsShouldNotAllowInvalidName(string input)
        {
            //Arrange
            Restaurant test = new Restaurant();
            
            //Act & Assert
            //When I try to set the restaurant's name to an invalid data
            //We make sure that the program throws input invalid exception
            Assert.Throws<InputInvalidException>(() => test.Name = input);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(10000)]
        public void ReviewShouldNotSetInvalidRating(int input)
        {
            Review test = new Review();

            Assert.Throws<InputInvalidException>(() => test.Rating = input);
        }
    }
}
