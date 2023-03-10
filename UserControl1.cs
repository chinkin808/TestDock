using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teigha.DatabaseServices;
using AresApp = Teigha.ApplicationServices.Application;

namespace TestDock
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            var doc = AresApp.DocumentManager.MdiActiveDocument;//ドキュメント
            var db = doc.Database;//データベース
            var ed = doc.Editor;//エディタ

            var docLock = doc.LockDocument();
            using (var tr = doc.TransactionManager.StartTransaction())
            {
                var tbl_TextStyle = tr.GetObject(db.TextStyleTableId, OpenMode.ForWrite) as TextStyleTable;
                TextStyleTableRecord rec_TextStyel = null;
                if (!tbl_TextStyle.Has(txt_StyleName.Text))
                {
                    rec_TextStyel = new TextStyleTableRecord();
                    rec_TextStyel.Name = txt_StyleName.Text;
                    rec_TextStyel.FileName = "romans.shx";
                    rec_TextStyel.BigFontFileName = "extfont2.shx";
                    tbl_TextStyle.Add(rec_TextStyel);
                    tr.AddNewlyCreatedDBObject(rec_TextStyel, true);
                    tr.Commit();
                }
                else
                {
                    MessageBox.Show("既に文字スタイルが存在しています");
                }
            }

            docLock.Dispose();
        }

        private void dgv_PropData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("クリックされました。");
        }

        private void dgv_PropData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("ダブルクリッククリックされました。");
        }
    }
}
