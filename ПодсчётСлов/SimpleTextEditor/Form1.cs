using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace SimpleTextEditor
{
    using System.IO;

    public partial class Form1 : Form
    {
        string name;

        public Form1()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = openFileDialog1.FileName;
                textBox1.Clear();
                textBox1.Text = File.ReadAllText(name, Encoding.Default);
                button1.Visible = true;
                listBox1.Items.Clear();
                listBox2.Items.Clear();

            }
        }
  
     /*   private void save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string name = saveFileDialog1.FileName;
                File.WriteAllText(name, textBox1.Text);
            }
        }*/ 

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            
         //  Регулярные выражения
            string sentence = File.ReadAllText(name, Encoding.Default);
            string слова = @"\b(\w|[-])+\b";
            int a = Regex.Matches(sentence, слова).Count;
            string b = Convert.ToString(a);
            textBox2.Text= b ;

            int словоДлина = (int)numericUpDown1.Value;
        
            string[] words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var result = words.GroupBy(x => x)
                .Where(x => x.Count() > 1 && x.Key.Length > словоДлина)
                .Select(x => new { Word = x.Key, Frequency = x.Count(), Number = words.Count() });
            foreach (var item in result)
                listBox1.Items.Add(item.Word);
         
            string[] words1 = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var result1 = words.GroupBy(x => x)
                .Where(x => x.Count() > 1 && x.Key.Length > словоДлина)
                .Select(x => new { Word = x.Key, Frequency = x.Count(), Number = words.Count() });
            foreach (var item in result1)
                listBox2.Items.Add(item.Frequency);
        
            string[] words2 = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var result2 = words.GroupBy(x => x)
                .Where(x => x.Count() > 1 && x.Key.Length > словоДлина)
                .Select(x => new { Word = x.Key, Frequency = x.Count(), Number = words.Count() });
            foreach (var item in result2)
                listBox3.Items.Add(item.Number);
            
            string[] words3 = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
           var result3 = words3.GroupBy(x => x) 
             .Where(x => x.Count() < 2)
             
              .Select(x => new { Unik = x.Key });
         //  int A = result1.Count() ;
           foreach (var item in result3)
               listBox4.Items.Add(item.Unik);

           string[] words4 = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
           var result4 = words4.GroupBy(x => x)
             .Where(x => x.Count() < 2);

            //  .Select(x => new { Unik = x.Key });
           int A = result4.Count();
           foreach (var item in result4)
               listBox5.Items.Add(A);

            /*    Console.WriteLine("Слово: {0}\tКоличество повторов: {1} \t Количество слов {2} ", item.Word,
                    item.Frequency, item.Number);*/
            
        // Уверен что код можно оптимизировать, но я пока не знаю как.    
        }
    }
}
