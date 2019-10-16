using System;
using System.Linq;
using Xunit;
using Extension.Methods;

namespace Extensions.UnitTest
{
    public class DateTimeExtensionTests
    {
        #region DateTimeExtensions.ToMMDDYY

        [Fact]
        public void ToMMDDYY_WithoutSeparator_ShouldPass()
        {
            var expected = "09/24/2019";

            var dateTime = new DateTime(2019, 09, 24);
            var actual = dateTime.ToMMDDYY();

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void ToMMDDYY_WithSeparator_ShouldPass()
        {
            var expected = "09-24-2019";

            var dateTime = new DateTime(2019, 09, 24);
            var actual = dateTime.ToMMDDYY('-');

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void ToMMDDYY_ForNullableDateTime_WithoutSeparator_ShouldPass()
        {
            var expected = string.Empty;

            DateTime? dateTime = null;
            var actual = dateTime.ToMMDDYY();

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void ToMMDDYY_ForNullableDateTime_WithSeparator_ShouldPass()
        {
            var expected = "09-24-2019";

            DateTime? dateTime = new DateTime(2019, 09, 24);
            var actual = dateTime.ToMMDDYY('-');

            Assert.Equal(actual, expected);
        }

        #endregion

        #region DateTimeExtensions.ToDDMMYY

        [Fact]
        public void ToDDMMYY_WithoutSeparator_ShouldPass()
        {
            var expected = "24/09/2019";

            var dateTime = new DateTime(2019, 09, 24);
            var actual = dateTime.ToDDMMYY();

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void ToDDMMYY_WithSeparator_ShouldPass()
        {
            var expected = "24-09-2019";

            var dateTime = new DateTime(2019, 09, 24);
            var actual = dateTime.ToDDMMYY('-');

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void ToDDMMYY_ForNullableDateTime_WithoutSeparator_ShouldPass()
        {
            var expected = string.Empty;

            DateTime? dateTime = null;
            var actual = dateTime.ToDDMMYY();

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void ToDDMMYY_ForNullableDateTime_WithSeparator_ShouldPass()
        {
            var expected = "24-09-2019";

            DateTime? dateTime = new DateTime(2019, 09, 24);
            var actual = dateTime.ToDDMMYY('-');

            Assert.Equal(actual, expected);
        }

        #endregion

        #region DateTimeExtensions.ToTime

        [Fact]
        public void ToTime_ShouldPass()
        {
            var expected = "11:11 AM";

            var dateTime = new DateTime(2019, 09, 24, 11, 11, 11);
            var actual = dateTime.ToTime();

            Assert.Equal(actual, expected);
        }
        [Fact]
        public void ToTime_ShouldFail()
        {
            var expected = "11:11 PM";

            var dateTime = new DateTime(2019, 09, 24, 11, 11, 11);
            var actual = dateTime.ToTime();

            Assert.NotEqual(actual, expected);
        }

        [Fact]
        public void ToTime_ForNullableDateTime_ShouldPass()
        {
            var expected = "11:11 AM";

            DateTime? dateTime = new DateTime(2019, 09, 24, 11, 11, 11);
            var actual = dateTime.ToTime();

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void ToTime_ForNullableDateTime_WithNullValue_ShouldPass()
        {
            var expected = string.Empty;

            DateTime? dateTime = null;
            var actual = dateTime.ToTime();

            Assert.Equal(actual, expected);
        }

        #endregion

        #region DateTime.DateDiff

        [Theory]
        [InlineData(2010, 1, 1, 0, 0, 0, 0, 2019, 1, 1, 0, 0, 0, 0, "year", 9)]
        [InlineData(2010, 1, 1, 0, 0, 0, 0, 2019, 1, 1, 0, 0, 0, 0, "yy", 9)]
        [InlineData(2010, 1, 1, 0, 0, 0, 0, 2019, 1, 1, 0, 0, 0, 0, "yyyy", 9)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 12, 1, 0, 0, 0, 0, "quarter", 3)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 12, 1, 0, 0, 0, 0, "q", 3)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 12, 1, 0, 0, 0, 0, "qq", 3)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 12, 1, 0, 0, 0, 0, "month", 11)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 12, 1, 0, 0, 0, 0, "m", 11)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 12, 1, 0, 0, 0, 0, "mm", 11)]
        [InlineData(2019, 12, 1, 0, 0, 0, 0, 2019, 12, 11, 0, 0, 0, 0, "day", 10)]
        [InlineData(2019, 12, 1, 0, 0, 0, 0, 2019, 12, 11, 0, 0, 0, 0, "d", 10)]
        [InlineData(2019, 12, 1, 0, 0, 0, 0, 2019, 12, 11, 0, 0, 0, 0, "dd", 10)]
        [InlineData(2019, 12, 1, 0, 0, 0, 0, 2019, 12, 11, 0, 0, 0, 0, "week", 1)]
        [InlineData(2019, 12, 1, 0, 0, 0, 0, 2019, 12, 11, 0, 0, 0, 0, "wk", 1)]
        [InlineData(2019, 12, 1, 0, 0, 0, 0, 2019, 12, 11, 0, 0, 0, 0, "ww", 1)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 1, 2, 0, 0, 0, 0, "hour", 24)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 1, 2, 0, 0, 0, 0, "hh", 24)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 1, 1, 2, 20, 0, 0, "minute", 140)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 1, 1, 2, 20, 0, 0, "mi", 140)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 1, 2, 2, 22, 0, 0, "n", 1582)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 1, 1, 1, 22, 22, 0, "second", 4942)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 1, 1, 0, 0, 22, 0, "s", 22)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 1, 1, 1, 22, 20, 0, "ss", 4940)]
        [InlineData(2019, 1, 1, 0, 0, 0, 0, 2019, 1, 1, 0, 0, 0, 60, "millisecond", 60)]
         
        public void DateDiff_ShouldPass(
            int startYear, int startMonth, int startDay,
            int startHour, int startMinute, int startSec, int startMiliSecond,
            int endYear, int endMonth, int endDay,
            int endHour, int endMinute, int endSec, int endMiliSecond,
            string datePart, long expected)
        {
            var startDate = new DateTime(startYear, startMonth, startDay, startHour, startMinute, startSec, startMiliSecond);
            var endDate = new DateTime(endYear, endMonth, endDay, endHour, endMinute, endSec, endMiliSecond);

            var actual = startDate.DateDiff(endDate, datePart);

            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData(2010, 1, 1, 0, 0, 0, 0, 2019, 1, 1, 0, 0, 0, 0, "")]
        public void DateDiff_ShouldFail(
            int startYear, int startMonth, int startDay,
            int startHour, int startMinute, int startSec, int startMiliSecond,
            int endYear, int endMonth, int endDay,
            int endHour, int endMinute, int endSec, int endMiliSecond,
            string datePart)
        {
            var startDate = new DateTime(startYear, startMonth, startDay, startHour, startMinute, startSec, startMiliSecond);
            var endDate = new DateTime(endYear, endMonth, endDay, endHour, endMinute, endSec, endMiliSecond);

            Action actual = () => startDate.DateDiff(endDate, datePart);

            Assert.Throws<Exception>(actual);
        }

        #endregion

        #region DateTime.ToReadableTime



        #endregion
    }
}
