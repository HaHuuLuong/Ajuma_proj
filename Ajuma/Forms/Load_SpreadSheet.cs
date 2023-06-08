using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;

namespace Ajuma.Forms
{
    public partial class Load_SpreadSheet : Form
    {
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Demo Read Google SpeadSheet";
        public Load_SpreadSheet()
        {
            InitializeComponent();
        }

        private void btn_get_Click(object sender, EventArgs e)
        {
            UserCredential credential;

            using (var stream =
                new FileStream(@"D:\Github\Ajuma_proj\Ajuma\client_secret_273516347664-rutpsgbhu4gi4lrh1b9f5bohurhii89p.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.
            String spreadsheetId = "1keSaX_LygjvSGq8YKNC_AUY1-Ur1e50HDLW6tLgU3V0";
            String range = "Sheet1!A2:G";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // https://docs.google.com/spreadsheets/d/1baDMAYztpUTKbnI5j6cEaZ2BysfY6MqJn-1ah4HoI8s/edit#gid=0

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                ListViewItem item = new ListViewItem();
                foreach (var row in values)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", row[0], row[1], row[2], row[3], row[4], row[5], row[6]);

                    item = new ListViewItem(new string[] { row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString() });
                    lst_data.Items.AddRange(new ListViewItem[] { item });
                }

            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (lst_data.Items.Count >= 1)
                lst_data.Items.RemoveAt(0);
        }
    }
}
