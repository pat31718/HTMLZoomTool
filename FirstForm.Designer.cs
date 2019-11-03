namespace HTMLZoomTool {
    partial class FirstForm {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstForm));
            this.SourceHTML = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ResultHTML = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.zoomComboBox = new System.Windows.Forms.ComboBox();
            this.resultPreviewCheckBox = new System.Windows.Forms.CheckBox();
            this.startButton = new System.Windows.Forms.Button();
            this.centerCheckBox = new System.Windows.Forms.CheckBox();
            this.sourcePreviewCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UpDownOffsetUp = new System.Windows.Forms.NumericUpDown();
            this.rightSideRadioButton = new System.Windows.Forms.RadioButton();
            this.downRadioButton = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cleanButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.urlRichTextBox = new System.Windows.Forms.RichTextBox();
            this.urlCheckBox = new System.Windows.Forms.CheckBox();
            this.youtubeRadioButton = new System.Windows.Forms.RadioButton();
            this.imgRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownOffsetUp)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourceHTML
            // 
            this.SourceHTML.Location = new System.Drawing.Point(16, 145);
            this.SourceHTML.Name = "SourceHTML";
            this.SourceHTML.Size = new System.Drawing.Size(423, 128);
            this.SourceHTML.TabIndex = 0;
            this.SourceHTML.Text = resources.GetString("SourceHTML.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "欲轉換的HTML";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(12, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "轉換後的HTML";
            // 
            // ResultHTML
            // 
            this.ResultHTML.Location = new System.Drawing.Point(16, 308);
            this.ResultHTML.Name = "ResultHTML";
            this.ResultHTML.Size = new System.Drawing.Size(423, 141);
            this.ResultHTML.TabIndex = 2;
            this.ResultHTML.Text = "";
            this.ResultHTML.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ResultHTML_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "長寬縮放百分比";
            // 
            // zoomComboBox
            // 
            this.zoomComboBox.FormattingEnabled = true;
            this.zoomComboBox.Items.AddRange(new object[] {
            "10%",
            "20%",
            "30%",
            "40%",
            "50%",
            "60%",
            "70%",
            "80%",
            "90%",
            "100%",
            "110%",
            "120%",
            "130%",
            "140%",
            "150%",
            "160%",
            "170%",
            "180%",
            "190%",
            "200%"});
            this.zoomComboBox.Location = new System.Drawing.Point(3, 15);
            this.zoomComboBox.Name = "zoomComboBox";
            this.zoomComboBox.Size = new System.Drawing.Size(121, 20);
            this.zoomComboBox.TabIndex = 11;
            this.zoomComboBox.Text = "100%";
            this.zoomComboBox.SelectedIndexChanged += new System.EventHandler(this.ZoomComboBox_SelectedIndexChanged);
            // 
            // resultPreviewCheckBox
            // 
            this.resultPreviewCheckBox.AutoSize = true;
            this.resultPreviewCheckBox.Checked = true;
            this.resultPreviewCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.resultPreviewCheckBox.Location = new System.Drawing.Point(3, 63);
            this.resultPreviewCheckBox.Name = "resultPreviewCheckBox";
            this.resultPreviewCheckBox.Size = new System.Drawing.Size(108, 16);
            this.resultPreviewCheckBox.TabIndex = 12;
            this.resultPreviewCheckBox.Text = "轉換後預覽視窗";
            this.resultPreviewCheckBox.UseVisualStyleBackColor = true;
            this.resultPreviewCheckBox.CheckedChanged += new System.EventHandler(this.resultPreviewCheckBox_CheckedChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(467, 411);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(82, 38);
            this.startButton.TabIndex = 13;
            this.startButton.Text = "轉換";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // centerCheckBox
            // 
            this.centerCheckBox.AutoSize = true;
            this.centerCheckBox.Location = new System.Drawing.Point(3, 85);
            this.centerCheckBox.Name = "centerCheckBox";
            this.centerCheckBox.Size = new System.Drawing.Size(124, 16);
            this.centerCheckBox.TabIndex = 14;
            this.centerCheckBox.Text = "是否置中(YouTube)";
            this.centerCheckBox.UseVisualStyleBackColor = true;
            this.centerCheckBox.CheckedChanged += new System.EventHandler(this.CenterCheckBox_CheckedChanged);
            // 
            // sourcePreviewCheckBox
            // 
            this.sourcePreviewCheckBox.AutoSize = true;
            this.sourcePreviewCheckBox.Checked = true;
            this.sourcePreviewCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sourcePreviewCheckBox.Location = new System.Drawing.Point(3, 41);
            this.sourcePreviewCheckBox.Name = "sourcePreviewCheckBox";
            this.sourcePreviewCheckBox.Size = new System.Drawing.Size(108, 16);
            this.sourcePreviewCheckBox.TabIndex = 15;
            this.sourcePreviewCheckBox.Text = "預覽轉換前畫面";
            this.sourcePreviewCheckBox.UseVisualStyleBackColor = true;
            this.sourcePreviewCheckBox.CheckedChanged += new System.EventHandler(this.sourcePreviewCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "預覽視窗向上偏移";
            // 
            // UpDownOffsetUp
            // 
            this.UpDownOffsetUp.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.UpDownOffsetUp.Location = new System.Drawing.Point(3, 3);
            this.UpDownOffsetUp.Name = "UpDownOffsetUp";
            this.UpDownOffsetUp.Size = new System.Drawing.Size(57, 22);
            this.UpDownOffsetUp.TabIndex = 18;
            this.UpDownOffsetUp.ValueChanged += new System.EventHandler(this.UpDownOffsetUp_ValueChanged);
            // 
            // rightSideRadioButton
            // 
            this.rightSideRadioButton.AutoSize = true;
            this.rightSideRadioButton.Checked = true;
            this.rightSideRadioButton.Location = new System.Drawing.Point(3, 18);
            this.rightSideRadioButton.Name = "rightSideRadioButton";
            this.rightSideRadioButton.Size = new System.Drawing.Size(83, 16);
            this.rightSideRadioButton.TabIndex = 20;
            this.rightSideRadioButton.TabStop = true;
            this.rightSideRadioButton.Text = "主視窗右側";
            this.rightSideRadioButton.UseVisualStyleBackColor = true;
            this.rightSideRadioButton.CheckedChanged += new System.EventHandler(this.RightSideRadioButton_CheckedChanged);
            // 
            // downRadioButton
            // 
            this.downRadioButton.AutoSize = true;
            this.downRadioButton.Location = new System.Drawing.Point(3, 40);
            this.downRadioButton.Name = "downRadioButton";
            this.downRadioButton.Size = new System.Drawing.Size(83, 16);
            this.downRadioButton.TabIndex = 21;
            this.downRadioButton.Text = "主視窗下方";
            this.downRadioButton.UseVisualStyleBackColor = true;
            this.downRadioButton.CheckedChanged += new System.EventHandler(this.downRadioButton_CheckedChange);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.zoomComboBox);
            this.flowLayoutPanel1.Controls.Add(this.sourcePreviewCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.resultPreviewCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.centerCheckBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(445, 285);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(138, 108);
            this.flowLayoutPanel1.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.UpDownOffsetUp, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 84);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(127, 31);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "單位";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "預覽視窗顯示位置";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.rightSideRadioButton);
            this.flowLayoutPanel2.Controls.Add(this.downRadioButton);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(450, 32);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(127, 126);
            this.flowLayoutPanel2.TabIndex = 24;
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(467, 211);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(82, 38);
            this.cleanButton.TabIndex = 25;
            this.cleanButton.Text = "清除";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(457, 193);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "清除欲轉換的HTML";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(483, 396);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "開始轉換";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(12, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "YouTube /圖片網址";
            // 
            // urlRichTextBox
            // 
            this.urlRichTextBox.Enabled = false;
            this.urlRichTextBox.Location = new System.Drawing.Point(16, 54);
            this.urlRichTextBox.Name = "urlRichTextBox";
            this.urlRichTextBox.Size = new System.Drawing.Size(423, 42);
            this.urlRichTextBox.TabIndex = 28;
            this.urlRichTextBox.Text = "";
            this.urlRichTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UrlRichTextBox_MouseClick);
            this.urlRichTextBox.TextChanged += new System.EventHandler(this.UrlRichTextBox_TextChanged);
            // 
            // urlCheckBox
            // 
            this.urlCheckBox.AutoSize = true;
            this.urlCheckBox.Location = new System.Drawing.Point(241, 32);
            this.urlCheckBox.Name = "urlCheckBox";
            this.urlCheckBox.Size = new System.Drawing.Size(72, 16);
            this.urlCheckBox.TabIndex = 29;
            this.urlCheckBox.Text = "網址轉換";
            this.urlCheckBox.UseVisualStyleBackColor = true;
            this.urlCheckBox.CheckedChanged += new System.EventHandler(this.UrlCheckBox_CheckedChanged);
            // 
            // youtubeRadioButton
            // 
            this.youtubeRadioButton.AutoSize = true;
            this.youtubeRadioButton.Checked = true;
            this.youtubeRadioButton.Location = new System.Drawing.Point(319, 32);
            this.youtubeRadioButton.Name = "youtubeRadioButton";
            this.youtubeRadioButton.Size = new System.Drawing.Size(67, 16);
            this.youtubeRadioButton.TabIndex = 30;
            this.youtubeRadioButton.TabStop = true;
            this.youtubeRadioButton.Text = "YouTube";
            this.youtubeRadioButton.UseVisualStyleBackColor = true;
            this.youtubeRadioButton.CheckedChanged += new System.EventHandler(this.YoutubeRadioButton_CheckedChanged);
            // 
            // imgRadioButton
            // 
            this.imgRadioButton.AutoSize = true;
            this.imgRadioButton.Location = new System.Drawing.Point(392, 32);
            this.imgRadioButton.Name = "imgRadioButton";
            this.imgRadioButton.Size = new System.Drawing.Size(47, 16);
            this.imgRadioButton.TabIndex = 31;
            this.imgRadioButton.Text = "圖片";
            this.imgRadioButton.UseVisualStyleBackColor = true;
            this.imgRadioButton.CheckedChanged += new System.EventHandler(this.ImgRadioButton_CheckedChanged);
            // 
            // FirstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 476);
            this.Controls.Add(this.imgRadioButton);
            this.Controls.Add(this.youtubeRadioButton);
            this.Controls.Add(this.urlCheckBox);
            this.Controls.Add(this.urlRichTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cleanButton);
            this.Controls.Add(this.ResultHTML);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SourceHTML);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FirstForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTMLZoomTool";
            this.Load += new System.EventHandler(this.FirstForm_Load);
            this.LocationChanged += new System.EventHandler(this.FirstForm_LocationChange);
            ((System.ComponentModel.ISupportInitialize)(this.UpDownOffsetUp)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox SourceHTML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox ResultHTML;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox zoomComboBox;
        private System.Windows.Forms.CheckBox resultPreviewCheckBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox centerCheckBox;
        private System.Windows.Forms.CheckBox sourcePreviewCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown UpDownOffsetUp;
        private System.Windows.Forms.RadioButton rightSideRadioButton;
        private System.Windows.Forms.RadioButton downRadioButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox urlRichTextBox;
        private System.Windows.Forms.CheckBox urlCheckBox;
        private System.Windows.Forms.RadioButton youtubeRadioButton;
        private System.Windows.Forms.RadioButton imgRadioButton;
    }
}

