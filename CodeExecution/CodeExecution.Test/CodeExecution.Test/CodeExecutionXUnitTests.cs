using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace CodeExecution.Test
{
    [TestClass]
    public class CodeExecutionXUnitTests
    {

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-5, 2, -3)]
        [InlineData(-5, -2, -7)]
        public void AddingFunction_SuccessfulAddition(int a, int b, int expected)
        {
            var func = 
                @"using System.IO;
                using System;

                public class Addition
                {
                    public int Add(int a, int b)
                    {
                        return a+b;
                    }
                }";

            var inputArray = new object[] { a, b };

            var code = new Code("Addition", "Add", func);
            var actual = code.GetSolution(inputArray);

            Xunit.Assert.Equal(expected.ToString(), actual);
        }
    }
}
