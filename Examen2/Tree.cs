using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    class Tree
    {
        public Node root;
        public Tree leftSon;
        public Tree rightSon;

        public Tree(int value)
        {
            this.root = new Node(value);
            this.leftSon = null;
            this.rightSon = null;
        }

        public Tree()
        {
        }

        public void Insert(int value)
        {
            if (this.root == null)
            {
                this.root = new Node(value);
                return;
            }

            if (this.root.value == value)
                return;

            if (value > this.root.value)
            {
                if (this.rightSon == null)
                {
                    rightSon = new Tree(value);
                    return;
                }

                rightSon.Insert(value);
                return;
            }

            if (this.leftSon == null)
            {
                leftSon = new Tree(value);
                return;
            }

            this.leftSon.Insert(value);
        }

        public Tuple<int, int> GetStats()
        {
            int minValue = getLeftMostValue();
            int maxValue = getRightMostValue();
                        
            return new Tuple<int, int>(minValue, maxValue);
        }

        public int getRightMostValue()
        {
            if(this.rightSon == null)
            {
                return this.root.value;
            }else
            {
                return this.rightSon.getRightMostValue();
            }
        }

        public int getLeftMostValue()
        {
            if (this.leftSon == null)
            {
                return this.root.value;
            }
            else
            {
                return this.leftSon.getLeftMostValue();
            }
        }
    }
}
