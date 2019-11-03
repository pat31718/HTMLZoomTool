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

    //讓JavaScript支援
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class Preview : Form {

        private WebBrowser webBrowser;
        public FirstForm firstForm;
        public string formName;

        //用來讓網頁顯示起來更寬一點，不然會有卷軸
        private int widthOffset = 30;
        private int heightOffset = 56;

        //預設的視窗長寬
        private static int defaultWidth = 199;
        private static int defaultHeight = 141;
        private static Size defaultSize = new Size(defaultWidth, defaultHeight);

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
        
        //使用 method 寫入 Document 並更新
        public void WriteWebBrowserDocumentAndRefresh(string documentText) {
            //初始化為空白頁
            webBrowser.Navigate("about:blank");
            //寫檔
            webBrowser.Document.Write(documentText);
            //更新
            webBrowser.Refresh();
        }
        
        //Document準備完成後 (這樣寫或許不是很好，因為影片會跳轉兩次)
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {

            //Loading 完成才Show
            this.Show();
            
            WebBrowser webBrowserObject = (WebBrowser)sender;
            //如果此WebBrowser尚未Ready，則DocumentCompleted不生效，直接return
            if (webBrowserObject.ReadyState != WebBrowserReadyState.Complete)
                return;
                        
            //重設比例
            ResizeWebBrowser();
            Console.WriteLine("completed:" + webBrowserObject.DocumentText);
        }

        //重新設定長寬比例
        public void ResizeWebBrowser() {
            webBrowser.Size = defaultSize;//重設長寬
            webBrowser.Size = new Size(webBrowser.Document.Body.ScrollRectangle.Width, webBrowser.Document.Body.ScrollRectangle.Height);

            this.Size = defaultSize;//重設長寬
            this.Size = new Size(webBrowser.Document.Body.ScrollRectangle.Width + widthOffset, webBrowser.Document.Body.ScrollRectangle.Height + heightOffset);

            //如果sourecePreview長寬設置完了，且resultPreview存在，重設resultPreviw的位置
            if (this.formName == "sourcePreview" && FirstForm.resultPreview != null && !FirstForm.resultPreview.IsDisposed) {
                firstForm.ResetFormPosition(ref FirstForm.resultPreview);
            }

        }
    }
}
