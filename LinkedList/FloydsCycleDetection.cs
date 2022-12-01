using System;

public class LinkedList
{
    Node head;
    public class Node
    {
        public int data;
        public Node next;
        public Node(int n)
        {
            data = n;
            next = null;
        }
    }
    public void push(int new_data)
    {
        Node new_node = new Node(new_data);
        new_node.next = head;
        head = new_node;
    }

    // 리스트가  순환할경우 true 아닐경우 false를 반환
    Boolean detectLoop()
    {
        Node slow_p = head;
        Node fast_p = head;
        while(slow_p != null && fast_p != null && fast_p.next != null)
        {
            slow_p = slow_p.next;
            fast_p = fast_p.next.next;
            if(slow_p == fast_p) { return true; }
        }
        return false;
    }
    
    public static void Main(string[] args)
    {
        LinkedList myList = new LinkedList();
        myList.push(10);
        myList.push(20);
        myList.push(15);
        myList.push(5);

        // 순환하기 위해 마지막 루프를 헤드로 연결
        myList.head.next.next.next.next = myList.head;

        
        Boolean found = myList.detectLoop();
        if(found) { Console.WriteLine("Loop Found"); }
        else { Console.WriteLine("No Loop"); }
    }
}
