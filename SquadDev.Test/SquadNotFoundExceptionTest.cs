using SquadDev.Exceptions;
using System;
using Xunit;

namespace SquadDev.Test
{
    public class SquadNotFoundExceptionTest
    {
        [Fact]
        public void SquadNotFoundException()
        {
            Assert.ThrowsAsync<SquadNotFoundException>(() => throw new SquadNotFoundException());
        }

        [Fact]
        public void SquadNotFoundException_Message()
        {
            var ex = Assert.ThrowsAsync<SquadNotFoundException>(() => throw new SquadNotFoundException("invalid operation"));
            Assert.Equal("invalid operation", ex.Result.Message);
        }

        [Fact]
        public void SquadNotFoundException_Message_Exception()
        {
            var exception = new Exception("nova exceção");
            var ex = Assert.ThrowsAsync<SquadNotFoundException>(() => throw new SquadNotFoundException("invalid operation", exception));
            Assert.Equal("invalid operation", ex.Result.Message);
        }
    }
}
