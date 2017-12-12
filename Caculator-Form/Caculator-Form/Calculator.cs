using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caculator_Form
{
   public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        List<string> IN = new List<string>();
        List<string> OUT = new List<string>();
        char[] phepToan = new char[100];
        int i = 0;
        Stack S = new Stack();

        //-------------------------------------
        int level(string x)
        {
            if (x == "(")
                return 0;
            if (x == "+" || x == "-")
                return 1;
            if (x == "*" || x == "/" || x == "%")
                return 2;
            return 3;
        }
        //-------------------------------------
        private int isNumb(string x)
        {
            double y;
            if(double.TryParse(x, out y))
                return 1;
            else
                return 0;
        }
        //-----------------------------------
        private int isEmpty()
        {
            if (S.getTop() != "#")
                return 0;
            else return 1;
        }
        //-----------------------------------
        private void hauTo(List<string> IN,List<String>OUT)
        {

            
         
            
            string x;
            for (int i = 0; IN[i] != "\0"; i++)
            {

                if (isNumb(IN[i]) == 1)
                {
                    OUT.Add(IN[i]);
                    
                    
                }

                else
                    if (IN[i] == "(")
                    S.Push("(");
                else
                        if (IN[i] == ")")
                {
                    while (isEmpty() == 0)//
                    {
                        x = S.Pop();
                        if (x != "(")
                        {
                            OUT.Add(x);
                            
                        }
                        else break;
                    }
                }
                else
                {
                    while (isEmpty() == 0 && level(IN[i]) <= level(S.getTop()))
                    {
                       
                        OUT.Add(S.Pop());
                        
                    }
                    S.Push(IN[i]);
                }
            }

            while (isEmpty() == 0)
            {
               
                OUT.Add(S.Pop());
               
            }

            OUT.Add("\0");

        }
        //------------------------------------
        string calculate(List<string> OUT)
        {
            
            double x1, x2;
            double kq;
            int i = 0;
            while (i < OUT.Count && OUT[i] != "\0")
            {
                while (OUT[i] == " ")
                {
                    i++;
                }
                if (isNumb(OUT[i]) == 1)
                {
                    double num = 0;
                    while (isNumb(OUT[i]) == 1)
                    {
                        num = num * 10 + Convert.ToDouble(OUT[i]) ;
                        i++;
                    }
                    S.Push(Convert.ToString((num)));
                    
                }
                else
                {
                    x1 = Convert.ToDouble(Convert.ToDouble(S.Pop()));
                    x2 = Convert.ToDouble(Convert.ToDouble(S.Pop()));
                    switch (OUT[i])
                    {
                        case "+":
                            kq = x1 + x2;
                            break;
                        case "-":
                            kq = x2 - x1;
                            break;
                        case "*":
                            kq = x1 * x2;
                            break;
                        case "/":
                            kq = x2 / x1;
                            break;
                        case "%":
                            kq = x2 % x1;
                            break;

                        default:
                            
                            return "0";
                    }
                    S.Push(Convert.ToString(kq));
                    
                }
               i++;
            }
            
            return S.Pop();
        }
        //------------------------------------

       

        private void button20_Click(object sender, EventArgs e)
        {
            if (kq.Text == "")
            {
                Button b = (Button)(sender);
                if (tb.Text == "0")
                {
                    tb.Text = "";
                }
                if (b.Text == "+" && tb.Text == "-")
                {
                    tb.Text = "";
                }
                else

                if (b.Text == "%")
                {


                    if ((i == 0) || (i > 0 && phepToan[i - 1] == '%') || (i == 1 && isNumb(Convert.ToString(phepToan[0])) == 1) || (i > 0 && isNumb(Convert.ToString(phepToan[i - 1])) == 0))// (8%
                    {

                        MessageBox.Show("Sai cú pháp ! Vui lòng nhập phần trăm theo dạng ( x % y ) !");
                        if (tb.Text == "")
                            tb.Text = "0";
                    }
                    else
                    {

                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (phepToan[k] == '(')
                            {
                                if (i > 0 && ((isNumb(Convert.ToString(phepToan[i - 1])) == 1 && isNumb(b.Text) == 0) || (isNumb(Convert.ToString(phepToan[i - 1])) == 0 && isNumb(b.Text) == 1) || (isNumb(Convert.ToString(phepToan[i - 1])) == 0 && isNumb(b.Text) == 0)) || (i > 0 && phepToan[i - 1] == ' ' && isNumb(b.Text) == 1))
                                    tb.Text = tb.Text + " ";
                                tb.Text = tb.Text + b.Text;
                                phepToan[i] = Convert.ToChar(b.Text);
                                i++;
                            }
                            else
                            {
                                if (k == 0)
                                {
                                    MessageBox.Show("Sai cú pháp ! Vui lòng nhập phần trăm theo dạng ( x % y ) !");
                                    if (tb.Text == "")
                                        tb.Text = "0";
                                }

                            }
                        }



                    }

                }
                else

                    if ((i > 0 && phepToan[i - 1] == '-' && b.Text == "-") || (i > 0 && phepToan[i - 1] == '+' && b.Text == "-"))
                {
                    MessageBox.Show("Vui lòng nhập số âm theo cú pháp ( - x ) !");
                    if (i == 0)
                        tb.Text = "0";
                }
                else
                {
                    if (i > 0 && isNumb(Convert.ToString(phepToan[i - 1])) == 0 && isNumb(b.Text) == 0 && b.Text != "(" && b.Text != ")" && phepToan[i - 1] != '(' && phepToan[i - 1] != ')')//////////////////////////////////////////////////////////////
                    {
                        MessageBox.Show("Sai cú pháp !");
                    }
                    else

                    {
                        if (i > 0 && ((isNumb(Convert.ToString(phepToan[i - 1])) == 1 && isNumb(b.Text) == 0) || (isNumb(Convert.ToString(phepToan[i - 1])) == 0 && isNumb(b.Text) == 1) || (isNumb(Convert.ToString(phepToan[i - 1])) == 0 && isNumb(b.Text) == 0)) || (i > 0 && phepToan[i - 1] == ' ' && isNumb(b.Text) == 1))

                            tb.Text = tb.Text + " ";
                        tb.Text = tb.Text + b.Text;
                        phepToan[i] = Convert.ToChar(b.Text);
                        i++;
                    }
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tb.Enabled = true;
            tb.Text = "0";
            label1.Text = "Dạng hậu tố: ";
            label2.Text = "Kết quả: ";
            kq.Text = "";
            i = 0;

        }


        public int isToanTu(char x)
        {
            if (x == '+' || x == '-' || x == '*' || x == '/')
                return 1;
            else return 0;
        }

        public int errorChecker(string s)
        {
            //dau cach 
            //dau ngoac
            //toan tu gan nhau
            //toan tu o dau

            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] >= 'A' && s[i] <= 'Z'))
                    return 5;
                else

                if (i != s.Length - 1 && s[i] != ' ' && s[i + 1] != ' ' && ((isNumb(Convert.ToString(s[i])) == 0 && isNumb(Convert.ToString(s[i + 1])) == 1) || ((isNumb(Convert.ToString(s[i])) == 1 && isNumb(Convert.ToString(s[i + 1])) == 0))))
                {
                    //MessageBox.Show("Các toán tử và toán hạng phải cách nhau bởi dấu cách !");
                    return 1;

                }
                else
                    if (isToanTu(s[i]) == 1 && isToanTu(s[i + 1]) == 1 || (isToanTu(s[i]) == 1 && isToanTu(s[i + 2]) == 1))
                {
                    //MessageBox.Show("Hai toán tử không được nằm cạnh nhau !");
                    return 2;

                }
                else
                {
                    if (s[i] == '/' && s[i + 2] == '0')
                        return 6;
                    else
                    {
                        int left = 0, right = 0;
                        for (int k = 0; k < s.Length; k++)
                        {

                            {
                                if (k != s.Length - 1 && s[k] == ')' && s[k + 1] == '(')
                                {
                                    //MessageBox.Show("Vui lòng kiểm tra lại dấu ngoặc !");
                                    return 3;

                                }
                                else
                                {
                                    if (s[k] == '(')
                                        left++;
                                    else
                                        if (s[k] == ')')
                                        right++;
                                }
                            }
                        }
                        if (left != right)
                        {
                            //MessageBox.Show("Vui lòng kiểm tra lại dấu ngoặc !");
                            return 4;

                        }
                    }
                }
                
                
            }
            return 0;

        }


        private void button18_Click(object sender, EventArgs e)
        {
            //label1.Text = "Dạng hậu tố: ";
            if (kq.Text == "")
            {
                
                string pt = tb.Text;
                if (errorChecker(pt) != 0)
                {
                    int x = errorChecker(pt);
                    switch (x)
                    {
                        case 1:

                            MessageBox.Show("Các toán tử và toán hạng phải cách nhau bởi dấu cách !");
                            break;

                        case 2:
                            MessageBox.Show("Hai toán tử không được nằm cạnh nhau !");
                            break;
                        case 3:
                            MessageBox.Show("Vui lòng kiểm tra lại dấu ngoặc !");
                            break;
                        case 4:
                            MessageBox.Show("Vui lòng kiểm tra lại dấu ngoặc !");
                            break;
                        case 5:
                            MessageBox.Show("Vui lòng chỉ nhập số và phép tính !");
                            break;
                        case 6:
                            MessageBox.Show("Không thể thực hiện phép chia cho 0 !");
                            break;
                    }
                }
                else
                {
                    for (int i = 0; i < pt.Length; i++)
                    {

                        if ((pt[i] == '(' && pt[i + 2] == '-') || (i == 0 && pt[i] == '-' && isNumb(Convert.ToString(pt[i + 2])) == 1))//số âm
                        {
                            if(i != 0)//nếu số âm không nằm đầu tiên
                            IN.Add("(");
                            int num = 0;
                            if (i == 0)
                                i += 2;
                            else
                                i += 4;
                            while (pt[i] != ' ')
                            {
                                num = num * 10 + int.Parse(Convert.ToString(pt[i]));
                                i++;
                            }

                            IN.Add(Convert.ToString(0 - num));//xử lý số âm trong ngoặc

                                i--;// vòng while ở trên chạy đến dấu cách, nếu làm tiếp nó sẽ bỏ qua dấu cách mà ko add vào => 2 số sát nhau => không tính được
                        }
                        else
                            if (pt[i] == '(' && pt[i + 4] == '%')//phần trăm
                        {
                            IN.Add("(");
                            for (int k = 0; pt[k] != ')'; k++)
                            {
                                if (pt[k] == '%')
                                {
                                    float numb1 = 0;
                                    float numb2 = 0;//2 so de tinh %( 5 % 50 )
                                    i += 2;
                                    while (pt[i] != ' ')
                                    {
                                        numb1 = numb1 * 10 + float.Parse(Convert.ToString(pt[i]));
                                        i++;
                                    }
                                    i += 3;
                                    while (pt[i] != ' ')
                                    {
                                        numb2 = numb2 * 10 + float.Parse(Convert.ToString(pt[i]));
                                        i++;
                                    }

                                    IN.Add(Convert.ToString(tinhPhanTram(numb1, numb2)));
                                    i += 1;
                                    break;
                                }
                            }
                        }
                        else
                            IN.Add(Convert.ToString(pt[i]));
                    }

                    IN.Add("\0");
                    hauTo(IN, OUT);
                    for (int j = 0; OUT[j] != "\0"; j++)
                    {
                        if (OUT[j] == " " && OUT[j + 1] == " ")
                            OUT.RemoveAt(j);
                    }
                    for (int u = 0; OUT[u] != "\0"; u++)
                    {

                        label1.Text = label1.Text + OUT[u];
                    }

                    kq.Text = calculate(OUT);
                    IN = new List<string>();
                    OUT = new List<string>();
                    phepToan = new char[100];
                }
            }
        }

        public float tinhPhanTram(float s1, float s2)
        {
            float kq = s2/100*s1;
            return kq;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = tb.Text;
            if (s[s.Length-1] == ' ')
            {
                phepToan[i - 1] = '\0';
                i--;
            }
            if (kq.Text == "")
            {
                if (tb.Text.Length > 1)
                {
                    
                    tb.Text = tb.Text.Remove(tb.Text.Length - 1, 1);
                    
                   
                }
                else

                    tb.Text = "0";


               
            }
        }

        private void button16_TextChanged(object sender, EventArgs e)
        {

        }

       

       

      

       
        private void kq_TextChanged(object sender, EventArgs e)
        {
            if(kq.Text != "")
                tb.Enabled = false;
            else
                tb.Enabled = true;
        }

        private void button19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button18.PerformClick();
            }
        }
    }
}
