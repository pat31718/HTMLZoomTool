﻿using System;
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
        private static int widthOffset = 41;
        private static int heightOffset = 55;
        
        //預設的視窗長寬
        private static int defaultWidth = 50;
        private static int defaultHeight = 50;
        private static Size defaultSize = new Size(defaultWidth, defaultHeight);

        //是否是圖片網址用來先載入一次的Result Preview
        public bool isImageLoading = false;

        public Preview(string formName, FirstForm firstForm) {
            InitializeComponent();
            webBrowser = this.webBrowser1;

            //給他firstForm
            this.firstForm = firstForm;

            //設定此視窗名稱
            this.Text = formName;
            this.formName = formName;

            //Form的一些設定
            this.StartPosition = FormStartPosition.Manual;//初始位置可被調整
            
        }
        
        //使用 method 寫入 Document 並更新
        public void WriteWebBrowserDocumentAndRefresh(string documentText) {
            //初始化為空白頁
            webBrowser.Navigate("about:blank");
            //寫檔
            webBrowser.Document.Write(documentText);
            //更新，會觸發DocumentCompleted
            webBrowser.Refresh();
        }
        
        //Document 加載完畢，重設比例/位置並顯示
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {

            WebBrowser webBrowserObject = (WebBrowser)sender;
            //如果此WebBrowser尚未Ready，則DocumentCompleted不生效，直接return 
            //理論上影片會跳轉一次，可避免尚未ready的時候call這個method也被執行到
            if (webBrowserObject.ReadyState != WebBrowserReadyState.Complete)
                return;
                        
            //重設比例(並且重設resultPreview的位置)
            ResizeWebBrowser();

            //預覽視窗長寬比例/位置,設定完畢才Show，避免一開始出現在奇怪的位置
            //如果此為圖片網址取得結果用的showPreview，則不Show
            if (!isImageLoading) {
                this.Show();
            }   

            Console.WriteLine("completed:" + webBrowserObject.DocumentText);
        }

        //重新設定預覽視窗長寬比例
        public void ResizeWebBrowser() {

            int imageWidth = webBrowser.Document.Body.ScrollRectangle.Width;
            int imageHeight = webBrowser.Document.Body.ScrollRectangle.Height;

            Console.WriteLine("BrowserSize:" + imageWidth + "x" + imageHeight);

            this.Size = defaultSize;//重設視窗長寬
            this.Size = new Size(imageWidth + widthOffset, imageHeight + heightOffset);

            //如果sourecePreview長寬設置完了，且resultPreview存在，重設resultPreview的位置
            if (this.formName == FirstForm.sourcePreviewString && FirstForm.resultPreview != null && !FirstForm.resultPreview.IsDisposed) {
                firstForm.ResetFormPosition(ref FirstForm.resultPreview);
            }

            //如果是ResultPreview用來先讀取一次圖片長寬用的，則呼叫重設長寬專用的method
            if (isImageLoading) {
                isImageLoading = false;
                firstForm.ChangeResultHTMLAndPreviewForImageURL(imageWidth, imageHeight);
            }

        }
    }
}
