
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.search = new MetroFramework.Controls.MetroButton();
            this.search_text = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previous = new MetroFramework.Controls.MetroButton();
            this.next = new MetroFramework.Controls.MetroButton();
            this.down = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(271, 43);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(43, 26);
            this.search.TabIndex = 0;
            this.search.Text = "검색";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // search_text
            // 
            this.search_text.Location = new System.Drawing.Point(94, 43);
            this.search_text.Name = "search_text";
            this.search_text.Size = new System.Drawing.Size(158, 26);
            this.search_text.TabIndex = 1;
            this.search_text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_text_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 2;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.name});
            this.dgv.Location = new System.Drawing.Point(13, 75);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(339, 194);
            this.dgv.TabIndex = 3;
            // 
            // num
            // 
            this.num.HeaderText = "번호";
            this.num.Name = "num";
            this.num.Width = 55;
            // 
            // name
            // 
            this.name.HeaderText = "제목";
            this.name.Name = "name";
            this.name.Width = 280;
            // 
            // previous
            // 
            this.previous.Location = new System.Drawing.Point(13, 275);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(75, 23);
            this.previous.TabIndex = 4;
            this.previous.Text = "이전";
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(94, 275);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 23);
            this.next.TabIndex = 5;
            this.next.Text = "다음";
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // down
            // 
            this.down.Location = new System.Drawing.Point(288, 275);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(64, 24);
            this.down.TabIndex = 6;
            this.down.Text = "다운";
            this.down.Click += new System.EventHandler(this.down_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(48, 45);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(40, 26);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "제목";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "마나토끼 다운로더";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(365, 302);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.down);
            this.Controls.Add(this.next);
            this.Controls.Add(this.previous);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.search_text);
            this.Controls.Add(this.search);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton search;
        private MetroFramework.Controls.MetroTextBox search_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private MetroFramework.Controls.MetroButton previous;
        private MetroFramework.Controls.MetroButton next;
        private MetroFramework.Controls.MetroButton down;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

