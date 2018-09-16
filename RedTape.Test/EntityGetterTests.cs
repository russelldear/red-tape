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
        public void Can_get_entity(string nzbn, string entityName)
        {
            When_I_request_this_entity(nzbn);

            Then_I_get_the_entity_name(entityName);
        }

        private void When_I_request_this_entity(string nzbn)
        {
            _receivedResponse = EntityGetter.Get(nzbn).Result;
        }

        private void Then_I_get_the_entity_name(string entityName)
        {
            Assert.Contains(entityName, _receivedResponse);
        }
    }
}
