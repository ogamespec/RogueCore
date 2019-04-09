namespace RogueDemo
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillScreenByRandomCharsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setCursorAtRandomPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setScreenToRandomSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.printHelloAtCursorPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPoemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.generateRandomDungeonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillByWallsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.digRandomRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.digRandomTunnelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.traceRandomLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traceRandomCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traceRandomExplosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traceSaluteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.inputStringAtCursorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fillByFloorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putWallSlabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traceRandomPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traceTopbottomPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugMoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeDungeonInvisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeDungeonVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomFOVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rogueScreen1 = new RogueCore.Screen();
            this.randomFOVAtCursorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.debugMoreToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.loadImageToolStripMenuItem.Text = "Load image...";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillScreenByRandomCharsToolStripMenuItem,
            this.clearScreenToolStripMenuItem,
            this.setCursorAtRandomPositionToolStripMenuItem,
            this.setScreenToRandomSizeToolStripMenuItem,
            this.toolStripSeparator2,
            this.printHelloAtCursorPositionToolStripMenuItem,
            this.addMessageToolStripMenuItem,
            this.addPoemToolStripMenuItem,
            this.showMessagesToolStripMenuItem,
            this.toolStripSeparator3,
            this.generateRandomDungeonToolStripMenuItem,
            this.fillByWallsToolStripMenuItem,
            this.fillByFloorToolStripMenuItem,
            this.digRandomRoomToolStripMenuItem,
            this.digRandomTunnelToolStripMenuItem,
            this.putWallSlabToolStripMenuItem,
            this.toolStripSeparator4,
            this.traceRandomLineToolStripMenuItem,
            this.traceRandomCircleToolStripMenuItem,
            this.traceRandomExplosionToolStripMenuItem,
            this.traceSaluteToolStripMenuItem,
            this.traceRandomPathToolStripMenuItem,
            this.traceTopbottomPathToolStripMenuItem,
            this.toolStripSeparator5,
            this.inputStringAtCursorToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // fillScreenByRandomCharsToolStripMenuItem
            // 
            this.fillScreenByRandomCharsToolStripMenuItem.Name = "fillScreenByRandomCharsToolStripMenuItem";
            this.fillScreenByRandomCharsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.fillScreenByRandomCharsToolStripMenuItem.Text = "Fill screen by random chars";
            this.fillScreenByRandomCharsToolStripMenuItem.Click += new System.EventHandler(this.fillScreenByRandomCharsToolStripMenuItem_Click);
            // 
            // clearScreenToolStripMenuItem
            // 
            this.clearScreenToolStripMenuItem.Name = "clearScreenToolStripMenuItem";
            this.clearScreenToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.clearScreenToolStripMenuItem.Text = "Clear screen";
            this.clearScreenToolStripMenuItem.Click += new System.EventHandler(this.clearScreenToolStripMenuItem_Click);
            // 
            // setCursorAtRandomPositionToolStripMenuItem
            // 
            this.setCursorAtRandomPositionToolStripMenuItem.Name = "setCursorAtRandomPositionToolStripMenuItem";
            this.setCursorAtRandomPositionToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.setCursorAtRandomPositionToolStripMenuItem.Text = "Set cursor at random position";
            this.setCursorAtRandomPositionToolStripMenuItem.Click += new System.EventHandler(this.setCursorAtRandomPositionToolStripMenuItem_Click);
            // 
            // setScreenToRandomSizeToolStripMenuItem
            // 
            this.setScreenToRandomSizeToolStripMenuItem.Name = "setScreenToRandomSizeToolStripMenuItem";
            this.setScreenToRandomSizeToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.setScreenToRandomSizeToolStripMenuItem.Text = "Set screen to random size";
            this.setScreenToRandomSizeToolStripMenuItem.Click += new System.EventHandler(this.setScreenToRandomSizeToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(227, 6);
            // 
            // printHelloAtCursorPositionToolStripMenuItem
            // 
            this.printHelloAtCursorPositionToolStripMenuItem.Name = "printHelloAtCursorPositionToolStripMenuItem";
            this.printHelloAtCursorPositionToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.printHelloAtCursorPositionToolStripMenuItem.Text = "Print Hello at cursor position";
            this.printHelloAtCursorPositionToolStripMenuItem.Click += new System.EventHandler(this.printHelloAtCursorPositionToolStripMenuItem_Click);
            // 
            // addMessageToolStripMenuItem
            // 
            this.addMessageToolStripMenuItem.Name = "addMessageToolStripMenuItem";
            this.addMessageToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.addMessageToolStripMenuItem.Text = "Add message";
            this.addMessageToolStripMenuItem.Click += new System.EventHandler(this.addMessageToolStripMenuItem_Click);
            // 
            // addPoemToolStripMenuItem
            // 
            this.addPoemToolStripMenuItem.Name = "addPoemToolStripMenuItem";
            this.addPoemToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.addPoemToolStripMenuItem.Text = "Add Poem";
            this.addPoemToolStripMenuItem.Click += new System.EventHandler(this.addPoemToolStripMenuItem_Click);
            // 
            // showMessagesToolStripMenuItem
            // 
            this.showMessagesToolStripMenuItem.Name = "showMessagesToolStripMenuItem";
            this.showMessagesToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.showMessagesToolStripMenuItem.Text = "Show messages";
            this.showMessagesToolStripMenuItem.Click += new System.EventHandler(this.showMessagesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(227, 6);
            // 
            // generateRandomDungeonToolStripMenuItem
            // 
            this.generateRandomDungeonToolStripMenuItem.Name = "generateRandomDungeonToolStripMenuItem";
            this.generateRandomDungeonToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.generateRandomDungeonToolStripMenuItem.Text = "Generate random dungeon";
            this.generateRandomDungeonToolStripMenuItem.Click += new System.EventHandler(this.generateRandomDungeonToolStripMenuItem_Click);
            // 
            // fillByWallsToolStripMenuItem
            // 
            this.fillByWallsToolStripMenuItem.Name = "fillByWallsToolStripMenuItem";
            this.fillByWallsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.fillByWallsToolStripMenuItem.Text = "Fill by walls";
            this.fillByWallsToolStripMenuItem.Click += new System.EventHandler(this.fillByWallsToolStripMenuItem_Click);
            // 
            // digRandomRoomToolStripMenuItem
            // 
            this.digRandomRoomToolStripMenuItem.Name = "digRandomRoomToolStripMenuItem";
            this.digRandomRoomToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.digRandomRoomToolStripMenuItem.Text = "Dig random room";
            this.digRandomRoomToolStripMenuItem.Click += new System.EventHandler(this.digRandomRoomToolStripMenuItem_Click);
            // 
            // digRandomTunnelToolStripMenuItem
            // 
            this.digRandomTunnelToolStripMenuItem.Name = "digRandomTunnelToolStripMenuItem";
            this.digRandomTunnelToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.digRandomTunnelToolStripMenuItem.Text = "Dig random tunnel";
            this.digRandomTunnelToolStripMenuItem.Click += new System.EventHandler(this.digRandomTunnelToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(227, 6);
            // 
            // traceRandomLineToolStripMenuItem
            // 
            this.traceRandomLineToolStripMenuItem.Name = "traceRandomLineToolStripMenuItem";
            this.traceRandomLineToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.traceRandomLineToolStripMenuItem.Text = "Trace random line";
            this.traceRandomLineToolStripMenuItem.Click += new System.EventHandler(this.traceRandomLineToolStripMenuItem_Click);
            // 
            // traceRandomCircleToolStripMenuItem
            // 
            this.traceRandomCircleToolStripMenuItem.Name = "traceRandomCircleToolStripMenuItem";
            this.traceRandomCircleToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.traceRandomCircleToolStripMenuItem.Text = "Trace random circle";
            this.traceRandomCircleToolStripMenuItem.Click += new System.EventHandler(this.traceRandomCircleToolStripMenuItem_Click);
            // 
            // traceRandomExplosionToolStripMenuItem
            // 
            this.traceRandomExplosionToolStripMenuItem.Name = "traceRandomExplosionToolStripMenuItem";
            this.traceRandomExplosionToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.traceRandomExplosionToolStripMenuItem.Text = "Trace random explosion";
            this.traceRandomExplosionToolStripMenuItem.Click += new System.EventHandler(this.traceRandomExplosionToolStripMenuItem_Click);
            // 
            // traceSaluteToolStripMenuItem
            // 
            this.traceSaluteToolStripMenuItem.Name = "traceSaluteToolStripMenuItem";
            this.traceSaluteToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.traceSaluteToolStripMenuItem.Text = "Trace salute";
            this.traceSaluteToolStripMenuItem.Click += new System.EventHandler(this.traceSaluteToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(227, 6);
            // 
            // inputStringAtCursorToolStripMenuItem
            // 
            this.inputStringAtCursorToolStripMenuItem.Name = "inputStringAtCursorToolStripMenuItem";
            this.inputStringAtCursorToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.inputStringAtCursorToolStripMenuItem.Text = "Input string at cursor";
            this.inputStringAtCursorToolStripMenuItem.Click += new System.EventHandler(this.inputStringAtCursorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "jpg";
            this.openFileDialog1.Filter = "Image Files|*.jpg;*.png;*.bmp|All files|*.*";
            // 
            // fillByFloorToolStripMenuItem
            // 
            this.fillByFloorToolStripMenuItem.Name = "fillByFloorToolStripMenuItem";
            this.fillByFloorToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.fillByFloorToolStripMenuItem.Text = "Fill by floor";
            this.fillByFloorToolStripMenuItem.Click += new System.EventHandler(this.fillByFloorToolStripMenuItem_Click);
            // 
            // putWallSlabToolStripMenuItem
            // 
            this.putWallSlabToolStripMenuItem.Name = "putWallSlabToolStripMenuItem";
            this.putWallSlabToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.putWallSlabToolStripMenuItem.Text = "Put wall slab";
            this.putWallSlabToolStripMenuItem.Click += new System.EventHandler(this.putWallSlabToolStripMenuItem_Click);
            // 
            // traceRandomPathToolStripMenuItem
            // 
            this.traceRandomPathToolStripMenuItem.Name = "traceRandomPathToolStripMenuItem";
            this.traceRandomPathToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.traceRandomPathToolStripMenuItem.Text = "Trace random path";
            this.traceRandomPathToolStripMenuItem.Click += new System.EventHandler(this.traceRandomPathToolStripMenuItem_Click);
            // 
            // traceTopbottomPathToolStripMenuItem
            // 
            this.traceTopbottomPathToolStripMenuItem.Name = "traceTopbottomPathToolStripMenuItem";
            this.traceTopbottomPathToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.traceTopbottomPathToolStripMenuItem.Text = "Trace top-bottom path";
            this.traceTopbottomPathToolStripMenuItem.Click += new System.EventHandler(this.traceTopbottomPathToolStripMenuItem_Click);
            // 
            // debugMoreToolStripMenuItem
            // 
            this.debugMoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeDungeonInvisibleToolStripMenuItem,
            this.makeDungeonVisibleToolStripMenuItem,
            this.randomFOVToolStripMenuItem,
            this.randomFOVAtCursorToolStripMenuItem});
            this.debugMoreToolStripMenuItem.Name = "debugMoreToolStripMenuItem";
            this.debugMoreToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.debugMoreToolStripMenuItem.Text = "Debug More";
            // 
            // makeDungeonInvisibleToolStripMenuItem
            // 
            this.makeDungeonInvisibleToolStripMenuItem.Name = "makeDungeonInvisibleToolStripMenuItem";
            this.makeDungeonInvisibleToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.makeDungeonInvisibleToolStripMenuItem.Text = "Make dungeon invisible";
            this.makeDungeonInvisibleToolStripMenuItem.Click += new System.EventHandler(this.makeDungeonInvisibleToolStripMenuItem_Click);
            // 
            // makeDungeonVisibleToolStripMenuItem
            // 
            this.makeDungeonVisibleToolStripMenuItem.Name = "makeDungeonVisibleToolStripMenuItem";
            this.makeDungeonVisibleToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.makeDungeonVisibleToolStripMenuItem.Text = "Make dungeon visible";
            this.makeDungeonVisibleToolStripMenuItem.Click += new System.EventHandler(this.makeDungeonVisibleToolStripMenuItem_Click);
            // 
            // randomFOVToolStripMenuItem
            // 
            this.randomFOVToolStripMenuItem.Name = "randomFOVToolStripMenuItem";
            this.randomFOVToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.randomFOVToolStripMenuItem.Text = "Random FOV";
            this.randomFOVToolStripMenuItem.Click += new System.EventHandler(this.randomFOVToolStripMenuItem_Click);
            // 
            // rogueScreen1
            // 
            this.rogueScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rogueScreen1.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rogueScreen1.Location = new System.Drawing.Point(0, 24);
            this.rogueScreen1.Name = "rogueScreen1";
            this.rogueScreen1.ScreenHeight = 25;
            this.rogueScreen1.ScreenWidth = 80;
            this.rogueScreen1.Size = new System.Drawing.Size(753, 340);
            this.rogueScreen1.TabIndex = 1;
            this.rogueScreen1.Text = "rogueScreen1";
            this.rogueScreen1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rogueScreen1_KeyDown);
            // 
            // randomFOVAtCursorToolStripMenuItem
            // 
            this.randomFOVAtCursorToolStripMenuItem.Name = "randomFOVAtCursorToolStripMenuItem";
            this.randomFOVAtCursorToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.randomFOVAtCursorToolStripMenuItem.Text = "Random FOV at cursor";
            this.randomFOVAtCursorToolStripMenuItem.Click += new System.EventHandler(this.randomFOVAtCursorToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 364);
            this.Controls.Add(this.rogueScreen1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "RogueDemo";
            this.Move += new System.EventHandler(this.Form1_Move);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillScreenByRandomCharsToolStripMenuItem;
        private RogueCore.Screen rogueScreen1;
        private System.Windows.Forms.ToolStripMenuItem clearScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setCursorAtRandomPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setScreenToRandomSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printHelloAtCursorPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPoemToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem generateRandomDungeonToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem traceRandomLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traceRandomCircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traceRandomExplosionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traceSaluteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem inputStringAtCursorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillByWallsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem digRandomTunnelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem digRandomRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillByFloorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem putWallSlabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traceRandomPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traceTopbottomPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugMoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeDungeonInvisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeDungeonVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomFOVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomFOVAtCursorToolStripMenuItem;
    }
}

