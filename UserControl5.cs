using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDock
{
    public partial class UserControl5 : UserControl
    {
        private List<DataGridView> _datagridviews = new List<DataGridView>();
        private List<GroupBox> _groupboxes = new List<GroupBox>();

        private Panel _panel { get; set; } = new Panel();

        public UserControl5()
        {
            InitializeComponent();

            // 添加初始的3个组合框
            for (int i = 0; i < 3; i++)
            {
                // 在组合框内添加一个DataGridView控件
                var datagridview = new DataGridView();
                datagridview.Name = $"dgv_{_groupboxes.Count + 1}";
                datagridview.Columns.Add("Fruit", "Fruit");
                datagridview.Columns.Add("Amount", "Amount");
                datagridview.Columns[0].ReadOnly = true;
                datagridview.Rows.Add("Apple", "10");
                datagridview.Rows.Add("Banana", "20");
                datagridview.Rows.Add("Cherry", "30");
                datagridview.Rows.Add("Grape", "40");
                _datagridviews.Add(datagridview);
                AddGroupBox(datagridview);
            }

            // 将 _panel 添加到 UserControl4 中
            Controls.Add(_panel);

            // 设置 _panel 的位置和初始大小
            _panel.Location = new Point(0, 0);
            _panel.Size = new Size(Width, Height - 50);
            _panel.AutoScroll = true;

            MinimumSize = new Size(800, 300);
            // 订阅 UserControl4 的 Resize 事件
            Resize += UserControl4_Resize;

        }

        private void UserControl4_Resize(object sender, EventArgs e)
        {
            // 更新 _panel 的大小
            _panel.Size = new Size(Width, Height - 50);

            // 更新每个 GroupBox 的宽度和位置
            foreach (var groupbox in _groupboxes)
            {
                groupbox.Width = _panel.Width - 20;
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            var datagridview = new DataGridView();            
            datagridview.Columns.Add("Fruit", "Fruit");
            datagridview.Columns.Add("Amount", "Amount");
            datagridview.Columns[0].ReadOnly = true;
            datagridview.Rows.Add("Apple", "10");
            datagridview.Rows.Add("Banana", "20");
            
            AddGroupBox(datagridview);
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            if (_groupboxes.Count > 0)
            {
                // 从UserControl中删除最后一个组合框
                _panel.Controls.Remove(_groupboxes[_groupboxes.Count - 1]);

                // 从集合中删除最后一个组合框
                _groupboxes.RemoveAt(_groupboxes.Count - 1);
            }
        }

        private void AddGroupBox(DataGridView dgv)
        {
            // 设置单击单元格事件
            dgv.CellClick += DataGridView_CellClick;
            // 设置双击单元格事件
            dgv.CellDoubleClick += DataGridView_CellDoubleClick;
            //dgv.ColumnWidthChanged += DataGridView_ColumnWidthChanged;

            dgv.ColumnHeadersVisible = false;
            dgv.Location = new System.Drawing.Point(10, 20);
            //dgv.Size = new System.Drawing.Size(groupbox.Width - 20, 100);
            dgv.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            dgv.Dock = DockStyle.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.ScrollBars = ScrollBars.None;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            int dgvHeight = dgv.Rows.Cast<DataGridViewRow>().Sum(r => r.Height);
            dgv.Height = dgvHeight+6;
            //dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            //dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.CurrentCell = null;
            dgv.ClearSelection();

            

            int nY = 10;
            if (_groupboxes.Count > 0)
            {
                var lstGp = _groupboxes[_groupboxes.Count - 1];
                nY = 10 + lstGp.Location.Y + lstGp.Height;
            }

            // 创建一个新的组合框
            var groupbox = new GroupBox
            {
                Text = $"Group {_groupboxes.Count + 1}",
                Location = new System.Drawing.Point(10, nY),
                Size = new System.Drawing.Size(_panel.Width - 20, dgv.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) +10+ 30)
            };

            //// 在组合框内添加一个DataGridView控件
            //var datagridview = new DataGridView
            //{
            //    Location = new System.Drawing.Point(10, 20),
            //    //Size = new System.Drawing.Size(280, 100),
            //    Size = new System.Drawing.Size(groupbox.Width - 20, 100),
            //    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
            //    AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            //};
            //groupbox.Controls.Add(datagridview);

            dgv.Width = groupbox.Width - 20;

            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //foreach (DataGridViewColumn column in dgv.Columns)
            //{
            //    column.Width = dgv.Width / dgv.Columns.Count;
            //}

            groupbox.Controls.Add(dgv);

            // 添加折叠/展开功能
            var togglebutton = new Button
            {
                Text = "折叠",
                Location = new System.Drawing.Point(groupbox.Width - 80, 0),
                Size = new System.Drawing.Size(70, 20),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            togglebutton.Click += (s, ev) =>
            {
                bool bOpen = true;
                int ngbHeight = groupbox.Height;
                //if (groupbox.Height == 140)
                if (togglebutton.Text == "折叠")
                {                    
                    //dgv.Visible = false;
                    groupbox.Height = groupbox.Height - dgv.Rows.Cast<DataGridViewRow>().Sum(r => r.Height)-10;
                    togglebutton.Text = "展开";
                    bOpen = false;
                }
                else
                {                    
                    //dgv.Visible = true;
                    groupbox.Height = dgv.Rows.Cast<DataGridViewRow>().Sum(r => r.Height)+10 + 30;
                    togglebutton.Text = "折叠";
                }

                // 获取当前组合框在 _groupboxes 中的索引
                int index = _groupboxes.IndexOf(groupbox);

                // 更新下面组合框的位置
                for (int i = index + 1; i < _groupboxes.Count; i++)
                {
                    var gb = _groupboxes[i];
                    if (bOpen)
                    {
                        gb.Location = new Point(gb.Location.X, gb.Location.Y + dgv.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10);
                    }
                    else
                    {
                        gb.Location = new Point(gb.Location.X, gb.Location.Y - dgv.Rows.Cast<DataGridViewRow>().Sum(r => r.Height)-10);
                    }

                }
            };
            groupbox.Controls.Add(togglebutton);

            // 订阅组合框的 SizeChanged 事件，更新 togglebutton 的位置
            groupbox.SizeChanged += (s, e) =>
            {
                togglebutton.Size = new System.Drawing.Size(70, 20);
                togglebutton.Location = new System.Drawing.Point(groupbox.Width - 80, 0);

                //// 找到 GroupBox 控件，现在查找 ToggleButton 控件
                //Button tgb = groupbox.Controls.OfType<Button>().FirstOrDefault();

                //if (tgb != null)
                //{
                //    tgb.Size = new System.Drawing.Size(70, 20);
                //    tgb.Location = new System.Drawing.Point(groupbox.Width - 80, 0);
                //}


            };

            // 将组合框添加到UserControl中
            _panel.Controls.Add(groupbox);

            // 将组合框保存到集合中
            _groupboxes.Add(groupbox);
        }


        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int nRow = e.RowIndex;
                int nColumn = e.ColumnIndex;
                var dgv = sender as DataGridView;

                foreach(var d in _datagridviews)
                {
                    if(d!=null && d.Name != dgv.Name)
                    {
                        d.ClearSelection();
                    }
                    else
                    {
                        d[1, nRow].Selected = true;
                        d.CurrentCell = d[1, nRow];
                        d.BeginEdit(true);
                    }
                }

            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 处理双击单元格事件
        }

        //private void DataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        //{
        //    var dgv = sender as DataGridView;
        //    // 获取调整大小的列
        //    DataGridViewColumn resizedColumn = e.Column;
            
        //    foreach (var d in _datagridviews)
        //    {
        //        if (d != null && d.Name != dgv.Name)
        //        {
                    
        //            d.Columns[resizedColumn.Index].Width = resizedColumn.Width;
        //        }
        //    }


        //}

    }
}
