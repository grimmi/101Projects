namespace airline_reservation
{
    partial class airlineForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.flightList = new System.Windows.Forms.ListView();
            this.idColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.destinationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dbgLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpBoxFlightDetail = new System.Windows.Forms.GroupBox();
            this.book3rdBtn = new System.Windows.Forms.Button();
            this.book2ndBtn = new System.Windows.Forms.Button();
            this.book1stBtn = new System.Windows.Forms.Button();
            this.FlightDetail3rdClassInput = new System.Windows.Forms.TextBox();
            this.FlightDetail2ndClassInput = new System.Windows.Forms.TextBox();
            this.FlightDetail1stClassInput = new System.Windows.Forms.TextBox();
            this.FlightDetail3rdClassLabel = new System.Windows.Forms.Label();
            this.FlightDetail2ndClassLabel = new System.Windows.Forms.Label();
            this.flightDetail1stClassLabel = new System.Windows.Forms.Label();
            this.flightDetailDestinationInput = new System.Windows.Forms.TextBox();
            this.FlightDetailDestinationLabel = new System.Windows.Forms.Label();
            this.flightDetailStartInput = new System.Windows.Forms.TextBox();
            this.flightDetailStartLabel = new System.Windows.Forms.Label();
            this.flightDetailIdInput = new System.Windows.Forms.TextBox();
            this.flightDetailIdLabel = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.grpBoxFlightDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // flightList
            // 
            this.flightList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumn,
            this.startColumn,
            this.destinationColumn});
            this.flightList.FullRowSelect = true;
            this.flightList.GridLines = true;
            this.flightList.HideSelection = false;
            this.flightList.ImeMode = System.Windows.Forms.ImeMode.On;
            this.flightList.Location = new System.Drawing.Point(12, 12);
            this.flightList.MultiSelect = false;
            this.flightList.Name = "flightList";
            this.flightList.Size = new System.Drawing.Size(271, 458);
            this.flightList.TabIndex = 0;
            this.flightList.UseCompatibleStateImageBehavior = false;
            this.flightList.View = System.Windows.Forms.View.Details;
            this.flightList.SelectedIndexChanged += new System.EventHandler(this.flightSelected);
            // 
            // idColumn
            // 
            this.idColumn.Text = "id";
            this.idColumn.Width = 45;
            // 
            // startColumn
            // 
            this.startColumn.Text = "start";
            this.startColumn.Width = 92;
            // 
            // destinationColumn
            // 
            this.destinationColumn.Text = "destination";
            this.destinationColumn.Width = 129;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbgLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1063, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dbgLabel
            // 
            this.dbgLabel.Name = "dbgLabel";
            this.dbgLabel.Size = new System.Drawing.Size(118, 17);
            this.dbgLabel.Text = "toolStripStatusLabel1";
            // 
            // grpBoxFlightDetail
            // 
            this.grpBoxFlightDetail.Controls.Add(this.book3rdBtn);
            this.grpBoxFlightDetail.Controls.Add(this.book2ndBtn);
            this.grpBoxFlightDetail.Controls.Add(this.book1stBtn);
            this.grpBoxFlightDetail.Controls.Add(this.FlightDetail3rdClassInput);
            this.grpBoxFlightDetail.Controls.Add(this.FlightDetail2ndClassInput);
            this.grpBoxFlightDetail.Controls.Add(this.FlightDetail1stClassInput);
            this.grpBoxFlightDetail.Controls.Add(this.FlightDetail3rdClassLabel);
            this.grpBoxFlightDetail.Controls.Add(this.FlightDetail2ndClassLabel);
            this.grpBoxFlightDetail.Controls.Add(this.flightDetail1stClassLabel);
            this.grpBoxFlightDetail.Controls.Add(this.flightDetailDestinationInput);
            this.grpBoxFlightDetail.Controls.Add(this.FlightDetailDestinationLabel);
            this.grpBoxFlightDetail.Controls.Add(this.flightDetailStartInput);
            this.grpBoxFlightDetail.Controls.Add(this.flightDetailStartLabel);
            this.grpBoxFlightDetail.Controls.Add(this.flightDetailIdInput);
            this.grpBoxFlightDetail.Controls.Add(this.flightDetailIdLabel);
            this.grpBoxFlightDetail.Location = new System.Drawing.Point(307, 18);
            this.grpBoxFlightDetail.Name = "grpBoxFlightDetail";
            this.grpBoxFlightDetail.Size = new System.Drawing.Size(432, 202);
            this.grpBoxFlightDetail.TabIndex = 2;
            this.grpBoxFlightDetail.TabStop = false;
            this.grpBoxFlightDetail.Text = "Flight Detail";
            // 
            // book3rdBtn
            // 
            this.book3rdBtn.Enabled = false;
            this.book3rdBtn.Location = new System.Drawing.Point(234, 159);
            this.book3rdBtn.Name = "book3rdBtn";
            this.book3rdBtn.Size = new System.Drawing.Size(75, 20);
            this.book3rdBtn.TabIndex = 14;
            this.book3rdBtn.Text = "book";
            this.book3rdBtn.UseVisualStyleBackColor = true;
            this.book3rdBtn.Click += new System.EventHandler(this.book3rdSeat);
            // 
            // book2ndBtn
            // 
            this.book2ndBtn.Enabled = false;
            this.book2ndBtn.Location = new System.Drawing.Point(234, 133);
            this.book2ndBtn.Name = "book2ndBtn";
            this.book2ndBtn.Size = new System.Drawing.Size(75, 20);
            this.book2ndBtn.TabIndex = 13;
            this.book2ndBtn.Text = "book";
            this.book2ndBtn.UseVisualStyleBackColor = true;
            this.book2ndBtn.Click += new System.EventHandler(this.book2ndSeat);
            // 
            // book1stBtn
            // 
            this.book1stBtn.Enabled = false;
            this.book1stBtn.Location = new System.Drawing.Point(234, 107);
            this.book1stBtn.Name = "book1stBtn";
            this.book1stBtn.Size = new System.Drawing.Size(75, 20);
            this.book1stBtn.TabIndex = 12;
            this.book1stBtn.Text = "book";
            this.book1stBtn.UseVisualStyleBackColor = true;
            this.book1stBtn.Click += new System.EventHandler(this.book1stSeat);
            // 
            // FlightDetail3rdClassInput
            // 
            this.FlightDetail3rdClassInput.Enabled = false;
            this.FlightDetail3rdClassInput.Location = new System.Drawing.Point(172, 159);
            this.FlightDetail3rdClassInput.Name = "FlightDetail3rdClassInput";
            this.FlightDetail3rdClassInput.Size = new System.Drawing.Size(56, 20);
            this.FlightDetail3rdClassInput.TabIndex = 11;
            this.FlightDetail3rdClassInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FlightDetail2ndClassInput
            // 
            this.FlightDetail2ndClassInput.Enabled = false;
            this.FlightDetail2ndClassInput.Location = new System.Drawing.Point(172, 133);
            this.FlightDetail2ndClassInput.Name = "FlightDetail2ndClassInput";
            this.FlightDetail2ndClassInput.Size = new System.Drawing.Size(56, 20);
            this.FlightDetail2ndClassInput.TabIndex = 10;
            this.FlightDetail2ndClassInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FlightDetail1stClassInput
            // 
            this.FlightDetail1stClassInput.Enabled = false;
            this.FlightDetail1stClassInput.Location = new System.Drawing.Point(172, 107);
            this.FlightDetail1stClassInput.Name = "FlightDetail1stClassInput";
            this.FlightDetail1stClassInput.Size = new System.Drawing.Size(56, 20);
            this.FlightDetail1stClassInput.TabIndex = 9;
            this.FlightDetail1stClassInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FlightDetail3rdClassLabel
            // 
            this.FlightDetail3rdClassLabel.AutoSize = true;
            this.FlightDetail3rdClassLabel.Location = new System.Drawing.Point(12, 162);
            this.FlightDetail3rdClassLabel.Name = "FlightDetail3rdClassLabel";
            this.FlightDetail3rdClassLabel.Size = new System.Drawing.Size(127, 13);
            this.FlightDetail3rdClassLabel.TabIndex = 8;
            this.FlightDetail3rdClassLabel.Text = "Available 3rd Class seats:";
            // 
            // FlightDetail2ndClassLabel
            // 
            this.FlightDetail2ndClassLabel.AutoSize = true;
            this.FlightDetail2ndClassLabel.Location = new System.Drawing.Point(12, 136);
            this.FlightDetail2ndClassLabel.Name = "FlightDetail2ndClassLabel";
            this.FlightDetail2ndClassLabel.Size = new System.Drawing.Size(130, 13);
            this.FlightDetail2ndClassLabel.TabIndex = 7;
            this.FlightDetail2ndClassLabel.Text = "Available 2nd Class seats:";
            // 
            // flightDetail1stClassLabel
            // 
            this.flightDetail1stClassLabel.AutoSize = true;
            this.flightDetail1stClassLabel.Location = new System.Drawing.Point(12, 110);
            this.flightDetail1stClassLabel.Name = "flightDetail1stClassLabel";
            this.flightDetail1stClassLabel.Size = new System.Drawing.Size(126, 13);
            this.flightDetail1stClassLabel.TabIndex = 6;
            this.flightDetail1stClassLabel.Text = "Available 1st Class seats:";
            // 
            // flightDetailDestinationInput
            // 
            this.flightDetailDestinationInput.Enabled = false;
            this.flightDetailDestinationInput.Location = new System.Drawing.Point(74, 72);
            this.flightDetailDestinationInput.Name = "flightDetailDestinationInput";
            this.flightDetailDestinationInput.Size = new System.Drawing.Size(154, 20);
            this.flightDetailDestinationInput.TabIndex = 5;
            this.flightDetailDestinationInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FlightDetailDestinationLabel
            // 
            this.FlightDetailDestinationLabel.AutoSize = true;
            this.FlightDetailDestinationLabel.Location = new System.Drawing.Point(12, 75);
            this.FlightDetailDestinationLabel.Name = "FlightDetailDestinationLabel";
            this.FlightDetailDestinationLabel.Size = new System.Drawing.Size(63, 13);
            this.FlightDetailDestinationLabel.TabIndex = 4;
            this.FlightDetailDestinationLabel.Text = "Destination:";
            // 
            // flightDetailStartInput
            // 
            this.flightDetailStartInput.Enabled = false;
            this.flightDetailStartInput.Location = new System.Drawing.Point(74, 46);
            this.flightDetailStartInput.Name = "flightDetailStartInput";
            this.flightDetailStartInput.Size = new System.Drawing.Size(154, 20);
            this.flightDetailStartInput.TabIndex = 3;
            this.flightDetailStartInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flightDetailStartLabel
            // 
            this.flightDetailStartLabel.AutoSize = true;
            this.flightDetailStartLabel.Location = new System.Drawing.Point(12, 49);
            this.flightDetailStartLabel.Name = "flightDetailStartLabel";
            this.flightDetailStartLabel.Size = new System.Drawing.Size(32, 13);
            this.flightDetailStartLabel.TabIndex = 2;
            this.flightDetailStartLabel.Text = "Start:";
            // 
            // flightDetailIdInput
            // 
            this.flightDetailIdInput.Enabled = false;
            this.flightDetailIdInput.Location = new System.Drawing.Point(172, 20);
            this.flightDetailIdInput.Name = "flightDetailIdInput";
            this.flightDetailIdInput.Size = new System.Drawing.Size(56, 20);
            this.flightDetailIdInput.TabIndex = 1;
            this.flightDetailIdInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flightDetailIdLabel
            // 
            this.flightDetailIdLabel.AutoSize = true;
            this.flightDetailIdLabel.Location = new System.Drawing.Point(12, 23);
            this.flightDetailIdLabel.Name = "flightDetailIdLabel";
            this.flightDetailIdLabel.Size = new System.Drawing.Size(52, 13);
            this.flightDetailIdLabel.TabIndex = 0;
            this.flightDetailIdLabel.Text = "Flight ID: ";
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(976, 471);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exit);
            // 
            // airlineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 519);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.grpBoxFlightDetail);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.flightList);
            this.Name = "airlineForm";
            this.Text = "Airline Reservation";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpBoxFlightDetail.ResumeLayout(false);
            this.grpBoxFlightDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView flightList;
        public System.Windows.Forms.ColumnHeader idColumn;
        public System.Windows.Forms.ColumnHeader startColumn;
        public System.Windows.Forms.ColumnHeader destinationColumn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel dbgLabel;
        private System.Windows.Forms.GroupBox grpBoxFlightDetail;
        private System.Windows.Forms.Label flightDetailIdLabel;
        private System.Windows.Forms.TextBox flightDetailDestinationInput;
        private System.Windows.Forms.Label FlightDetailDestinationLabel;
        private System.Windows.Forms.TextBox flightDetailStartInput;
        private System.Windows.Forms.Label flightDetailStartLabel;
        private System.Windows.Forms.TextBox flightDetailIdInput;
        private System.Windows.Forms.TextBox FlightDetail3rdClassInput;
        private System.Windows.Forms.TextBox FlightDetail2ndClassInput;
        private System.Windows.Forms.TextBox FlightDetail1stClassInput;
        private System.Windows.Forms.Label FlightDetail3rdClassLabel;
        private System.Windows.Forms.Label FlightDetail2ndClassLabel;
        private System.Windows.Forms.Label flightDetail1stClassLabel;
        private System.Windows.Forms.Button book3rdBtn;
        private System.Windows.Forms.Button book2ndBtn;
        private System.Windows.Forms.Button book1stBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}

