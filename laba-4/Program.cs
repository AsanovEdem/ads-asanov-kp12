using System;

namespace adspervash
{
    class SlNode
    {
        public int data;
        public SlNode Next { get; set; }
        public SlNode(int data)
        {
            this.data = data;
        }
    }
    class List
    {
        public SlNode tail;
        public List()
        {
            this.tail = null;
        }
        public bool AddLast(int data)
        {
            if (tail == null)
            {
                this.tail = new SlNode(data);
                this.tail.Next = this.tail;
                return true;
            }
            else
            {
                SlNode current = tail;
                while (current != tail)
                {
                    current = current.Next;
                }
                SlNode toAdd = new SlNode(data);
                toAdd.Next = tail.Next;
                tail.Next = toAdd;
                toAdd = tail;
                return true;
            }
        }
        public bool AddFirst(int data)
        {
            if (tail == null)
            {
                tail = new SlNode(data);
                tail.Next = tail;
                return true;
            }
            else
            {
                SlNode toAdd = new SlNode(data);
                toAdd.Next = tail.Next;
                tail.Next = toAdd;
                return true;
            }
        }
        public bool AddAtPosition(int data, int pos)
        {
            if (tail == null && pos == 1)
            {
                this.tail = new SlNode(data);
                this.tail.Next = tail;
                return true;
            }
            else if (tail != null && pos == 1)
            {
                if (AddFirst(data))
                {
                    return true;
                }
                else return false;
            }
            else
            {
                SlNode current = tail;
                for (int i = 1; i < pos; i++)
                {
                    current = current.Next;
                }
                SlNode toAdd = new SlNode(data);
                toAdd.Next = current.Next;
                current.Next = toAdd;
                return true;
            }
        }
        public bool DeleteFirst()
        {
            if (tail == null)
            {
                Console.WriteLine("List is empty");
                return false;
            }
            else
            {
                tail.Next.Next = tail.Next;
                return true;
            }
        }
        public bool DeleteLast()
        {
            if (tail == null)
            {
                Console.WriteLine("List is empty");
                return false;
            }
            else
            {
                SlNode current = tail;
                while (current.Next != tail)
                {
                    current = current.Next;
                }
                current.Next = tail.Next;
                current = tail;
                return true;
            }
        }
        public bool DeleteAtPosition(int pos)
        {
            if (tail == null)
            {
                return false;
            }
            else
            {
                SlNode current = tail;
                for (int i = 1; i < pos; i++)
                {
                    if (current.Next == tail && i != pos - 1)
                    {
                        return false;
                    }
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                return true;
            }
        }
        public int FindMax()
        {
            SlNode current = tail;
            SlNode maxvalnode = tail;
            int counter = 0;
            int maxvalindex = 0;
            while (current.Next != tail)
            {
                if (current.data >= maxvalnode.data)
                {
                    maxvalnode = current;
                    maxvalindex = counter;
                }
                current = current.Next;
                counter += 1;
            }
            return maxvalindex;
        }
        public void RandomFillList(int num)
        {
            Random r = new Random();
            tail = new SlNode(r.Next());
            for (int i = 0; i < num; i++)
            {
                AddLast(r.Next());
            }
        }
        public void Print()
        {
            SlNode current = tail.Next;
            string s = "";
            while (current.Next != tail.Next)
            {
                s += current.data;
                if (current != tail)
                {
                    s += ", ";
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.RandomFillList(20);
            list.Print();
            int pos = list.FindMax();
            list.DeleteAtPosition(pos);
            list.Print();
        }
    }
}
