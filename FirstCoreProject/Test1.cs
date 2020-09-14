using Xunit;
using FirstLib;
namespace FirstCoreProject.tests
{
    public class FirstCoreProjectTests
    {
        [Fact]
        public void AdditionTest()
        {
            //Given
            var ob = new Addition(1, 2);
            //When

            //Then
            Assert.Equal(3, ob.calculate());
        }

        [Fact]
        public void SubtractionTest()
        {
            //Given
            var ob = new Subtraction(2, 1);
            //When

            //Then
            Assert.Equal(1, ob.calculate());
        }

        [Fact]
        public void MultiplicationTest()
        {
            //Given
            var ob = new Multiplication(2, 2);
            //When

            //Then
            Assert.Equal(4, ob.calculate());
        }


        [Fact]
        public void DivisionTest()
        {
            //Given
            var ob = new Division(2, 2);
            //When

            //Then
            Assert.Equal(1, ob.calculate());
        }
    }
}