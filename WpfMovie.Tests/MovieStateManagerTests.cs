using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMovie.Models;
using WpfMovie.Services;

namespace WpfMovie.Tests
{
    internal class MovieStateManagerTests
    {
        private MovieStateManager stateManager;

        [SetUp]
        public void SetUp()
        {
            stateManager = new MovieStateManager();
        }

        [Test]
        public void Serialize_ShouldCreateString()
        {
            // Arrange
            string title = "Test Title";
            string description = "Test Description";
            var aMovie = new Movie
            {
                Title = title,
                Description = description
            };

            // Act
            var movieString = stateManager.Serialize(aMovie);

            // Assert
            Assert.NotNull(movieString);
            Assert.IsNotEmpty(movieString);
        }

        [Test]
        public void Deserialize_ShouldCreateMovie()
        {
            // Arrange
            // First create a movie and serialize it to get a valid JSON-based string
            var originalMovie = new Movie
            {
                Title = "Test Title",
                Description = "Test Description"
            };
            var movieString = stateManager.Serialize(originalMovie);
            
            // Act
            var newMovie = stateManager.Deserialize(movieString);
            
            // Assert
            Assert.IsNotNull(newMovie);
            Assert.AreEqual("Test Title", newMovie.Title);
            Assert.AreEqual("Test Description", newMovie.Description);
        }

        [Test]
        public void Serialize_IsIdempotent()
        {
            // Arrange
            string title = "Test Title";
            string description = "Test Description";
            var aMovie = new Movie
            {
                Title = title,
                Description = description
            };

            // Act
            var movieString = stateManager.Serialize(aMovie);
            var newMovie = stateManager.Deserialize(movieString);

            // Assert
            Assert.IsNotNull(newMovie);
            Assert.AreEqual(aMovie.Title, newMovie.Title);
            Assert.AreEqual(aMovie.Description, newMovie.Description);
        }
    }
}
