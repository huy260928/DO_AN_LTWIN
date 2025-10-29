using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFixPicture
{
    public partial class FormCrop : Form
    {
        // Thuộc tính để nhận ảnh từ Form1
        public Bitmap ImageToCrop { get; set; }

        // Thuộc tính để trả về ảnh đã cắt về Form1
        public Bitmap ResultImage { get; private set; }
        // Biến cho chức năng Crop
        private bool isSelecting = false; // Trạng thái đang chọn vùng cắt
        private Point startPoint;         // Vị trí bắt đầu (MouseDown)
        private Rectangle selectionRect;  // Vùng chữ nhật được chọn

        // Tỷ lệ chuyển đổi tọa độ (quan trọng cho PictureBox Mode = Zoom)
        private float zoomRatio = 1.0f;
        private Bitmap workingImage;
        private Bitmap rotationBaseImage;

        // Lưu trữ góc xoay hiện tại (cần thiết cho logic Apply)
        private int currentRotationAngle = 0;
        public FormCrop()
        {
            InitializeComponent();
            this.Load += FormCrop_Load;
        }

        private void FormCrop_Load(object sender, EventArgs e)
        {
            // Normalize initialization: create workingImage and rotationBaseImage as a copy of ImageToCrop
            if (ImageToCrop == null)
            {
                MessageBox.Show("Không có ảnh để chỉnh. Vui lòng mở ảnh trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Ensure any previous bitmaps are cleared
            if (workingImage != null) { workingImage.Dispose(); workingImage = null; }
            if (rotationBaseImage != null) { rotationBaseImage.Dispose(); rotationBaseImage = null; }

            // Create fresh copies
            workingImage = new Bitmap(ImageToCrop);
            rotationBaseImage = new Bitmap(workingImage);

            pictureBoxCrop.Image = workingImage;
            pictureBoxCrop.SizeMode = PictureBoxSizeMode.Zoom;

            // Initialize rotation controls
            trackBarRotation.Value = 0;
            lblRotationValue.Text = "0°";
            currentRotationAngle = 0;

            // Calculate zoom ratio for coordinate conversions
            RecalculateZoomRatio();

            // Reset selection
            selectionRect = Rectangle.Empty;
            isSelecting = false;
        }

        private void pictureBoxCrop_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxCrop_MouseDown(object sender, MouseEventArgs e)
        {
            if (workingImage == null) return;

            isSelecting = true;
            startPoint = e.Location;
            selectionRect = Rectangle.Empty;

            // Bắt đầu vẽ
            pictureBoxCrop.Invalidate();
        }

        private void pictureBoxCrop_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isSelecting) return;

            // Tính toán kích thước và vị trí của vùng chọn
            int x = Math.Min(startPoint.X, e.X);
            int y = Math.Min(startPoint.Y, e.Y);
            int w = Math.Abs(startPoint.X - e.X);
            int h = Math.Abs(startPoint.Y - e.Y);

            selectionRect = new Rectangle(x, y, w, h);

            // Yêu cầu PictureBox vẽ lại
            pictureBoxCrop.Invalidate();
        }

        private void pictureBoxCrop_MouseUp(object sender, MouseEventArgs e)
        {
            isSelecting = false;
        }

        private void pictureBoxCrop_Paint(object sender, PaintEventArgs e)
        {
            if (selectionRect != Rectangle.Empty)
            {
                // Vẽ khung nét đứt màu trắng (hoặc màu đỏ)
                using (Pen pen = new Pen(Color.White, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                {
                    e.Graphics.DrawRectangle(pen, selectionRect);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Trường hợp 1: Người dùng đã thực hiện thao tác kéo chuột để chọn vùng
            if (!selectionRect.IsEmpty && selectionRect.Width >= 5 && selectionRect.Height >= 5)
            {
                // === LOGIC CẮT THỦ CÔNG (MANUAL CROP) ===
                try
                {
                    // Cần kiểm tra workingImage
                    if (workingImage == null)
                    {
                        MessageBox.Show("Không có ảnh để cắt.", "Lỗi");
                        return;
                    }

                    // 1. Tính toán Offset để căn chỉnh (vì PictureBoxMode.Zoom)
                    int displayedImageW = (int)(workingImage.Width * zoomRatio);
                    int displayedImageH = (int)(workingImage.Height * zoomRatio);

                    int offsetX = (pictureBoxCrop.Width - displayedImageW) / 2;
                    int offsetY = (pictureBoxCrop.Height - displayedImageH) / 2;

                    // 2. Chuyển đổi tọa độ từ PictureBox sang tọa độ ảnh gốc (pixel)
                    int cropX = (int)((selectionRect.X - offsetX) / zoomRatio);
                    int cropY = (int)((selectionRect.Y - offsetY) / zoomRatio);
                    int cropW = (int)(selectionRect.Width / zoomRatio);
                    int cropH = (int)(selectionRect.Height / zoomRatio);

                    // 3. Đảm bảo vùng cắt nằm trong giới hạn của ảnh
                    cropX = Math.Max(0, cropX);
                    cropY = Math.Max(0, cropY);
                    cropW = Math.Min(workingImage.Width - cropX, cropW);
                    cropH = Math.Min(workingImage.Height - cropY, cropH);

                    Rectangle cropArea = new Rectangle(cropX, cropY, cropW, cropH);

                    // 4. Thực hiện Crop
                    if (cropArea.Width > 0 && cropArea.Height > 0)
                    {
                        // **Cắt ảnh dựa trên workingImage**
                        Bitmap croppedBitmap = workingImage.Clone(cropArea, workingImage.PixelFormat);

                        // Gán kết quả cuối cùng cho ResultImage
                        ResultImage = croppedBitmap;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Vùng cắt không hợp lệ hoặc quá nhỏ.", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi trong quá trình cắt thủ công: {ex.Message}");
                }
            }
            // Trường hợp 2: Người dùng vừa nhấn Auto Crop (hoặc đã có workingImage) và không kéo chuột thêm
            else if (workingImage != null)
            {
                // Xác nhận ảnh hiện tại (đã qua Auto Crop) là kết quả cuối cùng
                // Trả về một bản sao để tránh sharing references
                ResultImage = new Bitmap(workingImage);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            // Trường hợp 3: Chưa có ảnh hoặc không có hành động nào
            else
            {
                MessageBox.Show("Chưa có ảnh được tải hoặc vùng cắt hợp lệ nào được chọn/áp dụng.", "Thông Báo");
            }
        }

        // Helper: apply a new working image and update rotation base, reset rotation UI
        private void SetNewWorkingImage(Bitmap newImage)
        {
            if (newImage == null) return;

            // Dispose previous workingImage if it's not the same reference
            if (workingImage != null)
            {
                try { workingImage.Dispose(); } catch { }
            }

            workingImage = newImage;

            // Update rotation base to the unrotated version of the current working image
            if (rotationBaseImage != null)
            {
                try { rotationBaseImage.Dispose(); } catch { }
            }
            rotationBaseImage = new Bitmap(workingImage);

            // Reset rotation UI
            currentRotationAngle = 0;
            try { trackBarRotation.Value = 0; } catch { }
            lblRotationValue.Text = "0°";

            // Update display and zoom ratio
            pictureBoxCrop.Image = workingImage;
            RecalculateZoomRatio();

            // Reset selection
            selectionRect = Rectangle.Empty;
            isSelecting = false;
            pictureBoxCrop.Invalidate();
        }

        private void btnAutoCrop43_Click(object sender, EventArgs e)
        {
            // Tỷ lệ mong muốn: 4:3 (W:H)
            const float TARGET_RATIO = 4.0f / 3.0f;

            if (workingImage == null)
            {
                MessageBox.Show("Không có ảnh để cắt.", "Lỗi");
                return;
            }

            Bitmap original = workingImage;
            int originalW = original.Width;
            int originalH = original.Height;
            float originalRatio = (float)originalW / originalH;

            Rectangle cropArea;

            if (originalRatio > TARGET_RATIO)
            {
                int newW = (int)(originalH * TARGET_RATIO);
                int offsetX = (originalW - newW) / 2;
                cropArea = new Rectangle(offsetX, 0, newW, originalH);
            }
            else
            {
                int newH = (int)(originalW / TARGET_RATIO);
                int offsetY = (originalH - newH) / 2;
                cropArea = new Rectangle(0, offsetY, originalW, newH);
            }

            try
            {
                if (cropArea.Width > 0 && cropArea.Height > 0)
                {
                    Bitmap croppedBitmap = original.Clone(cropArea, original.PixelFormat);
                    SetNewWorkingImage(croppedBitmap);

                    MessageBox.Show("Ảnh đã được cắt tự động 4:3. Vui lòng nhấn 'Áp dụng' để xác nhận hoặc kéo chuột để cắt tiếp.", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình cắt tự động: {ex.Message}");
            }
        }

        private void btnAutoCrop11_Click(object sender, EventArgs e)
        {
            // Tỷ lệ mong muốn: 1:1 (Hình vuông)
            const float TARGET_RATIO = 1.0f; // 1.0f / 1.0f

            if (workingImage == null)
            {
                MessageBox.Show("Không có ảnh để cắt. Vui lòng tải ảnh lên Form chính trước.", "Lỗi");
                return;
            }

            Bitmap currentImage = workingImage;
            int originalW = currentImage.Width;
            int originalH = currentImage.Height;
            float originalRatio = (float)originalW / originalH;

            Rectangle cropArea;

            if (originalRatio > TARGET_RATIO)
            {
                int newSize = originalH;
                int offsetX = (originalW - newSize) / 2;

                cropArea = new Rectangle(offsetX, 0, newSize, newSize);
            }
            else
            {
                int newSize = originalW;
                int offsetY = (originalH - newSize) / 2;
                cropArea = new Rectangle(0, offsetY, newSize, newSize);
            }

            try
            {
                if (cropArea.Width > 0 && cropArea.Height > 0)
                {
                    Bitmap croppedBitmap = currentImage.Clone(cropArea, currentImage.PixelFormat);
                    SetNewWorkingImage(croppedBitmap);

                    MessageBox.Show("Ảnh đã được cắt tự động 1:1. Vui lòng nhấn 'Áp dụng' để xác nhận.", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình cắt tự động 1:1: {ex.Message}");
            }
        }

        private Bitmap CropImageToCircle(Bitmap srcSquareImage)
        {
            Bitmap croppedCircle = new Bitmap(srcSquareImage.Width, srcSquareImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(croppedCircle))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    gp.AddEllipse(0, 0, srcSquareImage.Width, srcSquareImage.Height);
                    g.SetClip(gp);
                    g.DrawImage(srcSquareImage, 0, 0);
                }
            }

            return croppedCircle;
        }

        private void btnAutoCropCircle_Click(object sender, EventArgs e)
        {
            if (workingImage == null)
            {
                MessageBox.Show("Không có ảnh để cắt.", "Lỗi");
                return;
            }

            Bitmap currentImage = workingImage;
            int originalW = currentImage.Width;
            int originalH = currentImage.Height;
            float originalRatio = (float)originalW / originalH;

            Rectangle cropArea;

            if (originalRatio > 1.0f)
            {
                int newSize = originalH;
                int offsetX = (originalW - newSize) / 2;
                cropArea = new Rectangle(offsetX, 0, newSize, newSize);
            }
            else
            {
                int newSize = originalW;
                int offsetY = (originalH - newSize) / 2;
                cropArea = new Rectangle(0, offsetY, newSize, newSize);
            }

            try
            {
                if (cropArea.Width > 0 && cropArea.Height > 0)
                {
                    Bitmap croppedSquareBitmap = currentImage.Clone(cropArea, currentImage.PixelFormat);
                    Bitmap croppedCircleBitmap = CropImageToCircle(croppedSquareBitmap);
                    croppedSquareBitmap.Dispose();

                    SetNewWorkingImage(croppedCircleBitmap);

                    MessageBox.Show("Ảnh đã được cắt tự động thành hình tròn. Vui lòng nhấn 'Áp dụng' để xác nhận.", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình cắt tự động hình tròn: {ex.Message}");
            }
        }

        private void btnResetCrop_Click(object sender, EventArgs e)
        {
            if (ImageToCrop == null)
            {
                MessageBox.Show("Không có ảnh gốc để reset.", "Thông báo");
                return;
            }

            // Always replace workingImage with fresh copy of original input image
            SetNewWorkingImage(new Bitmap(ImageToCrop));

            MessageBox.Show("Ảnh đã được khôi phục về trạng thái ban đầu.", "Thông Báo");
        }

        private void btnFlipHorizontal_Click(object sender, EventArgs e)
        {
            if (workingImage == null)
            {
                MessageBox.Show("Không có ảnh để lật.", "Lỗi");
                return;
            }

            try
            {
                workingImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                // After in-place change, update rotation base
                if (rotationBaseImage != null) { rotationBaseImage.Dispose(); }
                rotationBaseImage = new Bitmap(workingImage);

                // Reset rotation UI
                currentRotationAngle = 0;
                try { trackBarRotation.Value = 0; } catch { }
                lblRotationValue.Text = "0°";

                pictureBoxCrop.Image = workingImage;
                pictureBoxCrop.Invalidate();

                selectionRect = Rectangle.Empty;
                isSelecting = false;
                RecalculateZoomRatio();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình lật ngang: {ex.Message}", "Lỗi Lật Ảnh");
            }
        }

        private void btnFlipVertical_Click(object sender, EventArgs e)
        {
            if (workingImage == null)
            {
                MessageBox.Show("Không có ảnh để lật.", "Lỗi");
                return;
            }

            try
            {
                workingImage.RotateFlip(RotateFlipType.RotateNoneFlipY);

                if (rotationBaseImage != null) { rotationBaseImage.Dispose(); }
                rotationBaseImage = new Bitmap(workingImage);

                currentRotationAngle = 0;
                try { trackBarRotation.Value = 0; } catch { }
                lblRotationValue.Text = "0°";

                pictureBoxCrop.Image = workingImage;
                pictureBoxCrop.Invalidate();

                selectionRect = Rectangle.Empty;
                isSelecting = false;
                RecalculateZoomRatio();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình lật dọc: {ex.Message}", "Lỗi Lật Ảnh");
            }
        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            if (workingImage == null)
            {
                MessageBox.Show("Không có ảnh để xoay.", "Lỗi");
                return;
            }

            try
            {
                workingImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // update rotation base and reset trackbar rotation
                if (rotationBaseImage != null) { rotationBaseImage.Dispose(); }
                rotationBaseImage = new Bitmap(workingImage);
                currentRotationAngle = 0;
                try { trackBarRotation.Value = 0; } catch { }
                lblRotationValue.Text = "0°";

                pictureBoxCrop.Image = workingImage;
                pictureBoxCrop.Invalidate();

                selectionRect = Rectangle.Empty;
                isSelecting = false;
                RecalculateZoomRatio();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình xoay phải: {ex.Message}", "Lỗi Xoay Ảnh");
            }

        }

        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            if (workingImage == null)
            {
                MessageBox.Show("Không có ảnh để xoay.", "Lỗi");
                return;
            }

            try
            {
                workingImage.RotateFlip(RotateFlipType.Rotate270FlipNone);

                if (rotationBaseImage != null) { rotationBaseImage.Dispose(); }
                rotationBaseImage = new Bitmap(workingImage);
                currentRotationAngle = 0;
                try { trackBarRotation.Value = 0; } catch { }
                lblRotationValue.Text = "0°";

                pictureBoxCrop.Image = workingImage;
                pictureBoxCrop.Invalidate();

                selectionRect = Rectangle.Empty;
                isSelecting = false;
                RecalculateZoomRatio();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình xoay trái: {ex.Message}", "Lỗi Xoay Ảnh");
            }
        }
        private void RecalculateZoomRatio()
        {
            if (workingImage == null)
            {
                zoomRatio = 1.0f;
                return;
            }

            float ratioW = (float)pictureBoxCrop.Width / workingImage.Width;
            float ratioH = (float)pictureBoxCrop.Height / workingImage.Height;
            zoomRatio = Math.Min(ratioW, ratioH);
        }

        private void trackBarRotation_Scroll(object sender, EventArgs e)
        {
            if (rotationBaseImage == null) return;

            // Lấy góc xoay mới từ TrackBar
            currentRotationAngle = trackBarRotation.Value;

            // Cập nhật Label
            lblRotationValue.Text = $"{currentRotationAngle}°";

            // Thực hiện xoay ảnh dựa trên rotationBaseImage (không thay đổi rotationBaseImage)
            Bitmap newRotatedImage = RotateImage(rotationBaseImage, currentRotationAngle);

            // Giải phóng workingImage cũ
            if (workingImage != null) { try { workingImage.Dispose(); } catch { } }

            // Gán ảnh xoay mới (chỉ hiển thị, rotationBaseImage vẫn giữ ảnh nguồn)
            workingImage = newRotatedImage;
            pictureBoxCrop.Image = workingImage;

            // Cần tính toán lại zoomRatio vì kích thước ảnh sau khi xoay có thể thay đổi
            RecalculateZoomRatio();

            // Reset vùng chọn (vì vùng chọn cũ không còn chính xác)
            selectionRect = Rectangle.Empty;
            pictureBoxCrop.Invalidate();
        }
        private Bitmap RotateImage(Bitmap baseImage, float angle)
        {
            if (angle == 0) return new Bitmap(baseImage);

            double radianAngle = angle * Math.PI / 180.0;
            float sin = (float)Math.Abs(Math.Sin(radianAngle));
            float cos = (float)Math.Abs(Math.Cos(radianAngle));
            int newWidth = (int)(baseImage.Width * cos + baseImage.Height * sin);
            int newHeight = (int)(baseImage.Width * sin + baseImage.Height * cos);

            Bitmap rotatedImage = new Bitmap(newWidth, newHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            rotatedImage.SetResolution(baseImage.HorizontalResolution, baseImage.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                g.TranslateTransform(newWidth / 2f, newHeight / 2f);
                g.RotateTransform(angle);
                g.TranslateTransform(-baseImage.Width / 2f, -baseImage.Height / 2f);

                g.DrawImage(baseImage, 0, 0, baseImage.Width, baseImage.Height);
            }

            return rotatedImage;
        }

        private void btnAutoCropDropdown_Click(object sender, EventArgs e)
        {
            pnlAutoCropMenu.Visible = !pnlAutoCropMenu.Visible;

            if (pnlAutoCropMenu.Visible)
            {
                pnlAutoCropMenu.Location = new Point(
                    btnAutoCropDropdown.Left,
                    btnAutoCropDropdown.Bottom
                );
                pnlAutoCropMenu.BringToFront();
            }
        }

        private void btnAutoCrop32_Click(object sender, EventArgs e)
        {
            const float TARGET_RATIO = 3.0f / 2.0f;

            if (workingImage == null)
            {
                MessageBox.Show("Không có ảnh để cắt. Vui lòng tải ảnh lên Form chính trước.", "Lỗi");
                return;
            }

            Bitmap currentImage = workingImage;
            int originalW = currentImage.Width;
            int originalH = currentImage.Height;
            float originalRatio = (float)originalW / originalH;

            Rectangle cropArea;

            if (originalRatio > TARGET_RATIO)
            {
                int newW = (int)(originalH * TARGET_RATIO);
                int offsetX = (originalW - newW) / 2;
                cropArea = new Rectangle(offsetX, 0, newW, originalH);
            }
            else
            {
                int newH = (int)(originalW / TARGET_RATIO);
                int offsetY = (originalH - newH) / 2;
                cropArea = new Rectangle(0, offsetY, originalW, newH);
            }

            try
            {
                if (cropArea.Width > 0 && cropArea.Height > 0)
                {
                    Bitmap croppedBitmap = currentImage.Clone(cropArea, currentImage.PixelFormat);
                    SetNewWorkingImage(croppedBitmap);
                    MessageBox.Show("Ảnh đã được cắt tự động 3:2. Vui lòng nhấn 'Áp dụng' để xác nhận.", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình cắt tự động 3:2: {ex.Message}");
            }
        }

        private void btnAutoCrop169_Click(object sender, EventArgs e)
        {
            const float TARGET_RATIO = 16.0f / 9.0f;

            if (workingImage == null)
            {
                MessageBox.Show("Không có ảnh để cắt. Vui lòng tải ảnh lên Form chính trước.", "Lỗi");
                return;
            }

            Bitmap currentImage = workingImage;
            int originalW = currentImage.Width;
            int originalH = currentImage.Height;
            float originalRatio = (float)originalW / originalH;

            Rectangle cropArea;

            if (originalRatio > TARGET_RATIO)
            {
                int newW = (int)(originalH * TARGET_RATIO);
                int offsetX = (originalW - newW) / 2;
                cropArea = new Rectangle(offsetX, 0, newW, originalH);
            }
            else
            {
                int newH = (int)(originalW / TARGET_RATIO);
                int offsetY = (originalH - newH) / 2;
                cropArea = new Rectangle(0, offsetY, originalW, newH);
            }

            try
            {
                if (cropArea.Width > 0 && cropArea.Height > 0)
                {
                    Bitmap croppedBitmap = currentImage.Clone(cropArea, currentImage.PixelFormat);
                    SetNewWorkingImage(croppedBitmap);
                    MessageBox.Show("Ảnh đã được cắt tự động 16:9. Vui lòng nhấn 'Áp dụng' để xác nhận.", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình cắt tự động 16:9: {ex.Message}");
            }
        }

        private void btnAutoCrop23_Click(object sender, EventArgs e)
        {
            const float TARGET_RATIO = 2.0f / 3.0f;

            if (workingImage == null)
            {
                MessageBox.Show("Không có ảnh để cắt. Vui lòng tải ảnh lên Form chính trước.", "Lỗi");
                return;
            }

            Bitmap currentImage = workingImage;
            int originalW = currentImage.Width;
            int originalH = currentImage.Height;
            float originalRatio = (float)originalW / originalH;

            Rectangle cropArea;

            if (originalRatio > TARGET_RATIO)
            {
                int newW = (int)(originalH * TARGET_RATIO);
                int offsetX = (originalW - newW) / 2;
                cropArea = new Rectangle(offsetX, 0, newW, originalH);
            }
            else
            {
                int newH = (int)(originalW / TARGET_RATIO);
                int offsetY = (originalH - newH) / 2;
                cropArea = new Rectangle(0, offsetY, originalW, newH);
            }

            try
            {
                if (cropArea.Width > 0 && cropArea.Height > 0)
                {
                    Bitmap croppedBitmap = currentImage.Clone(cropArea, currentImage.PixelFormat);
                    SetNewWorkingImage(croppedBitmap);
                    MessageBox.Show("Ảnh đã được cắt tự động theo tỷ lệ 2:3 (Passport). Vui lòng nhấn 'Áp dụng' để xác nhận.", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình cắt tự động 2:3: {ex.Message}");
            }
        }

        private void btnAutoCrop31_Click(object sender, EventArgs e)
        {
            const float TARGET_RATIO = 3.0f / 1.0f;

            if (workingImage == null)
            {
                MessageBox.Show("Không có ảnh để cắt. Vui lòng tải ảnh lên Form chính trước.", "Lỗi");
                return;
            }

            Bitmap currentImage = workingImage;
            int originalW = currentImage.Width;
            int originalH = currentImage.Height;
            float originalRatio = (float)originalW / originalH;

            Rectangle cropArea;

            if (originalRatio > TARGET_RATIO)
            {
                int newW = (int)(originalH * TARGET_RATIO);
                int offsetX = (originalW - newW) / 2;
                cropArea = new Rectangle(offsetX, 0, newW, originalH);
            }
            else
            {
                int newH = (int)(originalW / TARGET_RATIO);
                int offsetY = (originalH - newH) / 2;
                cropArea = new Rectangle(0, offsetY, originalW, newH);
            }

            try
            {
                if (cropArea.Width > 0 && cropArea.Height > 0)
                {
                    Bitmap croppedBitmap = currentImage.Clone(cropArea, currentImage.PixelFormat);
                    SetNewWorkingImage(croppedBitmap);
                    MessageBox.Show("Ảnh đã được cắt tự động theo tỷ lệ 3:1. Vui lòng nhấn 'Áp dụng' để xác nhận.", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình cắt tự động 3:1: {ex.Message}");
            }
        }

        private void btnApplyCustomRatio_Click(object sender, EventArgs e)
        {
            if (workingImage == null)
            {
                MessageBox.Show("Không có ảnh để cắt. Vui lòng tải ảnh lên trước.", "Lỗi");
                return;
            }

            if (!int.TryParse(txtCustomWidth.Text, out int desiredW) || !int.TryParse(txtCustomHeight.Text, out int desiredH))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho Chiều Rộng và Chiều Cao.", "Lỗi Input");
                return;
            }

            if (desiredW <= 0 || desiredH <= 0)
            {
                MessageBox.Show("Chiều Rộng và Chiều Cao phải lớn hơn 0.", "Lỗi Input");
                return;
            }

            float TARGET_RATIO = (float)desiredW / desiredH;

            Bitmap currentImage = workingImage;
            int originalW = currentImage.Width;
            int originalH = currentImage.Height;
            float originalRatio = (float)originalW / originalH;

            Rectangle cropArea;

            if (originalRatio > TARGET_RATIO)
            {
                int newW = (int)(originalH * TARGET_RATIO);
                int offsetX = (originalW - newW) / 2;
                cropArea = new Rectangle(offsetX, 0, newW, originalH);
            }
            else
            {
                int newH = (int)(originalW / TARGET_RATIO);
                int offsetY = (originalH - newH) / 2;
                cropArea = new Rectangle(0, offsetY, originalW, newH);
            }

            try
            {
                if (cropArea.Width > 0 && cropArea.Height > 0)
                {
                    Bitmap croppedBitmap = currentImage.Clone(cropArea, currentImage.PixelFormat);
                    SetNewWorkingImage(croppedBitmap);
                    MessageBox.Show($"Ảnh đã được cắt tự động theo tỷ lệ {desiredW}:{desiredH}. Vui lòng nhấn 'Áp dụng' để xác nhận.", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình cắt tự động: {ex.Message}");
            }
        }

        private void txtCustomWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCustomHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
