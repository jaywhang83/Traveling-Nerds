using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traveling_Nerds.Models;
using Xunit;

namespace TravelingNerds.Tests
{
    public class PostingTest
    {

        [Fact]
        public void GetTitleTest()
        {
            // Arrange
            var post = new Posting();
            post.Title = "What to do in Split, Croatia!";

            // Act
            var result = post.Title;

            // Assert
            Assert.Equal("What to do in Split, Croatia!", result); 
        }

        [Fact]
        public void GetAuthorTest()
        {
            // Arrange
            var post = new Posting();
            post.Author = "Sam Jones";

            // Act
            var result = post.Author;

            // Assert
            Assert.Equal("Sam Jones", result);
        }

        [Fact]
        public void GetDescriptionTest()
        {
            // Arrange
            var post = new Posting();
            post.Description = "Info about place to see, things to do, foods to eat and much much more";

            // Act
            var result = post.Description;

            // Assert
            Assert.Equal("Info about place to see, things to do, foods to eat and much much more", result);
        }
    }
}
