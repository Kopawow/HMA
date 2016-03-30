namespace HMA
{
  partial class HMA
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
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.bGetWeather = new System.Windows.Forms.Button();
      this.License = new System.Windows.Forms.TextBox();
      this.bImHome = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(13, 13);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(100, 20);
      this.textBox1.TabIndex = 0;
      // 
      // bGetWeather
      // 
      this.bGetWeather.Location = new System.Drawing.Point(152, 12);
      this.bGetWeather.Name = "bGetWeather";
      this.bGetWeather.Size = new System.Drawing.Size(120, 23);
      this.bGetWeather.TabIndex = 1;
      this.bGetWeather.Text = "Pobierz Pogode";
      this.bGetWeather.UseVisualStyleBackColor = true;
      this.bGetWeather.Click += new System.EventHandler(this.bGetWeather_Click);
      // 
      // License
      // 
      this.License.Location = new System.Drawing.Point(12, 229);
      this.License.Name = "License";
      this.License.Size = new System.Drawing.Size(260, 20);
      this.License.TabIndex = 2;
      // 
      // bImHome
      // 
      this.bImHome.Location = new System.Drawing.Point(99, 154);
      this.bImHome.Name = "bImHome";
      this.bImHome.Size = new System.Drawing.Size(75, 23);
      this.bImHome.TabIndex = 3;
      this.bImHome.Text = "Wróciłem";
      this.bImHome.UseVisualStyleBackColor = true;
      this.bImHome.Click += new System.EventHandler(this.bImHome_Click);
      // 
      // HMA
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 261);
      this.Controls.Add(this.bImHome);
      this.Controls.Add(this.License);
      this.Controls.Add(this.bGetWeather);
      this.Controls.Add(this.textBox1);
      this.Name = "HMA";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button bGetWeather;
    private System.Windows.Forms.TextBox License;
    private System.Windows.Forms.Button bImHome;
  }
}

