using Microsoft.Win32;
using PCAD_AX_X;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teigha.ApplicationServices;
using Teigha.Colors;
using Teigha.DatabaseServices;
using Teigha.EditorInput;
using Teigha.Geometry;
using Teigha.Internal;
using Teigha.Runtime;
using Teigha.Windows;
using AresApp = Teigha.ApplicationServices.Application;
using AresColor = Teigha.Colors.Color;

namespace TestDock
{
    
    public class Class1
    {
        [CommandMethod("TestPaletteSet")]
        
        public static void TestPaletteSet()
        {
            var doc = AresApp.DocumentManager.MdiActiveDocument;//ドキュメント
            var db = doc.Database;//データベース
            var ed = doc.Editor;//エディタ

            try
            {
                //PaletteSet paletteSet = new PaletteSet("文字スタイル");
                //paletteSet.Style = PaletteSetStyles.ShowPropertiesMenu |
                //                PaletteSetStyles.ShowAutoHideButton |
                //                PaletteSetStyles.ShowCloseButton |
                //                PaletteSetStyles.Snappable;

                //paletteSet.MinimumSize = new System.Drawing.Size(300, 200);
                //paletteSet.Visible = true;

                //if (paletteSet.Count == 0)
                //{
                //    var userControl = new UserControl1();
                //    paletteSet.Add("文字スタイル", userControl);
                //}

                //paletteSet.Dock = DockSides.None;
                //paletteSet.Size = new System.Drawing.Size(300, 200);



                //int result = Add(1, 2);
                //AresApp.ShowAlertDialog($"{result}"); // Output: 3

                //int ans = MyFuncA(1);
                //AresApp.ShowAlertDialog($"C# : ans = {ans}");

                //int a = 77;
                //AresApp.ShowAlertDialog($"C# : a = {a} -- before");
                //MyFuncB(ref a);
                //AresApp.ShowAlertDialog($"C# : a = {a} -- after");

                var st = new SampleStruct()
                {
                    index = 4,
                    name = "構造体サンプル",
                    data = new int[50],
                };
                st.data[0] = 10;
                st.data[1] = 20;
                st.data[2] = 30;
                MyFuncD(st);

                ///////////////////////////////////////////

                var pst = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SampleStruct)));
                try
                {
                    MyFuncE(pst);

                    var st_rtn = (SampleStruct)Marshal.PtrToStructure(pst, typeof(SampleStruct));
                    AresApp.ShowAlertDialog($"C# : index = {st_rtn.index}");
                    AresApp.ShowAlertDialog($"C# : name = {st_rtn.name}");
                    AresApp.ShowAlertDialog($"C# : data = [{st_rtn.data[0]},{st_rtn.data[1]},{st_rtn.data[2]}]");
                }
                catch (System.Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
                finally
                {
                    //必ずメモリ解放
                    Marshal.FreeHGlobal(pst);
                }



            }
            catch (System.Exception e)
            {
                AresApp.ShowAlertDialog(e.Message);
                return;
            }
        }

        //[DllImport("mylibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int Add(int a, int b);

        //[DllImport("B:\\vs2019\\TestDock-master\\TestDock-master\\InOutLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        //private static extern int MyFuncA(int a);

        ////C#側
        //[DllImport("B:\\vs2019\\TestDock-master\\TestDock-master\\InOutLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        //private static extern void MyFuncB(ref int a); //refで参照渡し

        [DllImport("B:\\vs2019\\TestDock-master\\TestDock-master\\TestCFxMfc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int a, int b);


        [DllImport("B:\\vs2019\\TestDock-master\\TestDock-master\\TestCFxMfc.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int MyFuncA(int a);

        //C#側
        [DllImport("B:\\vs2019\\TestDock-master\\TestDock-master\\TestCFxMfc.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void MyFuncB(ref int a); //refで参照渡し

        [DllImport("B:\\vs2019\\TestDock-master\\TestDock-master\\TestCFxMfc.dll")]
        private static extern void MyFuncD(SampleStruct st);

        [DllImport("B:\\vs2019\\TestDock-master\\TestDock-master\\TestCFxMfc.dll")]
        //SampleStruct*に対してIntPtrを渡す
        private static extern void MyFuncE(IntPtr pst);




        [StructLayout(LayoutKind.Sequential)]
        private struct SampleStruct
        {
            public int index;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)] //固定長文字列配列
            public string name;

            //固定長配列
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)] //固定長配列
            public int[] data;
        }





        [CommandMethod("TestPaletteSet2")]

        public static void TestPaletteSet2()
        {
            var doc = AresApp.DocumentManager.MdiActiveDocument;//ドキュメント
            var db = doc.Database;//データベース
            var ed = doc.Editor;//エディタ

            try
            {
                PaletteSet paletteSet = new PaletteSet("文字スタイル");
                paletteSet.Style = PaletteSetStyles.ShowPropertiesMenu |
                                PaletteSetStyles.ShowAutoHideButton |
                                PaletteSetStyles.ShowCloseButton |
                                PaletteSetStyles.Snappable;

                paletteSet.MinimumSize = new System.Drawing.Size(300, 200);
                paletteSet.Visible = true;

                if (paletteSet.Count == 0)
                {
                    var userControl = new UserControl5();
                    paletteSet.Add("文字スタイル", userControl);
                }

                paletteSet.Dock = DockSides.None;
                paletteSet.Size = new System.Drawing.Size(300, 200);

            }
            catch (System.Exception e)
            {
                AresApp.ShowAlertDialog(e.Message);
                return;
            }
        }


    }
}
