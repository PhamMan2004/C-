using Lab04_01.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_01
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

    private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB context = new StudentContextDB();
                List<FACULTY> listFacultys = context.FACULTY.ToList();
                List<STUDENT> listStudent = context.STUDENT.ToList();
                FillFacultyCombobox(listFacultys);
                BindGrid(listStudent);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void FillFacultyCombobox(List<FACULTY> listFacultys)
        {
            this.cmbFaculty.DataSource = listFacultys;
            this.cmbFaculty.DisplayMember = "FacultyName"; 
            this.cmbFaculty.ValueMember = "FacultyId";
        }

        private void BindGrid(List<STUDENT> listStudent)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                dgvStudent.Rows[index].Cells[2].Value = item.FACULTY.FacultyName;
                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
       string.IsNullOrWhiteSpace(txtHoTen.Text) ||
       string.IsNullOrWhiteSpace(txtDiemTb.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin: Mã SV, Họ tên và Điểm TB!");
                return;
            }

            try
            {
                using (StudentContextDB context = new StudentContextDB())
                {
                    STUDENT newStudent = new STUDENT
                    {
                        StudentID = txtMaSV.Text,
                        FullName = txtHoTen.Text,
                        FacultyID = (int)cmbFaculty.SelectedValue,
                        AverageScore = float.Parse(txtDiemTb.Text)
                    };

                    context.STUDENT.Add(newStudent);
                    context.SaveChanges();
                    MessageBox.Show("Thêm sinh viên thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message);
            } 
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtDiemTb.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin: Mã SV, Họ tên và Điểm TB!");
                return;
            }

            try
            {
                using (StudentContextDB context = new StudentContextDB())
                {
                    string studentID = txtMaSV.Text;
                    var studentToUpdate = context.STUDENT.FirstOrDefault(s => s.StudentID == studentID);

                    if (studentToUpdate != null)
                    {
                        studentToUpdate.FullName = txtHoTen.Text;
                        studentToUpdate.FacultyID = (int)cmbFaculty.SelectedValue;
                        studentToUpdate.AverageScore = float.Parse(txtDiemTb.Text);

                        context.SaveChanges();
                        MessageBox.Show("Sửa thông tin sinh viên thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên để sửa!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa thông tin sinh viên: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (StudentContextDB context = new StudentContextDB())
                {
                    string studentID = txtMaSV.Text;
                    var studentToDelete = context.STUDENT.FirstOrDefault(s => s.StudentID == studentID);

                    if (studentToDelete != null)
                    {
                        context.STUDENT.Remove(studentToDelete);
                        context.SaveChanges();
                        MessageBox.Show("Xóa sinh viên thành công!");
                        LoadData(); 
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên để xóa!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message);
            }
        }

        private void LoadData()
        {
            using (StudentContextDB context = new StudentContextDB())
            {
                List<FACULTY> listFacultys = context.FACULTY.ToList();
                List<STUDENT> listStudent = context.STUDENT.ToList();
                FillFacultyCombobox(listFacultys);
                BindGrid(listStudent);
            }
        }
       
    }
}
