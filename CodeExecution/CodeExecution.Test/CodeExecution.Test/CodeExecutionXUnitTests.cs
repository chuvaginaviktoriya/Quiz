using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
                @"public class Execution
                  {
                    public int Main(int a)
                    {
                        return a+10;
                    }
                  }";
            var inputArray = new object[] { a };

            var code = new Code(func);
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
                @"public class Execution
                  {
                    public int Main(int a, int b)
                    {
                        return a+b;
                    }
                  }";
            var inputArray = new object[] { a, b };

            var code = new Code(func);
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
                @"public class Execution
                  {
                    public int Main(int [] array)
                    {
                        var result = 0;
                        foreach (var item in array)
                            result += item;
                        return result;
                    }
                  }";
            var inputArray = new object[] { array };

            var code = new Code(func);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected.ToString(), actual);
        }

        [Fact]
        public void MethodWithGenericList_SuccessfulExecution()
        {
            var array = new string[] { "111", "22", "3333", "4" };
            var expected = "3333";
            var func =
                @"public class Execution
                  {
                    public string Main(string[] array)
                    {
                        var list = new List<string> (array);
                        return list[2];
                    }
                  }";
            var inputArray = new object[] { array };
            
            var code = new Code(func);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("word","WORD")]
        [InlineData("Word", "WORD")]
        [InlineData("WORD", "WORD")]
        [InlineData("  wOrd", "  WORD")]
        public void MethodWithStringData_SuccessfulExecution(string word, string expected)
        {
            var func =
                @"public class Execution
                  {
                    public string Main(string word)
                    {                       
                        return word.ToUpper();
                    }
                  }";
            var inputArray = new object[] { word };

            var code = new Code(func);
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
                @"public class Execution
                  {
                    public char Main(string word, int index)
                    {                       
                        return word[index];
                    }
                  }";
            var inputArray = new object[] { word, index };

            var code = new Code(func);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected.ToString(), actual);
        }

        [Fact]
        public void MethodWithLinq_SuccessfulExecution()
        {
            var expected = "A";
            var func =
                @"public class Execution
                  {
                    public char Main(int[] users)
                    {
                        var constructed = new BigInteger(3535);
                        return 'A';
                    }
                  }";

            var inputArray = new object[] { new object[] {1,2} };

            var code = new Code(func);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void MethodWithException_TargetInvocationException()
        {
            var func =
                @"public class Execution
                  {
                    public char Main(string word, int index)
                    {                       
                        return word[index];
                    }
                  }";
            var inputArray = new object[] { "word", 4 };

            var code = new Code(func);

            Xunit.Assert.Throws<System.Reflection.TargetInvocationException>(
            () => code.GetSolution(inputArray));
        }


        [Fact]
        public void UsingOneCodeMoreThanOneTime_SuccessulExecution()
        {
            var func =
                @"public class Execution
                  {
                    public int Main(int a, int b)
                    {
                        return a+b;
                    }
                  }";
            var firstInputArray = new object[] { 1, 2 };
            var secondInputArray = new object[] { 4, 9 };

            var code = new Code(func);     
            var firstActual = code.GetSolution(firstInputArray);
            var secondActual = code.GetSolution(secondInputArray);

            Xunit.Assert.Equal("3", firstActual);
            Xunit.Assert.Equal("13", secondActual);
        }

        [Fact]
        public void MethodWithCompileErrors_ExceptionMessage()
        {
            var func =
                @"public class Execution
                  {
                    public int Main(int a, int b)
                    {+ 
                        return a+b;
                    }
                  }";

            var inputArray = new object[] { 1, 2 };
            var expected = Environment.NewLine+ "Problems at compile time!"+
            Environment.NewLine + @"line5: Недопустимый терм ""return"" в выражении";

            var code = new Code(func);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected, actual);
        }

       
    }
}
