using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using System.Text;

namespace CurrencyConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnableDisableButton(button1, "Working....", false);

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://cdn.jsdelivr.net/")
            };

            client.Timeout = TimeSpan.FromSeconds(10);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Get Response from the api
            HttpResponseMessage response = client.GetAsync("gh/fawazahmed0/currency-api@1/latest/currencies.json").Result;

            if (response != null && response.IsSuccessStatusCode)
            {
                JsonNode? node = JsonNode.Parse(response.Content.ReadAsStringAsync().Result);

                Dictionary<string, string>? currencyDictionary = node.Deserialize<Dictionary<string, string>>();

                DialogResult dialogResult = DialogResult.None;

                if (node == null)
                {
                    dialogResult = MessageBox.Show("Got Error while processing api data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (currencyDictionary == null)
                {
                    dialogResult = MessageBox.Show("API returned invalid data, please check", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (dialogResult == DialogResult.OK)
                {
                    EnableDisableButton(button1, "Click Me", true);
                    return;
                }

                string allKeys = string.Empty;
                string tempValue = string.Empty;
                foreach (string key in currencyDictionary.Keys)
                {
                    tempValue = key.ToUpperInvariant() + "- " + currencyDictionary[key] + "\n";
                    allKeys += tempValue;
                    comboBox1.Items.Add(tempValue);
                    comboBox2.Items.Add(tempValue);
                }

                comboBox1.SelectedIndex = 50;
                comboBox2.SelectedIndex = 4;

                dialogResult = MessageBox.Show(allKeys, "Currency List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                    EnableDisableButton(button1, "Click Me", true);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show($"Got Error: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.OK)
                    EnableDisableButton(button1, "Click Me", true);
            }

        }

        private static void EnableDisableButton(Button button, string btnText, bool shouldInteract)
        {
            button.Enabled = shouldInteract;
            button.Text = btnText;
        }
    }
}