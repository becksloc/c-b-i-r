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
            this.pbQueryImage = new System.Windows.Forms.PictureBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ilResult = new System.Windows.Forms.ImageList(this.components);
            this.ofdBrowseImage = new System.Windows.Forms.OpenFileDialog();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThreshold = new System.Windows.Forms.TextBox();
            this.gpObject = new System.Windows.Forms.GroupBox();
            this.pbExtractedObject = new System.Windows.Forms.PictureBox();
            this.btnNextObject = new System.Windows.Forms.Button();
            this.btnPrevObject = new System.Windows.Forms.Button();
            this.gpFeatures = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbQueryImage)).BeginInit();
            this.gbQuery.SuspendLayout();
            this.gpObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExtractedObject)).BeginInit();
            this.SuspendLayout();
            // 
            // lvResult
            // 
            this.lvResult.Location = new System.Drawing.Point(297, 41);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(547, 320);
            this.lvResult.TabIndex = 0;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            // 
            // gbImageDetail
            // 
            this.gbImageDetail.Location = new System.Drawing.Point(521, 380);
            this.gbImageDetail.Name = "gbImageDetail";
            this.gbImageDetail.Size = new System.Drawing.Size(323, 152);
            this.gbImageDetail.TabIndex = 1;
            this.gbImageDetail.TabStop = false;
            this.gbImageDetail.Text = "Thông tin chi tiết của ảnh (đã chọn ở trên)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kết quả tìm kiếm:";
            // 
            // pbQueryImage
            // 
            this.pbQueryImage.Location = new System.Drawing.Point(18, 19);
            this.pbQueryImage.Name = "pbQueryImage";
            this.pbQueryImage.Size = new System.Drawing.Size(207, 213);
            this.pbQueryImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbQueryImage.TabIndex = 0;
            this.pbQueryImage.TabStop = false;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(28, 338);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(80, 23);
            this.btnBrowseImage.TabIndex = 0;
            this.btnBrowseImage.Text = "Chọn ảnh...";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(187, 39);
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
            // gbQuery
            // 
            this.gbQuery.Controls.Add(this.pbQueryImage);
            this.gbQuery.Location = new System.Drawing.Point(28, 83);
            this.gbQuery.Name = "gbQuery";
            this.gbQuery.Size = new System.Drawing.Size(241, 249);
            this.gbQuery.TabIndex = 7;
            this.gbQuery.TabStop = false;
            this.gbQuery.Text = "Ảnh cần tìm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ngưỡng xấp xỉ:";
            // 
            // txtThreshold
            // 
            this.txtThreshold.Location = new System.Drawing.Point(104, 40);
            this.txtThreshold.Name = "txtThreshold";
            this.txtThreshold.Size = new System.Drawing.Size(44, 20);
            this.txtThreshold.TabIndex = 9;
            // 
            // gpObject
            // 
            this.gpObject.Controls.Add(this.pbExtractedObject);
            this.gpObject.Location = new System.Drawing.Point(28, 380);
            this.gpObject.Name = "gpObject";
            this.gpObject.Size = new System.Drawing.Size(241, 152);
            this.gpObject.TabIndex = 10;
            this.gpObject.TabStop = false;
            this.gpObject.Text = "Đối tượng được tách ra (HCN cơ sở)";
            // 
            // pbExtractedObject
            // 
            this.pbExtractedObject.Location = new System.Drawing.Point(18, 19);
            this.pbExtractedObject.Name = "pbExtractedObject";
            this.pbExtractedObject.Size = new System.Drawing.Size(207, 121);
            this.pbExtractedObject.TabIndex = 0;
            this.pbExtractedObject.TabStop = false;
            this.pbExtractedObject.Paint += new System.Windows.Forms.PaintEventHandler(this.pbExtractedObject_Paint);
            // 
            // btnNextObject
            // 
            this.btnNextObject.Location = new System.Drawing.Point(230, 351);
            this.btnNextObject.Name = "btnNextObject";
            this.btnNextObject.Size = new System.Drawing.Size(39, 23);
            this.btnNextObject.TabIndex = 12;
            this.btnNextObject.Text = ">>";
            this.btnNextObject.UseVisualStyleBackColor = true;
            // 
            // btnPrevObject
            // 
            this.btnPrevObject.Location = new System.Drawing.Point(187, 351);
            this.btnPrevObject.Name = "btnPrevObject";
            this.btnPrevObject.Size = new System.Drawing.Size(39, 23);
            this.btnPrevObject.TabIndex = 12;
            this.btnPrevObject.Text = "<<";
            this.btnPrevObject.UseVisualStyleBackColor = true;
            // 
            // gpFeatures
            // 
            this.gpFeatures.Location = new System.Drawing.Point(297, 380);
            this.gpFeatures.Name = "gpFeatures";
            this.gpFeatures.Size = new System.Drawing.Size(197, 152);
            this.gpFeatures.TabIndex = 13;
            this.gpFeatures.TabStop = false;
            this.gpFeatures.Text = "Đặc trưng của đối tượng";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 554);
            this.Controls.Add(this.gpFeatures);
            this.Controls.Add(this.btnPrevObject);
            this.Controls.Add(this.btnNextObject);
            this.Controls.Add(this.gpObject);
            this.Controls.Add(this.txtThreshold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbQuery);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbImageDetail);
            this.Controls.Add(this.lvResult);
            this.Name = "frmMain";
            this.Text = "Tim kiem anh (su dung luoi vung)";
            ((System.ComponentModel.ISupportInitialize)(this.pbQueryImage)).EndInit();
            this.gbQuery.ResumeLayout(false);
            this.gpObject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbExtractedObject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.GroupBox gbImageDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbQueryImage;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ImageList ilResult;
        private System.Windows.Forms.OpenFileDialog ofdBrowseImage;
        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtThreshold;
        private System.Windows.Forms.GroupBox gpObject;
        private System.Windows.Forms.Button btnNextObject;
        private System.Windows.Forms.Button btnPrevObject;
        private System.Windows.Forms.GroupBox gpFeatures;
        private System.Windows.Forms.PictureBox pbExtractedObject;
    }
}

