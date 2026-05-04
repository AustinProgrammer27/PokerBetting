using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerBetting
{
    public partial class frmPoker : Form
    {
        private readonly PictureBox[] pic = new PictureBox[5];

        private readonly int[] allPoker = new int[52];
        private readonly int[] playerPoker = new int[5];

        private readonly Random random = new Random();

        private int totalMoney = 1000000;
        private int currentBet = 0;
        private bool handActive = false;

        public frmPoker()
        {
            InitializeComponent();
            InitializePoker();
            UpdateMoneyText();

            btnDealCard.Enabled = false;
            btnChangeCard.Enabled = false;
            btnCheck.Enabled = false;

            lblResult.Text = "請先輸入押注金額並按下下注";
        }

        /// <summary>
        /// 用字串讀取圖片。
        /// </summary>
        private Image GetImage(string name)
        {
            return PokerBetting.Properties.Resources.ResourceManager.GetObject(name) as Image;
        }

        /// <summary>
        /// 用撲克牌編號讀取圖片。
        /// </summary>
        private Image GetImage(int num)
        {
            return GetImage($"pic{num}");
        }

        /// <summary>
        /// 動態產生 5 張撲克牌控制項。
        /// </summary>
        private void InitializePoker()
        {
            for (int i = 0; i < 5; i++)
            {
                pic[i] = new PictureBox();
                pic[i].Image = GetImage("back");
                pic[i].Name = "pic" + i;
                pic[i].SizeMode = PictureBoxSizeMode.AutoSize;
                pic[i].Top = 30;
                pic[i].Left = 10 + ((pic[i].Width + 10) * i);
                pic[i].Visible = true;
                pic[i].Enabled = false;
                pic[i].Tag = "back";

                grpPoker.Controls.Add(pic[i]);
                pic[i].MouseClick += new MouseEventHandler(pic_Click);
            }
        }

        private void ResetCardsToBack()
        {
            for (int i = 0; i < 5; i++)
            {
                pic[i].Image = GetImage("back");
                pic[i].Tag = "back";
                pic[i].Enabled = false;
            }
        }

        private void UpdateMoneyText()
        {
            txtTotalMoney.Text = totalMoney.ToString();
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBetAmount.Text.Trim(), out int bet) || bet <= 0)
            {
                MessageBox.Show("請輸入大於 0 的押注金額。", "下注錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBetAmount.Focus();
                return;
            }

            if (bet > totalMoney)
            {
                MessageBox.Show("押注金額不可超過目前總資金。", "下注錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBetAmount.Focus();
                return;
            }

            currentBet = bet;
            totalMoney -= currentBet;
            UpdateMoneyText();

            btnBet.Enabled = false;
            txtBetAmount.Enabled = false;
            btnDealCard.Enabled = true;
            btnChangeCard.Enabled = false;
            btnCheck.Enabled = false;
            handActive = false;

            ResetCardsToBack();
            lblResult.Text = $"已下注 {currentBet}，請按「發牌」";
        }

        private async void btnDealCard_Click(object sender, EventArgs e)
        {
            lblResult.Text = "發牌中...";

            // 先將牌面蓋掉。
            ResetCardsToBack();

            // 暫停 500ms，避免蓋牌和發牌速度太快。
            await Task.Delay(500);

            // 初始化 52 張牌。
            for (int i = 0; i < 52; i++)
            {
                allPoker[i] = i;
            }

            // 洗牌。
            Shuffle();

            // 發牌。
            for (int i = 0; i < 5; i++)
            {
                playerPoker[i] = allPoker[i];
                pic[i].Image = GetImage(playerPoker[i] + 1);
                pic[i].Enabled = true;
                pic[i].Tag = "front";
            }

            btnDealCard.Enabled = false;
            btnChangeCard.Enabled = true;
            btnCheck.Enabled = true;
            handActive = true;

            lblResult.Text = "可點擊要換的牌，或直接按「判斷牌型」";
        }

        /// <summary>
        /// 洗牌：使用 Fisher-Yates shuffle，確保不會重複發牌。
        /// </summary>
        private void Shuffle()
        {
            for (int i = allPoker.Length - 1; i > 0; i--)
            {
                int r = random.Next(i + 1);
                int temp = allPoker[i];
                allPoker[i] = allPoker[r];
                allPoker[r] = temp;
            }
        }

        private void pic_Click(object sender, MouseEventArgs e)
        {
            PictureBox clickedPic = (PictureBox)sender;

            // 取得 pic 的索引值。
            int index = int.Parse(clickedPic.Name.Replace("pic", ""));

            // 如果 Tag 為 back，則顯示撲克牌；否則蓋牌，代表選擇要換掉這張牌。
            if (clickedPic.Tag.ToString() == "back")
            {
                clickedPic.Tag = "front";
                clickedPic.Image = GetImage(playerPoker[index] + 1);
            }
            else
            {
                clickedPic.Tag = "back";
                clickedPic.Image = GetImage("back");
            }
        }

        private void btnChangeCard_Click(object sender, EventArgs e)
        {
            // 前五張已經發牌了，為避免重複，從第六張開始換牌。
            int cardIndex = 5;

            for (int i = 0; i < pic.Length; i++)
            {
                if (pic[i].Tag.ToString() == "back")
                {
                    playerPoker[i] = allPoker[cardIndex];
                    pic[i].Image = GetImage(playerPoker[i] + 1);
                    pic[i].Tag = "front";
                    cardIndex++;
                }
            }

            // 換牌只能一次，所以換完牌後關閉滑鼠點擊。
            for (int i = 0; i < pic.Length; i++)
            {
                pic[i].Enabled = false;
            }

            btnChangeCard.Enabled = false;
            btnCheck.Enabled = true;
            lblResult.Text = "換牌完成，請按「判斷牌型」";
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            PokerResult pokerResult = CheckPokerResult();

            int winAmount = currentBet * pokerResult.Odds;
            totalMoney += winAmount;
            UpdateMoneyText();

            lblResult.Text =
                $"{pokerResult.Name}，賠率 {pokerResult.Odds}，中獎金額 {winAmount}，總資金 {totalMoney}";

            for (int i = 0; i < pic.Length; i++)
            {
                pic[i].Enabled = false;
            }

            btnChangeCard.Enabled = false;
            btnCheck.Enabled = false;
            btnDealCard.Enabled = false;
            btnBet.Enabled = totalMoney > 0;
            txtBetAmount.Enabled = totalMoney > 0;
            handActive = false;
            currentBet = 0;

            if (totalMoney <= 0)
            {
                MessageBox.Show("總資金不足，遊戲結束。", "Game Over",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 判斷目前五張牌的牌型與賠率。
        /// </summary>
        private PokerResult CheckPokerResult()
        {
            string[] colorList = { "梅花", "方塊", "愛心", "黑桃" };
            string[] pointList = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            // 記錄目前五張撲克牌的花色和點數。
            int[] pokerColor = new int[5];
            int[] pokerPoint = new int[5];

            for (int i = 0; i < 5; i++)
            {
                pokerColor[i] = playerPoker[i] % 4;
                pokerPoint[i] = playerPoker[i] / 4;
            }

            // 統計花色和點數出現次數。
            int[] colorCount = new int[4];
            int[] pointCount = new int[13];

            for (int i = 0; i < 5; i++)
            {
                int color = pokerColor[i];
                int point = pokerPoint[i];

                colorCount[color]++;
                pointCount[point]++;
            }

            // 排序 colorCount 和 pointCount 由大到小，並同步調整 colorList、pointList。
            Array.Sort(colorCount, colorList);
            Array.Reverse(colorCount);
            Array.Reverse(colorList);

            Array.Sort(pointCount, pointList);
            Array.Reverse(pointCount);
            Array.Reverse(pointList);

            // 判斷是否為同花。
            bool isFlush = (colorCount[0] == 5);

            // 判斷是否為五張單張。
            bool isSingle = (pointCount[0] == 1 && pointCount[1] == 1 &&
                             pointCount[2] == 1 && pointCount[3] == 1 &&
                             pointCount[4] == 1);

            // 判斷是否為差四。
            bool isDiffFour = (pokerPoint.Max() - pokerPoint.Min() == 4);

            // 判斷是否為 A, 10, J, Q, K。
            bool isRoyal = pokerPoint.Contains(0) &&
                            pokerPoint.Contains(9) &&
                            pokerPoint.Contains(10) &&
                            pokerPoint.Contains(11) &&
                            pokerPoint.Contains(12);

            bool isRoyalFlush = isFlush && isRoyal;
            bool isStraightFlush = isFlush && isSingle && isDiffFour;
            bool isStraight = isSingle && (isDiffFour || isRoyal);
            bool isFourOfAKind = (pointCount[0] == 4);
            bool isFullHouse = (pointCount[0] == 3 && pointCount[1] == 2);
            bool isThreeOfAKind = (pointCount[0] == 3 && pointCount[1] == 1);
            bool isTwoPair = (pointCount[0] == 2 && pointCount[1] == 2);
            bool isOnePair = (pointCount[0] == 2 && pointCount[1] == 1);

            if (isRoyalFlush)
            {
                return new PokerResult($"{colorList[0]} 皇家同花順", 250);
            }
            else if (isStraightFlush)
            {
                return new PokerResult($"{colorList[0]} 同花順", 50);
            }
            else if (isFourOfAKind)
            {
                return new PokerResult($"{pointList[0]} 四條", 25);
            }
            else if (isFullHouse)
            {
                return new PokerResult($"{pointList[0]} 三張，{pointList[1]} 兩張，葫蘆", 9);
            }
            else if (isFlush)
            {
                return new PokerResult($"{colorList[0]} 同花", 6);
            }
            else if (isStraight)
            {
                return new PokerResult("順子", 4);
            }
            else if (isThreeOfAKind)
            {
                return new PokerResult($"{pointList[0]} 三條", 3);
            }
            else if (isTwoPair)
            {
                return new PokerResult($"{pointList[0]}、{pointList[1]} 兩對", 2);
            }
            else if (isOnePair)
            {
                return new PokerResult($"{pointList[0]} 一對", 1);
            }
            else
            {
                return new PokerResult("雜牌", 0);
            }
        }

        /// <summary>
        /// 顯示五張撲克牌到桌面上。
        /// </summary>
        private void ShowCards()
        {
            for (int i = 0; i < 5; i++)
            {
                pic[i].Image = GetImage(playerPoker[i] + 1);
                pic[i].Tag = "front";
            }
        }

        private void frmPoker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!handActive)
            {
                return;
            }

            bool hasCheat = true;

            switch (e.KeyChar)
            {
                case 'q': // 皇家同花順
                    SetTestHand(51, 47, 43, 39, 3);
                    break;

                case 'w': // 同花順
                    SetTestHand(37, 33, 29, 25, 21);
                    break;

                case 'a': // 順子
                    SetTestHand(28, 24, 20, 16, 12);
                    break;

                case 'r': // 四條
                    SetTestHand(48, 39, 38, 37, 36);
                    break;

                case 't': // 葫蘆
                    SetTestHand(30, 29, 6, 5, 4);
                    break;

                case 'e': // 同花
                    SetTestHand(50, 38, 34, 22, 18);
                    break;

                case 'y': // 三條
                    SetTestHand(48, 39, 15, 14, 13);
                    break;

                case 'u': // 兩對
                    SetTestHand(48, 49, 44, 45, 0);
                    break;

                case 'i': // 一對
                    SetTestHand(0, 1, 6, 11, 16);
                    break;

                default:
                    hasCheat = false;
                    break;
            }

            if (hasCheat)
            {
                ShowCards();

                for (int i = 0; i < pic.Length; i++)
                {
                    pic[i].Enabled = false;
                }

                btnChangeCard.Enabled = false;
                btnCheck.Enabled = true;
                lblResult.Text = "已載入測試牌型，請按「判斷牌型」";
            }
        }

        private void SetTestHand(params int[] cards)
        {
            for (int i = 0; i < 5; i++)
            {
                playerPoker[i] = cards[i];
            }
        }

        private class PokerResult
        {
            public string Name { get; }
            public int Odds { get; }

            public PokerResult(string name, int odds)
            {
                Name = name;
                Odds = odds;
            }
        }
    }
}
