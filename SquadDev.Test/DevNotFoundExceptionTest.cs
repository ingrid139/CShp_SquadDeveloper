using SquadDev.Exceptions;
using System;
using Xunit;

namespace SquadDev.Test
{
    public class DevNotFoundExceptionTest
    {
        [Fact]
        public void DevNotFoundException()
        {
            Assert.ThrowsAsync<DevNotFoundException>(() => throw new DevNotFoundException());
        }

        [Fact]
        public void DevNotFoundException_Message()
        {
            var ex = Assert.ThrowsAsync<DevNotFoundException>(() => throw new DevNotFoundException("invalid operation"));
            Assert.Equal("invalid operation", ex.Result.Message);
        }

        [Fact]
        public void DevNotFoundException_Message_Exception()
        {
            var exception = new Exception("nova exceção");
            var ex = Assert.ThrowsAsync<DevNotFoundException>(() => throw new DevNotFoundException("invalid operation", exception));
            Assert.Equal("invalid operation", ex.Result.Message);
        }
    }

}
