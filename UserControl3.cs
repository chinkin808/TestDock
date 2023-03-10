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
    public partial class UserControl3 : UserControl
    {
        private List<GroupBox> _groupboxes = new List<GroupBox>();

        public UserControl3()
        {
            InitializeComponent();

            // 创建三个组合框，并添加到UserControl中
            for (int i = 0; i < 3; i++)
            {
                var groupbox = new GroupBox
                {
                    Text = $"Group {i + 1}",
                    Location = new System.Drawing.Point(10, 10 + i * 150),
                    Size = new System.Drawing.Size(300, 140),
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };

                var datagridview = new DataGridView
                {
                    Location = new System.Drawing.Point(10, 20),
                    Size = new System.Drawing.Size(280, 100),
                };
                groupbox.Controls.Add(datagridview);

                var togglebutton = new Button
                {
                    Text = "折叠",
                    Location = new System.Drawing.Point(220, 120),
                    Size = new System.Drawing.Size(70, 20),
                };
                togglebutton.Click += (s, ev) =>
                {
                    if (datagridview.Visible)
                    {
                        datagridview.Visible = false;
                        togglebutton.Text = "展开";
                    }
                    else
                    {
                        datagridview.Visible = true;
                        togglebutton.Text = "折叠";
                    }
                };
                groupbox.Controls.Add(togglebutton);

                this.Controls.Add(groupbox);
                _groupboxes.Add(groupbox);
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            // 创建一个新的组合框
            var groupbox = new GroupBox
            {
                Text = $"Group {_groupboxes.Count + 1}",
                Location = new System.Drawing.Point(10, 10 + _groupboxes.Count * 150),
                Size = new System.Drawing.Size(300, 140),
            };

            // 在组合框内添加一个DataGridView控件
            var datagridview = new DataGridView
            {
                Location = new System.Drawing.Point(10, 20),
                Size = new System.Drawing.Size(280, 100),
            };
            groupbox.Controls.Add(datagridview);

            // 添加折叠/展开功能
            var togglebutton = new Button
            {
                Text = "折叠",
                Location = new System.Drawing.Point(220, 120),
                Size = new System.Drawing.Size(70, 20),
            };
            togglebutton.Click += (s, ev) =>
            {
                if (datagridview.Visible)
                {
                    datagridview.Visible = false;
                    togglebutton.Text = "展开";
                }
                else
                {
                    datagridview.Visible = true;
                    togglebutton.Text = "折叠";
                }
            };
            groupbox.Controls.Add(togglebutton);

            // 将组合框添加到UserControl中
            this.Controls.Add(groupbox);

            // 将组合框保存到集合中
            _groupboxes.Add(groupbox);
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            if (_groupboxes.Count > 0)
            {
                // 从UserControl中删除最后一个组合框
                this.Controls.Remove(_groupboxes[_groupboxes.Count - 1]);

                // 从集合中删除最后一个组合框
                _groupboxes.RemoveAt(_groupboxes.Count - 1);
            }
        }
    }
}
