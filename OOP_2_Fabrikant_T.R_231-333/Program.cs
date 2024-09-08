using System;
using System.ComponentModel.Design;

namespace OOP2
{

    class Programm
    {
        static void Menu()
        {
            Console.WriteLine("\n1 - Init LinkedList\n2 - Add val in list");
            Console.WriteLine("3 - Delete all node with current val\n4 - Print LinkedList");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("Enter number\n");
        }

        static bool ValidStr(string str) {
            if (str == "") {
                return false;
            }

            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    count++;
                } else {
                    count = 0;
                }
                if (count > 1)
                {
                    return false;
                }
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < '0' || str[i] > '9')
                {
                    if (str[i] == ' ')
                    {
                        continue;
                    }
                    return false;
                }

            }
            return true;
        }
        static int[] InputArray()
        {
            Console.WriteLine("Enter numbers: ");
            string input = Console.ReadLine();
            if (!ValidStr(input)) {
                Console.WriteLine("\nInvalid data");
                return new int[0];
            }
            string[] inputArray = input.Split(' ');
            int[] array = new int[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                array[i] = int.Parse(inputArray[i]);
            }

            return array;
        }
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            bool flag = true;
            while (flag) 
            {
                Menu();
                int p = int.Parse(Console.ReadLine());
                switch (p)
                {
                    case 1:
                        int[] nums = InputArray();
                        list.InitLinkedList(nums);
                        break;
                    case 2:
                        Console.Write("Enter number: ");
                        int add = int.Parse(Console.ReadLine());
                        list.AddNode(new Node(add, null));
                        break;
                    case 3:
                        Console.WriteLine("Enter number: ");
                        int delete = int.Parse(Console.ReadLine());
                        list.DeleteAllNodeWithVal(delete);
                        break;
                    case 4:
                        list.PrintListNode();
                        break;
                    case 5:
                        flag = false;
                        break;
                }
            }
        }


        struct LinkedList
        {
            private Node head;
            public int length;

            public void InitLinkedList(int[] arr)
            {
                length = arr.Length;
                if (length == 0)
                {
                    head = null;
                    return;
                }

                head = new Node(arr[0], null);
                Node copyHead = head;
                for (int i = 1; i < arr.Length; i++)
                {
                    copyHead.next = new Node(arr[i], null);
                    copyHead = copyHead.next;
                }
            }

            public void AddNode(Node node)
            {
                length++;
                if (head == null)
                {
                    head = node;
                    return;
                }
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = node;
            }

            public void DeleteAllNodeWithVal(int val)
            {
                Node current = head;
                Node prew = head;

                while (current != null)
                {
                    if (current.val == val)
                    {
                        if (prew == current)
                        {
                            head = current.next;
                            prew = current.next;
                        } else {
                            prew.next = current.next;
                        }
                        length--;
                    } else {
                        prew = current;
                    }
                    current = current.next;
                }
            }

            public void PrintListNode()
            {
                Node current = head;
                Console.Write("LinkedList: ");
                while (current != null)
                {
                    Console.Write(current.val + " ");
                    current = current.next;
                }
                Console.WriteLine("\tLength: " + length);
            }
            

        }
        class Node
        {
            public int val = 0;
            public Node next = null;
            public Node(int val, Node next)
            {
                this.val = val;
                this.next = next;
            }
        }

    }
}
