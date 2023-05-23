using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using System.Text.Json;


namespace CurrencyConverter
{
    public partial class Form1 : Form
    {
        private string baseUri = "https://cdn.jsdelivr.net/";
        private string currencyListUri = "gh/fawazahmed0/currency-api@1/latest/currencies.json";

        private string usdBasedCurrencyValueUri = "gh/fawazahmed0/currency-api@1/latest/currencies/usd.json";

        private List<string>? currencyNames = new List<string>();
        private List<double>? currencyValues = new List<double>();

        public Form1()
        {
            InitializeComponent();
        }

        #region Button Click Method
        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(amountTextBox.Text))
            {
                ShowDataParseError("You have not entered any number. Please input a valid number.");
                return;
            }

            if (currencyNames == null || currencyValues == null)
            {
                MessageBox.Show("List is null!");
                return;
            }

            bool parseSuccess = float.TryParse(amountTextBox.Text.ToString(), out float exchangeAmount);

            if (parseSuccess)
            {
                ConvertCurrency();
                return;
            }

            ShowDataParseError("You have entered an invalid number. Please input a valid number.");
        }

        private async void StartBtn_ClickAsync(object sender, EventArgs e)
        {
            EnableDisableButton(startBtn, "Please wait....", false);

            string currencyNameList = await SendHTTPRequest(currencyListUri, ResetStartPageToNormal);
            string currencyValue = await SendHTTPRequest(usdBasedCurrencyValueUri, ResetStartPageToNormal);

            ParseCurrencyList(currencyNameList);
            ParseCurrencyValues(currencyValue);
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            EnableDisableStartPanel(true);
            StartBtn_ClickAsync(sender, e);
        }
        #endregion Button Click Methods

        #region Currency Conversion Logic
        private void ConvertCurrency()
        {
            try
            {
                double amount = double.Parse(amountTextBox.Text);
                double fromCurrencyInUSD = (1.0f / currencyValues[fromCurrencyCombo.SelectedIndex]) * amount;
                double result = fromCurrencyInUSD * currencyValues[toCurrencyCombo.SelectedIndex];
                exchangeTxt.Text = result.ToString("0.00");
            }
            catch (Exception ex)
            {
                ShowDataParseError("ConvertCurrency: " + ex.Message);
            }
        }
        #endregion Currency Conversion Logic

        #region UI Control Section
        private void EnableDisableStartPanel(bool value)
        {
            panel1.Visible = value;
            startBtn.Visible = value;
            startBtn.Enabled = value;

            if (value)
                startBtn.Text = "Start";
        }

        private void EnableDisableInputAndButtons(bool enable)
        {
            fromCurrencyCombo.Enabled = enable;
            toCurrencyCombo.Enabled = enable;

            convertBtn.Enabled = enable;
            refreshBtn.Enabled = enable;

            exchangeTxt.Enabled = enable;
        }

        private static void EnableDisableButton(Button button, string btnText, bool shouldInteract)
        {
            button.Enabled = shouldInteract;
            button.Text = btnText;
        }
        #endregion UI Control Section

        #region Error Handling
        private void ResetStartPageToNormal(string errorMessage)
        {
            DialogResult dialogResult = MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (dialogResult == DialogResult.OK)
                EnableDisableStartPanel(true);
        }

        private void ShowDataParseError(string errorMessage)
        {
            DialogResult dialogResult = MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (dialogResult == DialogResult.OK)
            {
                EnableDisableInputAndButtons(true);
            }
        }
        #endregion Error Handling

        #region Data Parsing
        private void ParseCurrencyList(string result)
        {
            if (string.IsNullOrEmpty(result))
                return;

            try
            {
                JsonNode? node = JsonNode.Parse(result);

                Dictionary<string, string> currencyNameDic = node.Deserialize<Dictionary<string, string>>();

                int usdIndex = 0;
                int bdtIndex = 0;

                currencyNames.Clear();

                fromCurrencyCombo.Items.Clear();
                toCurrencyCombo.Items.Clear();

                foreach (string key in currencyNameDic.Keys)
                {
                    string tempValue = key.ToUpperInvariant() + " - " + currencyNameDic[key] + "\n";
                    fromCurrencyCombo.Items.Add(tempValue);
                    toCurrencyCombo.Items.Add(tempValue);

                    currencyNames.Add(key);

                    if (key.Equals("bdt"))
                        bdtIndex = fromCurrencyCombo.Items.Count - 1;

                    if (key.Equals("usd"))
                        usdIndex = fromCurrencyCombo.Items.Count - 1;
                }

                fromCurrencyCombo.SelectedIndex = usdIndex;
                toCurrencyCombo.SelectedIndex = bdtIndex;
            }
            catch (Exception ex)
            {
                ResetStartPageToNormal($"Got Error of {ex.Message} while downloading currency list from the api!");
            }
        }

        private void ParseCurrencyValues(string result)
        {
            try
            {
                if (string.IsNullOrEmpty(result))
                    return;

                JsonNode? node = JsonNode.Parse(result);

                var jObject = JsonObject.Parse(result);

                Dictionary<string, double> currencyValueDic = node["usd"].Deserialize<Dictionary<string, double>>();
                amountTextBox.Text = "1";

                currencyValues.Clear();

                currencyValues = currencyValueDic.Values.ToList();
                ConvertCurrency();

                EnableDisableStartPanel(false);
            }
            catch (Exception ex)
            {
                ResetStartPageToNormal($"Got Error of {ex.Message} while downloading currency values from the api!");
            }
        }
        #endregion Data Parsing

        #region HTTP Request
        private async Task<string> SendHTTPRequest(string requestUri, Action<string> errorCallback)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //Setting base uri of httpClient
                    httpClient.BaseAddress = new Uri(baseUri);

                    //Setting timeout time of httpClient to 10 seconds
                    httpClient.Timeout = TimeSpan.FromSeconds(10);

                    //Clearing any previous header adding a header to accept JSON format
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage httpResponse = await httpClient.GetAsync(requestUri);

                    //Confirming that the http request must confirms that the request is successful or not
                    httpResponse.EnsureSuccessStatusCode();

                    //Reading the returned string data and returning
                    return await httpResponse.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException requestEx)
            {
                string errorMessage = "An error occurred during the API request:" + requestEx.Message;
                //show error window
                errorCallback?.Invoke(errorMessage);
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred during the API request:" + ex.Message;
                //show error window
                errorCallback?.Invoke(errorMessage);
            }

            return string.Empty;
        }

        #endregion HTTP Request

    }
}