namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonAddDraft = new System.Windows.Forms.Button();
            this.ListboxFiles = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ButtonToSTEP = new System.Windows.Forms.Button();
            this.ButtonToIGES = new System.Windows.Forms.Button();
            this.CheckboxIsOverwrite = new System.Windows.Forms.CheckBox();
            this.ButtonToDXF = new System.Windows.Forms.Button();
            this.ButtonToPDF = new System.Windows.Forms.Button();
            this.ButtonToPDFandDXF = new System.Windows.Forms.Button();
            this.ButtonRemoveDraft = new System.Windows.Forms.Button();
            this.ButtonRemoveAllDrafts = new System.Windows.Forms.Button();
            this.TextboxDestDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonSelectDestDir = new System.Windows.Forms.Button();
            this.ButtonAutoAddDrafts = new System.Windows.Forms.Button();
            this.ButtonSelectAutoLoadSetting = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TextboxAutoLoadSetting = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonAddDraft
            // 
            this.ButtonAddDraft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddDraft.Location = new System.Drawing.Point(403, 71);
            this.ButtonAddDraft.Name = "ButtonAddDraft";
            this.ButtonAddDraft.Size = new System.Drawing.Size(67, 27);
            this.ButtonAddDraft.TabIndex = 5;
            this.ButtonAddDraft.Text = "追加";
            this.ButtonAddDraft.UseVisualStyleBackColor = true;
            this.ButtonAddDraft.Click += new System.EventHandler(this.ButtonAddDraft_Click);
            // 
            // ListboxFiles
            // 
            this.ListboxFiles.AllowDrop = true;
            this.ListboxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListboxFiles.FormattingEnabled = true;
            this.ListboxFiles.ItemHeight = 12;
            this.ListboxFiles.Location = new System.Drawing.Point(12, 38);
            this.ListboxFiles.Name = "ListboxFiles";
            this.ListboxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListboxFiles.Size = new System.Drawing.Size(385, 172);
            this.ListboxFiles.TabIndex = 6;
            this.ListboxFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListboxFiles_DragDrop);
            this.ListboxFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListboxFiles_DragEnter);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.ButtonToSTEP);
            this.panel1.Controls.Add(this.ButtonToIGES);
            this.panel1.Controls.Add(this.CheckboxIsOverwrite);
            this.panel1.Controls.Add(this.ButtonToDXF);
            this.panel1.Controls.Add(this.ButtonToPDF);
            this.panel1.Controls.Add(this.ButtonToPDFandDXF);
            this.panel1.Location = new System.Drawing.Point(12, 245);
            this.panel1.MinimumSize = new System.Drawing.Size(459, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 116);
            this.panel1.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(13, 91);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(437, 16);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 13;
            // 
            // ButtonToSTEP
            // 
            this.ButtonToSTEP.Location = new System.Drawing.Point(342, 50);
            this.ButtonToSTEP.Name = "ButtonToSTEP";
            this.ButtonToSTEP.Size = new System.Drawing.Size(107, 34);
            this.ButtonToSTEP.TabIndex = 12;
            this.ButtonToSTEP.Text = "to STEP";
            this.ButtonToSTEP.UseVisualStyleBackColor = true;
            this.ButtonToSTEP.Click += new System.EventHandler(this.ButtonToSTEP_Click);
            // 
            // ButtonToIGES
            // 
            this.ButtonToIGES.Location = new System.Drawing.Point(342, 9);
            this.ButtonToIGES.Name = "ButtonToIGES";
            this.ButtonToIGES.Size = new System.Drawing.Size(107, 34);
            this.ButtonToIGES.TabIndex = 11;
            this.ButtonToIGES.Text = "to IGES";
            this.ButtonToIGES.UseVisualStyleBackColor = true;
            this.ButtonToIGES.Click += new System.EventHandler(this.ButtonToIGES_Click);
            // 
            // CheckboxIsOverwrite
            // 
            this.CheckboxIsOverwrite.AutoSize = true;
            this.CheckboxIsOverwrite.Checked = true;
            this.CheckboxIsOverwrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckboxIsOverwrite.Location = new System.Drawing.Point(193, 19);
            this.CheckboxIsOverwrite.Name = "CheckboxIsOverwrite";
            this.CheckboxIsOverwrite.Size = new System.Drawing.Size(114, 16);
            this.CheckboxIsOverwrite.TabIndex = 10;
            this.CheckboxIsOverwrite.Text = "上書き確認を抑制";
            this.CheckboxIsOverwrite.UseVisualStyleBackColor = true;
            // 
            // ButtonToDXF
            // 
            this.ButtonToDXF.Location = new System.Drawing.Point(110, 50);
            this.ButtonToDXF.Name = "ButtonToDXF";
            this.ButtonToDXF.Size = new System.Drawing.Size(76, 35);
            this.ButtonToDXF.TabIndex = 9;
            this.ButtonToDXF.Text = "to DXF";
            this.ButtonToDXF.UseVisualStyleBackColor = true;
            this.ButtonToDXF.Click += new System.EventHandler(this.ButtonToDXF_Click);
            // 
            // ButtonToPDF
            // 
            this.ButtonToPDF.Location = new System.Drawing.Point(13, 50);
            this.ButtonToPDF.Name = "ButtonToPDF";
            this.ButtonToPDF.Size = new System.Drawing.Size(76, 35);
            this.ButtonToPDF.TabIndex = 5;
            this.ButtonToPDF.Text = "to PDF";
            this.ButtonToPDF.UseVisualStyleBackColor = true;
            this.ButtonToPDF.Click += new System.EventHandler(this.ButtonToPDF_Click);
            // 
            // ButtonToPDFandDXF
            // 
            this.ButtonToPDFandDXF.Location = new System.Drawing.Point(13, 9);
            this.ButtonToPDFandDXF.Name = "ButtonToPDFandDXF";
            this.ButtonToPDFandDXF.Size = new System.Drawing.Size(173, 35);
            this.ButtonToPDFandDXF.TabIndex = 4;
            this.ButtonToPDFandDXF.Text = "to PDF and DXF";
            this.ButtonToPDFandDXF.UseVisualStyleBackColor = true;
            this.ButtonToPDFandDXF.Click += new System.EventHandler(this.ButtonToPDFandDXF_Click);
            // 
            // ButtonRemoveDraft
            // 
            this.ButtonRemoveDraft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRemoveDraft.Location = new System.Drawing.Point(403, 104);
            this.ButtonRemoveDraft.Name = "ButtonRemoveDraft";
            this.ButtonRemoveDraft.Size = new System.Drawing.Size(67, 27);
            this.ButtonRemoveDraft.TabIndex = 8;
            this.ButtonRemoveDraft.Text = "削除";
            this.ButtonRemoveDraft.UseVisualStyleBackColor = true;
            this.ButtonRemoveDraft.Click += new System.EventHandler(this.ButtonRemoveDraft_Click);
            // 
            // ButtonRemoveAllDrafts
            // 
            this.ButtonRemoveAllDrafts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRemoveAllDrafts.Location = new System.Drawing.Point(403, 137);
            this.ButtonRemoveAllDrafts.Name = "ButtonRemoveAllDrafts";
            this.ButtonRemoveAllDrafts.Size = new System.Drawing.Size(67, 27);
            this.ButtonRemoveAllDrafts.TabIndex = 9;
            this.ButtonRemoveAllDrafts.Text = "全削除";
            this.ButtonRemoveAllDrafts.UseVisualStyleBackColor = true;
            this.ButtonRemoveAllDrafts.Click += new System.EventHandler(this.ButtonRemoveAllDrafts_Click);
            // 
            // TextboxDestDir
            // 
            this.TextboxDestDir.AllowDrop = true;
            this.TextboxDestDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxDestDir.Location = new System.Drawing.Point(65, 216);
            this.TextboxDestDir.Name = "TextboxDestDir";
            this.TextboxDestDir.Size = new System.Drawing.Size(334, 19);
            this.TextboxDestDir.TabIndex = 10;
            this.TextboxDestDir.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextboxDestDir_DragDrop);
            this.TextboxDestDir.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextboxDestDir_DragEnter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "dest dir";
            // 
            // ButtonSelectDestDir
            // 
            this.ButtonSelectDestDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSelectDestDir.Location = new System.Drawing.Point(405, 212);
            this.ButtonSelectDestDir.Name = "ButtonSelectDestDir";
            this.ButtonSelectDestDir.Size = new System.Drawing.Size(67, 27);
            this.ButtonSelectDestDir.TabIndex = 12;
            this.ButtonSelectDestDir.Text = "選択";
            this.ButtonSelectDestDir.UseVisualStyleBackColor = true;
            this.ButtonSelectDestDir.Click += new System.EventHandler(this.ButtonSelectDestDir_Click);
            // 
            // ButtonAutoAddDrafts
            // 
            this.ButtonAutoAddDrafts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAutoAddDrafts.Location = new System.Drawing.Point(403, 38);
            this.ButtonAutoAddDrafts.Name = "ButtonAutoAddDrafts";
            this.ButtonAutoAddDrafts.Size = new System.Drawing.Size(67, 27);
            this.ButtonAutoAddDrafts.TabIndex = 13;
            this.ButtonAutoAddDrafts.Text = "自動追加";
            this.ButtonAutoAddDrafts.UseVisualStyleBackColor = true;
            this.ButtonAutoAddDrafts.Click += new System.EventHandler(this.ButtonAutoAddDrafts_Click);
            // 
            // ButtonSelectAutoLoadSetting
            // 
            this.ButtonSelectAutoLoadSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSelectAutoLoadSetting.Location = new System.Drawing.Point(405, 8);
            this.ButtonSelectAutoLoadSetting.Name = "ButtonSelectAutoLoadSetting";
            this.ButtonSelectAutoLoadSetting.Size = new System.Drawing.Size(67, 27);
            this.ButtonSelectAutoLoadSetting.TabIndex = 16;
            this.ButtonSelectAutoLoadSetting.Text = "選択";
            this.ButtonSelectAutoLoadSetting.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "auto load setting";
            // 
            // TextboxAutoLoadSetting
            // 
            this.TextboxAutoLoadSetting.AllowDrop = true;
            this.TextboxAutoLoadSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxAutoLoadSetting.Location = new System.Drawing.Point(112, 12);
            this.TextboxAutoLoadSetting.Name = "TextboxAutoLoadSetting";
            this.TextboxAutoLoadSetting.Size = new System.Drawing.Size(287, 19);
            this.TextboxAutoLoadSetting.TabIndex = 14;
            this.TextboxAutoLoadSetting.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextboxAutoLoadSetting_DragDrop);
            this.TextboxAutoLoadSetting.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextboxAutoLoadSetting_DragEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 364);
            this.Controls.Add(this.ButtonSelectAutoLoadSetting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextboxAutoLoadSetting);
            this.Controls.Add(this.ButtonAutoAddDrafts);
            this.Controls.Add(this.ButtonSelectDestDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextboxDestDir);
            this.Controls.Add(this.ButtonRemoveAllDrafts);
            this.Controls.Add(this.ButtonRemoveDraft);
            this.Controls.Add(this.ListboxFiles);
            this.Controls.Add(this.ButtonAddDraft);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 347);
            this.Name = "Form1";
            this.Text = "SolidEdge dft Converter";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonAddDraft;
        private System.Windows.Forms.ListBox ListboxFiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox CheckboxIsOverwrite;
        private System.Windows.Forms.Button ButtonToDXF;
        private System.Windows.Forms.Button ButtonToPDF;
        private System.Windows.Forms.Button ButtonToPDFandDXF;
        private System.Windows.Forms.Button ButtonRemoveDraft;
        private System.Windows.Forms.Button ButtonRemoveAllDrafts;
        private System.Windows.Forms.TextBox TextboxDestDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonSelectDestDir;
        private System.Windows.Forms.Button ButtonToSTEP;
        private System.Windows.Forms.Button ButtonToIGES;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button ButtonAutoAddDrafts;
        private System.Windows.Forms.Button ButtonSelectAutoLoadSetting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextboxAutoLoadSetting;
    }
}

