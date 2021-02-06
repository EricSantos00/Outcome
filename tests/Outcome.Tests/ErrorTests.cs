using System;
using Xunit;

namespace Outcome.Tests
{
    public class ErrorTests
    {
        [Fact]
        public void Create_should_success()
        {
            const string propertyName = "property";
            const string errorMessage = "error";

            var error = new Error(propertyName, errorMessage);

            Assert.Equal(errorMessage, error.ErrorMessage);
            Assert.Equal(propertyName, error.PropertyName);
        }

        [Fact]
        public void Create_with_null_property_name_should_throw_exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Error(null, ""));
        }

        [Fact]
        public void Create_with_null_error_message_should_throw_exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Error("", null));
        }
        
        [Fact]
        public void Error_to_string_should_be_error_message()
        {
            const string propertyName = "property";
            const string errorMessage = "error";

            var error = new Error(propertyName, errorMessage);

            Assert.Equal(errorMessage, error.ToString());
        }
    }
}