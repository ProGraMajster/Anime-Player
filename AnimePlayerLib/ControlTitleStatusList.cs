﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnimePlayer.ControlsWinForms;

namespace AnimePlayerLibrary
{
    public partial class ControlTitleStatusList : UserControl
    {
        readonly NewFlowLayoutPanel newFlowLayoutPanel;
        public ControlTitleStatusList()
        {
            InitializeComponent();
            newFlowLayoutPanel = new NewFlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Name = "newFlowLayoutPanel_Titles",
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };
            newFlowLayoutPanel.Resize += NewFlowLayoutPanel_Resize;
            panelDock.Controls.Add(newFlowLayoutPanel);
            newFlowLayoutPanel.Show();

            try
            {
                for(int i = 0; i < 20; i++)
                {
                    ControlTitleStatusList_Item item = new()
                    {
                        Name = "item_"
                    };
                    item.SetWidth(newFlowLayoutPanel.Width-35);
                    newFlowLayoutPanel.Controls.Add(item);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void NewFlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            if(!bWresiezItem.IsBusy)
            {
                bWresiezItem.RunWorkerAsync();
            }
        }

        private void BWresiezItem_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                foreach(ControlTitleStatusList_Item i in newFlowLayoutPanel.Controls.OfType<ControlTitleStatusList_Item>())
                {
                    this.BeginInvoke(new Action(() => i.SetWidth(newFlowLayoutPanel.Width - 35)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ControlTitleStatusList_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (ControlTitleStatusList_Item i in newFlowLayoutPanel.Controls.OfType<ControlTitleStatusList_Item>())
                {
                    i.SetWidth(newFlowLayoutPanel.Width - 35);
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
