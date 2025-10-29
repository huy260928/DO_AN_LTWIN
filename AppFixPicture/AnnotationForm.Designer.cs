namespace AppFixPicture
{
    partial class AnnotationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controls (match names used in AnnotationForm.cs)
        private System.Windows.Forms.ToolStrip toolStripTop;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSelect;
        private System.Windows.Forms.ToolStripButton btnPencil;
        private System.Windows.Forms.ToolStripButton btnRect;
        private System.Windows.Forms.ToolStripButton btnCircle;
        private System.Windows.Forms.ToolStripButton btnArrow;
        private System.Windows.Forms.ToolStripButton btnText;
        private System.Windows.Forms.ToolStripButton btnColor;
        private System.Windows.Forms.ToolStripButton btnFont;
        private System.Windows.Forms.ToolStripComboBox cbFontSize;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripButton btnZoomIn;
        private System.Windows.Forms.ToolStripButton btnZoomOut;
        private System.Windows.Forms.ToolStripButton btnApply;

        private System.Windows.Forms.PictureBox pictureBoxCanvas;
        private System.Windows.Forms.StatusStrip statusStripBottom;
        private System.Windows.Forms.ToolStripStatusLabel statusCoords;
        private System.Windows.Forms.ToolStripStatusLabel statusTool;
        private System.Windows.Forms.ToolStripStatusLabel statusZoom;

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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSelect = new System.Windows.Forms.ToolStripButton();
            this.btnPencil = new System.Windows.Forms.ToolStripButton();
            this.btnRect = new System.Windows.Forms.ToolStripButton();
            this.btnCircle = new System.Windows.Forms.ToolStripButton();
            this.btnArrow = new System.Windows.Forms.ToolStripButton();
            this.btnText = new System.Windows.Forms.ToolStripButton();
            this.btnColor = new System.Windows.Forms.ToolStripButton();
            this.btnFont = new System.Windows.Forms.ToolStripButton();
            this.cbFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.btnApply = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxCanvas = new System.Windows.Forms.PictureBox();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.statusCoords = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTool = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusZoom = new System.Windows.Forms.ToolStripStatusLabel();
            // 
            // toolStripTop
            // 
            this.toolStripTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.btnOpen,
                this.btnSelect,
                this.btnPencil,
                this.btnRect,
                this.btnCircle,
                this.btnArrow,
                this.btnText,
                this.btnColor,
                this.btnFont,
                this.cbFontSize,
                this.btnUndo,
                this.btnRedo,
                this.btnSave,
                this.btnClear,
                this.btnZoomIn,
                this.btnZoomOut,
                this.btnApply
            });

            // Simple text for buttons
            this.btnOpen.Text = "Open";
            this.btnSelect.Text = "Select";
            this.btnPencil.Text = "Pencil";
            this.btnRect.Text = "Rectangle";
            this.btnCircle.Text = "Circle";
            this.btnArrow.Text = "Arrow";
            this.btnText.Text = "Add Text";
            this.btnColor.Text = "Color";
            this.btnFont.Text = "Font";
            this.cbFontSize.Width = 60;
            this.cbFontSize.Text = "12";
            this.btnUndo.Text = "Undo";
            this.btnRedo.Text = "Redo";
            this.btnSave.Text = "Save";
            this.btnClear.Text = "Clear";
            this.btnZoomIn.Text = "Zoom+";
            this.btnZoomOut.Text = "Zoom-";
            this.btnApply.Text = "Apply";

            // 
            // pictureBoxCanvas
            // 
            this.pictureBoxCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCanvas.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;

            // 
            // statusStripBottom
            // 
            this.statusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.statusCoords,
                this.statusTool,
                this.statusZoom
            });

            this.statusCoords.Text = "X:0 Y:0";
            this.statusTool.Text = "Tool: Pencil";
            this.statusZoom.Text = "Zoom: 100%";

            // 
            // AnnotationForm (this)
            // 
            this.Controls.Add(this.pictureBoxCanvas);
            this.Controls.Add(this.statusStripBottom);
            this.Controls.Add(this.toolStripTop);
            this.Name = "AnnotationForm";
            this.Text = "Annotation";
        }

        #endregion
    }
}
