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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExtract = new System.Windows.Forms.Button();
            this.ofdBrowseImage = new System.Windows.Forms.OpenFileDialog();
            this.ilResult = new System.Windows.Forms.ImageList(this.components);
            this.pbImageInDB = new System.Windows.Forms.PictureBox();
            this.btnPrevObject = new System.Windows.Forms.Button();
            this.btnNextObject = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.pbExtractedObject = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBitString = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageInDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExtractedObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ảnh trong cơ sở dữ liệu:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(275, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Thêm ảnh";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(356, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Xóa ảnh";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(505, 21);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(128, 23);
            this.btnExtract.TabIndex = 10;
            this.btnExtract.Text = "Trích chọn đặc trưng";
            this.btnExtract.UseVisualStyleBackColor = true;
            // 
            // ofdBrowseImage
            // 
            this.ofdBrowseImage.Filter = "Ảnh Bitmap|*.bmp";
            // 
            // ilResult
            // 
            this.ilResult.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilResult.ImageSize = new System.Drawing.Size(16, 16);
            this.ilResult.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pbImageInDB
            // 
            this.pbImageInDB.Location = new System.Drawing.Point(27, 55);
            this.pbImageInDB.Name = "pbImageInDB";
            this.pbImageInDB.Size = new System.Drawing.Size(404, 291);
            this.pbImageInDB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImageInDB.TabIndex = 11;
            this.pbImageInDB.TabStop = false;
            // 
            // btnPrevObject
            // 
            this.btnPrevObject.Enabled = false;
            this.btnPrevObject.Location = new System.Drawing.Point(27, 352);
            this.btnPrevObject.Name = "btnPrevObject";
            this.btnPrevObject.Size = new System.Drawing.Size(39, 23);
            this.btnPrevObject.TabIndex = 14;
            this.btnPrevObject.Text = "<<";
            this.btnPrevObject.UseVisualStyleBackColor = true;
            this.btnPrevObject.Click += new System.EventHandler(this.btnPrevObject_Click);
            // 
            // btnNextObject
            // 
            this.btnNextObject.Location = new System.Drawing.Point(72, 352);
            this.btnNextObject.Name = "btnNextObject";
            this.btnNextObject.Size = new System.Drawing.Size(39, 23);
            this.btnNextObject.TabIndex = 13;
            this.btnNextObject.Text = ">>";
            this.btnNextObject.UseVisualStyleBackColor = true;
            this.btnNextObject.Click += new System.EventHandler(this.btnNextObject_Click);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(128, 362);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(50, 13);
            this.lblPage.TabIndex = 15;
            this.lblPage.Text = "(Ảnh thứ)";
            // 
            // pbExtractedObject
            // 
            this.pbExtractedObject.Location = new System.Drawing.Point(491, 196);
            this.pbExtractedObject.Name = "pbExtractedObject";
            this.pbExtractedObject.Size = new System.Drawing.Size(200, 150);
            this.pbExtractedObject.TabIndex = 16;
            this.pbExtractedObject.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(491, 414);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 150);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(253, 414);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 150);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(27, 414);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(200, 150);
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(24, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Đối tượng trích ra";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(488, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Phủ lưới lên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Brown;
            this.label4.Location = new System.Drawing.Point(488, 389);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Trục chính song song với X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(255, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tìm trục chính";
            // 
            // lblBitString
            // 
            this.lblBitString.AutoSize = true;
            this.lblBitString.ForeColor = System.Drawing.Color.Crimson;
            this.lblBitString.Location = new System.Drawing.Point(576, 72);
            this.lblBitString.Name = "lblBitString";
            this.lblBitString.Size = new System.Drawing.Size(49, 13);
            this.lblBitString.TabIndex = 22;
            this.lblBitString.Text = "0101010";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(488, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Chuỗi nhị phân:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 576);
            this.Controls.Add(this.lblBitString);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbExtractedObject);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.btnPrevObject);
            this.Controls.Add(this.btnNextObject);
            this.Controls.Add(this.pbImageInDB);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Quan ly & trich tron dac trung anh";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImageInDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExtractedObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.OpenFileDialog ofdBrowseImage;
        private System.Windows.Forms.ImageList ilResult;
        private System.Windows.Forms.PictureBox pbImageInDB;
        private System.Windows.Forms.Button btnPrevObject;
        private System.Windows.Forms.Button btnNextObject;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.PictureBox pbExtractedObject;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBitString;
        private System.Windows.Forms.Label label6;
    }
}

