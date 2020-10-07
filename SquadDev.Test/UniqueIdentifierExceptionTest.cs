using SquadDev.Exceptions;
using System;
using Xunit;

namespace SquadDev.Test
{
    public class UniqueIdentifierExceptionTest
    {
        [Fact]
        public void UniqueIdentifierException()
        {
            Assert.ThrowsAsync<UniqueIdentifierException>(() => throw new UniqueIdentifierException());
        }

        [Fact]
        public void UniqueIdentifierException_Message()
        {
            var ex = Assert.ThrowsAsync<UniqueIdentifierException>(() => throw new UniqueIdentifierException("invalid operation"));
            Assert.Equal("invalid operation", ex.Result.Message);
        }

        [Fact]
        public void UniqueIdentifierException_Message_Exception()
        {
            var exception = new Exception("nova exceção");
            var ex = Assert.ThrowsAsync<UniqueIdentifierException>(() => throw new UniqueIdentifierException("invalid operation", exception));
            Assert.Equal("invalid operation", ex.Result.Message);
        }
    }
}
