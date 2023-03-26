using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using google_calendar1.Models;

namespace google_calendar1.Helper
{
    public class GoogleCalendarHelper
    {
        public static async Task<Event> CreateGoogleCalendar(GoogleCalendar request)
        {
            string[] Scopes = { "https://www.googleapis.com/auth/calender" };
            string ApplicatiobName = "google Calender Api";
            UserCredential credential;
            using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "Cre", "cre.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            // define services
            var services = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicatiobName,
            });
            Event eventCalendar = new Event()
            {
                Summary = request.Summary,
                Location = request.Location,
                Start = new EventDateTime
                {
                    DateTime = request.Start,
                    TimeZone = "Africa/Egypt"
                },
                End = new EventDateTime
                {
                    DateTime = request.End,
                    TimeZone = "Africa/Egypt"
                },
                Description = request.Description
            };
            var eventRequest = services.Events.Insert(eventCalendar, "primary");
            var requestCreate = await eventRequest.ExecuteAsync();
            return requestCreate;
        }

    }
}
