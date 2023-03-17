using Services.PublicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Systems.Services
{
    public class DepotServiceTests
    {
        [Fact]
        public void testGetDepots()
        {
            //Arrange

            //Act
            var sut = DepotService.getDepots();

            //Assert
            Assert.NotNull(sut);
            Assert.True(sut.Count() > 0);
        }

        [Fact]
        public void doOutOperation()
        {
            //Act
            var result = DepotService.DoOutOperation(1,1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void doInOperation()
        {
            //Act
            var result = DepotService.DoInOperation(1,1);

            //Assert
            Assert.NotNull(result);
        }
    }
}
