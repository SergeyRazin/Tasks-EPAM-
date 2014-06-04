using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient.App_class
{
    public class CaptchaManager
    {
        private HttpContext _context;

        private List<RadioButton> _listShowRadioButtons = new List<RadioButton>();

        //конструктор
        public CaptchaManager(HttpContext context0)
        {
            this._context = context0;
        }

        //метод показать или скрыть капчу
        public void ShowCaptcha(Panel panel0, bool visible0)
        {
            if (visible0 == true)
                panel0.Visible = true;
            else
                panel0.Visible = false;

        }

        //метод указывает нужно выполнять проверку капчи или нет
        public bool CheckCaptcha(bool check0)
        {
            return check0;
        }

        //метод выполняет проверку правильности ввода капчи пользователем
        public bool CheckCaptchaUser(string enterValue0)
        {
            if (_context.Session["scap"].ToString() == enterValue0)
                return true;
            else
                return false;
        }

        //метод добавить радиокнопки при выборе которых отображается капча
        public void AddShowRadioButton(RadioButton radio0)
        {
            _listShowRadioButtons.Add(radio0);
        }

        //метод отобразить нужные радиокнопки
        public bool ShowCaptchaOrNot()
        {
            foreach (var i in _listShowRadioButtons)
            {
                if (i.Checked)
                    return true;
            }
            return false;
        }



    }
}