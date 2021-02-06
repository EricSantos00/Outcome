using Outcome.Exceptions;
using Outcome.Extensions;
using Xunit;

namespace Outcome.Tests
{
    public class ResultTests
    {
        [Fact]
        public void Check_ifs_succeeded_should_result_success()
        {
            const string resultTest1 = "result1";
            const string resultTest2 = "result2";
            const string resultTest3 = "result3";

            var result = Result<string>.Ensure()
                .CheckIf(false, nameof(resultTest1), resultTest1)
                .CheckIf(() => false, nameof(resultTest2), resultTest2)
                .IfSucceeded(resultTest3);

            Assert.True(result.IsSuccess);
            Assert.Equal(resultTest3, result.Value);
        }

        [Fact]
        public void Check_ifs_failed_should_result_fail()
        {
            const string resultTest1 = "result1";
            const string resultTest2 = "result2";
            const string resultTest3 = "result3";

            var result = Result<string>.Ensure()
                .CheckIf(true, nameof(resultTest1), resultTest1)
                .CheckIf(() => true, nameof(resultTest2), resultTest2)
                .IfSucceeded(resultTest3);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Result_fail_access_value_should_throw_exception()
        {
            const string resultTest1 = "result1";
            const string resultTest2 = "result2";
            const string resultTest3 = "result3";

            var result = Result<string>.Ensure()
                .CheckIf(true, nameof(resultTest1), resultTest1)
                .CheckIf(() => true, nameof(resultTest2), resultTest2)
                .IfSucceeded(resultTest3);

            Assert.Throws<ResultFailException>(() => result.Value);
        }

        [Fact]
        public void Any_check_if_failed_should_result_fail()
        {
            const string resultTest1 = "result1";
            const string resultTest2 = "result2";
            const string resultTest3 = "result3";
            const string resultTest4 = "result4";

            var result = Result<string>.Ensure()
                .CheckIf(true, nameof(resultTest1), resultTest1)
                .CheckIf(false, nameof(resultTest2), resultTest2)
                .CheckIf(() => true, nameof(resultTest3), resultTest3)
                .IfSucceeded(resultTest4);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Result_fail_errors_messages_should_be_expected()
        {
            const string resultTest1 = "result1";
            const string resultTest2 = "result2";
            const string resultTest3 = "result3";

            var result = Result<string>.Ensure()
                .CheckIf(true, nameof(resultTest1), resultTest1)
                .CheckIf(() => true, nameof(resultTest2), resultTest2)
                .IfSucceeded(resultTest3);

            Assert.Equal(2, result.Errors.Count);
            Assert.Contains(result.Errors, c => c.ErrorMessage == resultTest1 && c.PropertyName == nameof(resultTest1));
            Assert.Contains(result.Errors, c => c.ErrorMessage == resultTest2 && c.PropertyName == nameof(resultTest2));
        }

        [Fact]
        public void Append_error_should_append_error()
        {
            const string resultTest1 = "result1";
            const string resultTest2 = "result2";
            const string resultTest3 = "result3";

            var result = Result<string>.Ensure()
                .CheckIf(false, nameof(resultTest1), resultTest1)
                .IfSucceeded(resultTest2);

            result = result.AppendError(nameof(resultTest3), resultTest3);

            Assert.Contains(result.Errors, c => c.ErrorMessage == resultTest3 && c.PropertyName == nameof(resultTest3));
            Assert.True(result.IsFailure);
        }
    }
}