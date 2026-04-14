using System.IO;
namespace Не_дома
{
    public partial class Form1 : Form
    {
        string[] Name = new string[100];
        int[] Any = new int[100];
        int[] Price = new int[100];

        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowValues()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            for (int i = 0; i < count; i++)
            {
                listBox1.Items.Add(Name[i]);
                listBox2.Items.Add(Any[i]);
                listBox3.Items.Add(Price[i]);
            }
        }

        void SaveFile()
        {
            saveFileDialog1.Title = "Сохранить";
            saveFileDialog1.FileName = "File.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream file = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(file);
                for (int i = 0; i < count; i++)
                {
                    writer.Write(Name[i]);
                    writer.Write(Any[i]);
                    writer.Write(Price[i]);
                }
                writer.Close();
                file.Close();
            }
        }


        void OpenFile()
        {
            openFileDialog1.Title = "Загрузить";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream file = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                while (!reader.EndOfStream)
                {
                    Name[count] = reader.ReadLine();
                    Any[count] = int.Parse(reader.ReadLine());
                    Price[count] = int.Parse(reader.ReadLine());
                    count++;
                }
                reader.Close();
                file.Close();
                ShowValues();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            Name[count] = textBox1.Text;
            Any[count] = int.Parse(textBox2.Text) ;
            Price[count] = int.Parse(textBox3.Text);
            count++;
            label5.Text = "Количество: " + count;
            ShowValues();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
    }
}
