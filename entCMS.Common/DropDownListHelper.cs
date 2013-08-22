using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;

namespace entCMS.Common
{
    public class DropDownListHelper
    {
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DDL"></param>
        /// <param name="dt"></param>
        /// <param name="ValueField"></param>
        /// <param name="TextField"></param>
        /// <param name="ParentField"></param>
        /// <param name="ChildField"></param>
        /// <param name="SortField"></param>
        /// <param name="ParentValue"></param>
        /// <param name="LayNum"></param>
        private void DDLAddItems(ref DropDownList DDL, DataTable dt, string ValueField, string TextField, string ParentField, string ChildField, string SortField, string ParentValue, int LayNum, bool bLastNode)
        {
            DataRow[] rowArray;
            int layNum = LayNum;
            layNum++;
            if ((SortField != "") && (SortField != null))
            {
                rowArray = dt.Select(ParentField + "='" + ParentValue + "'", SortField);
            }
            else
            {
                rowArray = dt.Select(ParentField + "='" + ParentValue + "'");
            }
            for (int i = 0; i < rowArray.Length; i++)
            {
                string str = rowArray[i][ValueField].ToString();
                string text = rowArray[i][TextField].ToString();
                string parentValue = rowArray[i][ChildField].ToString();
                
                if (i < rowArray.Length - 1)
                {
                    text = "├" + text;//┣
                }
                else
                {
                    text = "└" + text;//　┗
                }
                int n = LayNum;
                if (bLastNode)
                {
                    text = "　" + text;//　│
                    n--;
                }
                for (int j = 0; j < n; j++)
                {
                    text = "│" + text;
                }
                DDL.Items.Add(new ListItem(text, str));
                DDLAddItems(ref DDL, dt, ValueField, TextField, ParentField, ChildField, SortField, parentValue, layNum, (i == rowArray.Length - 1));
            }
        }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DDL"></param>
        /// <param name="dt"></param>
        /// <param name="ValueField"></param>
        /// <param name="TextField"></param>
        /// <param name="ParentField"></param>
        /// <param name="ChildField"></param>
        /// <param name="SortField"></param>
        /// <param name="ParentValue"></param>
        /// <param name="parentStr"></param>
        private static void DDLAddItems(ref DropDownList DDL, DataTable dt, string ValueField, string TextField, string ParentField, string ChildField, string SortField, string ParentValue, string parentStr)
        {
            DataRow[] rowArray;
            string where = string.Empty;
            if (!string.IsNullOrEmpty(ParentValue))
                where = ParentField + "='" + ParentValue + "'";
            else
                where = ParentField + " ='' or " + ParentField + " is null";

            if ((SortField != "") && (SortField != null))
            {
                rowArray = dt.Select(where, SortField);
            }
            else
            {
                rowArray = dt.Select(where);
            }
            for (int i = 0; i < rowArray.Length; i++)
            {
                string str = rowArray[i][ValueField].ToString();
                string text = rowArray[i][TextField].ToString();
                string parentValue = rowArray[i][ChildField].ToString();
                string path = string.Empty;
                string pp = parentStr;
                if (i < rowArray.Length - 1)
                {
                    path = "├";//┣
                    pp += "│";
                }
                else
                {
                    path = "└";//　┗
                    pp += "　";
                }
                DDL.Items.Add(new ListItem(parentStr + path + text, str));
                DDLAddItems(ref DDL, dt, ValueField, TextField, ParentField, ChildField, SortField, parentValue, pp);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DDL"></param>
        /// <param name="dt"></param>
        /// <param name="ValueField"></param>
        /// <param name="TextField"></param>
        /// <param name="ParentField"></param>
        /// <param name="ChildField"></param>
        /// <param name="SortField"></param>
        /// <param name="ParentValue"></param>
        /// <param name="parentStr"></param>
        /// <param name="CurrentValue"></param>
        private static void DDLAddItems(ref DropDownList DDL, DataTable dt, string ValueField, string TextField, string ParentField, string ChildField, string SortField, string ParentValue, string parentStr, string CurrentValue)
        {
            DataRow[] rowArray;
            string where = string.Empty;
            if (!string.IsNullOrEmpty(ParentValue))
                where = ParentField + "='" + ParentValue + "'";
            else
                where = ParentField + " ='' or " + ParentField + " is null";

            if ((SortField != "") && (SortField != null))
            {
                rowArray = dt.Select(where, SortField);
            }
            else
            {
                rowArray = dt.Select(where);
            }
            for (int i = 0; i < rowArray.Length; i++)
            {
                string str = rowArray[i][ValueField].ToString();
                string str1 = rowArray[i][ParentField].ToString();
                string text = rowArray[i][TextField].ToString();
                string parentValue = rowArray[i][ChildField].ToString();
                string path = string.Empty;
                string pp = parentStr;
                if (i < rowArray.Length - 1)
                {
                    path = "├";//┣
                    pp += "│";
                }
                else
                {
                    path = "└";//　┗
                    pp += "　";
                }
                ListItem itm = new ListItem(parentStr + path + text, str);
                if (str == CurrentValue || str1 == CurrentValue)
                {
                    //itm.Attributes.Add("disabled", "true");
                    itm.Enabled = false;
                }
                DDL.Items.Add(itm);
                DDLAddItems(ref DDL, dt, ValueField, TextField, ParentField, ChildField, SortField, parentValue, pp, CurrentValue);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DDL"></param>
        /// <param name="dt"></param>
        /// <param name="ValueField"></param>
        /// <param name="TextField"></param>
        public static void DDLDataBind(DropDownList DDL, DataTable dt, string ValueField, string TextField)
        {
            DDL.Items.Clear();
            DDL.DataSource = dt;
            DDL.DataTextField = TextField;
            DDL.DataValueField = ValueField;
            DDL.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DDL"></param>
        /// <param name="dt"></param>
        /// <param name="ValueField"></param>
        /// <param name="TextField"></param>
        /// <param name="ValueCaption"></param>
        /// <param name="TextCaption"></param>
        public static void DDLDataBind(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ValueCaption, string TextCaption)
        {
            DDLDataBind(DDL, dt, ValueField, TextField);
            DDLItemsAdd(ref DDL, ValueCaption, TextCaption, 0);
        }

        public static void DDLDataBindDefaultIndex(DropDownList DDL, DataTable dt, string ValueField, string TextField, int DefaultSelectIndex)
        {
            DDLDataBind(DDL, dt, ValueField, TextField);
            DDLDefaultByIndex(DDL, DefaultSelectIndex);
        }

        public static void DDLDataBindDefaultIndex(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ValueCaption, string TextCaption, int DefaultSelectIndex)
        {
            DDLDataBind(DDL, dt, ValueField, TextField, ValueCaption, TextCaption);
            DDLDefaultByIndex(DDL, DefaultSelectIndex);
        }

        public static void DDLDataBindDefaultText(DropDownList DDL, DataTable dt, string ValueField, string TextField, string DefaultSelectText)
        {
            DDLDataBind(DDL, dt, ValueField, TextField);
            DDLDefaultByText(DDL, DefaultSelectText);
        }

        public static void DDLDataBindDefaultText(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ValueCaption, string TextCaption, string DefaultSelectText)
        {
            DDLDataBind(DDL, dt, ValueField, TextField, ValueCaption, TextCaption);
            DDLDefaultByText(DDL, DefaultSelectText);
        }

        public static void DDLDataBindDefaultValue(DropDownList DDL, DataTable dt, string ValueField, string TextField, string DefaultSelectValue)
        {
            DDLDataBind(DDL, dt, ValueField, TextField);
            DDLDefaultByValue(DDL, DefaultSelectValue);
        }

        public static void DDLDataBindDefaultValue(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ValueCaption, string TextCaption, string DefaultSelectValue)
        {
            DDLDataBind(DDL, dt, ValueField, TextField, ValueCaption, TextCaption);
            DDLDefaultByValue(DDL, DefaultSelectValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DDL"></param>
        /// <param name="dt"></param>
        /// <param name="ValueField"></param>
        /// <param name="TextField"></param>
        /// <param name="ParentField"></param>
        /// <param name="ChildField"></param>
        /// <param name="SortField"></param>
        /// <param name="ParentValue"></param>
        public static void DDLDataBindTreeView(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ParentField, string ChildField, string SortField, string ParentValue)
        {
            DDL.Items.Clear();
            //DDLAddItems(ref DDL, dt, ValueField, TextField, ParentField, ChildField, SortField, ParentValue, 0, false);
            DDLAddItems(ref DDL, dt, ValueField, TextField, ParentField, ChildField, SortField, ParentValue, "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DDL"></param>
        /// <param name="dt"></param>
        /// <param name="ValueField"></param>
        /// <param name="TextField"></param>
        /// <param name="ParentField"></param>
        /// <param name="ChildField"></param>
        /// <param name="SortField"></param>
        /// <param name="ParentValue"></param>
        /// <param name="CurrentValue"></param>
        public static void DDLDataBindTreeView(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ParentField, string ChildField, string SortField, string ParentValue, string CurrentValue)
        {
            DDL.Items.Clear();
            //DDLAddItems(ref DDL, dt, ValueField, TextField, ParentField, ChildField, SortField, ParentValue, 0, false);
            DDLAddItems(ref DDL, dt, ValueField, TextField, ParentField, ChildField, SortField, ParentValue, "", CurrentValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DDL"></param>
        /// <param name="dt"></param>
        /// <param name="ValueField"></param>
        /// <param name="TextField"></param>
        /// <param name="ValueCaption"></param>
        /// <param name="TextCaption"></param>
        /// <param name="ParentField"></param>
        /// <param name="ChildField"></param>
        /// <param name="SortField"></param>
        /// <param name="ParentValue"></param>
        public static void DDLDataBindTreeView(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ValueCaption, string TextCaption, string ParentField, string ChildField, string SortField, string ParentValue)
        {
            DDLDataBindTreeView(DDL, dt, ValueField, TextField, ParentField, ChildField, SortField, ParentValue);
            DDLItemsAdd(ref DDL, ValueCaption, TextCaption, 0);
        }

        public static void DDLDataBindTreeView(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ValueCaption, string TextCaption, string ParentField, string ChildField, string SortField, string ParentValue, string CurrentValue)
        {
            DDLDataBindTreeView(DDL, dt, ValueField, TextField, ParentField, ChildField, SortField, ParentValue, CurrentValue);
            DDLItemsAdd(ref DDL, ValueCaption, TextCaption, 0);
        }

        public static void DDLDataBindTreeViewDefaultIndex(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ParentField, string ChildField, string SortField, string ParentValue, int DefaultSelectIndex)
        {
            DDLDataBindTreeView(DDL, dt, ValueField, TextField, ParentField, ChildField, SortField, ParentValue);
            DDLDefaultByIndex(DDL, DefaultSelectIndex);
        }

        public static void DDLDataBindTreeViewDefaultIndex(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ValueCaption, string TextCaption, string ParentField, string ChildField, string SortField, string ParentValue, int DefaultSelectIndex)
        {
            DDLDataBindTreeView(DDL, dt, ValueField, TextField, ValueCaption, TextCaption, ParentField, ChildField, SortField, ParentValue);
            DDLDefaultByIndex(DDL, DefaultSelectIndex);
        }

        public static void DDLDataBindTreeViewDefaultText(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ParentField, string ChildField, string SortField, string ParentValue, string DefaultSelectText)
        {
            DDLDataBindTreeView(DDL, dt, ValueField, TextField, ParentField, ChildField, SortField, ParentValue);
            DDLDefaultByText(DDL, DefaultSelectText);
        }

        public static void DDLDataBindTreeViewDefaultText(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ValueCaption, string TextCaption, string ParentField, string ChildField, string SortField, string ParentValue, string DefaultSelectText)
        {
            DDLDataBindTreeView(DDL, dt, ValueField, TextField, ValueCaption, TextCaption, ParentField, ChildField, SortField, ParentValue);
            DDLDefaultByText(DDL, DefaultSelectText);
        }

        public static void DDLDataBindTreeViewDefaultValue(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ParentField, string ChildField, string SortField, string ParentValue, string DefaultSelectValue)
        {
            DDLDataBindTreeView(DDL, dt, ValueField, TextField, ParentField, ChildField, SortField, ParentValue);
            DDLDefaultByValue(DDL, DefaultSelectValue);
        }

        public static void DDLDataBindTreeViewDefaultValue(DropDownList DDL, DataTable dt, string ValueField, string TextField, string ValueCaption, string TextCaption, string ParentField, string ChildField, string SortField, string ParentValue, string DefaultSelectValue)
        {
            DDLDataBindTreeView(DDL, dt, ValueField, TextField, ValueCaption, TextCaption, ParentField, ChildField, SortField, ParentValue);
            DDLDefaultByValue(DDL, DefaultSelectValue);
        }

        private static void DDLDefaultByIndex(DropDownList DDL, int DefaultSelectIndex)
        {
            if ((DefaultSelectIndex >= DDL.Items.Count) || (DefaultSelectIndex < 0))
            {
                DefaultSelectIndex = -1;
            }
            else
            {
                DDL.SelectedIndex = DefaultSelectIndex;
            }
        }

        private static void DDLDefaultByText(DropDownList DDL, string DefaultSelectText)
        {
            DDL.SelectedIndex = DDL.Items.IndexOf(DDL.Items.FindByText(DefaultSelectText));
        }

        private static void DDLDefaultByValue(DropDownList DDL, string DefaultSelectValue)
        {
            DDL.SelectedIndex = DDL.Items.IndexOf(DDL.Items.FindByValue(DefaultSelectValue));
        }

        public static void DDLItemsAdd(ref DropDownList DDL, string ValueCaption, string TextCaption, int Index)
        {
            if (Index < 0)
            {
                Index = 0;
            }
            if ((Index >= DDL.Items.Count) && (Index != 0))
            {
                Index = DDL.Items.Count - 1;
            }
            DDL.Items.Insert(Index, new ListItem(TextCaption, ValueCaption));
        }
    }
}
