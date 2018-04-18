using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTree
{
    public partial class Form1 : Form
    {
        private BinaryTree tr;
        public Form1()
        {
            InitializeComponent();
            tr = new BinaryTree();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num;
           
            double.TryParse(textBox2.Text, out num);
            if(num>0)
                tr.insert(num);
            textBox2.Text = "";
            string s = "";
            // richTextBox1.Text = tr.getTreePrint();
            string[] st = tr.getPrintOrder();
            s = "Root added\n";
            for(int i=tr.getTreeHelper()-1;i >= 0;i--)
            {
                    s += st[i] + "\n";
            }
            richTextBox2.Text = s;
            richTextBox1.Text = tr.getTreePrint();
            automatedChange();

        }
        //PreOrder
        private void button5_Click(object sender, EventArgs e)
        {
            tr.searchPreOrder();
            textBox6.Text = tr.getTree();
        }

        //Inorder
        private void button6_Click(object sender, EventArgs e)
        {
            tr.searchInorder();
            textBox6.Text =  tr.getTree();
        }
        //PostOrder
        private void button7_Click(object sender, EventArgs e)
        {
            tr.searchPostOrder();
            textBox6.Text = tr.getTree();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label2.Text = tr.leftToRigth();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            label2.Text = tr.rigthtoLeft();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double numb;
            double.TryParse(textBox3.Text, out numb);
            textBox1.Text =  tr.searchNode(numb);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           textBox5.Text = tr.countNodes() + "";
            automatedChange();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double numb;
            double.TryParse(textBox4.Text, out numb);
            textBox4.Text =  tr.delete(numb) +"";
            richTextBox1.Text = tr.getTreePrint();
            automatedChange();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox7.Text = tr.getRoot() + "";
            automatedChange();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox8.Text = tr.findLargest() + "";
            automatedChange();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox9.Text = tr.findMinimum() + "";
            automatedChange();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox10.Text = tr.findMinAndMax() + "";
            automatedChange();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox11.Text = tr.getHeigth();
            automatedChange();
        }

        private void automatedChange()
        {
            textBox12.Text = tr.getRoot() + "";
            textBox13.Text = tr.countNodes() + "";
            textBox14.Text = tr.getHeigth();
            textBox15.Text = tr.findLargest() + "";
            textBox16.Text = tr.findMinimum() + "";

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
