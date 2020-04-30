namespace DijkstraApp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.generateNodeMap_btn = new System.Windows.Forms.Button();
            this.nodeCount_tb = new System.Windows.Forms.TextBox();
            this.nodeNumberLabel = new System.Windows.Forms.Label();
            this.startNode_Label = new System.Windows.Forms.Label();
            this.endNode_label = new System.Windows.Forms.Label();
            this.nodeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dijkstra_Btn = new System.Windows.Forms.Button();
            this.distance_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 355);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel_click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_mouseMove);
            // 
            // generateNodeMap_btn
            // 
            this.generateNodeMap_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.generateNodeMap_btn.Location = new System.Drawing.Point(12, 486);
            this.generateNodeMap_btn.Name = "generateNodeMap_btn";
            this.generateNodeMap_btn.Size = new System.Drawing.Size(133, 37);
            this.generateNodeMap_btn.TabIndex = 2;
            this.generateNodeMap_btn.Text = "Generate";
            this.generateNodeMap_btn.UseVisualStyleBackColor = true;
            this.generateNodeMap_btn.Click += new System.EventHandler(this.generateNodeMap_btn_Click);
            // 
            // nodeCount_tb
            // 
            this.nodeCount_tb.Location = new System.Drawing.Point(12, 460);
            this.nodeCount_tb.Name = "nodeCount_tb";
            this.nodeCount_tb.Size = new System.Drawing.Size(132, 20);
            this.nodeCount_tb.TabIndex = 1;
            // 
            // nodeNumberLabel
            // 
            this.nodeNumberLabel.AutoSize = true;
            this.nodeNumberLabel.Location = new System.Drawing.Point(12, 441);
            this.nodeNumberLabel.Name = "nodeNumberLabel";
            this.nodeNumberLabel.Size = new System.Drawing.Size(73, 13);
            this.nodeNumberLabel.TabIndex = 4;
            this.nodeNumberLabel.Text = "No. of Nodes:";
            // 
            // startNode_Label
            // 
            this.startNode_Label.AutoSize = true;
            this.startNode_Label.Location = new System.Drawing.Point(312, 409);
            this.startNode_Label.Name = "startNode_Label";
            this.startNode_Label.Size = new System.Drawing.Size(61, 13);
            this.startNode_Label.TabIndex = 5;
            this.startNode_Label.Text = "Start Node:";
            // 
            // endNode_label
            // 
            this.endNode_label.AutoSize = true;
            this.endNode_label.Location = new System.Drawing.Point(312, 467);
            this.endNode_label.Name = "endNode_label";
            this.endNode_label.Size = new System.Drawing.Size(58, 13);
            this.endNode_label.TabIndex = 6;
            this.endNode_label.Text = "End Node:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(379, 409);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(379, 467);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 8;
            // 
            // dijkstra_Btn
            // 
            this.dijkstra_Btn.Location = new System.Drawing.Point(539, 409);
            this.dijkstra_Btn.Name = "dijkstra_Btn";
            this.dijkstra_Btn.Size = new System.Drawing.Size(75, 23);
            this.dijkstra_Btn.TabIndex = 9;
            this.dijkstra_Btn.Text = "Calculate";
            this.dijkstra_Btn.UseVisualStyleBackColor = true;
            this.dijkstra_Btn.Click += new System.EventHandler(this.dijkstra_Btn_Click);
            // 
            // distance_label
            // 
            this.distance_label.AutoSize = true;
            this.distance_label.Location = new System.Drawing.Point(539, 474);
            this.distance_label.Name = "distance_label";
            this.distance_label.Size = new System.Drawing.Size(0, 13);
            this.distance_label.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 535);
            this.Controls.Add(this.distance_label);
            this.Controls.Add(this.dijkstra_Btn);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.endNode_label);
            this.Controls.Add(this.startNode_Label);
            this.Controls.Add(this.nodeNumberLabel);
            this.Controls.Add(this.nodeCount_tb);
            this.Controls.Add(this.generateNodeMap_btn);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button generateNodeMap_btn;
        private System.Windows.Forms.TextBox nodeCount_tb;
        private System.Windows.Forms.Label nodeNumberLabel;
        private System.Windows.Forms.Label startNode_Label;
        private System.Windows.Forms.Label endNode_label;
        private System.Windows.Forms.ToolTip nodeToolTip;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button dijkstra_Btn;
        private System.Windows.Forms.Label distance_label;
    }
}

