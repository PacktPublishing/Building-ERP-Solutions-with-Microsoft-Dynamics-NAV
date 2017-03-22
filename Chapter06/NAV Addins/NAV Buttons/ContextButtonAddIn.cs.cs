// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContextBindingAddIn.cs" company="Microsoft Corporation">
// Copyright © Microsoft Corporation.  All Rights Reserved.  
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.) 
// </copyright>
// <summary>
//   Defines the AddIn class type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

//NOTA: Per installare l'addin:
//Aprire Visual Studio Command Prompt
//SN.exe -T DynamicsNAVButtonPanel.dll
//Leggere la Strong Name Key ritornata (es. 48f3911b65e24838)
//Andare in NAV, Object Designer, tabella 2000000069 (Add-In) ed inserire il record per l'addin:

//NAV: vmeid31 - nav2016Cronus

namespace NAVButtonAddin
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Microsoft.Dynamics.Framework.UI.Extensibility;
    using Microsoft.Dynamics.Framework.UI.Extensibility.WinForms;
    using System;
    using System.Collections.Generic;
    using DynamicsNAVButtonPanel;

    /// <summary>
    /// Dynamics NAV AddIn that delivers an AddIn:
    /// * Static content (No data binding)
    /// * Caption
    /// * Fixed Size
    /// * Context binding
    /// </summary>
    [ControlAddInExport("EID.NAVButtonAddin")] //Nome da utilizzare in NAV per richiamare l'addin
    [Description("NAV Button Controls Add-In")]
    public class ContextBindingAddIn : StringControlAddInBase, IStringControlAddInDefinition 
    {
        [ApplicationVisible]
        [field: NonSerialized]
        public event MethodInvoker AddInReady = delegate { };

        [ApplicationVisible]
        [field:NonSerialized]
        public event EventHandler<ODPEventArgs> LoadODP = delegate { };  
        /// <summary>
        /// Creates the native WinForms control, delivered by this AddIn: A panel with a bitmap
        /// </summary>
        /// <returns>The native WinForms control, that NAV RTC shall use in the UI</returns>
        protected override Control CreateControl()
        {

            //Button button1 = new Button();
            //button1.Location = new System.Drawing.Point(39, 25);
            //button1.Name = "button1";
            //button1.Size = new System.Drawing.Size(75, 23);
            //button1.TabIndex = 0;
            //button1.Text = "button1";
            //button1.UseVisualStyleBackColor = true;
            //button1.Click += new System.EventHandler(button1_Click);

            DynamicsNAVButtonPanel.DAL DAL = new DynamicsNAVButtonPanel.DAL();
            Dictionary<string, Boolean> dict = DAL.GetItems();

            Button buttonRefresh = new Button();
            buttonRefresh.Location = new System.Drawing.Point(0, 300);
            buttonRefresh.Name = "btnRefresh";
            buttonRefresh.Size = new System.Drawing.Size(175, 100);
            buttonRefresh.TabIndex = 0;
            buttonRefresh.Text = "GET DATA";
            buttonRefresh.BackColor = System.Drawing.Color.OrangeRed;
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += new System.EventHandler(buttonRefresh_Click);

            ////Add a Textbox for Prod. Order details
            //TextBox txtProdOrderNo = new TextBox();
            //txtProdOrderNo.Location = new System.Drawing.Point(400, 0);
            //txtProdOrderNo.Size = new System.Drawing.Size(200, 100);
            //txtProdOrderNo.Text = "";
            //txtProdOrderNo.Font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Point);


            Panel buttonpanel = new Panel();
            buttonpanel.Controls.Add(buttonRefresh);
            buttonpanel.Location = new System.Drawing.Point(12, 12);
            buttonpanel.Name = "ButtonPanel";
            buttonpanel.Padding = new System.Windows.Forms.Padding(4, 20, 4, 4);
            buttonpanel.Size = new System.Drawing.Size(600, 400);
            buttonpanel.TabIndex = 0;
            buttonpanel.Text = "Global Monitor";

            //Font testo rettangolo
            //Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);

            //SolidBrush errorBrush = new SolidBrush(Color.Red);
            //SolidBrush readyBrush = new SolidBrush(Color.Green);

            //Graphics formGraphics;
            //formGraphics = buttonpanel.CreateGraphics();

            
            int x = 0, y = 0;
            int rowcount = 0, i = 0;
            foreach (KeyValuePair<string, bool> kvp in dict)
            {
                i++;
                rowcount++;
                if (rowcount > 3)
                {
                    //Massimo 3 rettangoli per riga
                    x = 0;
                    y += 70;
                    rowcount = 1;
                }

                ////Creo rettangolo
                //Rectangle rect = new Rectangle(x, y, 50, 100);
                //if (kvp.Value == true)
                //{
                //    formGraphics.FillRectangle(readyBrush, rect); //GREEN
                //}
                //else
                //{
                //    formGraphics.FillRectangle(errorBrush, rect);  //RED
                //}

                //x += 70;

                ////Scrivo testo nel rettangolo
                //formGraphics.DrawString(kvp.Key, font1, Brushes.Black, rect);

                Button button = new Button();
                button.Location = new System.Drawing.Point(x, y);
                button.Name = "btnODP" + i.ToString();
                button.Size = new System.Drawing.Size(50, 50);
                button.Text = kvp.Key;
                if (kvp.Value == true)
                { 
                    button.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    button.BackColor = System.Drawing.Color.Red;
                }

                x += 70;

                button.UseVisualStyleBackColor = true;
                button.Click += new System.EventHandler(button_Click);

                buttonpanel.Controls.Add(button);

            }

            //The AddInReady event is fired when the control is created
            buttonpanel.HandleCreated += (s, e) => AddInReady();

            return buttonpanel;
        }

        void buttonRefresh_Click(object sender, System.EventArgs e)
        {
            //Here we can call a method to refresh data
            this.RaiseControlAddInEvent(1, "Data refreshed");
        }

        void button_Click(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            string _ProdOrderNo = button.Text;

            //Launch the event
            DynamicsNAVButtonPanel.DAL DAL = new DynamicsNAVButtonPanel.DAL();
            ODP odp = DAL.GetODPDetails(_ProdOrderNo);
            LoadODP(this, new ODPEventArgs(odp));
            
            //Here we can call a method to refresh data
            this.RaiseControlAddInEvent(2, _ProdOrderNo);
        }

        

        /// <summary>
        /// Overrides base class implementation of WinFormsControlAddInBase.OnStyleChanged.
        /// This allows the control to show the propper Icon for a style
        /// </summary>
        /// <param name="style">New style after change</param>
        protected override void OnStyleChanged(Style style)
        {
            base.OnStyleChanged(style);
            switch (style)
            {
                case Style.Attention:
                    this.Control.BackColor = Color.Red;
                    this.Control.ForeColor = Color.Black;
                    break;
                case Style.Favorable:
                    this.Control.BackColor = Color.GreenYellow;
                    this.Control.ForeColor = Color.Black;
                    break;
                case Style.None:
                    this.Control.BackColor = SystemColors.Window;
                    this.Control.ForeColor = SystemColors.WindowText;
                    break;
                case Style.Strong:
                    this.Control.BackColor = Color.Blue;
                    this.Control.ForeColor = Color.White;
                    break;
            }
        }
        public override bool AllowCaptionControl
        {
            get
            {
                return false;
            }
        }
        

    }

    [Serializable]
    public class ODPEventArgs: EventArgs
    {
        private readonly ODP _ODP;
        public ODPEventArgs(ODP odp)
        {
            _ODP = odp;
        }
        public ODP ODP
        {
            get { return _ODP;  }
        }
    }

    

}
