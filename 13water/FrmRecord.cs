﻿using CCWin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13water
{
    public partial class FrmRecord : CCSkinMain
    {
        int page = 0;
        public FrmRecord()
        {
            InitializeComponent();
        }

        private void FrmRecord_Load(object sender, EventArgs e)
        {
            skinToolTipRecord.SetToolTip(spbPlayer, "玩家ID：" + User.user_id);
            skinToolTipRecord.SetToolTip(skinPictureBox1, "返回");
            skinToolTipRecord.SetToolTip(skinPictureBoxPre, "上一页");
            skinToolTipRecord.SetToolTip(skinPictureBoxNext, "下一页");


            var client = new RestClient("https://api.shisanshui.rtxux.xyz/history?page="+page+"&limit=15&player_id=" + User.user_id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-auth-token", User.token);
            IRestResponse response = client.Execute(request);
            JObject jo = (JObject)JsonConvert.DeserializeObject(response.Content);

            if ((int)jo["status"] == 0)
            {
                JArray ja = (JArray)jo["data"];
                List<MyRecordInfo> listMyRecord = new List<MyRecordInfo>();
                foreach (var item in ja)
                {
                    MyRecordInfo tmp = new MyRecordInfo();
                    tmp.battle_id = (int)item["id"];
                    tmp.cardStr = item["card"].ToString();
                    tmp.score = (int)item["score"];
                    tmp.timestamp = (long)item["timestamp"];
                    listMyRecord.Add(tmp);
                }
                sdgvMyRecord.AutoGenerateColumns = false;
                sdgvMyRecord.DataSource = null;
                sdgvMyRecord.DataSource = listMyRecord;
            }
            else
            {
                MessageBox.Show("查询记录失败", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 按下关闭按钮后发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRecord_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        /// <summary>
        /// 单击单元格发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sdgvMyRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==0)
            {
                var row = sdgvMyRecord.Rows[e.RowIndex];
                if (row.Cells[0].Value == null)
                {
                    return;
                }
                FrmBattleDetail.QueryBattle_id = (int)row.Cells[0].Value;
                FrmBattleDetail frm = new FrmBattleDetail();
                frm.ShowDialog();
            }
        }

        private void skinPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void skbtnSearch_Click(object sender, EventArgs e)
        {
            string player_id = stxtQuery_id.Text;
            var client = new RestClient("https://api.shisanshui.rtxux.xyz/history?page=1&limit=15&player_id=" + player_id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-auth-token", User.token);
            IRestResponse response = client.Execute(request);
            JObject jo = (JObject)JsonConvert.DeserializeObject(response.Content);

            if ((int)jo["status"] == 0)
            {
                JArray ja = (JArray)jo["data"];
                List<MyRecordInfo> listMyRecord = new List<MyRecordInfo>();
                foreach (var item in ja)
                {
                    MyRecordInfo tmp = new MyRecordInfo();
                    tmp.battle_id = (int)item["id"];
                    tmp.cardStr = item["card"].ToString();
                    tmp.score = (int)item["score"];
                    tmp.timestamp = (long)item["timestamp"];
                    listMyRecord.Add(tmp);
                }
                sdgvMyRecord.AutoGenerateColumns = false;
                sdgvMyRecord.DataSource = null;
                sdgvMyRecord.DataSource = listMyRecord;
            }
            else
            {
                MessageBox.Show("查询记录失败", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void skinPictureBoxPre_Click(object sender, EventArgs e)
        {
            if(page==0)
            {
                return;
            }
            else
            {
                page--;


                string player_id = stxtQuery_id.Text;
                if(player_id=="")
                {
                    player_id = User.user_id.ToString();
                }
                var client = new RestClient("https://api.shisanshui.rtxux.xyz/history?page=" + page + "&limit=15&player_id=" + player_id);
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-auth-token", User.token);
                IRestResponse response = client.Execute(request);
                JObject jo = (JObject)JsonConvert.DeserializeObject(response.Content);

                if ((int)jo["status"] == 0)
                {
                    JArray ja = (JArray)jo["data"];
                    List<MyRecordInfo> listMyRecord = new List<MyRecordInfo>();
                    foreach (var item in ja)
                    {
                        MyRecordInfo tmp = new MyRecordInfo();
                        tmp.battle_id = (int)item["id"];
                        tmp.cardStr = item["card"].ToString();
                        tmp.score = (int)item["score"];
                        tmp.timestamp = (long)item["timestamp"];
                        listMyRecord.Add(tmp);
                    }
                    sdgvMyRecord.AutoGenerateColumns = false;
                    sdgvMyRecord.DataSource = null;
                    sdgvMyRecord.DataSource = listMyRecord;
                }
                else
                {
                    MessageBox.Show("查询记录失败", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void skinPictureBoxNext_Click(object sender, EventArgs e)
        {
            page++;
            string player_id = stxtQuery_id.Text;
            if (player_id == "")
            {
                player_id = User.user_id.ToString();
            }
            var client = new RestClient("https://api.shisanshui.rtxux.xyz/history?page=" + page + "&limit=15&player_id=" + player_id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-auth-token", User.token);
            IRestResponse response = client.Execute(request);
            JObject jo = (JObject)JsonConvert.DeserializeObject(response.Content);

            if ((int)jo["status"] == 0)
            {
                JArray ja = (JArray)jo["data"];
                List<MyRecordInfo> listMyRecord = new List<MyRecordInfo>();
                foreach (var item in ja)
                {
                    MyRecordInfo tmp = new MyRecordInfo();
                    tmp.battle_id = (int)item["id"];
                    tmp.cardStr = item["card"].ToString();
                    tmp.score = (int)item["score"];
                    tmp.timestamp = (long)item["timestamp"];
                    listMyRecord.Add(tmp);
                }
                sdgvMyRecord.AutoGenerateColumns = false;
                sdgvMyRecord.DataSource = null;
                sdgvMyRecord.DataSource = listMyRecord;
            }
            else
            {
                MessageBox.Show("查询记录失败", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
