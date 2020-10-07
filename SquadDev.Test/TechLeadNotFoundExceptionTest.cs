using SquadDev.Exceptions;
using System;
using Xunit;

namespace SquadDev.Test
{
    public class TechLeadNotFoundExceptionTest
    {
        [Fact]
        public void TechLeadNotFoundException()
        {
            Assert.ThrowsAsync<TechLeadNotFoundException>(() => throw new TechLeadNotFoundException());
        }

        [Fact]
        public void TechLeadNotFoundException_Message()
        {
            var ex = Assert.ThrowsAsync<TechLeadNotFoundException>(() => throw new TechLeadNotFoundException("invalid operation"));
            Assert.Equal("invalid operation", ex.Result.Message);
        }

        [Fact]
        public void TechLeadNotFoundException_Message_Exception()
        {
            var exception = new Exception("nova exceção");
            var ex = Assert.ThrowsAsync<TechLeadNotFoundException>(() => throw new TechLeadNotFoundException("invalid operation", exception));
            Assert.Equal("invalid operation", ex.Result.Message);
        }
    }
}
