using UseCase7.Models;
using UseCase7.Services;

namespace UseCase7.Tests
{
    /// <summary>
    /// Tests setup for <see cref="StudentConverter"/>
    /// </summary>
    public partial class StudentConverterTests : BaseTest
    {
        private List<Student> _students;
        private List<Student> _resultStudents;

        /// <summary>
        /// Setup constructor
        /// </summary>
        public StudentConverterTests()
        {
            _students = new List<Student>();
            _resultStudents = new List<Student>();
        }

        #region Given
        private void GivenNullListProvided() => _students = null!;

        private void GivenNoStudentsProvided() => _students = new List<Student>();

        protected void GivenAStudent(int age, int grade) => _students.Add(new Student { Age = age, Grade = grade });
        #endregion

        #region When
        private void WhenConvertingStudents() => _resultStudents = StudentConverter.ConvertStudents(_students);
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
        #endregion
    }
}