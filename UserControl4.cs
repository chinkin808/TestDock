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
    public partial class UserControl4 : UserControl
    {
        private List<GroupBox> _groupboxes = new List<GroupBox>();

        private Panel _panel { get; set; } = new Panel();

        public UserControl4()
        {
            InitializeComponent();

            // 添加初始的3个组合框
            for (int i = 0; i < 3; i++)
            {
                AddGroupBox();
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
            AddGroupBox();
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

        private void AddGroupBox()
        {
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
                Size = new System.Drawing.Size(_panel.Width - 20, 140)
            };

            // 在组合框内添加一个DataGridView控件
            var datagridview = new DataGridView
            {
                Location = new System.Drawing.Point(10, 20),
                //Size = new System.Drawing.Size(280, 100),
                Size = new System.Drawing.Size(groupbox.Width - 20, 100),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                //AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            };
            groupbox.Controls.Add(datagridview);

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
                int nHeight = groupbox.Height;
                if (groupbox.Height == 140)
                //if (togglebutton.Text == "折叠")
                {
                    groupbox.Height = 40;
                    togglebutton.Text = "展开";
                    bOpen = false;
                }
                else
                {
                    groupbox.Height = 140;
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
                        gb.Location = new Point(gb.Location.X, gb.Location.Y + 100);
                    }
                    else
                    {
                        gb.Location = new Point(gb.Location.X, gb.Location.Y - nHeight + 40);
                    }
                    
                }
            };
            groupbox.Controls.Add(togglebutton);

            // 订阅组合框的 SizeChanged 事件，更新 togglebutton 的位置
            groupbox.SizeChanged += (s, e) =>
            {
                togglebutton.Size = new System.Drawing.Size(70, 20);
                togglebutton.Location = new System.Drawing.Point(groupbox.Width - 80, 0);
                
            };

            // 将组合框添加到UserControl中
            _panel.Controls.Add(groupbox);

            // 将组合框保存到集合中
            _groupboxes.Add(groupbox);
        }




    }
}
