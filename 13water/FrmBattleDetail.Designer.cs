﻿namespace _13water
{
    partial class FrmBattleDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBattleDetail));
            this.sdgvBattleDetail = new CCWin.SkinControl.SkinDataGridView();
            this.ColBattle_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPlayer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sdgvBattleDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // sdgvBattleDetail
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.sdgvBattleDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.sdgvBattleDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.sdgvBattleDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sdgvBattleDetail.ColumnFont = null;
            this.sdgvBattleDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("华文新魏", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sdgvBattleDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.sdgvBattleDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sdgvBattleDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColBattle_id,
            this.ColTimestamp,
            this.ColPlayer_id,
            this.ColName,
            this.ColScore,
            this.ColCard});
            this.sdgvBattleDetail.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("华文新魏", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sdgvBattleDetail.DefaultCellStyle = dataGridViewCellStyle3;
            this.sdgvBattleDetail.EnableHeadersVisualStyles = false;
            this.sdgvBattleDetail.Font = new System.Drawing.Font("华文新魏", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sdgvBattleDetail.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.sdgvBattleDetail.HeadFont = new System.Drawing.Font("华文新魏", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sdgvBattleDetail.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.sdgvBattleDetail.Location = new System.Drawing.Point(7, 201);
            this.sdgvBattleDetail.Name = "sdgvBattleDetail";
            this.sdgvBattleDetail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.sdgvBattleDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.sdgvBattleDetail.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.sdgvBattleDetail.RowTemplate.Height = 23;
            this.sdgvBattleDetail.Size = new System.Drawing.Size(1266, 488);
            this.sdgvBattleDetail.TabIndex = 1;
            this.sdgvBattleDetail.TitleBack = null;
            this.sdgvBattleDetail.TitleBackColorBegin = System.Drawing.Color.White;
            this.sdgvBattleDetail.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            // 
            // ColBattle_id
            // 
            this.ColBattle_id.DataPropertyName = "battle_id";
            this.ColBattle_id.HeaderText = "战局ID";
            this.ColBattle_id.Name = "ColBattle_id";
            this.ColBattle_id.ReadOnly = true;
            // 
            // ColTimestamp
            // 
            this.ColTimestamp.DataPropertyName = "timestamp";
            this.ColTimestamp.HeaderText = "结算时间";
            this.ColTimestamp.Name = "ColTimestamp";
            this.ColTimestamp.ReadOnly = true;
            this.ColTimestamp.Width = 200;
            // 
            // ColPlayer_id
            // 
            this.ColPlayer_id.DataPropertyName = "player_id";
            this.ColPlayer_id.HeaderText = "用户ID";
            this.ColPlayer_id.Name = "ColPlayer_id";
            this.ColPlayer_id.ReadOnly = true;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "name";
            this.ColName.HeaderText = "昵称";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            this.ColName.Width = 210;
            // 
            // ColScore
            // 
            this.ColScore.DataPropertyName = "score";
            this.ColScore.HeaderText = "分数";
            this.ColScore.Name = "ColScore";
            this.ColScore.ReadOnly = true;
            this.ColScore.Width = 110;
            // 
            // ColCard
            // 
            this.ColCard.DataPropertyName = "cardStr";
            this.ColCard.HeaderText = "牌型";
            this.ColCard.Name = "ColCard";
            this.ColCard.ReadOnly = true;
            this.ColCard.Width = 500;
            // 
            // FrmBattleDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = ((System.Drawing.Image)(resources.GetObject("$this.Back")));
            this.ClientSize = new System.Drawing.Size(1280, 810);
            this.Controls.Add(this.sdgvBattleDetail);
            this.Name = "FrmBattleDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBattleDetail";
            this.Load += new System.EventHandler(this.FrmBattleDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sdgvBattleDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinDataGridView sdgvBattleDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBattle_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTimestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPlayer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCard;
    }
}