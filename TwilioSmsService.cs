using System;
using System.IO;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;

public class TwilioSmsService {

  public TwilioSmsService() {
    incr = 0;
  }

  private int incr;
  private readonly string[] _messages = {"0", "1", "2", "3", "4", "5", "6"};

  public async Task SendSmsAsync() {
    // Find your Account SID and Auth Token at twilio.com/console
    // and set the environment variables. See http://twil.io/secure
    string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID") ?? "";
    string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN") ?? "";

    TwilioClient.Init(accountSid, authToken);

    var message = await MessageResource.CreateAsync(
        body: _messages[incr % _messages.Length],
        from: new Twilio.Types.PhoneNumber("+3197010259485"),
        to: new Twilio.Types.PhoneNumber("+31610072654"));

    Console.WriteLine(message.Body);
    incr++;

  }
}
