namespace OOP8
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.sheet = new System.Windows.Forms.PictureBox();
            this.DrCirc = new System.Windows.Forms.Button();
            this.DrRec = new System.Windows.Forms.Button();
            this.DrTr = new System.Windows.Forms.Button();
            this.YellowBt = new System.Windows.Forms.Button();
            this.BlueBt = new System.Windows.Forms.Button();
            this.BlackBt = new System.Windows.Forms.Button();
            this.group = new System.Windows.Forms.Button();
            this.UnGroup = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // sheet
            // 
            this.sheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sheet.Location = new System.Drawing.Point(12, 37);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(738, 482);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // DrCirc
            // 
            this.DrCirc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DrCirc.Location = new System.Drawing.Point(766, 37);
            this.DrCirc.Name = "DrCirc";
            this.DrCirc.Size = new System.Drawing.Size(75, 30);
            this.DrCirc.TabIndex = 1;
            this.DrCirc.Text = "Круг";
            this.DrCirc.UseVisualStyleBackColor = true;
            this.DrCirc.Click += new System.EventHandler(this.DrCirc_Click);
            // 
            // DrRec
            // 
            this.DrRec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DrRec.Location = new System.Drawing.Point(766, 73);
            this.DrRec.Name = "DrRec";
            this.DrRec.Size = new System.Drawing.Size(75, 30);
            this.DrRec.TabIndex = 2;
            this.DrRec.Text = "Квадрат";
            this.DrRec.UseVisualStyleBackColor = true;
            this.DrRec.Click += new System.EventHandler(this.DrRec_Click);
            // 
            // DrTr
            // 
            this.DrTr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DrTr.Location = new System.Drawing.Point(766, 109);
            this.DrTr.Name = "DrTr";
            this.DrTr.Size = new System.Drawing.Size(75, 45);
            this.DrTr.TabIndex = 3;
            this.DrTr.Text = "Треугольник";
            this.DrTr.UseVisualStyleBackColor = true;
            this.DrTr.Click += new System.EventHandler(this.DrTr_Click);
            // 
            // YellowBt
            // 
            this.YellowBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.YellowBt.Location = new System.Drawing.Point(766, 246);
            this.YellowBt.Name = "YellowBt";
            this.YellowBt.Size = new System.Drawing.Size(75, 23);
            this.YellowBt.TabIndex = 4;
            this.YellowBt.Text = "Желтый";
            this.YellowBt.UseVisualStyleBackColor = true;
            this.YellowBt.Click += new System.EventHandler(this.YellowBt_Click);
            // 
            // BlueBt
            // 
            this.BlueBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BlueBt.Location = new System.Drawing.Point(766, 275);
            this.BlueBt.Name = "BlueBt";
            this.BlueBt.Size = new System.Drawing.Size(75, 23);
            this.BlueBt.TabIndex = 5;
            this.BlueBt.Text = "Синий";
            this.BlueBt.UseVisualStyleBackColor = true;
            this.BlueBt.Click += new System.EventHandler(this.BlueBt_Click);
            // 
            // BlackBt
            // 
            this.BlackBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BlackBt.Location = new System.Drawing.Point(766, 304);
            this.BlackBt.Name = "BlackBt";
            this.BlackBt.Size = new System.Drawing.Size(75, 23);
            this.BlackBt.TabIndex = 6;
            this.BlackBt.Text = "Черный";
            this.BlackBt.UseVisualStyleBackColor = true;
            this.BlackBt.Click += new System.EventHandler(this.BlackBt_Click);
            // 
            // group
            // 
            this.group.Location = new System.Drawing.Point(12, 6);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(150, 25);
            this.group.TabIndex = 7;
            this.group.Text = "Сгруппировать ";
            this.group.UseVisualStyleBackColor = true;
            this.group.Click += new System.EventHandler(this.group_Click);
            // 
            // UnGroup
            // 
            this.UnGroup.Location = new System.Drawing.Point(168, 6);
            this.UnGroup.Name = "UnGroup";
            this.UnGroup.Size = new System.Drawing.Size(150, 25);
            this.UnGroup.TabIndex = 8;
            this.UnGroup.Text = "Разгруппировать";
            this.UnGroup.UseVisualStyleBackColor = true;
            this.UnGroup.Click += new System.EventHandler(this.UnGroup_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(324, 6);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(100, 25);
            this.Save.TabIndex = 9;
            this.Save.Text = "Сохранить ";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(430, 6);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(100, 25);
            this.Load.TabIndex = 10;
            this.Load.Text = "Загрузить ";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(766, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 45);
            this.button1.TabIndex = 11;
            this.button1.Text = "Липкий квадрат";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 531);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.UnGroup);
            this.Controls.Add(this.group);
            this.Controls.Add(this.BlackBt);
            this.Controls.Add(this.BlueBt);
            this.Controls.Add(this.YellowBt);
            this.Controls.Add(this.DrTr);
            this.Controls.Add(this.DrRec);
            this.Controls.Add(this.DrCirc);
            this.Controls.Add(this.sheet);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Button DrCirc;
        private System.Windows.Forms.Button DrRec;
        private System.Windows.Forms.Button DrTr;
        private System.Windows.Forms.Button YellowBt;
        private System.Windows.Forms.Button BlueBt;
        private System.Windows.Forms.Button BlackBt;
        private System.Windows.Forms.Button group;
        private System.Windows.Forms.Button UnGroup;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

