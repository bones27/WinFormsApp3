using System.Net;
using System.Text.RegularExpressions;

namespace ReadForSpeed
{
    enum State { Run, Stop };
    public partial class Form1 : Form
    {
        private string fileName = @"C:\Users\temp_\source\repos\WinFormsApp1\WinFormsApp1\read.txt";
        int word = 0;
        string[] wordList;
        State state = State.Stop;
        private int wordAvg;
        private DateTime timeAvg;
        private decimal readSpeed = 0;
        int fontSize;
        Data data;

        public void RenderRainbowText(string Text, PictureBox pb)
        {
            //int redPos = (int)(Text.ToCharArray().Where(c => !nonWord.Contains(c)).Count() * 0.35);

            int redPos = (int)(MyRegex().Count(Regex.Replace(Text, $"\n|\r", "")) * 0.35);

            // PictureBox needs an image to draw on

            pb.Image?.Dispose();

            pb.Image = new Bitmap(pb.Width, pb.Height);


            using (Graphics g = Graphics.FromImage(pb.Image))
            {
                // create all-white background for drawing
                SolidBrush brush = new SolidBrush(Color.Azure);
                g.FillRectangle(brush, 0, 0,
                    pb.Image.Width, pb.Image.Height);
                // draw comma-delimited elements in multiple colors
                string[] chunks = { Text.Substring(0, redPos), Text[redPos].ToString(), Text.Substring(redPos + 1) };
                brush = new SolidBrush(Color.Black);
                SolidBrush[] brushes = new SolidBrush[] {
            new SolidBrush(Color.MidnightBlue),
            new SolidBrush(Color.IndianRed),
            new SolidBrush(Color.MidnightBlue),
            new SolidBrush(Color.Purple) };

                //StringFormat sf = new StringFormat(StringFormatFlags.MeasureTrailingSpaces);
                float x = 0.4f * pb.Width - g.MeasureString(chunks[0], pb.Font).Width;
                float sp = g.MeasureString(" ", pb.Font).Width;
                float y = (pb.Height - g.MeasureString(" ", pb.Font).Height) / 2;
                for (int i = 0; i < chunks.Length; i++)
                {
                    // draw text in whatever color
                    g.DrawString(chunks[i], pb.Font, brushes[i], x, y);
                    // measure text and advance x
                    x += g.MeasureString(chunks[i], pb.Font).Width - sp;
                }
            }
        }
        public Form1()
        {
            data = new Data();


            InitializeComponent();
            loadSettings();
            loadFile(fileName);

            pictureBox1.Font = new Font("Arial", fontSize);

            if (word >= wordList?.Length) word = 0;
            updLabel();
            //System.Diagnostics.Debugger.Log(0, "info", Location.ToString());
        }

        private void loadSettings()
        {
            word = Properties.Settings.Default.wordNumber;
            readSpeed = Properties.Settings.Default.readSpeed;
            fontSize = Properties.Settings.Default.fontSize;
            fileName = Properties.Settings.Default.fileName;
            Location = Properties.Settings.Default.formLocation; //form location
            Size = Properties.Settings.Default.formSize; //form location
            //System.Diagnostics.Debugger.Log(0, "info", Location.ToString());
            fontSizeCtrl.Value = fontSize;
            readSpeedCtrl.Value = readSpeed;
            data.Load("progress.json");
            fillMenu();
        }

