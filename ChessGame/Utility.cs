using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public static class Utility
    {
        static public bool IsOpeningForm(string formname)
        {
            foreach (Form f in Application.OpenForms)
                if (f.Name == formname)
                    return true;
            return false;
        }

        // Dùng Dictionary để lưu trạng thái của các form thăng cấp
        private static Dictionary<string, bool> openingForms = new Dictionary<string, bool>();

        // Kiểm tra xem form thăng cấp đã được mở hay chưa dựa trên tên form
        public static bool IsOpeningForm2(string formName)
        {
            if (openingForms.ContainsKey(formName))
            {
                return openingForms[formName];
            }
            return false;
        }

        // Đặt trạng thái của form thăng cấp
        public static void SetOpeningForm(string formName, bool isOpen)
        {
            if (openingForms.ContainsKey(formName))
            {
                openingForms[formName] = isOpen;
            }
            else
            {
                openingForms.Add(formName, isOpen);
            }
        }
    }

}
