using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Caculator_Form
{
    class Stack
    {
        Node pTop;

        public Stack()
        {
            pTop = new Node();
            pTop.createNode("#");
        }

        public void Push(string s)
        {

            Node p = new Node();
            p.createNode(s);
            if (pTop == null)
                pTop = p;
            else
            {
                p.Next(pTop);//pNext cua p tro den pTop
                pTop = p;
            }
        }

        public string Pop()
        {

            if (pTop.getInfo() != "#")
            {
                string s;
                s = pTop.getInfo();
                pTop = pTop.getNext();
                return s;

            }
            else return "#";
        }

        public string getTop()
        {
            return pTop.getInfo();
        }

    }
}