        private void fillMenu()
        {
            contextMenuRecent.Items.Clear();
            foreach (var item in data.asList)
            {
                var menuItem = new ToolStripMenuItem(item);
                contextMenuRecent.Items.Add(menuItem);
                menuItem.Click += toolStripMenuItem_Click;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (state == State.Stop)
            {
                //timer1.Enabled = true;
                //time = DateTime.Now;
                button1.Text = "run";
                state = State.Run;
                resetStat();
                ShowWords();
            }
            else
            {
                //timer1.Enabled = false;
                button1.Text = "stop";
                state = State.Stop;
            }
        }

        private void resetStat()
        {
            wordAvg = 0;
            timeAvg = DateTime.Now;
        }

        async void ShowWords()
        {
            while (state == State.Run & word < wordList.Length)
            {
                var w = wordList[word];
                updLabel();
                var delay = (100 + 10 * w.Length + punctuationDelay(w)) * (1 - readSpeed / 20);
                await Task.Delay((int)delay);
                ++word;
                //words per minute
                var wpm = (++wordAvg / (DateTime.Now - timeAvg).TotalMinutes);
                statusActualSpeed.Text = wpm.ToString("F1");
                //total time left
                var minutesLeft = (wordList.Length - word) / wpm;
                statusTimeLeft.Text = minutesLeft.ToString("F");

                //while (state == State.Stop) await Task.Delay(500);
            }
        }

        private int punctuationDelay(string w)
        {
            if (w.Contains(',')) return 20;
            if (w.Contains(';')) return 20;
            if (w.Contains(':')) return 20;

            if (w.Contains('.')) return 40;
            if (w.Contains('!')) return 40;
            if (w.Contains('?')) return 40;
            else return 0;
        }


        private void progressBar1_Click(object sender, EventArgs e)
        {
            var x = ((MouseEventArgs)e).X;
            word = x * wordList.Length / progressBar1.Width;
            state = State.Stop;
            updLabel();
        }

        private void updLabel()
        {
            if (wordList == null) return;
            label1.Text = $"{word} / {wordList.Length}";
            progressBar1.Value = word;
            var w = wordList[word];
            RenderRainbowText(w, pictureBox1);
            timeLabel.Text = (DateTime.Now - timeAvg).ToString(@"mm\:ss");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.wordNumber = word;
            Properties.Settings.Default.readSpeed = readSpeed;
            Properties.Settings.Default.fontSize = fontSize;
            Properties.Settings.Default.fileName = fileName;
            Properties.Settings.Default.formLocation = Location;
            Properties.Settings.Default.formSize = Size;
            Properties.Settings.Default.Save();
            SaveProgress();
        }

        private void SaveProgress()
        {
            if (data != null)
            {
                data.Set(fileName, word);
                data.Save("progress.json");
            }
        }

        [GeneratedRegex("\\w")]
        private static partial Regex MyRegex();


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                state = State.Stop;
                --word;
                updLabel();
            }
            else if (e.KeyCode == Keys.Right)
            {
                state = State.Stop;
                ++word;
                updLabel();
            }
        }

        private void readSpeed_ValueChanged(object sender, EventArgs e)
        {
            readSpeed = readSpeedCtrl.Value;
            resetStat();
        }

        private void fontSizeCtrl_ValueChanged(object sender, EventArgs e)
        {
            fontSize = (int)fontSizeCtrl.Value;
            pictureBox1.Font = new Font("Arial", fontSize);
            updLabel();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FileDialog dlg = new OpenFileDialog();
            var res = dlg.ShowDialog();
            if (res == DialogResult.OK)
            {
                //save current progress
                data.Set(fileName, word);
                //load new file
                loadFile(dlg.FileName);
                updLabel();
            }
        }

        private void loadFile(string fn)
        {
            fileName = fn.Replace("\"", "");

            if (File.Exists(fn))
            {
                var text = File.ReadAllText(fileName);
                var text1 = Regex.Replace(text, $"\n", " ");

                wordList = Regex.Replace(text1, @"(\.)(\w)", "$1 $2").Split(' ').Where(x => x.Length > 0).ToArray();
                progressBar1.Maximum = wordList.Length;
                statusFileName.Text = fileName;
            }
            else
            {
                // wordList = null;
                statusFileName.Text = "file not found";
            }
            try
            {
                word = data.Get(fn);
            }
            catch { }
            updLabel();
        }
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void label1_DoubleClick(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("Reset to  0?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                word = 0;
                updLabel();
            }
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadFile(((ToolStripMenuItem)sender).Text);
        }

        private void statusActualSpeed_Click(object sender, EventArgs e)
        {
            resetStat();
        }
    }
}