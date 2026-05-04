namespace PokerBetting
{
    partial class frmPoker
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpPoker;
        private System.Windows.Forms.GroupBox grpBet;
        private System.Windows.Forms.Label lblTotalMoneyTitle;
        private System.Windows.Forms.TextBox txtTotalMoney;
        private System.Windows.Forms.Label lblBetAmountTitle;
        private System.Windows.Forms.TextBox txtBetAmount;
        private System.Windows.Forms.Button btnBet;
        private System.Windows.Forms.GroupBox grpButton;
        private System.Windows.Forms.Button btnDealCard;
        private System.Windows.Forms.Button btnChangeCard;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblResult;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpPoker = new System.Windows.Forms.GroupBox();
            this.grpBet = new System.Windows.Forms.GroupBox();
            this.lblTotalMoneyTitle = new System.Windows.Forms.Label();
            this.txtTotalMoney = new System.Windows.Forms.TextBox();
            this.lblBetAmountTitle = new System.Windows.Forms.Label();
            this.txtBetAmount = new System.Windows.Forms.TextBox();
            this.btnBet = new System.Windows.Forms.Button();
            this.grpButton = new System.Windows.Forms.GroupBox();
            this.btnDealCard = new System.Windows.Forms.Button();
            this.btnChangeCard = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.grpBet.SuspendLayout();
            this.grpButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPoker
            // 
            this.grpPoker.Location = new System.Drawing.Point(12, 12);
            this.grpPoker.Name = "grpPoker";
            this.grpPoker.Size = new System.Drawing.Size(490, 145);
            this.grpPoker.TabIndex = 0;
            this.grpPoker.TabStop = false;
            this.grpPoker.Text = "牌桌";
            // 
            // grpBet
            // 
            this.grpBet.Controls.Add(this.lblTotalMoneyTitle);
            this.grpBet.Controls.Add(this.txtTotalMoney);
            this.grpBet.Controls.Add(this.lblBetAmountTitle);
            this.grpBet.Controls.Add(this.txtBetAmount);
            this.grpBet.Controls.Add(this.btnBet);
            this.grpBet.Location = new System.Drawing.Point(12, 163);
            this.grpBet.Name = "grpBet";
            this.grpBet.Size = new System.Drawing.Size(490, 58);
            this.grpBet.TabIndex = 1;
            this.grpBet.TabStop = false;
            this.grpBet.Text = "下注";
            // 
            // lblTotalMoneyTitle
            // 
            this.lblTotalMoneyTitle.AutoSize = true;
            this.lblTotalMoneyTitle.Location = new System.Drawing.Point(14, 26);
            this.lblTotalMoneyTitle.Name = "lblTotalMoneyTitle";
            this.lblTotalMoneyTitle.Size = new System.Drawing.Size(56, 12);
            this.lblTotalMoneyTitle.TabIndex = 0;
            this.lblTotalMoneyTitle.Text = "總資金";
            // 
            // txtTotalMoney
            // 
            this.txtTotalMoney.Location = new System.Drawing.Point(78, 22);
            this.txtTotalMoney.Name = "txtTotalMoney";
            this.txtTotalMoney.ReadOnly = true;
            this.txtTotalMoney.Size = new System.Drawing.Size(115, 22);
            this.txtTotalMoney.TabIndex = 1;
            this.txtTotalMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBetAmountTitle
            // 
            this.lblBetAmountTitle.AutoSize = true;
            this.lblBetAmountTitle.Location = new System.Drawing.Point(212, 26);
            this.lblBetAmountTitle.Name = "lblBetAmountTitle";
            this.lblBetAmountTitle.Size = new System.Drawing.Size(68, 12);
            this.lblBetAmountTitle.TabIndex = 2;
            this.lblBetAmountTitle.Text = "押注金額";
            // 
            // txtBetAmount
            // 
            this.txtBetAmount.Location = new System.Drawing.Point(286, 22);
            this.txtBetAmount.Name = "txtBetAmount";
            this.txtBetAmount.Size = new System.Drawing.Size(95, 22);
            this.txtBetAmount.TabIndex = 3;
            this.txtBetAmount.Text = "500";
            this.txtBetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnBet
            // 
            this.btnBet.Location = new System.Drawing.Point(397, 20);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(75, 26);
            this.btnBet.TabIndex = 4;
            this.btnBet.Text = "下注";
            this.btnBet.UseVisualStyleBackColor = true;
            this.btnBet.Click += new System.EventHandler(this.btnBet_Click);
            // 
            // grpButton
            // 
            this.grpButton.Controls.Add(this.btnDealCard);
            this.grpButton.Controls.Add(this.btnChangeCard);
            this.grpButton.Controls.Add(this.btnCheck);
            this.grpButton.Controls.Add(this.lblResult);
            this.grpButton.Location = new System.Drawing.Point(12, 227);
            this.grpButton.Name = "grpButton";
            this.grpButton.Size = new System.Drawing.Size(490, 68);
            this.grpButton.TabIndex = 2;
            this.grpButton.TabStop = false;
            this.grpButton.Text = "功能";
            // 
            // btnDealCard
            // 
            this.btnDealCard.Location = new System.Drawing.Point(16, 24);
            this.btnDealCard.Name = "btnDealCard";
            this.btnDealCard.Size = new System.Drawing.Size(75, 28);
            this.btnDealCard.TabIndex = 0;
            this.btnDealCard.Text = "發牌";
            this.btnDealCard.UseVisualStyleBackColor = true;
            this.btnDealCard.Click += new System.EventHandler(this.btnDealCard_Click);
            // 
            // btnChangeCard
            // 
            this.btnChangeCard.Location = new System.Drawing.Point(101, 24);
            this.btnChangeCard.Name = "btnChangeCard";
            this.btnChangeCard.Size = new System.Drawing.Size(75, 28);
            this.btnChangeCard.TabIndex = 1;
            this.btnChangeCard.Text = "換牌";
            this.btnChangeCard.UseVisualStyleBackColor = true;
            this.btnChangeCard.Click += new System.EventHandler(this.btnChangeCard_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(186, 24);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(88, 28);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "判斷牌型";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblResult
            // 
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult.Location = new System.Drawing.Point(286, 23);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(185, 30);
            this.lblResult.TabIndex = 3;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPoker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 309);
            this.Controls.Add(this.grpButton);
            this.Controls.Add(this.grpBet);
            this.Controls.Add(this.grpPoker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmPoker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "五張撲克牌下注遊戲";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmPoker_KeyPress);
            this.grpBet.ResumeLayout(false);
            this.grpBet.PerformLayout();
            this.grpButton.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
