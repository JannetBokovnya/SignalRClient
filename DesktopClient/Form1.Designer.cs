
namespace DesktopClient
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
            this.stateLabel = new System.Windows.Forms.Label();
            this.stateLabelValue = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.getNameButton = new System.Windows.Forms.Button();
            this.setNameButton = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.messageTextLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.chatTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(12, 16);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(36, 15);
            this.stateLabel.TabIndex = 0;
            this.stateLabel.Text = "State:";
            // 
            // stateLabelValue
            // 
            this.stateLabelValue.AutoSize = true;
            this.stateLabelValue.ForeColor = System.Drawing.Color.Red;
            this.stateLabelValue.Location = new System.Drawing.Point(56, 16);
            this.stateLabelValue.Name = "stateLabelValue";
            this.stateLabelValue.Size = new System.Drawing.Size(79, 15);
            this.stateLabelValue.TabIndex = 1;
            this.stateLabelValue.Text = "Disconnected";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(151, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 45);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(39, 15);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(56, 41);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(170, 23);
            this.nameTextBox.TabIndex = 3;
            this.nameTextBox.Text = "Anonymous";
            // 
            // getNameButton
            // 
            this.getNameButton.Location = new System.Drawing.Point(70, 70);
            this.getNameButton.Name = "getNameButton";
            this.getNameButton.Size = new System.Drawing.Size(75, 23);
            this.getNameButton.TabIndex = 4;
            this.getNameButton.Text = "Get";
            this.getNameButton.UseVisualStyleBackColor = true;
            this.getNameButton.Click += new System.EventHandler(this.getNameButton_Click);
            // 
            // setNameButton
            // 
            this.setNameButton.Location = new System.Drawing.Point(151, 70);
            this.setNameButton.Name = "setNameButton";
            this.setNameButton.Size = new System.Drawing.Size(75, 23);
            this.setNameButton.TabIndex = 5;
            this.setNameButton.Text = "Set";
            this.setNameButton.UseVisualStyleBackColor = true;
            this.setNameButton.Click += new System.EventHandler(this.setNameButton_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(56, 99);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(170, 77);
            this.messageTextBox.TabIndex = 6;
            // 
            // messageTextLabel
            // 
            this.messageTextLabel.AutoSize = true;
            this.messageTextLabel.Location = new System.Drawing.Point(9, 108);
            this.messageTextLabel.Name = "messageTextLabel";
            this.messageTextLabel.Size = new System.Drawing.Size(28, 15);
            this.messageTextLabel.TabIndex = 7;
            this.messageTextLabel.Text = "Text";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(151, 182);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 8;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(242, 13);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(546, 425);
            this.chatTextBox.TabIndex = 9;
            this.chatTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageTextLabel);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.setNameButton);
            this.Controls.Add(this.getNameButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.stateLabelValue);
            this.Controls.Add(this.stateLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label stateLabelValue;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button getNameButton;
        private System.Windows.Forms.Button setNameButton;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Label messageTextLabel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.RichTextBox chatTextBox;
    }
}

