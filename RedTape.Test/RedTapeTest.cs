﻿using Newtonsoft.Json;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using Xunit;

namespace RedTape.Test
{
    public class RedTapeTest
    {
        private SkillRequest _skillRequest;
        private SkillResponse _skillResponse;

        [Theory]
        [InlineData("9429037784669")]
        public void Can_get_by_nzbn(string nzbn)
        {
            Given_a_request_for_this_nzbn(string.Format(@", ""value"": ""{0}""", nzbn));

            When_I_send_it_to_the_function();

            Then_the_response_is_valid();
        }

        private void Given_a_request_for_this_nzbn(string nzbn)
        {
            var skillAsString = string.Format(Template, nzbn);

            _skillRequest = JsonConvert.DeserializeObject<SkillRequest>(skillAsString);
        }

        private void When_I_send_it_to_the_function()
        {
            var function = new Function();

            _skillResponse = function.FunctionHandler(_skillRequest, null);
        }

        private void Then_the_response_is_valid()
        {
            var output = _skillResponse.Response.OutputSpeech as PlainTextOutputSpeech;

            Assert.NotNull(output);

            Assert.Contains("That New Zealand Business Number is for the entity", output.Text);
        }

        private const string Template = @"{{
  ""session"": {{
    ""sessionId"": ""SessionId.998c5b13-09bd-4434-ae44-4576c220963e"",
    ""application"": {{
      ""applicationId"": ""amzn1.ask.skill.b22bd929-3d02-4b86-99d3-1203791adea4""
    }},
    ""attributes"": {{}},
    ""user"": {{
      ""userId"": ""amzn1.ask.account.AHPFKMH3ZUSH725A5ZQWFW665FC2CCSHCA6HJ4IZHTPLDPZWN3K3YMURLPCVO5W23DUQ5YKXJSYMU22ZZR376S2ULHRHETVSOVXWK5P3IRWQCEGP3WGK6IZRG33IONEAMGXLBVANAASXMHOLWTWEN3IWQMDIU4II4G7SKB73SD3S3EM2B2KPCHNZOKOWHRZFWHIOINWXDBEYRMI""
    }},
    ""new"": true
  }},
  ""request"": {{
    ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.51fb17aa-497f-4308-8a3a-ad72ebdd64b9"",
    ""locale"": ""en-US"",
    ""timestamp"": ""2017-06-17T04:02:07Z"",
    ""intent"": {{
      ""name"": ""BusinessNumberIntent"",
      ""slots"": {{
        ""nzbn"": {{
          ""name"": ""nzbn""{0}
        }}
      }}
    }}
  }},
  ""version"": ""1.0""
}}";
    }
}
