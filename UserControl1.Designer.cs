
namespace TestDock
{
    partial class UserControl1
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_StyleName = new System.Windows.Forms.Label();
            this.txt_StyleName = new System.Windows.Forms.TextBox();
            this.btn_Create = new System.Windows.Forms.Button();
            this.dgv_PropData = new System.Windows.Forms.DataGridView();
            this.col_PropName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PropValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PropData)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_StyleName
            // 
            this.lbl_StyleName.AutoSize = true;
            this.lbl_StyleName.Location = new System.Drawing.Point(13, 276);
            this.lbl_StyleName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_StyleName.Name = "lbl_StyleName";
            this.lbl_StyleName.Size = new System.Drawing.Size(130, 24);
            this.lbl_StyleName.TabIndex = 5;
            this.lbl_StyleName.Text = "スタイル名";
            // 
            // txt_StyleName
            // 
            this.txt_StyleName.Location = new System.Drawing.Point(197, 273);
            this.txt_StyleName.Margin = new System.Windows.Forms.Padding(6);
            this.txt_StyleName.Name = "txt_StyleName";
            this.txt_StyleName.Size = new System.Drawing.Size(288, 35);
            this.txt_StyleName.TabIndex = 4;
            // 
            // btn_Create
            // 
            this.btn_Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Create.Location = new System.Drawing.Point(406, 330);
            this.btn_Create.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(84, 38);
            this.btn_Create.TabIndex = 3;
            this.btn_Create.Text = "作成";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // dgv_PropData
            // 
            this.dgv_PropData.AllowUserToAddRows = false;
            this.dgv_PropData.AllowUserToDeleteRows = false;
            this.dgv_PropData.AllowUserToResizeRows = false;
            this.dgv_PropData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_PropData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_PropData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_PropData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PropData.ColumnHeadersVisible = false;
            this.dgv_PropData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_PropName,
            this.col_PropValue});
            this.dgv_PropData.Location = new System.Drawing.Point(31, 28);
            this.dgv_PropData.Name = "dgv_PropData";
            this.dgv_PropData.RowHeadersVisible = false;
            this.dgv_PropData.RowTemplate.Height = 37;
            this.dgv_PropData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_PropData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PropData.Size = new System.Drawing.Size(454, 223);
            this.dgv_PropData.TabIndex = 6;
            this.dgv_PropData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PropData_CellContentClick);
            this.dgv_PropData.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PropData_CellContentDoubleClick);
            // 
            // col_PropName
            // 
            this.col_PropName.DataPropertyName = "col_PropName";
            this.col_PropName.HeaderText = "プロパティ名";
            this.col_PropName.Name = "col_PropName";
            this.col_PropName.ReadOnly = true;
            this.col_PropName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_PropName.Width = 5;
            // 
            // col_PropValue
            // 
            this.col_PropValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_PropValue.DataPropertyName = "col_PropValue";
            this.col_PropValue.HeaderText = "プロパティ値";
            this.col_PropValue.Name = "col_PropValue";
            this.col_PropValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_PropData);
            this.Controls.Add(this.lbl_StyleName);
            this.Controls.Add(this.txt_StyleName);
            this.Controls.Add(this.btn_Create);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(524, 398);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PropData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_StyleName;
        private System.Windows.Forms.TextBox txt_StyleName;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.DataGridView dgv_PropData;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PropName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PropValue;
    }
}
