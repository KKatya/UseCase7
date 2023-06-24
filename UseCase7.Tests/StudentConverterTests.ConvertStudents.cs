namespace UseCase7.Tests
{
    /// <summary>
    /// Tests for <see cref="StudentConverter.ConvertStudents(List{Models.Student})"/>
    /// </summary>
    public partial class StudentConverterTests
    {
        #region Positive Test Cases
        /// <summary>
        /// Given an array with a student object of age 21 or above and grade above 90, 
        /// the function should return an object with the additional field HonorRoll = true.
        /// </summary>
        [Theory]
        [InlineData(21, 91)]
        [InlineData(25, 100)]
        public void StudentConverted_HighAchiever(int age, int grade)
        {
            GivenAStudent(age, grade);
            WhenConvertingStudents();
            ThenAStudentIs(honnorRoll: true, exceptional: false, passed: false);
        }

        /// <summary>
        /// Given an array with a student object of age less than 21 and grade above 90, 
        /// the function should return an object with the additional field Exceptional = true. 
        /// </summary>
        [Fact]
        public void StudentConverted_ExceptionalYoungHighAchiever()
        {
            GivenAStudent(age: 20, grade: 91);
            WhenConvertingStudents();
            ThenAStudentIs(honnorRoll: false, exceptional: true, passed: false);
        }

        /// <summary>
        /// Given an array with a student object of grade between 71 and 90 (inclusive), 
        /// the function should return an object with the additional field Passed = true.
        /// </summary>
        [Theory]
        [InlineData(71)]
        [InlineData(80)]
        [InlineData(90)]
        public void StudentConverted_PassedStudent(int grade)
        {
            GivenAStudent(age: 0, grade);
            WhenConvertingStudents();
            ThenAStudentIs(honnorRoll: false, exceptional: false, passed: true);
        }

        /// <summary>
        /// Given an array with a student object of grade 70 or less, 
        /// the function should return an object with the additional field Passed = false. 
        /// </summary>
        [Theory]
        [InlineData(70)]
        [InlineData(69)]
        public void StudentConverted_FailedStudent(int grade)
        {
            GivenAStudent(age: 0, grade);
            WhenConvertingStudents();
            ThenAStudentIs(honnorRoll: false, exceptional: false, passed: false);
        }
        #endregion

        #region Negative Test Cases
        /// <summary>
        /// Given an empty array, the function should return an empty array. 
        /// </summary>
        [Fact]
        public void StudentConverted_EmptyArray()
        {
            GivenNoStudentsProvided();
            WhenConvertingStudents();
            ThenEmptyResultReturned();
        }

        /// <summary>
        /// Given an empty array, the function should return an empty array. 
        /// </summary>
        [Fact]
        public void StudentConverted_NotAnArray()
        {
            GivenNullListProvided();
            ThenErrorIsThrown<ArgumentNullException>(WhenConvertingStudents);
        }
        #endregion
    }
}