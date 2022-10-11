using System;
namespace PracticeExercise2
{

    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data = default(T), LinkedListNode<T> next=null)
        {
            Data = data;
            Next = next;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }

	public class LinkedList<T>: IList<T>
	{
        public LinkedListNode<T> Head { get; set; }
        public LinkedListNode<T> Tail { get; set; }

		public LinkedList()
		{
            Head = null;
            Tail = null;
		}

        public T? First => Head.Data;

        public T? Last => Tail.Data;

        public bool IsEmpty
        {
            get
            {
                if (Head == null && Tail == null)
                {
                    return true;
                }
                return false;
            }
        }


        private int length = 0;
        public int Length => length;

        public void Append(T value)
        {

            var newNode = new LinkedListNode<T>(value);

            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }

            length++;

        }

        public void Clear()
        {
            Head = null;
            Tail = null;

            length = 0;
        }

        public bool Contains(T value)
        {
            var currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(value))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public int FirstIndexOf(T value)
        {
            int index = 0;

            var currentNode = Head;

            while(currentNode!=null)
            {
                if( currentNode.Data.Equals(value) )
                {
                    return index;
                }
                index++;
                currentNode = currentNode.Next;

            }

            return -1;
        }

        public T Get(int index)
        {
            var count = 0;
            var currentNode = Head;

            while (currentNode != null)
            {
                if (count == index)
                {
                    return currentNode.Data;
                }
                count++;
                currentNode = currentNode.Next;
            }

            throw new IndexOutOfRangeException();

        }

        public void InsertAfter(T newValue, int existingValue)
        {

            if (existingValue == null)
            {
                return;
            }
            else
            {
                var newNode = new LinkedListNode<T>(newValue);
                length++;
            }
        }

        public void InsertAt(T value, int index)
        {
            var newNode = new LinkedListNode<T>(value);
            newNode.Data = value;
            newNode.Next = null;

            if (Head == null)
            {
                Head = newNode;
            }
            else if (index == 0)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }
        }

        public void Prepend(T value)
        {
            var newNode = new LinkedListNode<T>(value);
            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }

            length++;

        }

        public void Remove(T value)
        {
            // If list is empty, we're done, son. 
            if (IsEmpty)
            {
                return;
            }

            // Remove head
            if (Head.Data.Equals(value))
            {
                // 1-element list
                if (Head == Tail)
                {
                    Tail = null;
                    Head = null;
                }
                else
                {
                    Head = Head.Next;
                }
                length--;

                return;
            }

            // Remove non-head node
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Next != null && currentNode.Next.Data.Equals(value))
                {
                    var nodeToDelete = currentNode.Next;
                    length--;

                    if (nodeToDelete == Tail)
                    {
                        currentNode.Next = null;
                        Tail = currentNode;
                    }
                    else
                    {
                        currentNode.Next = currentNode.Next.Next;
                        nodeToDelete.Next = null;
                    }

                    return;
                }

                currentNode = currentNode.Next;
            }

        }

        public void RemoveAt(int index)
        {

            if (IsEmpty)
            {
                return;
            }
        }

        public IList<T> Reverse()
        {
            IList<T> reversedList = new LinkedList<T>();
            var currentNode = Head;
            while (currentNode != null)
            {
                reversedList.Prepend(currentNode.Data);
                currentNode = currentNode.Next;
            }
            return reversedList;
        }


        public override string ToString()
        {
            string result = "[";

            for(var currentNode = Head; currentNode !=null; currentNode = currentNode.Next )
            {
                result += currentNode.ToString();
                if(currentNode != Tail)
                {
                    result += ", ";
                }

            }
            result += "]";

            return result;

        }
    }
}

