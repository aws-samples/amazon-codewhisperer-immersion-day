using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

using Xunit;
using MotionPictures.Data;
using MotionPictures.Models;
using MotionPictures.Pages.Movies;

namespace MotionPictures.Tests.UnitTests
{
    public class CrudPageTests
    {
        public CrudPageTests()
        { }
    

        [Fact]
        public async Task OnPostAsync_Create_ReturnsARedirectToPageResult()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            var contextOptions = new DbContextOptionsBuilder<MovieContext>()
                .UseSqlite(connection)
                .Options;

            // Create the schema and seed some data
            
            using var context = new MovieContext(contextOptions);

            if (context.Database.EnsureCreated())
            {
                using var insertCommand = context.Database.GetDbConnection().CreateCommand();
                insertCommand.CommandText = @"
                    INSERT INTO Movie (Title, ReleaseDate, Genre, Price) VALUES ('Back to the Future Part II', '1989-11-22 00:00:00.0', 'Sci-Fi/Comedy', '9.95')";
                insertCommand.ExecuteNonQuery();
            }
            
            // Arrange
            var pageModel = new CreateModel(context)
            {
                Movie = new Movie(){
                    Title = "Back to the Future Part III",
                    ReleaseDate = new DateTime(1990, 05, 25),
                    Genre = "Sci-Fi/Comedy",
                    Price = 9.95M
                }
            };
            var before = await context.Movie.ToListAsync();

            // Act
            var result = await pageModel.OnPostAsync();

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var after = await context.Movie.ToListAsync();
            Assert.Equal(before.Count + 1, after.Count);
         
            connection.Dispose();
        }

        [Fact]
        public async Task OnPostAsync_Delete_ReturnsARedirectToPageResult()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            var contextOptions = new DbContextOptionsBuilder<MovieContext>()
                .UseSqlite(connection)
                .Options;

            // Create the schema and seed some data
            
            using var context = new MovieContext(contextOptions);

            if (context.Database.EnsureCreated())
            {
                using var insertCommand = context.Database.GetDbConnection().CreateCommand();
                insertCommand.CommandText = @"
                    INSERT INTO Movie (ID, Title, ReleaseDate, Genre, Price) VALUES (2567, 'Back to the Future Part II', '1989-11-22 00:00:00.0', 'Sci-Fi/Comedy', '9.95')";
                insertCommand.ExecuteNonQuery();
            }
            
            // Arrange
            var pageModel = new DeleteModel(context);
            var before = await context.Movie.ToListAsync();

            // Act
            var result = await pageModel.OnPostAsync(2567);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var after = await context.Movie.ToListAsync();
            Assert.Equal(before.Count - 1, after.Count);
         
            connection.Dispose();
        }
    }
}