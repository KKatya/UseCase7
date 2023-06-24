using UseCase7.Models;

namespace UseCase7.Tests
{
    /// <summary>
    /// Tests setup for <see cref="StudentConverter"/>
    /// </summary>
    public partial class StudentConverterTests
    {
        private List<Student> _students;
        private List<Student> _resultStudents;
        private StudentConverter _studentConverter;

        /// <summary>
        /// Setup constructor
        /// </summary>
        public StudentConverterTests()
        {
            _students = new List<Student>();
            _resultStudents = new List<Student>();
            _studentConverter = new StudentConverter();
        }

        #region GIven
        private void GivenNullListProvided() => _students = null!;

        private void GivenNoStudentsProvided() => _students = new List<Student>();

        protected void GivenAStudent(int age, int grade) => _students.Add(new Student { Age = age, Grade = grade });
        #endregion

        #region When
        private void WhenConvertingStudents() => _resultStudents = _studentConverter.ConvertStudents(_students);
        #endregion

        #region Then
        private void ThenAStudentIs(bool honnorRoll, bool exceptional, bool passed)
        {
            Assert.Equal(honnorRoll, _resultStudents[0].HonorRoll);
            Assert.Equal(exceptional, _resultStudents[0].Exceptional);
            Assert.Equal(passed, _resultStudents[0].Passed);
        }

        private void ThenEmptyResultReturned()
        {
            Assert.Empty(_resultStudents);
        }

        private static void ThenErrorIsThrown<TException>(Action when) where TException : Exception
        {
            Assert.Throws<TException>(when);
        }
        #endregion
    }
}