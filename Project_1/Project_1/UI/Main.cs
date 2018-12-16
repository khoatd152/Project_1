using Project_1.BL;
using Project_1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1.UI
{
    public partial class Main : Form
    {
        LoginAndGetDataForMain bus;
        SaveFileDialog saveFileDialog1 = null;
        OpenFileDialog file;
        public Main(LoginAndGetDataForMain buss)
        {
            InitializeComponent();
            this.bus = buss;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            cboNameDB.DisplayMember = "name";
            cboNameDB.ValueMember = "name";
            cboNameDB.DataSource = bus.getAllDataBase();
            

            cboTypeScript.Items.Add("Schema Only");
            cboTypeScript.Items.Add("Data Only");
            cboTypeScript.Items.Add("Schema and Data");
            
            cboTypeScript.SelectedIndex = 0;

            cboDBMS.Items.Add("MySQL");
            cboDBMS.Items.Add("Access");
            cboDBMS.SelectedIndex = 0;
            
        }

        private void cboNameDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            bus.changeDB(cboNameDB.SelectedValue.ToString());
            DataTable dt = bus.getAllTable();
            listTable.DataSource = dt;
            listTable.DisplayMember = "TableName";
            listTable.ValueMember = "TableName";
            checkBox1.Checked = false;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < listTable.Items.Count; i++)
                {
                    listTable.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < listTable.Items.Count; i++)
                {
                    listTable.SetItemChecked(i, false);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cboDBMS.SelectedIndex == 0)
            {
                saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "sql files (*.sql)|*.sql";
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = Path.GetFullPath(saveFileDialog1.FileName);
                }
            }

            else
            {
                file = new OpenFileDialog();
                file.Filter = "access files (*.mdb)|*.accdb";
                file.Title = "Select a Access File";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = Path.GetFullPath(file.FileName);
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            List<Mapping> listMap=null;
            try
            {
                ReadMappingFile read = new ReadMappingFile();
                listMap = read.getListMapping();
            }
            catch
            {
                MessageBox.Show("Đọc file mapping thất bại\nVui lòng kiểm tra lại !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (listTable.CheckedItems.Count != 0)
            {
                List<string> listTableChecked = new List<string>();
                foreach (DataRowView item in listTable.CheckedItems)
                {
                    listTableChecked.Add(item.Row[0].ToString());
                }

                if (!txtPath.Text.Equals(""))
                {
                    if (cboDBMS.SelectedIndex == 0)
                    {
                        MySQL my = new MySQL(bus.ConnSQL
                            , txtPath.Text
                            , cboNameDB.SelectedValue.ToString()
                            , listTableChecked, cboTypeScript.SelectedIndex
                            , listMap);
                        if (my.getScript(progressBar1))
                        {

                            MessageBox.Show("Tạo script thành công !", "Thông báo"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            progressBar1.Value = 0;
                        }

                        else
                        {
                            MessageBox.Show("Tạo script thất bại", "Thông báo"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            progressBar1.Value = 0;
                        }
                    }
                    else
                    {
                        MSAccess acc = new MSAccess(bus.ConnSQL
                            , txtPath.Text
                            , cboNameDB.SelectedValue.ToString()
                            , listTableChecked, cboTypeScript.SelectedIndex
                            , listMap);
                        if (acc.getScript(progressBar1))
                        {
                            MessageBox.Show("Tạo script thành công !", "Thông báo"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            progressBar1.Value = 0;
                        }
                        else
                        {
                            MessageBox.Show("Tạo script thất bại", "Thông báo"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            progressBar1.Value = 0;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn nơi lưu", "Thông báo"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Value = 0;
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn bảng", "Thông báo", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                progressBar1.Value = 0;
            }
        }

        private void cboDBMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPath.Text = "";
        }
    }
}
