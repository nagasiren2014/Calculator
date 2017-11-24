using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator_Form
{
    class Node
    {
        String info;
        Node pNext;

        public Node()
        {
            info = "";
            pNext = null;
        }

        public void createNode(string s)
        {

            info = s;
            pNext = null;

        }
        public void Next(Node x)//dung trong push
        {
            pNext = x;
        }
        public string getInfo()
        {
            return info;
        }

        public Node getNext()
        {
            return pNext;
        }
    }
}
