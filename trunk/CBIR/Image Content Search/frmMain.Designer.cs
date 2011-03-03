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
            this.pbQueryImage = new System.Windows.Forms.PictureBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ilResult = new System.Windows.Forms.ImageList(this.components);
            this.ofdBrowseImage = new System.Windows.Forms.OpenFileDialog();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.pbExtractedObject = new System.Windows.Forms.PictureBox();
            this.btnNextObject = new System.Windows.Forms.Button();
            this.btnPrevObject = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbQueryImage)).BeginInit();
            this.gbQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExtractedObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.btnBrowseImage.Location = new System.Drawing.Point(28, 39);
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
            // pbExtractedObject
            // 
            this.pbExtractedObject.Location = new System.Drawing.Point(28, 380);
            this.pbExtractedObject.Name = "pbExtractedObject";
            this.pbExtractedObject.Size = new System.Drawing.Size(200, 150);
            this.pbExtractedObject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbExtractedObject.TabIndex = 0;
            this.pbExtractedObject.TabStop = false;
            // 
            // btnNextObject
            // 
            this.btnNextObject.Location = new System.Drawing.Point(71, 351);
            this.btnNextObject.Name = "btnNextObject";
            this.btnNextObject.Size = new System.Drawing.Size(39, 23);
            this.btnNextObject.TabIndex = 12;
            this.btnNextObject.Text = ">>";
            this.btnNextObject.UseVisualStyleBackColor = true;
            // 
            // btnPrevObject
            // 
            this.btnPrevObject.Location = new System.Drawing.Point(28, 351);
            this.btnPrevObject.Name = "btnPrevObject";
            this.btnPrevObject.Size = new System.Drawing.Size(39, 23);
            this.btnPrevObject.TabIndex = 12;
            this.btnPrevObject.Text = "<<";
            this.btnPrevObject.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(674, 380);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 554);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbExtractedObject);
            this.Controls.Add(this.btnPrevObject);
            this.Controls.Add(this.btnNextObject);
            this.Controls.Add(this.gbQuery);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBrowseImage);
            this.Name = "frmMain";
            this.Text = "Tim kiem anh (su dung luoi vung)";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbQueryImage)).EndInit();
            this.gbQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbExtractedObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbQueryImage;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ImageList ilResult;
        private System.Windows.Forms.OpenFileDialog ofdBrowseImage;
        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.Button btnNextObject;
        private System.Windows.Forms.Button btnPrevObject;
        private System.Windows.Forms.PictureBox pbExtractedObject;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

