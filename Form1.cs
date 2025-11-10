using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Test
{
    public partial class Form1 : Form
    {
        const int BUTTON_SIZE_X = 100;
        const int BUTTON_SIZE_Y = 100;

        const int BOARD_SIZE_X = 3;
        const int BOARD_SIZE_Y = 3;

        private TestButton[,] _buttonArray;

        public Form1()
        {
            InitFunc();
        }

        public void InitFunc()
            {
            InitializeComponent();
            _buttonArray = new TestButton[BOARD_SIZE_X,
                BOARD_SIZE_Y];

            for (int i = 0; i < BOARD_SIZE_X; i++)
            {
                for (int j = 0; j < BOARD_SIZE_Y; j++)
                {
                    // インスタンスの生成
                    TestButton testButton =
                        new TestButton(
                            this,
                            i, j,
                            new Point(BUTTON_SIZE_X * i, BUTTON_SIZE_Y * j),
                            new Size(BUTTON_SIZE_X, BUTTON_SIZE_Y), "");

                    //配列にボタンの参照を実行
                    _buttonArray[j, i] = testButton;


                    // コントロールにボタンを追加
                    Controls.Add(testButton);
                }
            }
            //Random rand = new Random();
            // _buttonArray[1, 0].SetEnable(rand.Next(2) == 0);
            Random rand = new Random();

            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for (int x = 0; x < BOARD_SIZE_X; x++)
                {
                    bool isOn = rand.Next(2) == 0;
                    _buttonArray[y, x].SetEnable(isOn);
                }
            }

        }

        public void resetState()
        {
            Random rand = new Random();

            for (int y = 0; y < BOARD_SIZE_Y; y++){
                for (int x = 0; x < BOARD_SIZE_X; x++){
                    bool isOn = rand.Next(2) == 0;
                    _buttonArray[y, x].SetEnable(isOn);
                }
            }
        }

        // 自分で作成することも可能
        private void hogehogeClick(object sender, EventArgs e)
        {
            MessageBox.Show("くりっくされてしまいました");
        }
        public TestButton GetTestButton(int x, int y)
        {
            if (x < 0 || x >= BOARD_SIZE_X) return null;
            if (y < 0 || y >= BOARD_SIZE_Y) return null;

            return _buttonArray[y, x];
        }

        // 自動生成
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("クリック");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        } 
        public bool areAllButtonsSame()
        {
            bool first = _buttonArray[0, 0].IsEnable();
            for (int y = 0; y < BOARD_SIZE_Y; y++){
                for (int x = 0; x < BOARD_SIZE_X; x++){
                    if (_buttonArray[y, x].IsEnable() != first)
                        return false;
                }
            }
            return true;
       }

    }
}
