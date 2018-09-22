using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RedTape.Test
{
    public class EntityGetterTests
    {
        private string _receivedResponse;

        [Theory]
        [InlineData("9429037784669", "FONTERRA LIMITED")]
        [InlineData("9429000024440", "KATHMANDU LIMITED")]
        [InlineData("9429000023795", "THE WAREHOUSE LIMITED")]
        public void Can_get_entity(string nzbn, string entityName)
        {
            When_I_request_this_entity(nzbn);

            Then_the_response_contains_this_value(entityName);
        }

        [Theory]
        [InlineData("9429037784669", "Tuesday, 25 August 1998")]
        [InlineData("9429000024440", "Tuesday, 9 January 1979")]
        [InlineData("9429000023795", "Wednesday, 8 December 1982")]
        public void Can_get_registration_date(string nzbn, string entityName)
        {
            When_I_request_this_entity(nzbn);

            Then_the_response_contains_this_value(entityName);
        }

        [Theory]
        [InlineData("9429037784669", "Fanshawe Street")]
        [InlineData("9429000024440", "Tuam Street")]
        [InlineData("9429000023795", "Graham Street")]
        public void Can_get_address(string nzbn, string entityName)
        {
            When_I_request_this_entity(nzbn);

            Then_the_response_contains_this_value(entityName);
        }

        [Fact]
        public void Can_get_sole_trader()
        {
            When_I_request_this_entity("9429045991547");

            Then_the_response_contains_this_value("John Mason");
        }

        [Fact]
        public void Can_get_partnership()
        {
            When_I_request_this_entity("9429044572907");

            Then_the_response_contains_this_value("Jillian Frances Crone");
        }

        private void When_I_request_this_entity(string nzbn)
        {
            _receivedResponse = EntityGetter.Get(nzbn).Result;
        }

        private void Then_the_response_contains_this_value(string entityName)
        {
            Assert.Contains(entityName, _receivedResponse);
        }
    }
}
