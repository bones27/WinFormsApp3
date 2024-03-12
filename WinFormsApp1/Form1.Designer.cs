namespace ReadForSpeed
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            readSpeedCtrl = new NumericUpDown();
            label2 = new Label();
            fontSizeCtrl = new NumericUpDown();
            label3 = new Label();
            openBtn = new Button();
            contextMenuRecent = new ContextMenuStrip(components);
            statusStrip1 = new StatusStrip();
            statusActualSpeed = new ToolStripStatusLabel();
            statusTimeLeft = new ToolStripStatusLabel();
            statusFileName = new ToolStripStatusLabel();
            timeLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)readSpeedCtrl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fontSizeCtrl).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = SystemColors.ControlLight;
            label1.Location = new Point(93, 12);
            label1.Name = "label1";
            label1.Size = new Size(240, 23);
            label1.TabIndex = 0;
            label1.Text = "text";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.DoubleClick += label1_DoubleClick;
            // 
            // button1
            // 
            button1.Location = new Point(12, 46);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            button1.KeyUp += Form1_KeyUp;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(12, 75);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(573, 127);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(93, 46);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(240, 23);
            progressBar1.TabIndex = 3;
            progressBar1.Click += progressBar1_Click;
            // 
            // readSpeedCtrl
            // 
            readSpeedCtrl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            readSpeedCtrl.Location = new Point(339, 46);
            readSpeedCtrl.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            readSpeedCtrl.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            readSpeedCtrl.Name = "readSpeedCtrl";
            readSpeedCtrl.Size = new Size(120, 23);
            readSpeedCtrl.TabIndex = 4;
            readSpeedCtrl.ValueChanged += readSpeed_ValueChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(342, 21);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 5;
            label2.Text = "Read speed";
            // 
            // fontSizeCtrl
            // 
            fontSizeCtrl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            fontSizeCtrl.Location = new Point(465, 46);
            fontSizeCtrl.Name = "fontSizeCtrl";
            fontSizeCtrl.Size = new Size(120, 23);
            fontSizeCtrl.TabIndex = 4;
            fontSizeCtrl.ValueChanged += fontSizeCtrl_ValueChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(468, 21);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 5;
            label3.Text = "Font size";
            // 
            // openBtn
            // 
            openBtn.ContextMenuStrip = contextMenuRecent;
            openBtn.Location = new Point(12, 12);
            openBtn.Name = "openBtn";
            openBtn.Size = new Size(75, 23);
            openBtn.TabIndex = 6;
            openBtn.Text = "Open";
            openBtn.UseVisualStyleBackColor = true;
            openBtn.Click += Button2_Click;
            // 
            // contextMenuRecent
            // 
            contextMenuRecent.Name = "contextMenuStrip1";
            contextMenuRecent.Size = new Size(61, 4);
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusActualSpeed, statusTimeLeft, statusFileName });
            statusStrip1.Location = new Point(0, 360);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(597, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ItemClicked += statusStrip1_ItemClicked;
            // 
            // statusActualSpeed
            // 
            statusActualSpeed.Name = "statusActualSpeed";
            statusActualSpeed.Size = new Size(118, 17);
            statusActualSpeed.Text = "toolStripStatusLabel1";
            statusActualSpeed.Click += statusActualSpeed_Click;
            // 
            // statusTimeLeft
            // 
            statusTimeLeft.Name = "statusTimeLeft";
            statusTimeLeft.Size = new Size(118, 17);
            statusTimeLeft.Text = "toolStripStatusLabel1";
            // 
            // statusFileName
            // 
            statusFileName.Name = "statusFileName";
            statusFileName.Size = new Size(118, 17);
            statusFileName.Text = "toolStripStatusLabel2";
            statusFileName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(12, 205);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(38, 15);
            timeLabel.TabIndex = 8;
            timeLabel.Text = "label4";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 382);
            Controls.Add(timeLabel);
            Controls.Add(statusStrip1);
            Controls.Add(openBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(fontSizeCtrl);
            Controls.Add(readSpeedCtrl);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)readSpeedCtrl).EndInit();
            ((System.ComponentModel.ISupportInitialize)fontSizeCtrl).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    private Button button1;
    private PictureBox pictureBox1;
    private ProgressBar progressBar1;
    private NumericUpDown readSpeedCtrl;
    private Label label2;
    private NumericUpDown fontSizeCtrl;
    private Label label3;
    private Button openBtn;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel statusActualSpeed;
    private ToolStripStatusLabel statusFileName;
    private ToolStripStatusLabel statusTimeLeft;
        private ContextMenuStrip contextMenuRecent;
        private Label timeLabel;
    }
}