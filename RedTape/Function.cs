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
        private const string DefaultStation = "Ava";

        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            LambdaLogger.Log($"SkillRequest input: {JsonConvert.SerializeObject(input)}");

            Response response = new Response();
            IOutputSpeech innerResponse = null;

            if (input.GetRequestType() == typeof(Slight.Alexa.Framework.Models.Requests.RequestTypes.ILaunchRequest))
            {
                LambdaLogger.Log($"Default LaunchRequest made");

                innerResponse = new PlainTextOutputSpeech();
                (innerResponse as PlainTextOutputSpeech).Text = "Wellington Trains gives you real-time public transport information for Wellington, New Zealand. What station are you departing from?";
                
                response.ShouldEndSession = false;
            }
            else if (input.GetRequestType() == typeof(Slight.Alexa.Framework.Models.Requests.RequestTypes.IIntentRequest))
            {
                var intent = input.Request.Intent.Name;

                LambdaLogger.Log($"Intent Requested {intent}");

                var responseText = "";
                
                if (intent == "TrainIntent")
                {
                    var station = DefaultStation;

                    if (input.Request.Intent.Slots.ContainsKey("station") && !string.IsNullOrWhiteSpace(input.Request.Intent.Slots["station"].Value))
                    {
                        station = input.Request.Intent.Slots["station"].Value;
                        LambdaLogger.Log($"Station requested: {station}");
                    }

                    if (station.ToLower()  == "version")
                    {
                        responseText = "This is Wellington Trains version 1.0";
                    }
                    else
                    {
                        Task.Run(async () => responseText = await EntityGetter.Get(station)).Wait();
                    }
                
                    response.ShouldEndSession = true;
                }
                else if (intent == "AMAZON.HelpIntent")
                {
                    responseText = "You can ask me when the next train leaves from your nearest station. What station are you departing from? ";
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
                (innerResponse as PlainTextOutputSpeech).Text = responseText;
            }

            response.OutputSpeech = innerResponse;

            var skillResponse = new SkillResponse();
            skillResponse.Response = response;
            skillResponse.Version = "1.0";

            return skillResponse;
        }
    }
}
