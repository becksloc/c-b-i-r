namespace Image_Content_Search
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvResult = new System.Windows.Forms.ListView();
            this.gbImageDetail = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbImageTarget = new System.Windows.Forms.PictureBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ilResult = new System.Windows.Forms.ImageList(this.components);
            this.ofdBrowseImage = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThreshold = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageTarget)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvResult
            // 
            this.lvResult.Location = new System.Drawing.Point(297, 53);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(547, 320);
            this.lvResult.TabIndex = 0;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            // 
            // gbImageDetail
            // 
            this.gbImageDetail.Location = new System.Drawing.Point(297, 392);
            this.gbImageDetail.Name = "gbImageDetail";
            this.gbImageDetail.Size = new System.Drawing.Size(547, 108);
            this.gbImageDetail.TabIndex = 1;
            this.gbImageDetail.TabStop = false;
            this.gbImageDetail.Text = "Thông tin chi tiết của ảnh (đã chọn ở trên)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kết quả tìm kiếm:";
            // 
            // pbImageTarget
            // 
            this.pbImageTarget.Location = new System.Drawing.Point(18, 27);
            this.pbImageTarget.Name = "pbImageTarget";
            this.pbImageTarget.Size = new System.Drawing.Size(207, 223);
            this.pbImageTarget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImageTarget.TabIndex = 0;
            this.pbImageTarget.TabStop = false;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(28, 53);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(80, 23);
            this.btnBrowseImage.TabIndex = 0;
            this.btnBrowseImage.Text = "Chọn ảnh...";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(187, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Tìm kiếm >>>";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ilResult
            // 
            this.ilResult.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilResult.ImageSize = new System.Drawing.Size(16, 16);
            this.ilResult.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ofdBrowseImage
            // 
            this.ofdBrowseImage.Filter = "Tất cả|*.*|Ảnh Bitmap|*.bmp";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbImageTarget);
            this.groupBox1.Location = new System.Drawing.Point(28, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 278);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ảnh cần tìm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ngưỡng xấp xỉ:";
            // 
            // txtThreshold
            // 
            this.txtThreshold.Location = new System.Drawing.Point(109, 392);
            this.txtThreshold.Name = "txtThreshold";
            this.txtThreshold.Size = new System.Drawing.Size(82, 20);
            this.txtThreshold.TabIndex = 9;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 525);
            this.Controls.Add(this.txtThreshold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbImageDetail);
            this.Controls.Add(this.lvResult);
            this.Name = "frmMain";
            this.Text = "Tim kiem anh (su dung luoi vung)";
            ((System.ComponentModel.ISupportInitialize)(this.pbImageTarget)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.GroupBox gbImageDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbImageTarget;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ImageList ilResult;
        private System.Windows.Forms.OpenFileDialog ofdBrowseImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtThreshold;
    }
}

