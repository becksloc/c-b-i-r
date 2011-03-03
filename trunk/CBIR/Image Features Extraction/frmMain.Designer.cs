namespace Image_Features_Extraction
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
            this.label1 = new System.Windows.Forms.Label();
            this.gbImageDetail = new System.Windows.Forms.GroupBox();
            this.lblThongtin = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExtract = new System.Windows.Forms.Button();
            this.ofdBrowseImage = new System.Windows.Forms.OpenFileDialog();
            this.ilResult = new System.Windows.Forms.ImageList(this.components);
            this.pbImageInDB = new System.Windows.Forms.PictureBox();
            this.btnPrevObject = new System.Windows.Forms.Button();
            this.btnNextObject = new System.Windows.Forms.Button();
            this.btnTimTrucchinh = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.gbImageDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageInDB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ảnh trong cơ sở dữ liệu:";
            // 
            // gbImageDetail
            // 
            this.gbImageDetail.Controls.Add(this.lblThongtin);
            this.gbImageDetail.Location = new System.Drawing.Point(32, 405);
            this.gbImageDetail.Name = "gbImageDetail";
            this.gbImageDetail.Size = new System.Drawing.Size(598, 108);
            this.gbImageDetail.TabIndex = 6;
            this.gbImageDetail.TabStop = false;
            this.gbImageDetail.Text = "Thông tin chi tiết của ảnh (đã chọn ở trên)";
            // 
            // lblThongtin
            // 
            this.lblThongtin.AutoSize = true;
            this.lblThongtin.Location = new System.Drawing.Point(6, 28);
            this.lblThongtin.Name = "lblThongtin";
            this.lblThongtin.Size = new System.Drawing.Size(52, 13);
            this.lblThongtin.TabIndex = 0;
            this.lblThongtin.Text = "Thong tin";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(187, 36);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Thêm ảnh";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(268, 36);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Xóa ảnh";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(474, 37);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(128, 23);
            this.btnExtract.TabIndex = 10;
            this.btnExtract.Text = "Trích chọn đặc trưng";
            this.btnExtract.UseVisualStyleBackColor = true;
            // 
            // ofdBrowseImage
            // 
            this.ofdBrowseImage.Filter = "Ảnh Bitmap|*.bmp";
            this.ofdBrowseImage.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdBrowseImage_FileOk);
            // 
            // ilResult
            // 
            this.ilResult.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilResult.ImageSize = new System.Drawing.Size(16, 16);
            this.ilResult.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pbImageInDB
            // 
            this.pbImageInDB.Location = new System.Drawing.Point(32, 70);
            this.pbImageInDB.Name = "pbImageInDB";
            this.pbImageInDB.Size = new System.Drawing.Size(598, 291);
            this.pbImageInDB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImageInDB.TabIndex = 11;
            this.pbImageInDB.TabStop = false;
            // 
            // btnPrevObject
            // 
            this.btnPrevObject.Enabled = false;
            this.btnPrevObject.Location = new System.Drawing.Point(32, 367);
            this.btnPrevObject.Name = "btnPrevObject";
            this.btnPrevObject.Size = new System.Drawing.Size(39, 23);
            this.btnPrevObject.TabIndex = 14;
            this.btnPrevObject.Text = "<<";
            this.btnPrevObject.UseVisualStyleBackColor = true;
            this.btnPrevObject.Click += new System.EventHandler(this.btnPrevObject_Click);
            // 
            // btnNextObject
            // 
            this.btnNextObject.Location = new System.Drawing.Point(77, 367);
            this.btnNextObject.Name = "btnNextObject";
            this.btnNextObject.Size = new System.Drawing.Size(39, 23);
            this.btnNextObject.TabIndex = 13;
            this.btnNextObject.Text = ">>";
            this.btnNextObject.UseVisualStyleBackColor = true;
            this.btnNextObject.Click += new System.EventHandler(this.btnNextObject_Click);
            // 
            // btnTimTrucchinh
            // 
            this.btnTimTrucchinh.Location = new System.Drawing.Point(349, 36);
            this.btnTimTrucchinh.Name = "btnTimTrucchinh";
            this.btnTimTrucchinh.Size = new System.Drawing.Size(100, 24);
            this.btnTimTrucchinh.TabIndex = 11;
            this.btnTimTrucchinh.Text = "Tìm trục chính";
            this.btnTimTrucchinh.UseVisualStyleBackColor = true;
            this.btnTimTrucchinh.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(133, 377);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(50, 13);
            this.lblPage.TabIndex = 15;
            this.lblPage.Text = "(Ảnh thứ)";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 535);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.btnTimTrucchinh);
            this.Controls.Add(this.btnPrevObject);
            this.Controls.Add(this.btnNextObject);
            this.Controls.Add(this.pbImageInDB);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbImageDetail);
            this.Name = "frmMain";
            this.Text = "Quan ly & trich tron dac trung anh";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbImageDetail.ResumeLayout(false);
            this.gbImageDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageInDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbImageDetail;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.OpenFileDialog ofdBrowseImage;
        private System.Windows.Forms.ImageList ilResult;
        private System.Windows.Forms.PictureBox pbImageInDB;
        private System.Windows.Forms.Button btnPrevObject;
        private System.Windows.Forms.Button btnNextObject;
        private System.Windows.Forms.Button btnTimTrucchinh;
        private System.Windows.Forms.Label lblThongtin;
        private System.Windows.Forms.Label lblPage;
    }
}

