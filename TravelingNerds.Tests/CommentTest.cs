using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traveling_Nerds.Models;
using Xunit;

namespace TravelingNerds.Tests
{
    public class CommentTest
    {
        [Fact]
        public void GetAuthorTest()
        {
            // Arrange
            var comment = new Comment();
            comment.Author = "Mike Jones";

            // Act
            var result = comment.Author;

            // Assert
            Assert.Equal("Mike Jones", result);
        }

        [Fact]
        public void GetContentTest()
        {
            // Arrange
            var comment = new Comment();
            comment.Content = "Croatia looks amazing!";

            // Act
            var result = comment.Content;

            // Assert
            Assert.Equal("Croatia looks amazing!", result);
        }     
    }
}
