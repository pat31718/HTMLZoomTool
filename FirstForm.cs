using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLZoomTool {
    public partial class FirstForm : Form {

        public static Preview sourcePreview;
        public static Preview resultPreview;

        //顯示位置上移
        private int PreviewUpOffset = 0;
        
        public FirstForm() {
            InitializeComponent();
        }

        private void FirstForm_Load(object sender, EventArgs e) {
            SettingByConfig();
            
        }

        //依照使用者設定初始化整個版面
        private void SettingByConfig() {
            urlCheckBox.Checked = UserConfigManager.GetConfigValueByKey(ConfigType.UseUrl);
            //根據有沒有check來變換其他控制項之Enable
            UrlCheckBox_CheckedChanged(new Object(), new EventArgs());

            youtubeRadioButton.Checked = UserConfigManager.GetConfigValueByKey(ConfigType.IsYouTubeChecked);
            imgRadioButton.Checked = !UserConfigManager.GetConfigValueByKey(ConfigType.IsYouTubeChecked);
        }

        public void ShowPreview(ref Preview preview, string formName,string htmlText) {

            //加上網頁tag，須注意meta http-equiv必須有值，才能夠顯示影片及圖片
            htmlText = "<html><meta http-equiv = 'X-UA-Compatible' content='IE = edge'/><body>" + htmlText + "</body></html>";
            
            if (preview == null || preview.IsDisposed) {
                preview = new Preview(formName, this);
                
                //寫入Document並更新網頁
                preview.WriteWebBrowserDocumentAndRefresh(htmlText);
                preview.Show();                
            }
            else {                
                //寫入並更新html
                preview.WriteWebBrowserDocumentAndRefresh(htmlText);

                preview.Show();
                //將視窗置頂
                preview.Focus();                                
            }

            if (formName == "sourcePreview") {
                //重設顯示位置
                ResetFormPosition(ref preview);
            }
           
        }

        public void ResetFormPosition(ref Preview preview) {

            //在右側顯示
            if (rightSideRadioButton.Checked) {
                if (preview.formName == "sourcePreview") {
                    preview.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y - PreviewUpOffset);
                }

                else {
                    preview.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y - PreviewUpOffset + sourcePreview.Size.Height);
                }
            }

            //在下方顯示
            else {                
                if (preview.formName == "sourcePreview") {
                    preview.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height);
                }

                else {
                    preview.Location = new Point(this.Location.X + sourcePreview.Size.Width, this.Location.Y + this.Size.Height);
                    
                }
            }
                 

        }

        //如果主要視窗移動，子視窗移動
        private void FirstForm_LocationChange(object sender, EventArgs e) {
            if (sourcePreview != null && !sourcePreview.IsDisposed) {
                ResetFormPosition(ref sourcePreview);
            }

            if (resultPreview != null && !resultPreview.IsDisposed) {
                ResetFormPosition(ref resultPreview);
            }         

        }


        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e) {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e) {

        }

        private void TransferHTML() {   
            //將ResultHTML變成SourceHTML一設定改變的值            
            ResultHTML.Text = SourceHTML.Text;

            //置中語法
            if (centerCheckBox.Checked) {
                ResultHTML.Text = "<p align = 'center'>" + ResultHTML.Text + "</p>";
            }

            //預覽使用
            string sourceHTMLString = SourceHTML.Text.Replace('\"', '\'');
            string resultHTMLString = ResultHTML.Text.Replace('\"', '\'');

            //ShowPreview(ref sourcePreview, "sourcePreview", sourceHTMLString);
            //ShowPreview(ref resultPreview, "resultPreview", resultHTMLString);

            ShowPreview(ref sourcePreview, "sourcePreview", SourceHTML.Text);
            ShowPreview(ref resultPreview, "resultPreview", ResultHTML.Text);
        }


        //開始轉換按鈕
        private void StartButton_Click(object sender, EventArgs e) {
            //設定位移單位
            PreviewUpOffset = (int)UpDownOffsetUp.Value;

            TransferHTML();
        }
                

        private void CleanButton_Click(object sender, EventArgs e) {
           
            SourceHTML.Text = string.Empty;
        }

        private void UpDownOffsetUp_ValueChanged(object sender, EventArgs e) {

        }

        //滑鼠點擊則全選
        private void ResultHTML_MouseClick(object sender, MouseEventArgs e) {
            ResultHTML.SelectAll();
        }

        //預覽視窗在下方時，停用位移
        private void downRadioButton_CheckedChange(object sender, EventArgs e) {
            UpDownOffsetUp.Enabled = !downRadioButton.Checked;//不選時才會打開
        }

        private void Label9_Click(object sender, EventArgs e) {

        }

        private void UrlRichTextBox_TextChanged(object sender, EventArgs e) {

        }

        //全選URL
        private void UrlRichTextBox_MouseClick(object sender, MouseEventArgs e) {
            urlRichTextBox.SelectAll();
        }

        private void UrlCheckBox_CheckedChanged(object sender, EventArgs e) {
            bool isChecked = urlCheckBox.Checked;
            urlRichTextBox.Enabled = isChecked;
            SourceHTML.Enabled = !isChecked;
            youtubeRadioButton.Enabled = isChecked;
            imgRadioButton.Enabled = isChecked;

            UserConfigManager.SetAndWriteConfig(ConfigType.UseUrl, isChecked);

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e) {

        }

        private void ImgRadioButton_CheckedChanged(object sender, EventArgs e) {
            
            if (imgRadioButton.Checked) {
                if (!UserConfigManager.GetConfigValueByKey(ConfigType.DontRemindImgInfo)) {
                    FirstForm_ImgCheckInfo firstForm_ImgCheckInfo = new FirstForm_ImgCheckInfo();

                    firstForm_ImgCheckInfo.StartPosition = FormStartPosition.Manual;//手動設定跳窗初始位置
                    firstForm_ImgCheckInfo.Location = new Point(this.Location.X + this.Size.Width/4, this.Location.Y + this.Size.Height/4);//跳窗位置
                    DialogResult dontRemindImgInto = firstForm_ImgCheckInfo.ShowDialog();

                    bool result;
                    if (dontRemindImgInto == DialogResult.Yes) {
                        result = true;
                    }
                    else {
                        result = false;
                    }                     

                    UserConfigManager.SetAndWriteConfig(ConfigType.DontRemindImgInfo, result);
                }
            }
        }

        private void YoutubeRadioButton_CheckedChanged(object sender, EventArgs e) {
            UserConfigManager.SetAndWriteConfig(ConfigType.IsYouTubeChecked, youtubeRadioButton.Checked);
        }
    }
}
