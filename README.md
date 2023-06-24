# UseCase7
 Create unit tests that cover functionality to improve the quality and safety of the application.

The unit test project, UseCase7.Tests, contains two test suits. Each covers a corresponding class in UseCase7 project.

The first suite covers StudentConverter class. It has two classes, one for test setup StudentConverterTests.cs and one more for a specific method in the class under test - ConvertStudents. Each test case has a name in the following format: <MethodUnderTest_TestName>, where TestName provides a short summary for the test.

The second suite follows the same naming convention and covers logic for PlayerAnalyzer and its method CalculateScore. 

Each base test class inherits a method from the BaseTest to verify exceptions are thrown by the method under test. This class's purpose is to hold general methods that can be used in different test suits.

To run the tests in Visual Studion, just right-click on the solution and select "Run Tests".