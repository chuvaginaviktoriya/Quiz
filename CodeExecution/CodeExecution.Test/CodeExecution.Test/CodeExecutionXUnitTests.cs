using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace CodeExecution.Test
{
    [TestClass]
    public class CodeExecutionXUnitTests
    {

        [Theory]
        [InlineData(1, 11)]
        [InlineData(-5, 5)]
        [InlineData(-15, -5)]
        [InlineData(-10, 0)]
        public void MethodWithOneInput_SuccessfulExecution(int a, int expected)
        {
            var func =
                @"public static class Execution
                  {
                    public static int Main(int a)
                    {
                        return a+10;
                    }
                  }";
            var inputArray = new object[] { a };

            Code code;
            CodeCreation.TryCreateCode(func, out code, out var errors);

            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected.ToString(), actual);
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(5, 5)]
        [InlineData(10, 55)]
        public void MethodInvokingPrivateMethod_SuccessfulExecution(int x, int expected)
        {
            var func =
                @"public static class Execution
                  {
                    public static int Main(int x)
                    {
                        return Fibonacci(x);
                    }

	                private static int Fibonacci(int x)
	                {
		                if (x<=1) return x;
		                return Fibonacci(x-1)+Fibonacci(x-2);
	                }
                }";
            var inputArray = new object[] { x };

            Code code;
            CodeCreation.TryCreateCode(func, out code, out var errors);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected.ToString(), actual);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-5, 2, -3)]
        [InlineData(-5, -2, -7)]
        public void MethodWithTwoInputs_SuccessfulExecution(int a, int b, int expected)
        {
            var func =
                @"public static class Execution
                  {
                    public static int Main(int a, int b)
                    {
                        return a+b;
                    }
                  }";
            var inputArray = new object[] { a, b };

            Code code;
            CodeCreation.TryCreateCode(func, out code, out var errors);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected.ToString(), actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, 10)]
        [InlineData(new int[] { 1, 2, 3, 4, 5}, 15)]
        [InlineData(new int[] { -1, -2, -3, -4 }, -10)]
        [InlineData(new int[] { 1, 2, -3, 0 }, 0)]
        public void MethodWithArrayInput_SuccessfulExecution(int [] array, int expected)
        {
            var func =
                @"public static class Execution
                  {
                    public static int Main(int [] array)
                    {
                        var result = 0;
                        foreach (var item in array)
                            result += item;
                        return result;
                    }
                  }";
            var inputArray = new object[] { array };

            Code code;
            CodeCreation.TryCreateCode(func, out code, out var errors);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected.ToString(), actual);
        }

        [Fact]
        public void MethodWithGenericList_SuccessfulExecution()
        {
            var array = new string[] { "111", "22", "3333", "4" };
            var expected = "3333";
            var func =
                @"
                  public static class Execution
                  {
                    public static string Main(string[] array)
                    {
                        var list = new List<string> (array);
                        return list[2];
                    }
                  }";
            var inputArray = new object[] { array };

            Code code;
            CodeCreation.TryCreateCode(func, out code, out var errors);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2 }, 2)]
        [InlineData(new int[] { 3, 4 }, 4)]
        [InlineData(new int[] { 2, 4}, 4)]
        public void MethodWithInstanceOfCustomClass_SuccessfulExecution(int[] array, int expected)
        {
            var func =
                @"
                  public static class Execution
                  {
                    public static int Main(int[] array)
                    {
                        var point = new Point(array[0], array[1]);
                        var reversePoint = point.GetReversePoint();

                        return reversePoint.X;
                    }
                  }

                  public class Point
                  {
                    public int X;
                    public int Y;
                    
                    public Point(int x, int y)
                    {
                       X = x;
                       Y = y;
                    }

                    public Point GetReversePoint()
                    {
                        var point = new Point(Y,X);
                        return point;
                    }
                  }";
            var inputArray = new object[] { array };

            Code code;
            CodeCreation.TryCreateCode(func, out code, out var errors);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected.ToString(), actual);
        }

        [Theory]
        [InlineData("word","WORD")]
        [InlineData("Word", "WORD")]
        [InlineData("WORD", "WORD")]
        [InlineData("  wOrd", "  WORD")]
        public void MethodWithStringData_SuccessfulExecution(string word, string expected)
        {
            var func =
                @"public static class Execution
                  {
                    public static string Main(string word)
                    {                       
                        return word.ToUpper();
                    }
                  }";
            var inputArray = new object[] { word };

            Code code;
            CodeCreation.TryCreateCode(func, out code, out var errors);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("word", 0, 'w')]
        [InlineData("Word", 1, 'o')]
        [InlineData("WORD", 3, 'D')]
        public void MethodWithDifferentDataTypes_SuccessfulExecution(string word, int index, char expected)
        {
            var func =
                @"public static class Execution
                  {
                    public static char Main(string word, int index)
                    {                       
                        return word[index];
                    }
                  }";
            var inputArray = new object[] { word, index };

            Code code;
            CodeCreation.TryCreateCode(func, out code, out var errors);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected.ToString(), actual);
        }

        [Fact]
        public void MethodWithLinq_SuccessfulExecution()
        {
            var expected = "A";
            var func =
                @"public static class Execution
                  {
                    public static char Main(int[] users)
                    {
                        var list = new List<int> (users);
                        list.OrderBy(a=>a);
                        return 'A';
                    }
                  }";

            var inputArray = new object[] { new int[] {1,2} };

            Code code;
            CodeCreation.TryCreateCode(func, out code, out var errors);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected, actual);
        }    

        [Fact]
        public void MethodWithExeptiomMessageInInvokation_ExeptionMessage()
        {
            var func =
                @"public static class Execution
                  {
                    public static char Main(string word, int index)
                    {                       
                        return word[index];
                    }
                  }";
            var inputArray = new object[] { "word", 4 };
            var expected = "Адресат вызова создал исключение.";

            Code code;
            CodeCreation.TryCreateCode(func, out code, out var errors);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected, actual);

        }

        [Fact]
        public void MethodWithWrongInputParamsAmount_ExeptionMessage()
        {
            var func =
                @"public static class Execution
                  {
                    public static char Main(string word, int index)
                    {                       
                        return word[index];
                    }
                  }";
            var inputArray = new object[] { "word", 4, 2 };
            var expected = "Несоответствие числа параметров.";

            Code code;
            CodeCreation.TryCreateCode(func, out code, out var errors);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected, actual);

        }


        [Fact]
        public void UsingOneCodeMoreThanOneTime_SuccessulExecution()
        {
            var func =
                @"public static class Execution
                  {
                    public static int Main(int a, int b)
                    {
                        return a+b;
                    }
                  }";
            var firstInputArray = new object[] { 1, 2 };
            var secondInputArray = new object[] { 4, 9 };

            Code code;
            CodeCreation.TryCreateCode(func, out code, out var errors);
            var firstActual = code.GetSolution(firstInputArray);
            var secondActual = code.GetSolution(secondInputArray);

            Xunit.Assert.Equal("3", firstActual);
            Xunit.Assert.Equal("13", secondActual);
        }      
    }
}
