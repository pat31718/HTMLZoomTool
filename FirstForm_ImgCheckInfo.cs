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
    public partial class FirstForm_ImgCheckInfo : Form {
        public FirstForm_ImgCheckInfo() {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e) {
            
            //如果需要記憶的話回傳no
            if (this.remindCheckBox.Checked) {
                this.DialogResult = DialogResult.Yes;
            }
            else {
                this.DialogResult = DialogResult.No;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
