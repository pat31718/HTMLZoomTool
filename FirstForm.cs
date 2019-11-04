using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLZoomTool
{
    public partial class FirstForm : Form
    {
        public static Preview sourcePreview;
        public static Preview resultPreview;

        //固定的字串
        public static string sourcePreviewString = "sourcePreview";
        public static string resultPreviewString = "resultPreview";
        
        public FirstForm()
        {
            InitializeComponent();
        }

        private void FirstForm_Load(object sender, EventArgs e)
        {
            try
            {
                SettingByConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        //依照使用者設定初始化整個版面
        private void SettingByConfig()
        {

            urlCheckBox.Checked = (bool)UserConfigManager.GetConfigValueByKey(ConfigType.UseUrl);
            //根據有沒有check來變換其他控制項之Enable
            UrlCheckBox_CheckedChanged(new Object(), new EventArgs());

            youtubeRadioButton.Checked = (bool)UserConfigManager.GetConfigValueByKey(ConfigType.IsYouTubeChecked);
            imgRadioButton.Checked = !(bool)UserConfigManager.GetConfigValueByKey(ConfigType.IsYouTubeChecked);

            rightSideRadioButton.Checked = (bool)UserConfigManager.GetConfigValueByKey(ConfigType.IsPreViewAtRight);
            downRadioButton.Checked = !(bool)UserConfigManager.GetConfigValueByKey(ConfigType.IsPreViewAtRight);

            //Proview向上偏移
            UpDownOffsetUp.Value = (int)UserConfigManager.GetConfigValueByKey(ConfigType.UpOffet);

            zoomComboBox.Text = UserConfigManager.GetConfigValueByKey(ConfigType.ZoomPercentage).ToString() + "%";

            sourcePreviewCheckBox.Checked = (bool)UserConfigManager.GetConfigValueByKey(ConfigType.IsBeforePreviewChecked);
            resultPreviewCheckBox.Checked = (bool)UserConfigManager.GetConfigValueByKey(ConfigType.IsAfterPreviewChecked);
            centerCheckBox.Checked = (bool)UserConfigManager.GetConfigValueByKey(ConfigType.IsCenterChecked);

        }

        //主要的轉換Method
        private void ConvertHTMLAndShow()
        {
            //取得要縮放的百分比
            int zoom = Convert.ToInt32(zoomComboBox.Text.Split('%')[0]);

            string tempSourceHTML = string.Empty;

            //如果有勾選網址轉換
            if (urlCheckBox.Checked)
            {
                if (youtubeRadioButton.Checked)
                {
                    tempSourceHTML = YoutubeURL_ToHTML(urlRichTextBox.Text);
                }
                else
                {//image
                    tempSourceHTML = ImageURL_ToHTML(urlRichTextBox.Text);
                }
            }
            else
            {//一般HTML to HTML
                tempSourceHTML = SourceHTML.Text;
            }

            //先置換所有 " 為 '
            tempSourceHTML = tempSourceHTML.Replace('\"', '\'');

            //將ResultHTML變成SourceHTML縮放後的值
            if (!string.IsNullOrEmpty(tempSourceHTML))
            {
                SourceHTML.Text = tempSourceHTML;
                ResultHTML.Text = ZoomHTML(tempSourceHTML, zoom);
            }
            else
            {
                SourceHTML.Text = string.Empty;
                ResultHTML.Text = string.Empty;
            }

            //置中語法
            if (centerCheckBox.Checked)
            {
                ResultHTML.Text = "<p align = 'center'>" + ResultHTML.Text + "</p>";
            }

            //預覽畫面必須有結果才會更新
            if (ResultHTML.Text != string.Empty)
            {

                if (sourcePreviewCheckBox.Checked)
                {
                    ShowPreview(ref sourcePreview, sourcePreviewString, SourceHTML.Text);
                }
                if (resultPreviewCheckBox.Checked)
                {
                    ShowPreview(ref resultPreview, resultPreviewString, ResultHTML.Text);
                }
            }
        }

        private string YoutubeURL_ToHTML(string url)
        {
            //確定有youtube後開始置換
            if (url.IndexOf("youtube") != -1)
            {
                string youtubeCode = url.Substring(url.IndexOf("=") + 1).Split('&')[0];

                url =
                    "<iframe width = '560' height = '315' src = 'https://www.youtube.com/embed/" +
                    youtubeCode +
                    "' frameborder = '0' allow = 'accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen ></iframe> ";

            }
            else
            {
                MessageBox.Show("請再次確認為是否為合法的YouTube網址");
                url = string.Empty;
            }
            return url;
        }

        private string ImageURL_ToHTML(string url)
        {

            //確定有http後開始置換
            if (url.IndexOf("http") != -1)
            {
                url =
                    "<img src = '" +
                    url +
                    "' width = '640' height = '480' /> ";

            }
            else
            {
                MessageBox.Show("請再次確認為是否為合法的網址");
                url = string.Empty;
            }
            return url;
        }

        //使用zoom的百分比來縮放HTML
        private string ZoomHTML(string originHTML, int zoom)
        {

            //確定有width及height後開始置換
            if (originHTML.IndexOf("width") != -1 && originHTML.IndexOf("height") != -1)
            {

                try {

                    #region width
                    int startIndex = originHTML.IndexOf("width");
                    //尋找左邊的'
                    int leftIndex = originHTML.IndexOf("'", startIndex);
                    int rightIndex = originHTML.IndexOf("'", leftIndex + 1);

                    string originWidthString = originHTML.Substring(leftIndex + 1, rightIndex - (leftIndex + 1));
                    float originFloat = Convert.ToSingle(originWidthString);

                    float zoomfloat = originFloat * ((float)zoom / 100);
                    int zoomInt = Convert.ToInt32(zoomfloat);

                    //更改為縮放後的width
                    originHTML =
                        originHTML.Substring(0, leftIndex) +
                        "'" + zoomInt.ToString() + "'" +
                        originHTML.Substring(rightIndex + 1);
                    #endregion

                    #region height
                    startIndex = originHTML.IndexOf("height");
                    //尋找左邊的'
                    leftIndex = originHTML.IndexOf("'", startIndex);
                    rightIndex = originHTML.IndexOf("'", leftIndex + 1);

                    string originHeightString = originHTML.Substring(leftIndex + 1, rightIndex - (leftIndex + 1));
                    originFloat = Convert.ToSingle(originHeightString);

                    zoomfloat = originFloat * ((float)zoom / 100);
                    zoomInt = Convert.ToInt32(zoomfloat);

                    //更改為縮放後的height
                    originHTML =
                        originHTML.Substring(0, leftIndex) +
                        "'" + zoomInt.ToString() + "'" +
                        originHTML.Substring(rightIndex + 1);
                    #endregion
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }

            }
            else
            {
                MessageBox.Show("請再次確認\"width\"及\"height\"是否在語法中:\n" + originHTML);
                originHTML = string.Empty;
            }
            return originHTML;
        }

        public void ShowPreview(ref Preview preview, string formName, string htmlText)
        {

            //加上網頁tag，須注意meta http-equiv必須有值，才能夠顯示影片及圖片
            htmlText = "<html><meta http-equiv = 'X-UA-Compatible' content='IE = edge'/><body>" + htmlText + "</body></html>";

            //如果當前不存在，就new出來
            if (preview == null || preview.IsDisposed)
            {
                preview = new Preview(formName, this);
            }

            //依據不同的preview重設顯示位置            
            ResetFormPosition(ref preview);

            //寫入Document並更新網頁
            preview.WriteWebBrowserDocumentAndRefresh(htmlText);

            //將視窗置頂
            preview.Focus();
        }

        public void ResetFormPosition(ref Preview preview)
        {

            //設定位移單位
            int previewUpOffset = (int)UpDownOffsetUp.Value;

            //在右側顯示
            if (rightSideRadioButton.Checked)
            {
                //sourcePreview
                if (preview.formName == sourcePreviewString)
                {
                    preview.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y - previewUpOffset);
                }
                //resultPreview
                else
                {
                    if (sourcePreviewCheckBox.Checked)
                    {
                        preview.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y - previewUpOffset + sourcePreview.Size.Height);
                    }
                    else
                    {//取代source原本的位置
                        preview.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y - previewUpOffset);
                    }
                }
            }
            //在下方顯示
            else
            {
                //sourcePreview
                if (preview.formName == sourcePreviewString)
                {
                    preview.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height);
                }
                //resultPreview
                else
                {
                    if (sourcePreviewCheckBox.Checked)
                    {
                        preview.Location = new Point(this.Location.X + sourcePreview.Size.Width, this.Location.Y + this.Size.Height);
                    }
                    else
                    {//取代source原本的位置
                        preview.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height);
                    }


                }
            }

        }

        //關閉預覽畫面，如果存在的話
        private void ClosePreviewFormIfExist()
        {
            if (sourcePreview != null && !sourcePreview.IsDisposed)
                sourcePreview.Close();
            if (resultPreview != null && !resultPreview.IsDisposed)
            {
                resultPreview.Close();
            }
        }

        #region ClickEvent ----------------------------------------------------------

        //開始轉換按鈕
        private void StartButton_Click(object sender, EventArgs e)
        {
            ClosePreviewFormIfExist();
            ConvertHTMLAndShow();
        }


        private void CleanButton_Click(object sender, EventArgs e)
        {

            SourceHTML.Text = string.Empty;
            ClosePreviewFormIfExist();
        }

        private void UpDownOffsetUp_ValueChanged(object sender, EventArgs e)
        {
            UserConfigManager.SetAndWriteConfig(ConfigType.UpOffet, (int)UpDownOffsetUp.Value);
        }

        //滑鼠點擊則全選
        private void ResultHTML_MouseClick(object sender, MouseEventArgs e)
        {
            ResultHTML.SelectAll();
        }

        //全選URL
        private void UrlRichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            urlRichTextBox.SelectAll();
        }

        #endregion ----------------------------------------------------------


        #region ChangeEvent ----------------------------------------------------------

        //如果主要視窗移動，子視窗移動
        private void FirstForm_LocationChange(object sender, EventArgs e)
        {
            if (sourcePreview != null && !sourcePreview.IsDisposed)
            {
                ResetFormPosition(ref sourcePreview);
            }

            if (resultPreview != null && !resultPreview.IsDisposed)
            {
                ResetFormPosition(ref resultPreview);
            }

        }

        private void ZoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tempString = zoomComboBox.Text;
            int zoomPercentageInt = Convert.ToInt32(tempString.Split('%')[0]);

            UserConfigManager.SetAndWriteConfig(ConfigType.ZoomPercentage, zoomPercentageInt);
        }

        private void sourcePreviewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserConfigManager.SetAndWriteConfig(ConfigType.IsBeforePreviewChecked, sourcePreviewCheckBox.Checked);
        }

        private void resultPreviewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserConfigManager.SetAndWriteConfig(ConfigType.IsAfterPreviewChecked, resultPreviewCheckBox.Checked);
        }

        private void CenterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserConfigManager.SetAndWriteConfig(ConfigType.IsCenterChecked, centerCheckBox.Checked);
        }

        private void RightSideRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UserConfigManager.SetAndWriteConfig(ConfigType.IsPreViewAtRight, rightSideRadioButton.Checked);
        }

        //預覽視窗在下方時，停用位移
        private void downRadioButton_CheckedChange(object sender, EventArgs e)
        {
            UpDownOffsetUp.Enabled = !downRadioButton.Checked;//不選時才會打開
        }

        private void UrlRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void UrlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = urlCheckBox.Checked;
            urlRichTextBox.Enabled = isChecked;
            SourceHTML.Enabled = !isChecked;
            youtubeRadioButton.Enabled = isChecked;
            imgRadioButton.Enabled = isChecked;

            UserConfigManager.SetAndWriteConfig(ConfigType.UseUrl, isChecked);

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ImgRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            if (imgRadioButton.Checked && imgRadioButton.Enabled)
            {
                if (!(bool)UserConfigManager.GetConfigValueByKey(ConfigType.DontRemindImgInfo))
                {
                    FirstForm_ImgCheckInfo firstForm_ImgCheckInfo = new FirstForm_ImgCheckInfo();

                    firstForm_ImgCheckInfo.StartPosition = FormStartPosition.Manual;//手動設定跳窗初始位置
                    firstForm_ImgCheckInfo.Location = new Point(this.Location.X + this.Size.Width / 4, this.Location.Y + this.Size.Height / 4);//跳窗位置
                    DialogResult dontRemindImgInto = firstForm_ImgCheckInfo.ShowDialog();

                    bool result;
                    if (dontRemindImgInto == DialogResult.Yes)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                    UserConfigManager.SetAndWriteConfig(ConfigType.DontRemindImgInfo, result);
                }
            }
        }

        private void YoutubeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UserConfigManager.SetAndWriteConfig(ConfigType.IsYouTubeChecked, youtubeRadioButton.Checked);
        }

        #endregion ----------------------------------------------------------

    }
}
