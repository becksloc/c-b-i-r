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
            this.btnNextObject = new System.Windows.Forms.Button();
            this.btnPrevObject = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBitString = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblResultCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbQueryImage)).BeginInit();
            this.gbQuery.SuspendLayout();
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
            this.btnSearch.Enabled = false;
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
            // btnNextObject
            // 
            this.btnNextObject.Location = new System.Drawing.Point(71, 341);
            this.btnNextObject.Name = "btnNextObject";
            this.btnNextObject.Size = new System.Drawing.Size(39, 23);
            this.btnNextObject.TabIndex = 12;
            this.btnNextObject.Text = ">>";
            this.btnNextObject.UseVisualStyleBackColor = true;
            // 
            // btnPrevObject
            // 
            this.btnPrevObject.Location = new System.Drawing.Point(28, 341);
            this.btnPrevObject.Name = "btnPrevObject";
            this.btnPrevObject.Size = new System.Drawing.Size(39, 23);
            this.btnPrevObject.TabIndex = 12;
            this.btnPrevObject.Text = "<<";
            this.btnPrevObject.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Chuỗi nhị phân:";
            // 
            // lblBitString
            // 
            this.lblBitString.AutoSize = true;
            this.lblBitString.ForeColor = System.Drawing.Color.Crimson;
            this.lblBitString.Location = new System.Drawing.Point(393, 8);
            this.lblBitString.Name = "lblBitString";
            this.lblBitString.Size = new System.Drawing.Size(49, 13);
            this.lblBitString.TabIndex = 14;
            this.lblBitString.Text = "1010101";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(125, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Đối tượng trích ra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(293, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tìm trục chính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Brown;
            this.label4.Location = new System.Drawing.Point(441, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Xoay trục chính song song với X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(293, 492);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Phủ lưới lên cả 4 trường hợp lật ảnh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Kết quả tìm kiếm:";
            // 
            // lblResultCount
            // 
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.ForeColor = System.Drawing.Color.Crimson;
            this.lblResultCount.Location = new System.Drawing.Point(397, 67);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(41, 13);
            this.lblResultCount.TabIndex = 16;
            this.lblResultCount.Text = "Số ảnh";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 679);
            this.Controls.Add(this.lblResultCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBitString);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBitString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblResultCount;
    }
}

