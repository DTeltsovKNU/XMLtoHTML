using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace XMLtoHTML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetStud();
        }

        public void GetStud()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\лабы по проге\курс 2\XMLtoHTML\XMLtoHTML\XMLFile1.xml");

            XmlElement xRoot = doc.DocumentElement;
            XmlNodeList childNodes = xRoot.SelectNodes("Student");
            for (int i = 0; i < childNodes.Count; i++)
            {
                XmlNode n = childNodes.Item(i);
                AddItem(n);
            }
        } 

        public void AddItem(XmlNode n)
        {
            if (!comboBox1.Items.Contains(n.SelectSingleNode("@Name").Value))
                comboBox1.Items.Add(n.SelectSingleNode("@Name").Value);

            if (!comboBox2.Items.Contains(n.SelectSingleNode("@Faculty").Value))
                comboBox2.Items.Add(n.SelectSingleNode("@Faculty").Value);

            if (!comboBox3.Items.Contains(n.SelectSingleNode("@Mark").Value))
                comboBox3.Items.Add(n.SelectSingleNode("@Mark").Value);

            if (!comboBox4.Items.Contains(n.SelectSingleNode("@Group").Value))
                comboBox4.Items.Add(n.SelectSingleNode("@Group").Value);

            if (!comboBox5.Items.Contains(n.SelectSingleNode("@Subject").Value))
                comboBox5.Items.Add(n.SelectSingleNode("@Subject").Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            IXmlStrategy strat = new DOM();
            Students st = CheckForFilter();

            if (DOM_Button.Checked)
            {
                strat = new DOM();
            }

            if (SAX_Button.Checked)
            {
                strat = new SAX();
            }

            if (LINQtoXML_Button.Checked)
            {
                strat = new LINQ_to_XML();
            }

            List<Students> result = strat.search(st);

            foreach(Students s in result)
            {
                richTextBox1.Text += "Студент: " + s.Name + "\n";
                richTextBox1.Text += "Факультет: " + s.Faculty + "\n";
                richTextBox1.Text += "Група: " + s.Group + "\n";
                richTextBox1.Text += "Дисципліна: " + s.Subject + "\n";
                richTextBox1.Text += "Оцінка: " + s.Mark + "\n";
                richTextBox1.Text += "\n\n\n";
            }
            
        }


        private Students CheckForFilter()
        {
            Students st = new Students();
            if (checkBox1.Checked)
            {
                try
                {
                    st.Name = comboBox1.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Пожалуйста, выбирите имя студента");
                }
            }

            if (checkBox2.Checked)
            {
                try
                {
                    st.Faculty = comboBox2.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Пожалуйста, выбирите факультет студента");
                }
            }

            if (checkBox3.Checked)
            {
                try
                {
                    st.Mark = comboBox3.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Пожалуйста, выбирите оценку студента");
                }
            }

            if (checkBox4.Checked)
            {
                try
                {
                    st.Group = comboBox4.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Пожалуйста, выбирите группу студента");
                }
            }

            if (checkBox5.Checked)
            {
                try
                {
                    st.Subject = comboBox5.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Пожалуйста, выбирите предмет студента");
                }
            }

            return st;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XslCompiledTransform xct = new XslCompiledTransform();
            xct.Load(@"D:\лабы по проге\курс 2\XMLtoHTML\XMLtoHTML\XSLTFile1.xslt");
            string fXML = @"D:\лабы по проге\курс 2\XMLtoHTML\XMLtoHTML\XMLFile1.xml";
            string fXSL = @"D:\лабы по проге\курс 2\XMLtoHTML\XMLtoHTML\XMLFile1.html";
            xct.Transform(fXML, fXSL);
        }
    }
}
