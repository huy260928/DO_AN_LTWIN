namespace AppFixPicture
{
    partial class FormCrop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCrop));
            this.pictureBoxCrop = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnApplyCustomRatio = new System.Windows.Forms.Button();
            this.lblH = new System.Windows.Forms.Label();
            this.lblW = new System.Windows.Forms.Label();
            this.txtCustomHeight = new System.Windows.Forms.TextBox();
            this.txtCustomWidth = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRotationValue = new System.Windows.Forms.Label();
            this.trackBarRotation = new System.Windows.Forms.TrackBar();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.btnRotateLeft = new System.Windows.Forms.Button();
            this.btnFlipVertical = new System.Windows.Forms.Button();
            this.btnFlipHorizontal = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnResetCrop = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAutoCropCircle = new System.Windows.Forms.Button();
            this.btnAutoCrop11 = new System.Windows.Forms.Button();
            this.btnAutoCrop43 = new System.Windows.Forms.Button();
            this.btnAutoCropDropdown = new System.Windows.Forms.Button();
            this.pnlAutoCropMenu = new System.Windows.Forms.Panel();
            this.btnAutoCrop31 = new System.Windows.Forms.Button();
            this.btnAutoCrop23 = new System.Windows.Forms.Button();
            this.btnAutoCrop169 = new System.Windows.Forms.Button();
            this.btnAutoCrop32 = new System.Windows.Forms.Button();
            this.btnNew43 = new System.Windows.Forms.Button();
            this.btnNew11 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCrop)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotation)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlAutoCropMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxCrop
            // 
            this.pictureBoxCrop.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxCrop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCrop.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCrop.Name = "pictureBoxCrop";
            this.pictureBoxCrop.Size = new System.Drawing.Size(690, 495);
            this.pictureBoxCrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCrop.TabIndex = 0;
            this.pictureBoxCrop.TabStop = false;
            this.pictureBoxCrop.Click += new System.EventHandler(this.pictureBoxCrop_Click);
            this.pictureBoxCrop.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCrop_Paint);
            this.pictureBoxCrop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCrop_MouseDown);
            this.pictureBoxCrop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCrop_MouseMove);
            this.pictureBoxCrop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCrop_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxCrop);
            this.panel1.Location = new System.Drawing.Point(363, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 495);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 481);
            this.panel2.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnApplyCustomRatio);
            this.groupBox4.Controls.Add(this.lblH);
            this.groupBox4.Controls.Add(this.lblW);
            this.groupBox4.Controls.Add(this.txtCustomHeight);
            this.groupBox4.Controls.Add(this.txtCustomWidth);
            this.groupBox4.Location = new System.Drawing.Point(12, 390);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(260, 79);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Custom";
            // 
            // btnApplyCustomRatio
            // 
            this.btnApplyCustomRatio.Location = new System.Drawing.Point(185, 13);
            this.btnApplyCustomRatio.Name = "btnApplyCustomRatio";
            this.btnApplyCustomRatio.Size = new System.Drawing.Size(60, 60);
            this.btnApplyCustomRatio.TabIndex = 4;
            this.btnApplyCustomRatio.Text = "Apply CR";
            this.btnApplyCustomRatio.UseVisualStyleBackColor = true;
            this.btnApplyCustomRatio.Click += new System.EventHandler(this.btnApplyCustomRatio_Click);
            // 
            // lblH
            // 
            this.lblH.AutoSize = true;
            this.lblH.Location = new System.Drawing.Point(47, 52);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(17, 16);
            this.lblH.TabIndex = 3;
            this.lblH.Text = "H";
            // 
            // lblW
            // 
            this.lblW.AutoSize = true;
            this.lblW.Location = new System.Drawing.Point(47, 24);
            this.lblW.Name = "lblW";
            this.lblW.Size = new System.Drawing.Size(20, 16);
            this.lblW.TabIndex = 2;
            this.lblW.Text = "W";
            // 
            // txtCustomHeight
            // 
            this.txtCustomHeight.Location = new System.Drawing.Point(79, 49);
            this.txtCustomHeight.Name = "txtCustomHeight";
            this.txtCustomHeight.Size = new System.Drawing.Size(100, 22);
            this.txtCustomHeight.TabIndex = 1;
            this.txtCustomHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomHeight_KeyPress);
            // 
            // txtCustomWidth
            // 
            this.txtCustomWidth.Location = new System.Drawing.Point(79, 21);
            this.txtCustomWidth.Name = "txtCustomWidth";
            this.txtCustomWidth.Size = new System.Drawing.Size(100, 22);
            this.txtCustomWidth.TabIndex = 0;
            this.txtCustomWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomWidth_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lblRotationValue);
            this.groupBox3.Controls.Add(this.trackBarRotation);
            this.groupBox3.Controls.Add(this.btnRotateRight);
            this.groupBox3.Controls.Add(this.btnRotateLeft);
            this.groupBox3.Controls.Add(this.btnFlipVertical);
            this.groupBox3.Controls.Add(this.btnFlipHorizontal);
            this.groupBox3.Location = new System.Drawing.Point(12, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(311, 164);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rotate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Angle";
            // 
            // lblRotationValue
            // 
            this.lblRotationValue.AutoSize = true;
            this.lblRotationValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotationValue.Location = new System.Drawing.Point(235, 99);
            this.lblRotationValue.Name = "lblRotationValue";
            this.lblRotationValue.Size = new System.Drawing.Size(25, 20);
            this.lblRotationValue.TabIndex = 6;
            this.lblRotationValue.Text = "0°";
            // 
            // trackBarRotation
            // 
            this.trackBarRotation.Location = new System.Drawing.Point(95, 99);
            this.trackBarRotation.Maximum = 180;
            this.trackBarRotation.Minimum = -180;
            this.trackBarRotation.Name = "trackBarRotation";
            this.trackBarRotation.Size = new System.Drawing.Size(104, 56);
            this.trackBarRotation.TabIndex = 5;
            this.trackBarRotation.TickFrequency = 10;
            this.trackBarRotation.Scroll += new System.EventHandler(this.trackBarRotation_Scroll);
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRotateRight.Image")));
            this.btnRotateRight.Location = new System.Drawing.Point(221, 21);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(60, 60);
            this.btnRotateRight.TabIndex = 4;
            this.btnRotateRight.UseVisualStyleBackColor = true;
            this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnRotateLeft.Image")));
            this.btnRotateLeft.Location = new System.Drawing.Point(155, 21);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(60, 60);
            this.btnRotateLeft.TabIndex = 3;
            this.btnRotateLeft.UseVisualStyleBackColor = true;
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // btnFlipVertical
            // 
            this.btnFlipVertical.Image = ((System.Drawing.Image)(resources.GetObject("btnFlipVertical.Image")));
            this.btnFlipVertical.Location = new System.Drawing.Point(89, 21);
            this.btnFlipVertical.Name = "btnFlipVertical";
            this.btnFlipVertical.Size = new System.Drawing.Size(60, 60);
            this.btnFlipVertical.TabIndex = 2;
            this.btnFlipVertical.UseVisualStyleBackColor = true;
            this.btnFlipVertical.Click += new System.EventHandler(this.btnFlipVertical_Click);
            // 
            // btnFlipHorizontal
            // 
            this.btnFlipHorizontal.Image = ((System.Drawing.Image)(resources.GetObject("btnFlipHorizontal.Image")));
            this.btnFlipHorizontal.Location = new System.Drawing.Point(23, 21);
            this.btnFlipHorizontal.Name = "btnFlipHorizontal";
            this.btnFlipHorizontal.Size = new System.Drawing.Size(60, 60);
            this.btnFlipHorizontal.TabIndex = 1;
            this.btnFlipHorizontal.UseVisualStyleBackColor = true;
            this.btnFlipHorizontal.Click += new System.EventHandler(this.btnFlipHorizontal_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnResetCrop);
            this.groupBox2.Controls.Add(this.btnApply);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Location = new System.Drawing.Point(12, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 76);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Task";
            // 
            // btnResetCrop
            // 
            this.btnResetCrop.Location = new System.Drawing.Point(23, 32);
            this.btnResetCrop.Name = "btnResetCrop";
            this.btnResetCrop.Size = new System.Drawing.Size(75, 30);
            this.btnResetCrop.TabIndex = 3;
            this.btnResetCrop.Text = "Reset";
            this.btnResetCrop.UseVisualStyleBackColor = true;
            this.btnResetCrop.Click += new System.EventHandler(this.btnResetCrop_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(185, 32);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 30);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(104, 32);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAutoCropCircle);
            this.groupBox1.Controls.Add(this.btnAutoCrop11);
            this.groupBox1.Controls.Add(this.btnAutoCrop43);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crop";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Shape";
            // 
            // btnAutoCropCircle
            // 
            this.btnAutoCropCircle.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoCropCircle.Image")));
            this.btnAutoCropCircle.Location = new System.Drawing.Point(218, 30);
            this.btnAutoCropCircle.Name = "btnAutoCropCircle";
            this.btnAutoCropCircle.Size = new System.Drawing.Size(60, 60);
            this.btnAutoCropCircle.TabIndex = 2;
            this.btnAutoCropCircle.UseVisualStyleBackColor = true;
            this.btnAutoCropCircle.Click += new System.EventHandler(this.btnAutoCropCircle_Click);
            // 
            // btnAutoCrop11
            // 
            this.btnAutoCrop11.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoCrop11.Image")));
            this.btnAutoCrop11.Location = new System.Drawing.Point(147, 30);
            this.btnAutoCrop11.Name = "btnAutoCrop11";
            this.btnAutoCrop11.Size = new System.Drawing.Size(60, 60);
            this.btnAutoCrop11.TabIndex = 1;
            this.btnAutoCrop11.UseVisualStyleBackColor = true;
            this.btnAutoCrop11.Click += new System.EventHandler(this.btnAutoCrop11_Click);
            // 
            // btnAutoCrop43
            // 
            this.btnAutoCrop43.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoCrop43.Image")));
            this.btnAutoCrop43.Location = new System.Drawing.Point(81, 30);
            this.btnAutoCrop43.Name = "btnAutoCrop43";
            this.btnAutoCrop43.Size = new System.Drawing.Size(60, 60);
            this.btnAutoCrop43.TabIndex = 0;
            this.btnAutoCrop43.UseVisualStyleBackColor = true;
            this.btnAutoCrop43.Click += new System.EventHandler(this.btnAutoCrop43_Click);
            // 
            // btnAutoCropDropdown
            // 
            this.btnAutoCropDropdown.Location = new System.Drawing.Point(34, 488);
            this.btnAutoCropDropdown.Name = "btnAutoCropDropdown";
            this.btnAutoCropDropdown.Size = new System.Drawing.Size(80, 30);
            this.btnAutoCropDropdown.TabIndex = 5;
            this.btnAutoCropDropdown.Text = "AutoCrop";
            this.btnAutoCropDropdown.UseVisualStyleBackColor = true;
            this.btnAutoCropDropdown.Click += new System.EventHandler(this.btnAutoCropDropdown_Click);
            // 
            // pnlAutoCropMenu
            // 
            this.pnlAutoCropMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlAutoCropMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAutoCropMenu.Controls.Add(this.btnAutoCrop31);
            this.pnlAutoCropMenu.Controls.Add(this.btnAutoCrop23);
            this.pnlAutoCropMenu.Controls.Add(this.btnAutoCrop169);
            this.pnlAutoCropMenu.Controls.Add(this.btnAutoCrop32);
            this.pnlAutoCropMenu.Controls.Add(this.btnNew43);
            this.pnlAutoCropMenu.Controls.Add(this.btnNew11);
            this.pnlAutoCropMenu.Location = new System.Drawing.Point(120, 488);
            this.pnlAutoCropMenu.Name = "pnlAutoCropMenu";
            this.pnlAutoCropMenu.Size = new System.Drawing.Size(203, 74);
            this.pnlAutoCropMenu.TabIndex = 4;
            this.pnlAutoCropMenu.Visible = false;
        
            // btnAutoCrop31
            // 
            this.btnAutoCrop31.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoCrop31.Location = new System.Drawing.Point(136, 39);
            this.btnAutoCrop31.Name = "btnAutoCrop31";
            this.btnAutoCrop31.Size = new System.Drawing.Size(60, 30);
            this.btnAutoCrop31.TabIndex = 13;
            this.btnAutoCrop31.Text = "3:1";
            this.btnAutoCrop31.UseVisualStyleBackColor = true;
            this.btnAutoCrop31.Click += new System.EventHandler(this.btnAutoCrop31_Click);
            // 
            // btnAutoCrop23
            // 
            this.btnAutoCrop23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoCrop23.Location = new System.Drawing.Point(71, 39);
            this.btnAutoCrop23.Name = "btnAutoCrop23";
            this.btnAutoCrop23.Size = new System.Drawing.Size(60, 30);
            this.btnAutoCrop23.TabIndex = 12;
            this.btnAutoCrop23.Text = "2:3";
            this.btnAutoCrop23.UseVisualStyleBackColor = true;
            this.btnAutoCrop23.Click += new System.EventHandler(this.btnAutoCrop23_Click);
            // 
            // btnAutoCrop169
            // 
            this.btnAutoCrop169.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoCrop169.Location = new System.Drawing.Point(5, 39);
            this.btnAutoCrop169.Name = "btnAutoCrop169";
            this.btnAutoCrop169.Size = new System.Drawing.Size(60, 30);
            this.btnAutoCrop169.TabIndex = 11;
            this.btnAutoCrop169.Text = "16:9";
            this.btnAutoCrop169.UseVisualStyleBackColor = true;
            this.btnAutoCrop169.Click += new System.EventHandler(this.btnAutoCrop169_Click);
            // 
            // btnAutoCrop32
            // 
            this.btnAutoCrop32.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoCrop32.Location = new System.Drawing.Point(136, 3);
            this.btnAutoCrop32.Name = "btnAutoCrop32";
            this.btnAutoCrop32.Size = new System.Drawing.Size(60, 30);
            this.btnAutoCrop32.TabIndex = 10;
            this.btnAutoCrop32.Text = "3:2";
            this.btnAutoCrop32.UseVisualStyleBackColor = true;
            this.btnAutoCrop32.Click += new System.EventHandler(this.btnAutoCrop32_Click);
            // 
            // btnNew43
            // 
            this.btnNew43.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew43.Location = new System.Drawing.Point(5, 3);
            this.btnNew43.Name = "btnNew43";
            this.btnNew43.Size = new System.Drawing.Size(60, 30);
            this.btnNew43.TabIndex = 8;
            this.btnNew43.Text = "4:3";
            this.btnNew43.UseVisualStyleBackColor = true;
            this.btnNew43.Click += new System.EventHandler(this.btnAutoCrop43_Click);
            // 
            // btnNew11
            // 
            this.btnNew11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew11.Location = new System.Drawing.Point(70, 3);
            this.btnNew11.Name = "btnNew11";
            this.btnNew11.Size = new System.Drawing.Size(60, 30);
            this.btnNew11.TabIndex = 9;
            this.btnNew11.Text = "1:1";
            this.btnNew11.UseVisualStyleBackColor = true;
            this.btnNew11.Click += new System.EventHandler(this.btnAutoCrop11_Click);
            // 
            // FormCrop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 607);
            this.Controls.Add(this.btnAutoCropDropdown);
            this.Controls.Add(this.pnlAutoCropMenu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormCrop";
            this.Text = "FormCrop";
            this.Load += new System.EventHandler(this.FormCrop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCrop)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotation)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlAutoCropMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCrop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAutoCrop43;
        private System.Windows.Forms.Button btnAutoCrop11;
        private System.Windows.Forms.Button btnAutoCropCircle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnResetCrop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFlipHorizontal;
        private System.Windows.Forms.Button btnFlipVertical;
        private System.Windows.Forms.Button btnRotateRight;
        private System.Windows.Forms.Button btnRotateLeft;
        private System.Windows.Forms.TrackBar trackBarRotation;
        private System.Windows.Forms.Label lblRotationValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlAutoCropMenu;
        private System.Windows.Forms.Button btnAutoCropDropdown;
        private System.Windows.Forms.Button btnNew43;
        private System.Windows.Forms.Button btnNew11;
        private System.Windows.Forms.Button btnAutoCrop32;
        private System.Windows.Forms.Button btnAutoCrop169;
        private System.Windows.Forms.Button btnAutoCrop23;
        private System.Windows.Forms.Button btnAutoCrop31;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblW;
        private System.Windows.Forms.TextBox txtCustomHeight;
        private System.Windows.Forms.TextBox txtCustomWidth;
        private System.Windows.Forms.Button btnApplyCustomRatio;
    }
}