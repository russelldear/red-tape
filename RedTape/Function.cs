using Amazon.Lambda.Core;
using Newtonsoft.Json;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace RedTape
{
    public class Function
    {
        private const string DefaultNzbn = "9429037784669";

        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            LambdaLogger.Log($"SkillRequest input: {JsonConvert.SerializeObject(input)}");

            var response = new Response();

            IOutputSpeech innerResponse = null;

            if (input.GetRequestType() == typeof(Slight.Alexa.Framework.Models.Requests.RequestTypes.ILaunchRequest))
            {
                LambdaLogger.Log($"Default LaunchRequest made");

                innerResponse = new PlainTextOutputSpeech();

                ((PlainTextOutputSpeech) innerResponse).Text = "Red Tape gives you the company details for a supplied New Zealand Business Number. What New Zealand Business Number are you looking for?";
                
                response.ShouldEndSession = false;
            }
            else if (input.GetRequestType() == typeof(Slight.Alexa.Framework.Models.Requests.RequestTypes.IIntentRequest))
            {
                var intent = input.Request.Intent.Name;

                LambdaLogger.Log($"Intent Requested {intent}");

                var responseText = "";
                
                if (intent == "BusinessNumberIntent")
                {
                    var nzbn = DefaultNzbn;

                    if (input.Request.Intent.Slots.ContainsKey("nzbn") && !string.IsNullOrWhiteSpace(input.Request.Intent.Slots["nzbn"].Value))
                    {
                        nzbn = input.Request.Intent.Slots["nzbn"].Value;

                        LambdaLogger.Log($"NZBN requested: {nzbn}");
                    }

                    if (nzbn.ToLower()  == "version")
                    {
                        responseText = "This is Red Tape version 1.0";
                    }
                    else
                    {
                        Task.Run(async () => responseText = await EntityGetter.Get(nzbn)).Wait();
                    }
                
                    response.ShouldEndSession = true;
                }
                else if (intent == "AMAZON.HelpIntent")
                {
                    responseText = "You can ask me for the company details for a supplied New Zealand Business Number. What New Zealand Business Number are you looking for?";

                    response.ShouldEndSession = false;
                }
                else if (intent == "AMAZON.StopIntent")
                {
                    response.ShouldEndSession = true;
                }
                else if (intent == "AMAZON.CancelIntent")
                {
                    response.ShouldEndSession = true;
                }

                LambdaLogger.Log($"Response: {responseText} - Session should end: {response.ShouldEndSession}");

                innerResponse = new PlainTextOutputSpeech();

                ((PlainTextOutputSpeech) innerResponse).Text = responseText;
            }

            response.OutputSpeech = innerResponse;

            var skillResponse = new SkillResponse
            {
                Response = response,
                Version = "1.0"
            };


            return skillResponse;
        }
    }
}
