using System;
using System.Windows.Forms;

namespace bai1_may_tinh_cuoc_dich_vu_giam_gia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Sự kiện Click cho nút "Tính tiền"
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            // 1. Validate Đơn giá
            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá hợp lệ (phải là số dương)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus(); // Đưa con trỏ về ô bị lỗi
                return; // Dừng thực thi
            }

            // 2. Validate Số lượng khách
            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong < 1)
            {
                MessageBox.Show("Vui lòng nhập số lượng khách hợp lệ (số nguyên lớn hơn 0)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            // 3. Validate Giảm giá (Cho phép trống, nếu trống tính là 0)
            decimal giamGia = 0;
            if (!string.IsNullOrWhiteSpace(txtGiamGia.Text))
            {
                if (!decimal.TryParse(txtGiamGia.Text, out giamGia) || giamGia < 0 || giamGia > 100)
                {
                    MessageBox.Show("Phần trăm giảm giá phải là số từ 0 đến 100!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiamGia.Focus();
                    return;
                }
            }

            // 4. Tính toán tổng tiền
            // Công thức: (Đơn giá × Số lượng) × (100 - % Giảm) / 100
            decimal tongTien = (donGia * soLuong) * ((100 - giamGia) / 100);

            // 5. Hiển thị kết quả (Format định dạng tiền tệ)
            lblTongTien.Text = $"Tổng tiền thanh toán: {tongTien:N0} VNĐ";
        }

        // Sự kiện Click cho nút "Làm mới"
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu các ô nhập
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Text = "0";

            // Reset Label
            lblTongTien.Text = "Tổng tiền thanh toán: 0 VNĐ";

            // Đưa con trỏ chuột về ô Đơn giá để sẵn sàng nhập mới
            txtDonGia.Focus();
        }
    }
}