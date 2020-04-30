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
            this.panel1 = new System.Windows.Forms.Panel();
            this.generateNodeMap_btn = new System.Windows.Forms.Button();
            this.nodeCount_tb = new System.Windows.Forms.TextBox();
            this.nodeNumberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 355);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 535);
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
    }
}

