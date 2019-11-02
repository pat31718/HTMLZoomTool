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

        public void ShowPreview(ref Preview preview, string formName,string htmlText) {

            //用 HTML Body tag 包住
            htmlText = "<html><meta http-equiv = 'X-UA-Compatible' content='IE = edge'/><body>" + htmlText + "</body></html>";

            //加上 Meta
            //htmlText += "<meta http-equiv = 'X-UA-Compatible' content='IE = edge'/>";
            
            if (preview == null || preview.IsDisposed) {
                preview = new Preview(formName, this);

                //一開始DocumentText要指定值,之後必須用Write的
                preview.SetWebBrowserDocumentText(htmlText);
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
                        
            if (preview.formName == "sourcePreview") {
                preview.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y - PreviewUpOffset);
            }
                        
            else {
                preview.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y - PreviewUpOffset + sourcePreview.Size.Height);
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

        private void Label3_Click(object sender, EventArgs e) {

        }

        //轉換
        private void Button1_Click(object sender, EventArgs e) {
            PreviewUpOffset = (int) UpDownOffsetUp.Value;

            //將ResultHTML變成SourceHTML一設定改變的值
            ResultHTML.Text = SourceHTML.Text;

            //預覽使用
            string sourceHTMLString = SourceHTML.Text.Replace('\"', '\'');
            string resultHTMLString = ResultHTML.Text.Replace('\"', '\'');
            
            ShowPreview(ref sourcePreview, "sourcePreview", sourceHTMLString);
            ShowPreview(ref resultPreview, "resultPreview", resultHTMLString);

        }

        private void SourceHTML_TextChanged(object sender, EventArgs e) {

        }
    }
}
