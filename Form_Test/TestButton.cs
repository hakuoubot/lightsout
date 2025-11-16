using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Form_Test
{
    // Buttonクラスを継承した
    // TestButtonクラスを作成してください。
    public class TestButton : Button
    {

        /// <summary>
        ///onの時の色
        ///</summary>
        private Color _onColor = Color.LightBlue;

        /// <summary>
        /// offの時の色
        /// </summary>
        private Color _offColor = Color.DarkBlue;

        ///<summary>現在

        ///</summary>
        private bool _enable;

        ///<summary>
        ///Form1の参照</summary>
        private Form1 _form1;

        ///<summary>横位置</summary>
        private int _x;
        ///<summary>縦位置</summary>
        private int _y;

        /// <summary>
        /// onとoffの色
        /// </summary>
        public void SetEnable(bool on)
        {
            _enable = on;
            if (on)
            {
                BackColor = _onColor;
            }
            else 
            {
                BackColor = _offColor;
            }

            
           
        }

        public bool IsEnable()
        {
            return _enable;
        }

        public void Toggle()
        {
            SetEnable(!_enable);
        }





        public TestButton(Form1 form1, int x, int y, Point position, Size size, string test)
        {  //Form1の参照を保管
            _form1 = form1;
            //横位置を保管
            _x = x;
            //縦位置を保管
            _y = y;
            //ボタンの位置を設定
            Location = position;
            

            //
            Size = size;

            Text = test;

            SetEnable(true);

            Click += ClickEvent;

        }

        private void ClickEvent(object sender, EventArgs e)
        {
            _form1.GetTestButton(_x, _y)?.Toggle();
            _form1.GetTestButton(_x + 1, _y)?.Toggle();
            _form1.GetTestButton(_x - 1, _y)?.Toggle();
            _form1.GetTestButton(_x, _y + 1)?.Toggle();
            _form1.GetTestButton(_x, _y - 1)?.Toggle();

            for (int i = 0; i < _toggleData.Length; i++)
            {
               /* var date = _toggleData[i];
                var button = _form1.GetTestButton(_x + date[0], _y + date[1]);
                if (button != null)
                {
                    button.Toggle();
                }*/

                if (_form1.areAllButtonsSame())
                {
                    MessageBox.Show("クリア！最初に戻ります");
                    _form1.resetState();
                }


            }
        }

        private int[][] _toggleData =
        {
            new int[]{0,0 },
            new int[]{1,0 },
            new int[]{-1,0 },
            new int[]{0,1 },
            new int[]{0,-1 }

        };


    }
}
