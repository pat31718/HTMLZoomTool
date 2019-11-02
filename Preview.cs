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
    public partial class Preview : Form {

        private WebBrowser webBrowser;
        public FirstForm firstForm;
        public string formName;

        //用來讓網頁顯示起來更寬一點，不然會有卷軸
        private int widthOffset = 30;
        private int heightOffset = 56;


        public Preview(string formName, FirstForm firstForm) {
            InitializeComponent();
            webBrowser = this.webBrowser1;

            //給他firstForm
            this.firstForm = firstForm;

            //設定此視窗名稱
            this.Text = formName;
            this.formName = formName;
            //webBrowser.ScriptErrorsSuppressed = true;
        }

        //設置 DocumentText
        public void SetWebBrowserDocumentText(string documentText) {
            if (webBrowser.Document == null) {
                webBrowser.DocumentText = documentText;
            }
            else {
                webBrowser.Document.Body.InnerText = documentText;
            }            
            //重設比例
            //ResizeWebBrowser();
        }

        //使用 method 寫入 Document 並更新
        public void WriteWebBrowserDocumentAndRefresh(string documentText) {
            //初始化
            webBrowser.Navigate("about:blank");
            //寫檔
            webBrowser.Document.Write(documentText);            

            //更新
            webBrowser.Refresh();
        }
        
        //Document準備完成後
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            //重設比例
            ResizeWebBrowser();
        }

        //重新設定長寬比例
        private void ResizeWebBrowser() {
            webBrowser.Size = new Size(webBrowser.Document.Body.ScrollRectangle.Width, webBrowser.Document.Body.ScrollRectangle.Height);
            this.Size = new Size(webBrowser.Document.Body.ScrollRectangle.Width + widthOffset, webBrowser.Document.Body.ScrollRectangle.Height + heightOffset);

            //如果原始碼視窗的已經跑完了，就重置result視窗的位置
            if (this.formName == "sourcePreview") {
                firstForm.ResetFormPosition(ref FirstForm.resultPreview);
            }

        }
    }
}
