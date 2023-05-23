namespace CurrencyConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            convertBtn = new Button();
            label2 = new Label();
            label1 = new Label();
            fromCurrencyCombo = new ComboBox();
            toCurrencyCombo = new ComboBox();
            panel1 = new Panel();
            startBtn = new Button();
            label3 = new Label();
            exchangeTxt = new Label();
            label4 = new Label();
            amountTextBox = new TextBox();
            refreshBtn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // convertBtn
            // 
            convertBtn.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            convertBtn.ForeColor = SystemColors.ButtonFace;
            convertBtn.Image = Properties.Resources.Rectangle_5;
            convertBtn.Location = new Point(449, 493);
            convertBtn.Margin = new Padding(4, 5, 4, 5);
            convertBtn.Name = "convertBtn";
            convertBtn.Size = new Size(333, 60);
            convertBtn.TabIndex = 0;
            convertBtn.Text = "CONVERT";
            convertBtn.UseVisualStyleBackColor = true;
            convertBtn.Click += ConvertBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(449, 378);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(39, 32);
            label2.TabIndex = 4;
            label2.Text = "To";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(449, 285);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(69, 32);
            label1.TabIndex = 2;
            label1.Text = "From";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fromCurrencyCombo
            // 
            fromCurrencyCombo.FormattingEnabled = true;
            fromCurrencyCombo.Location = new Point(449, 323);
            fromCurrencyCombo.Name = "fromCurrencyCombo";
            fromCurrencyCombo.Size = new Size(331, 33);
            fromCurrencyCombo.TabIndex = 5;
            // 
            // toCurrencyCombo
            // 
            toCurrencyCombo.FormattingEnabled = true;
            toCurrencyCombo.Location = new Point(449, 423);
            toCurrencyCombo.Name = "toCurrencyCombo";
            toCurrencyCombo.Size = new Size(331, 33);
            toCurrencyCombo.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Controls.Add(startBtn);
            panel1.Location = new Point(0, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1141, 702);
            panel1.TabIndex = 7;
            // 
            // startBtn
            // 
            startBtn.Location = new Point(446, 328);
            startBtn.Margin = new Padding(4, 5, 4, 5);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(277, 100);
            startBtn.TabIndex = 0;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += StartBtn_ClickAsync;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(553, 50);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(138, 28);
            label3.TabIndex = 8;
            label3.Text = "Exchange Rate";
            // 
            // exchangeTxt
            // 
            exchangeTxt.AutoSize = true;
            exchangeTxt.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            exchangeTxt.Location = new Point(553, 95);
            exchangeTxt.Margin = new Padding(4, 0, 4, 0);
            exchangeTxt.Name = "exchangeTxt";
            exchangeTxt.Size = new Size(140, 65);
            exchangeTxt.TabIndex = 9;
            exchangeTxt.Text = "$100";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(449, 193);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(218, 32);
            label4.TabIndex = 10;
            label4.Text = "Exchange Amounts";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // amountTextBox
            // 
            amountTextBox.Location = new Point(449, 233);
            amountTextBox.Margin = new Padding(4, 5, 4, 5);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(331, 31);
            amountTextBox.TabIndex = 11;
            // 
            // refreshBtn
            // 
            refreshBtn.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            refreshBtn.ForeColor = SystemColors.ActiveCaptionText;
            refreshBtn.Image = (Image)resources.GetObject("refreshBtn.Image");
            refreshBtn.Location = new Point(449, 578);
            refreshBtn.Margin = new Padding(4, 5, 4, 5);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(333, 60);
            refreshBtn.TabIndex = 12;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 702);
            Controls.Add(panel1);
            Controls.Add(refreshBtn);
            Controls.Add(amountTextBox);
            Controls.Add(label4);
            Controls.Add(exchangeTxt);
            Controls.Add(label3);
            Controls.Add(toCurrencyCombo);
            Controls.Add(fromCurrencyCombo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(convertBtn);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button convertBtn;
        private Label label2;
        private Label label1;
        private ComboBox fromCurrencyCombo;
        private ComboBox toCurrencyCombo;
        private Panel panel1;
        private Button startBtn;
        private Label label3;
        private Label exchangeTxt;
        private Label label4;
        private TextBox amountTextBox;
        private Button refreshBtn;
    }
}